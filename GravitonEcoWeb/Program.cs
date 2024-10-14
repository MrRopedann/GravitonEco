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

// Настройка Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File(
        Path.Combine(logDirectory, "app-log.txt"))  // Здесь RollingInterval будет доступен
    .CreateLogger();

builder.Host.UseSerilog();  // Используем Serilog

// Добавляем поддержку Razor Pages
builder.Services.AddRazorPages();

// Добавляем Modbus сервис
builder.Services.AddSingleton<ModbusService>();
builder.Services.AddTransient<ModbusDataFactory>();

// Добавляем поддержку сессий
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Настраиваем тайм-аут сессии
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Настраиваем тайм-аут сессии
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


// Добавляем поддержку контроллеров
builder.Services.AddControllers();

builder.WebHost.UseKestrel(options =>
{
    options.Listen(System.Net.IPAddress.Any, 5000); // HTTP
});

var app = builder.Build();

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
