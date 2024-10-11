using GravitonEcoWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Добавляем поддержку Razor Pages
builder.Services.AddRazorPages();

// Добавляем SignalR для обновления данных в реальном времени
builder.Services.AddSignalR();

// Добавляем ваш сервис для работы с ModbusTCP
builder.Services.AddSingleton<ModbusService>();

// Добавляем поддержку контроллеров для API
builder.Services.AddControllers();

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

// Настройка маршрутизации для Razor Pages
app.MapRazorPages();
app.MapControllers(); // Маршрутизация для контроллеров

app.Run();
