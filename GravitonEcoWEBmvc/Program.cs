using GravitonEcoWEBmvc.Services.BackgroundServices;
using GravitonEcoWEBmvc.Services.DataBase;
using GravitonEcoWEBmvc.Services.ModbusTCP;
using GravitonEcoWEBmvc.Services.SignalR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});



// Путь к базе данных
string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
var databaseDirectory = Path.Combine(appDataPath, "GravitonEco", "DataBase");
var databasePath = Path.Combine(databaseDirectory, "GravitonEcoMVC.db");

if (!Directory.Exists(databaseDirectory))
{
    Directory.CreateDirectory(databaseDirectory);
}

// Добавление служб в контейнер зависимостей
builder.Services.AddSingleton<TcpClientServices>();
builder.Services.AddSingleton<ModbusTCPServices>();

// Регистрация SignalR
builder.Services.AddSignalR();

// Регистрация ModbusBackgroundService как Singleton и HostedService
builder.Services.AddSingleton<ModbusBackgroundService>();
builder.Services.AddHostedService(provider => provider.GetRequiredService<ModbusBackgroundService>());

builder.Services.AddControllersWithViews();

// Регистрация Identity
builder.Services.AddDbContext<SqliteDbContext>(options =>
    options.UseSqlite($"Data Source={databasePath}"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<SqliteDbContext>()
                .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddHttpContextAccessor(); // Для доступа к контексту HTTP

// Создание базы данных, если она еще не создана
using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var sqliteDbContext = scope.ServiceProvider.GetRequiredService<SqliteDbContext>();
    sqliteDbContext.Database.EnsureCreated();

    // Инициализация ролей и администратора
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string[] roleNames = { "Admin", "User" };
    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    // Создание администратора с правами "Admin" (если его нет)
    var adminUser = await userManager.FindByNameAsync("admin");
    var defaultUser = await userManager.FindByNameAsync("user");

    if (adminUser == null)
    {
        adminUser = new IdentityUser { UserName = "admin", Email = "admin@example.com" };
        var result = await userManager.CreateAsync(adminUser, "Admin123!");
        if (result.Succeeded)
        {
            var roleResult = await userManager.AddToRoleAsync(adminUser, "Admin");
            if (!roleResult.Succeeded)
            {
                Console.WriteLine($"Error adding admin to role 'Admin': {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
            }
        }
        else
        {
            Console.WriteLine($"Error creating admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }

    if (defaultUser == null)
    {
        defaultUser = new IdentityUser { UserName = "user", Email = "user@example.com" };
        var result = await userManager.CreateAsync(defaultUser, "User123!");
        if (result.Succeeded)
        {
            var roleResult = await userManager.AddToRoleAsync(defaultUser, "User");
            if (!roleResult.Succeeded)
            {
                Console.WriteLine($"Error adding default user to role 'User': {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
            }
        }
        else
        {
            Console.WriteLine($"Error creating default user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
}

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // Укажите здесь нужный порт, например, 5001
});

var app = builder.Build();

// Подключаем сессию
app.UseSession();

// Middleware для очистки сессии и аутентификационных данных только один раз после запуска приложения
app.Use(async (context, next) =>
{
    // Проверяем, был ли уже выполнен сброс сессии и куков
    if (!context.Session.Keys.Contains("SessionInitialized"))
    {
        // Удаляем куки аутентификации, если они есть
        if (context.Request.Cookies.ContainsKey(".AspNetCore.Identity.Application"))
        {
            context.Response.Cookies.Delete(".AspNetCore.Identity.Application");
        }

        // Очищаем сессию
        context.Session.Clear();

        // Сбрасываем аутентификацию
        await context.SignOutAsync(IdentityConstants.ApplicationScheme);

        // Устанавливаем флаг, что сессия и куки были очищены
        context.Session.SetString("SessionInitialized", "true");
    }

    await next.Invoke();
});

// Настройка конвейера HTTP-запросов
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthentication(); // Подключение аутентификации
app.UseAuthorization();  // Подключение авторизации

// Основной маршрут — Home/Index, для авторизованных пользователей
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "admin",
    pattern: "admin/{action=AdminPanel}/{id?}",
    defaults: new { controller = "Admin" });


// Маршрут для SignalR
app.MapHub<DeviceHub>("/deviceHub");

app.Run();

