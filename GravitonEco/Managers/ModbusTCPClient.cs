using System;
using System.IO;
using System.Net.Sockets;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using GravitonEco.Managers;
using GravitonEco.Models;
using NModbus;

public sealed class ModbusTCPClient : ObservableObject, IObservable<bool>
{
    private static readonly Lazy<ModbusTCPClient> _instance = new Lazy<ModbusTCPClient>(() => new ModbusTCPClient());
    private TcpClient _tcpClient;
    private IModbusMaster _modbusMaster;
    private DeviceConfig _deviceConfig;
    private DispatcherTimer _connectionTimer;

    private readonly Subject<bool> _connectionStatusSubject = new Subject<bool>(); // Создаем Subject для управления подпиской

    private ModbusTCPClient()
    {
        InitializeConnectionTimer();
        Task.Run(() => Connect());
    }

    public static ModbusTCPClient Instance => _instance.Value;

    private bool _isConnected;
    public bool IsConnected
    {
        get => _isConnected;
        private set
        {
            if (SetProperty(ref _isConnected, value))
            {
                _connectionStatusSubject.OnNext(_isConnected); // Уведомляем подписчиков о изменении
            }
        }
    }

    private void InitializeConnectionTimer()
    {
        _connectionTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        _connectionTimer.Tick += CheckConnectionStatus;
        _connectionTimer.Start();
    }

    private void CheckConnectionStatus(object sender, EventArgs e)
    {
        if (_tcpClient == null)
        {
            IsConnected = false;
            return;
        }

        try
        {
            // Установим таймаут для проверки
            var stream = _tcpClient.GetStream();
            if (stream.DataAvailable || stream.ReadTimeout > 0)
            {
                IsConnected = true;
            }
            else
            {
                IsConnected = false; // Если данных нет, соединение считается разорванным
            }
        }
        catch (IOException)
        {
            IsConnected = false; // Если возникла ошибка ввода-вывода, соединение разорвано
        }
        catch (Exception ex)
        {
            // Логируем исключение (если нужно)
            Console.WriteLine($"Error checking connection status: {ex.Message}");
            IsConnected = false; // В случае других исключений считаем, что соединение потеряно
        }
    }


    public async Task Connect()
    {
        if (IsConnected) return;

        try
        {
            _deviceConfig = ConfigManager.LoadConfig();
            Console.WriteLine($"Connecting to {_deviceConfig.IpAddress}:{_deviceConfig.Port}");

            _tcpClient = new TcpClient();
            await _tcpClient.ConnectAsync(_deviceConfig.IpAddress, _deviceConfig.Port);

            var factory = new ModbusFactory();
            _modbusMaster = factory.CreateMaster(_tcpClient);
            IsConnected = true;

            Console.WriteLine($"Successfully connected to {_deviceConfig.IpAddress}:{_deviceConfig.Port}");
        }
        catch (SocketException ex)
        {
            IsConnected = false;
            Console.WriteLine($"Socket error: {ex.Message}");
            Disconnect();
        }
        catch (TimeoutException ex)
        {
            IsConnected = false;
            Console.WriteLine($"Connection timed out: {ex.Message}");
            Disconnect();
        }
        catch (Exception ex)
        {
            IsConnected = false;
            Console.WriteLine($"Error: {ex.Message}");
            Disconnect();
        }
    }


    public void Disconnect()
    {
        if (_tcpClient != null)
        {
            _tcpClient.Close();
            _tcpClient = null;
            _modbusMaster = null;
            IsConnected = false;
        }
    }

    // Реализация IObservable<T>
    public IDisposable Subscribe(IObserver<bool> observer)
    {
        return _connectionStatusSubject.Subscribe(observer);
    }
}
