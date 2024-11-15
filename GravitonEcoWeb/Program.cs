using GravitonEcoWeb.Model.DataBaseModel;
using GravitonEcoWeb.Services;
using GravitonEcoWeb.Services.Factorys;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);

// Настройка пути для логов
string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
string logDirectory = Path.Combine(appDataPath, "GravitonEco", "Log");

var dbConfig = DatabaseConfig.LoadDatabaseConfig(); // Вызов метода для загрузки конфигурации
if (dbConfig == null)
{
    throw new Exception("Ошибка загрузки конфигурации базы данных");
}



string connectionString = $"Host={dbConfig.IpAddress};Port={dbConfig.Port};Database={dbConfig.DbName};Username={dbConfig.UserName};Password={dbConfig.Password}";

if (!Directory.Exists(logDirectory))
{
    Directory.CreateDirectory(logDirectory);
}

var databaseDirectory = Path.Combine(appDataPath, "GravitonEco", "DataBase");
var databasePath = Path.Combine(databaseDirectory, "GravitonEco.db");

if (!Directory.Exists(databaseDirectory))
{
    Directory.CreateDirectory(databaseDirectory);
}


// Настройка Serilog с RollingInterval
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File(
        Path.Combine(logDirectory, "app-log.txt"),
        fileSizeLimitBytes: 10_000_000)
    .CreateLogger();

// Используем Serilog для логирования в приложении
builder.Host.UseSerilog();  // Используем Serilog для хостинга

// Добавляем поддержку Razor Pages
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddDbContext<SqliteDbContext>(options => options.UseSqlite($"Data Source={databasePath}"));
using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var sqliteDbContext = scope.ServiceProvider.GetRequiredService<SqliteDbContext>();
    sqliteDbContext.Database.EnsureCreated();
}
builder.Services.AddSingleton<ModbusConfigService>();

builder.Services.AddSingleton<ModbusService>();
builder.Services.AddHostedService<ModbusPollingService>(); // Только как фоновый сервис
builder.Services.AddTransient<ModbusDataFactory>();
builder.Services.AddTransient<ModbusCalibrationFactory>();
builder.Services.AddTransient<CalibrationCalculator>();
builder.Services.AddTransient<StatisticsService>();
builder.Services.AddSingleton<VersionService>();

// Добавляем поддержку сессий
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);  // Тайм-аут сессии
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();  // Доступ к HttpContext

// Добавляем поддержку контроллеров
builder.Services.AddControllers();

// Настройка Kestrel для прослушивания на порту 5000 (HTTP)
builder.WebHost.UseKestrel(options =>
{
    options.Listen(System.Net.IPAddress.Any, 5000); // HTTP
});

var app = builder.Build();

// Настройки ошибок и безопасности
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//app.UseAuthorization();
app.UseSession();  // Включаем поддержку сессий

app.MapRazorPages();
app.MapControllers();  // Маршрутизация для контроллеров

app.Run();
