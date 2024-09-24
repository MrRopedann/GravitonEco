using GravitonEco.Models;
using NModbus;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace GravitonEco.Managers
{
    public class ModbusTcpCommunication
    {
        private static ModbusTcpCommunication _instance;
        private static readonly object _lock = new object();

        private IModbusMaster _modbusMaster;
        private TcpClient _tcpClient;

        private readonly DeviceConfig _deviceConfig;

        private bool _isConnected = false;

        // Закрытый конструктор
        private ModbusTcpCommunication()
        {
            _deviceConfig = ConfigManager.LoadConfig();
            ConnectToModbusServer();
        }

        // Статический метод для получения единственного экземпляра
        public static ModbusTcpCommunication Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ModbusTcpCommunication();
                        }
                    }
                }
                return _instance;
            }
        }

        // Метод подключения к серверу Modbus с автоматической попыткой переподключения
        private void ConnectToModbusServer()
        {
            while (!_isConnected)
            {
                try
                {
                    _tcpClient = new TcpClient(_deviceConfig.IpAddress, _deviceConfig.Port);
                    var factory = new ModbusFactory();
                    _modbusMaster = factory.CreateMaster(_tcpClient);
                    _isConnected = true;
                }
                catch (SocketException ex)
                {
                    Console.WriteLine($"Ошибка подключения: {ex.Message}. Повторная попытка через 5 секунд...");
                    Task.Delay(TimeSpan.FromSeconds(5)).Wait();  // Подождать 5 секунд перед повторной попыткой
                }
            }
        }

        // Метод для проверки, подключён ли клиент
        private void EnsureConnected()
        {
            if (!_tcpClient.Connected)
            {
                _isConnected = false;
                ConnectToModbusServer();  // Повторное подключение при разрыве
            }
        }

        // Метод чтения Input Registers с обработкой ошибок
        public async Task<ushort[]> ReadInputRegistersAsync(byte slaveId, ushort startAddress)
        {
            return await ExecuteWithReconnect(async () =>
            {
                return await Task.Run(() => _modbusMaster.ReadInputRegisters(slaveId, startAddress, 1));
            });
        }

        // Метод чтения Holding Registers с обработкой ошибок
        public async Task<ushort[]> ReadHoldingRegistersAsync(byte slaveId, ushort startAddress)
        {
            return await ExecuteWithReconnect(async () =>
            {
                return await Task.Run(() => _modbusMaster.ReadHoldingRegisters(slaveId, startAddress, 1));
            });
        }

        // Метод чтения Discrete Registers с обработкой ошибок
        public async Task<bool[]> ReadDiscreteRegistersAsync(byte slaveId, ushort startAddress)
        {
            return await ExecuteWithReconnect(async () =>
            {
                return await Task.Run(() => _modbusMaster.ReadInputs(slaveId, startAddress, 1));
            });
        }

        public async Task WriteSingleHoldingRegisterAsync(byte slaveId, ushort address, ushort value)
        {
            try
            {
                await Task.Run(() =>
                {
                    _modbusMaster.Transport.WriteTimeout = 1000; // Уменьшить время ожидания
                    _modbusMaster.WriteSingleRegister(slaveId, address, value);
                }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи регистра Modbus: {ex.Message}");
                throw;  // Логировать ошибку и пробрасывать дальше
            }
        }


        // Универсальный метод для обработки повторных попыток подключения и выполнения операций Modbus
        private async Task<T> ExecuteWithReconnect<T>(Func<Task<T>> modbusOperation)
        {
            while (true)
            {
                try
                {
                    EnsureConnected();
                    return await modbusOperation();
                }
                catch (SocketException ex)
                {
                    Console.WriteLine($"Потеряно соединение: {ex.Message}. Повторная попытка через 5 секунд...");
                    _isConnected = false;
                    Task.Delay(TimeSpan.FromSeconds(5)).Wait();  // Подождать 5 секунд перед повторной попыткой
                    ConnectToModbusServer();  // Повторное подключение
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при выполнении операции Modbus: {ex.Message}");
                    throw;  // Логирование и проброс исключения для других потенциальных проблем
                }
            }
        }

        // Перегруженная версия для операций без возвращаемого значения (например, записи)
        private async Task ExecuteWithReconnect(Func<Task> modbusOperation)
        {
            while (true)
            {
                try
                {
                    EnsureConnected();
                    await modbusOperation();
                    return;
                }
                catch (SocketException ex)
                {
                    Console.WriteLine($"Потеряно соединение: {ex.Message}. Повторная попытка через 5 секунд...");
                    _isConnected = false;
                    Task.Delay(TimeSpan.FromSeconds(5)).Wait();  // Подождать 5 секунд перед повторной попыткой
                    ConnectToModbusServer();  // Повторное подключение
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при выполнении операции Modbus: {ex.Message}");
                    throw;
                }
            }
        }

        // Метод для завершения соединения
        public void Disconnect()
        {
            if (_tcpClient.Connected)
            {
                _tcpClient.Close();
                _isConnected = false;
            }
        }
    }
}
