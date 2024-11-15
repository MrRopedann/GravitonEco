using GravitonEcoWeb.Model;
using NModbus;
using NModbus.Extensions.Enron;
using System.Net.Sockets;
using System.Text.Json;

namespace GravitonEcoWeb.Services
{
    public class ModbusService
    {
        private TcpClient _tcpClient;
        private IModbusMaster _modbusMaster;
        private readonly IWebHostEnvironment _env;
        private List<ModbusDeviseConfig> _deviseConfigs;
        private string _ipAddress;
        private int _port;
        private int _pollingIntervalInSeconds = 1;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<ModbusService> _logger;
        private int _reconnectAttempts = 0;
        private const int MaxReconnectAttempts = 5;
        private const int ReconnectDelay = 5000; // 5 секунд на задержку между попытками

        private int? _lastSeconds;
        private int? _lastMinutes;
        private int? _lastHours;
        private int? _lastDay;
        private int? _lastMonth;
        private int? _lastYear;

        private DateTime _lastMinuteUpdate = DateTime.MinValue;
        private DateTime _lastHourUpdate = DateTime.MinValue;
        private DateTime _lastDayUpdate = DateTime.MinValue;
        private DateTime _lastMonthUpdate = DateTime.MinValue;
        private DateTime _lastYearUpdate = DateTime.MinValue;


        public ModbusService(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor, ILogger<ModbusService> logger)
        {
            _env = env;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            LoadConfig();
            Connect();
        }

        /// Метод для получения текущего интервала опроса
        public int GetPollingInterval()
        {
            return _pollingIntervalInSeconds;
        }

        // Метод для установки нового интервала опроса
        public void SetPollingInterval(int intervalInSeconds)
        {
            if (intervalInSeconds <= 0)
            {
                throw new ArgumentException("Интервал должен быть больше 0");
            }

            _pollingIntervalInSeconds = intervalInSeconds;
            // Можно добавить сохранение этого значения в файл или базу данных, если нужно
        }

        private void LoadConfig()
        {
            var configPath = Path.Combine(_env.WebRootPath, "config", "DeviseConnection.json");
            var configJson = File.ReadAllText(configPath);
            _deviseConfigs = JsonSerializer.Deserialize<List<ModbusDeviseConfig>>(configJson);
            foreach(var config in _deviseConfigs)
            {
                _ipAddress = config.IpAddress;
                _port = config.Port;
            }
            
        }

        // Метод для подключения к устройству
        public void Connect()
        {
            if (_tcpClient != null && _tcpClient.Connected)
                return;

            try
            {
                _tcpClient = new TcpClient
                {
                    ReceiveTimeout = 3000,
                    SendTimeout = 3000,
                    NoDelay = true,
                    ReceiveBufferSize = 8192,
                    SendBufferSize = 8192,
                    LingerState = new LingerOption(true, 10)
                };

                _tcpClient.Connect(_ipAddress, _port); // Подключаемся к устройству

                var factory = new ModbusFactory();
                _modbusMaster = factory.CreateMaster(_tcpClient);
            }
            catch (SocketException ex)
            {
                _logger.LogError(ex, "Не удалось подключиться к устройству по адресу {IpAddress}:{Port}.", _ipAddress, _port);

                // Перенаправление на страницу настроек
                var context = _httpContextAccessor.HttpContext;
                if (context != null)
                {
                    context.Response.Redirect("/Settings");
                }
            }
        }

        // Метод для получения времени с устройства
        public async Task<string> GetDeviceDateTimeAsync()
        {
            try
            {
                var secondsResult = await _modbusMaster.ReadHoldingRegistersAsync(251, 256, 1);
                var minutesResult = await _modbusMaster.ReadHoldingRegistersAsync(251, 257, 1);
                var hoursResult = await _modbusMaster.ReadHoldingRegistersAsync(251, 258, 1);
                var dayResult = await _modbusMaster.ReadHoldingRegistersAsync(251, 260, 1);
                var monthResult = await _modbusMaster.ReadHoldingRegistersAsync(251, 261, 1);
                var yearResult = await _modbusMaster.ReadHoldingRegistersAsync(251, 262, 1);

                if (secondsResult != null && minutesResult != null && hoursResult != null &&
                    dayResult != null && monthResult != null && yearResult != null)
                {
                    var seconds = BcdToDecimal(secondsResult[0]);
                    var minutes = BcdToDecimal(minutesResult[0]);
                    var hours = BcdToDecimal(hoursResult[0]);
                    var day = BcdToDecimal(dayResult[0]);
                    var month = BcdToDecimal(monthResult[0]);
                    var year = BcdToDecimal(yearResult[0]) + 2000;

                    return $"{day:D2}.{month:D2}.{year} {hours:D2}:{minutes:D2}:{seconds:D2}";
                }
            }
            catch
            {
                // Возвращаем пустую строку или ошибку в случае неудачи
                return "Ошибка чтения времени";
            }

            return "Ошибка";
        }

        // Метод для получения серийного номера устройства
        public async Task<string> GetDeviceSerialNumberAsync()
        {
            try
            {
                // Читаем каждый регистр по отдельности
                var register18 = await _modbusMaster.ReadHoldingRegistersAsync(251, 18, 1);
                var register19 = await _modbusMaster.ReadHoldingRegistersAsync(251, 19, 1);
                var register20 = await _modbusMaster.ReadHoldingRegistersAsync(251, 20, 1);
                var register21 = await _modbusMaster.ReadHoldingRegistersAsync(251, 21, 1);
                var register22 = await _modbusMaster.ReadHoldingRegistersAsync(251, 22, 1);
                var register23 = await _modbusMaster.ReadHoldingRegistersAsync(251, 23, 1);

                if (register18 != null && register19 != null && register20 != null &&
                    register21 != null && register22 != null && register23 != null)
                {
                    return $"SN-{register18[0]}{register19[0]}{register20[0]}{register21[0]}{register22[0]}{register23[0]}";
                }
            }
            catch
            {
                // Возвращаем сообщение об ошибке
                return "Ошибка чтения серийного номера";
            }

            return "Ошибка";
        }

        // Метод для получения серийного номера устройства
        public async Task<string> GetDevicePincodeAsync()
        {
            try
            {
                var firstPart = await _modbusMaster.ReadHoldingRegistersAsync(1, 530, 1);
                var secondPart = await _modbusMaster.ReadHoldingRegistersAsync(1, 531, 1);
                if (firstPart != null && secondPart != null)
                {
                    // Объединяем оба блока пинкода в одну строку
                    return firstPart[0].ToString("D4") + secondPart[0].ToString("D4");
                }
            }
            catch
            {
                // Возвращаем сообщение об ошибке
                return "Ошибка чтения серийного номера";
            }

            return "Ошибка";
        }

        private int BcdToDecimal(ushort bcd)
        {
            return (bcd >> 4) * 10 + (bcd & 0x0F);
        }

        // TODO: Обработать исключение [ Exception: System.NullReferenceException: "Object reference not set to an instance of an object." ]
        public ushort[] ReadInputRegisters(byte startAddress, ushort numberOfPoints)
        {
            // Если соединение было потеряно, пытаемся подключиться снова
            EnsureConnection();
            return _modbusMaster.ReadInputRegisters(startAddress, numberOfPoints, 1); // Чтение данных по ModbusTCP
        }

        public ushort[] ReadHoldingRegisters(byte startAddress, ushort numberOfPoints)
        {
            // Если соединение было потеряно, пытаемся подключиться снова
            EnsureConnection();
            return _modbusMaster.ReadHoldingRegisters(startAddress, numberOfPoints, 1); // Чтение данных по ModbusTCP
        }

        public bool[] ReadDiscretRegisters(byte startAddress, ushort numberOfPoints)
        {
            // Если соединение было потеряно, пытаемся подключиться снова
            EnsureConnection();
            return _modbusMaster.ReadInputs(startAddress, numberOfPoints, 1); // Чтение данных по ModbusTCP
        }

        public void WriteSingleRegister(byte slaveAddress, ushort registerAddress, ushort value)
        {
            // Если соединение было потеряно, пытаемся подключиться снова
            EnsureConnection();
            _modbusMaster.WriteSingleRegister(slaveAddress, registerAddress, value); // Запись данных
        }

        // Метод для проверки подключения и попытки восстановления соединения
        public bool CheckConnection()
        {
            try
            {
                EnsureConnection(); // Проверяем соединение и переподключаемся, если нужно
                var result = _modbusMaster.ReadHoldingRegisters(2, 5, 1); // Проверка подключения
                return result != null && result.Length > 0;
            }
            catch
            {
                return false; // Если произошла ошибка, считаем, что устройство не подключено
            }
        }

        public bool CheckInternetConnection()
        {
            try
            {
                using (var client = new TcpClient())
                {
                    client.Connect("8.8.8.8", 53); // Порт 53 для DNS
                    return true; // Соединение установлено
                }
            }
            catch
            {
                return false; // Соединение не удалось
            }
        }

        // Метод для проверки соединения, если потеряно — переподключаемся
        private void EnsureConnection()
        {
            if (_tcpClient == null || !_tcpClient.Connected)
            {
                Connect(); // Если соединение было потеряно, пытаемся подключиться снова
            }
        }
    }
}
