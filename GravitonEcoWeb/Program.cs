using GravitonEcoWeb.Model.DataBaseModel;
using GravitonEcoWeb.Services;
using GravitonEcoWeb.Services.Factorys;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);

// ��������� ���� ��� �����
string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
string logDirectory = Path.Combine(appDataPath, "GravitonEco", "Log");

var dbConfig = DatabaseConfig.LoadDatabaseConfig(); // ����� ������ ��� �������� ������������
if (dbConfig == null)
{
    throw new Exception("������ �������� ������������ ���� ������");
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


// ��������� Serilog � RollingInterval
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File(
        Path.Combine(logDirectory, "app-log.txt"),
        fileSizeLimitBytes: 10_000_000)
    .CreateLogger();

// ���������� Serilog ��� ����������� � ����������
builder.Host.UseSerilog();  // ���������� Serilog ��� ��������

// ��������� ��������� Razor Pages
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
builder.Services.AddHostedService<ModbusPollingService>(); // ������ ��� ������� ������
builder.Services.AddTransient<ModbusDataFactory>();
builder.Services.AddTransient<ModbusCalibrationFactory>();
builder.Services.AddTransient<CalibrationCalculator>();
builder.Services.AddTransient<StatisticsService>();
builder.Services.AddSingleton<VersionService>();

// ��������� ��������� ������
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);  // ����-��� ������
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();  // ������ � HttpContext

// ��������� ��������� ������������
builder.Services.AddControllers();

// ��������� Kestrel ��� ������������� �� ����� 5000 (HTTP)
builder.WebHost.UseKestrel(options =>
{
    options.Listen(System.Net.IPAddress.Any, 5000); // HTTP
});

var app = builder.Build();

// ��������� ������ � ������������
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//app.UseAuthorization();
app.UseSession();  // �������� ��������� ������

app.MapRazorPages();
app.MapControllers();  // ������������� ��� ������������

app.Run();
