using GravitonEcoWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// �������� ���� � ����� AppData ��� ���������� �����
string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
string logDirectory = Path.Combine(appDataPath, "GravitonEco", "Log");

// ��������, ��� ���������� ����������
if (!Directory.Exists(logDirectory))
{
    Directory.CreateDirectory(logDirectory);
}

// ����������� ����������� � ����
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddFile(Path.Combine(logDirectory, "app-log.txt"));

// ��������� ��������� Razor Pages
builder.Services.AddRazorPages();

// ��������� SignalR ��� ���������� ������ � �������� �������
builder.Services.AddSignalR();

// ��������� ��� ������ ��� ������ � ModbusTCP
builder.Services.AddSingleton<ModbusService>();
builder.Services.AddTransient<ModbusDataFactory>();

// ��������� ��������� ������������ ��� API
builder.Services.AddControllers();

// ��������� Kestrel ��� ������������� �������� �� ���� IP � ����� 5000
builder.WebHost.UseKestrel(options =>
{
    options.Listen(System.Net.IPAddress.Any, 5000); // HTTP
});

var app = builder.Build();

// ����������� �������� ��������� ��������
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ��������� ������������� ��� Razor Pages � ������������
app.MapRazorPages();
app.MapControllers(); // ������������� ��� ������������

app.Run();
