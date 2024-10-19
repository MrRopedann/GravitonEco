using GravitonEcoWeb.Middleware;
using GravitonEcoWeb.Services;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.File;

var builder = WebApplication.CreateBuilder(args);

// Настройка пути для логов
string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
string logDirectory = Path.Combine(appDataPath, "GravitonEco", "Log");

if (!Directory.Exists(logDirectory))
{
    Directory.CreateDirectory(logDirectory);
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

// Добавляем Modbus сервис
builder.Services.AddSingleton<ModbusService>();
builder.Services.AddTransient<ModbusDataFactory>();
builder.Services.AddTransient<CalibrationCalculator>();

// Добавляем поддержку сессий
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Тайм-аут сессии
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

// Добавляем кастомное middleware для обработки исключений
app.UseMiddleware<CustomExceptionMiddleware>();

// Настройки ошибок и безопасности
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseSession();  // Включаем поддержку сессий

app.MapRazorPages();
app.MapControllers();  // Маршрутизация для контроллеров

app.Run();
