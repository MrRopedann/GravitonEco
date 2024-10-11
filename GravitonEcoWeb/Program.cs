using GravitonEcoWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// ��������� ��������� Razor Pages
builder.Services.AddRazorPages();

// ��������� SignalR ��� ���������� ������ � �������� �������
builder.Services.AddSignalR();

// ��������� ��� ������ ��� ������ � ModbusTCP
builder.Services.AddSingleton<ModbusService>();

// ��������� ��������� ������������ ��� API
builder.Services.AddControllers();

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

// ��������� ������������� ��� Razor Pages
app.MapRazorPages();
app.MapControllers(); // ������������� ��� ������������

app.Run();
