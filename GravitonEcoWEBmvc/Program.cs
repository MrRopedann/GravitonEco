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



// ���� � ���� ������
string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
var databaseDirectory = Path.Combine(appDataPath, "GravitonEco", "DataBase");
var databasePath = Path.Combine(databaseDirectory, "GravitonEcoMVC.db");

if (!Directory.Exists(databaseDirectory))
{
    Directory.CreateDirectory(databaseDirectory);
}

// ���������� ����� � ��������� ������������
builder.Services.AddSingleton<TcpClientServices>();
builder.Services.AddSingleton<ModbusTCPServices>();

// ����������� SignalR
builder.Services.AddSignalR();

// ����������� ModbusBackgroundService ��� Singleton � HostedService
builder.Services.AddSingleton<ModbusBackgroundService>();
builder.Services.AddHostedService(provider => provider.GetRequiredService<ModbusBackgroundService>());

builder.Services.AddControllersWithViews();

// ����������� Identity
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

builder.Services.AddHttpContextAccessor(); // ��� ������� � ��������� HTTP

// �������� ���� ������, ���� ��� ��� �� �������
using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var sqliteDbContext = scope.ServiceProvider.GetRequiredService<SqliteDbContext>();
    sqliteDbContext.Database.EnsureCreated();

    // ������������� ����� � ��������������
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

    // �������� �������������� � ������� "Admin" (���� ��� ���)
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
    options.ListenAnyIP(5000); // ������� ����� ������ ����, ��������, 5001
});

var app = builder.Build();

// ���������� ������
app.UseSession();

// Middleware ��� ������� ������ � ������������������ ������ ������ ���� ��� ����� ������� ����������
app.Use(async (context, next) =>
{
    // ���������, ��� �� ��� �������� ����� ������ � �����
    if (!context.Session.Keys.Contains("SessionInitialized"))
    {
        // ������� ���� ��������������, ���� ��� ����
        if (context.Request.Cookies.ContainsKey(".AspNetCore.Identity.Application"))
        {
            context.Response.Cookies.Delete(".AspNetCore.Identity.Application");
        }

        // ������� ������
        context.Session.Clear();

        // ���������� ��������������
        await context.SignOutAsync(IdentityConstants.ApplicationScheme);

        // ������������� ����, ��� ������ � ���� ���� �������
        context.Session.SetString("SessionInitialized", "true");
    }

    await next.Invoke();
});

// ��������� ��������� HTTP-��������
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthentication(); // ����������� ��������������
app.UseAuthorization();  // ����������� �����������

// �������� ������� � Home/Index, ��� �������������� �������������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "admin",
    pattern: "admin/{action=AdminPanel}/{id?}",
    defaults: new { controller = "Admin" });


// ������� ��� SignalR
app.MapHub<DeviceHub>("/deviceHub");

app.Run();

