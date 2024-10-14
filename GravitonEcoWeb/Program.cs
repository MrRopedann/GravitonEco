using GravitonEcoWeb.Services;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.File;

var builder = WebApplication.CreateBuilder(args);

// ��������� ���� ��� �����
string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
string logDirectory = Path.Combine(appDataPath, "GravitonEco", "Log");

if (!Directory.Exists(logDirectory))
{
    Directory.CreateDirectory(logDirectory);
}

// ��������� Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File(
        Path.Combine(logDirectory, "app-log.txt"))  // ����� RollingInterval ����� ��������
    .CreateLogger();

builder.Host.UseSerilog();  // ���������� Serilog

// ��������� ��������� Razor Pages
builder.Services.AddRazorPages();

// ��������� Modbus ������
builder.Services.AddSingleton<ModbusService>();
builder.Services.AddTransient<ModbusDataFactory>();

// ��������� ��������� ������
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // ����������� ����-��� ������
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // ����������� ����-��� ������
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


// ��������� ��������� ������������
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
app.UseSession();  // �������� ��������� ������

app.MapRazorPages();
app.MapControllers();  // ������������� ��� ������������

app.Run();
