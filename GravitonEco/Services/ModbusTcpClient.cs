using NModbus;
using System.Net.Sockets;

namespace GravitonEco.Services
{
    public class ModbusTcpClient : IDisposable
    {
        private static ModbusTcpClient _instance;
        private static readonly object _lock = new object();

        private TcpClient _tcpClient;
        private IModbusMaster _modbusMaster;
        private readonly string _ipAddress;
        private readonly int _port;
        public bool _isConnected;

        // Приватный конструктор для предотвращения создания экземпляров извне
        private ModbusTcpClient(string ipAddress = "10.10.10.2", int port = 502)
        {
            _ipAddress = ipAddress;
            _port = port;
            _isConnected = false;
        }

        // Публичный метод для получения единственного экземпляра (Singleton)
        public static ModbusTcpClient GetInstance(string ipAddress = "10.10.10.2", int port = 502)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ModbusTcpClient(ipAddress, port);
                    }
                }
            }
            return _instance;
        }

        // Метод для подключения к устройству Modbus TCP
        public async Task<bool> ConnectAsync()
        {
            try
            {
                if (_isConnected && _tcpClient?.Connected == true)
                    return true; // Уже подключено

                _tcpClient?.Dispose();
                _tcpClient = new TcpClient();
                await _tcpClient.ConnectAsync(_ipAddress, _port);

                var factory = new ModbusFactory();
                _modbusMaster = factory.CreateMaster(_tcpClient);

                _isConnected = true; // Подключение успешно
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка подключения: {ex.Message}");
                _isConnected = false; // Подключение не удалось
                return false;
            }
        }

        // Метод для повторного подключения при потере соединения
        private async Task EnsureConnectedAsync()
        {
            if (!_isConnected || _tcpClient?.Connected != true)
            {
                Console.WriteLine("Попытка переподключения...");
                await ConnectAsync();
            }
        }

        // Метод для чтения регистров (например, Input Registers)
        public async Task<ushort[]> ReadInputRegistersAsync(byte slaveAddress, ushort startAddress)
        {
            try
            {
                await EnsureConnectedAsync(); // Убедиться, что подключение есть

                if (_modbusMaster == null)
                    throw new InvalidOperationException("Подключение не установлено.");

                return await _modbusMaster.ReadInputRegistersAsync(slaveAddress, startAddress, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения регистров: {ex.Message}");
                _isConnected = false; // В случае ошибки считаем, что подключение потеряно
                return null;
            }
        }

        // Метод для чтения регистров (например, Holding Registers)
        public async Task<ushort[]> ReadHoldingRegistersAsync(byte slaveAddress, ushort startAddress)
        {
            try
            {
                await EnsureConnectedAsync();

                if (_modbusMaster == null)
                    throw new InvalidOperationException("Подключение не установлено.");

                return await _modbusMaster.ReadHoldingRegistersAsync(slaveAddress, startAddress, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения регистров: {ex.Message}");
                _isConnected = false;
                return null;
            }
        }

        // Метод для чтения дискретных входов
        public async Task<bool[]> ReadDiscreteRegistersAsync(byte slaveAddress, ushort startAddress)
        {
            try
            {
                await EnsureConnectedAsync();

                if (_modbusMaster == null)
                    throw new InvalidOperationException("Подключение не установлено.");

                return await _modbusMaster.ReadInputsAsync(slaveAddress, startAddress, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения регистров: {ex.Message}");
                _isConnected = false;
                return null;
            }
        }

        // Метод для записи значений в Holding Registers
        public async Task WriteSingleHoldingRegisterAsync(byte slaveAddress, ushort registerAddress, ushort value)
        {
            try
            {
                await EnsureConnectedAsync();

                if (_modbusMaster == null)
                    throw new InvalidOperationException("Подключение не установлено.");

                await _modbusMaster.WriteSingleRegisterAsync(slaveAddress, registerAddress, value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи регистра: {ex.Message}");
                _isConnected = false;
            }
        }

        // Отключение от устройства Modbus TCP
        public void Disconnect()
        {
            _tcpClient?.Close();
            _tcpClient = null;
            _modbusMaster = null;
            _isConnected = false;
        }

        public void Dispose()
        {
            Disconnect();
        }
    }
}
