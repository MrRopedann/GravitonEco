using GravitonEcoWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Получаем путь к папке AppData для сохранения логов
string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
string logDirectory = Path.Combine(appDataPath, "GravitonEco", "Log");

// Убедимся, что директория существует
if (!Directory.Exists(logDirectory))
{
    Directory.CreateDirectory(logDirectory);
}

// Настраиваем логирование в файл
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddFile(Path.Combine(logDirectory, "app-log.txt"));

// Добавляем поддержку Razor Pages
builder.Services.AddRazorPages();

// Добавляем SignalR для обновления данных в реальном времени
builder.Services.AddSignalR();

// Добавляем ваш сервис для работы с ModbusTCP
builder.Services.AddSingleton<ModbusService>();
builder.Services.AddTransient<ModbusDataFactory>();

// Добавляем поддержку контроллеров для API
builder.Services.AddControllers();

// Настройка Kestrel для прослушивания запросов на всех IP и порту 5000
builder.WebHost.UseKestrel(options =>
{
    options.Listen(System.Net.IPAddress.Any, 5000); // HTTP
});

var app = builder.Build();

// Настраиваем конвейер обработки запросов
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Настройка маршрутизации для Razor Pages и контроллеров
app.MapRazorPages();
app.MapControllers(); // Маршрутизация для контроллеров

app.Run();
