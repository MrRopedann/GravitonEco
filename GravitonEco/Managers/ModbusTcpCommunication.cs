using GravitonEco.Models;
using NLog;
using NModbus;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace GravitonEco.Managers
{
    public class ModbusTcpCommunication
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private static ModbusTcpCommunication _instance;
        private static readonly object _lock = new object();

        private IModbusMaster _modbusMaster;
        private TcpClient _tcpClient;

        private readonly DeviceConfig _deviceConfig;

        public bool _isConnected = false;

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
                    logger.Error($"Ошибка подключения: {ex.Message}. Повторная попытка через 5 секунд...");
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
                return await Task.Run(() => _modbusMaster.ReadInputRegistersAsync(slaveId, startAddress, 1));
            });
        }

        // Метод чтения Holding Registers с обработкой ошибок
        public async Task<ushort[]> ReadHoldingRegistersAsync(byte slaveId, ushort startAddress)
        {
            return await ExecuteWithReconnect(async () =>
            {
                return await Task.Run(() => _modbusMaster.ReadHoldingRegistersAsync(slaveId, startAddress, 1));
            });
        }

        // Метод чтения Discrete Registers с обработкой ошибок
        public async Task<bool[]> ReadDiscreteRegistersAsync(byte slaveId, ushort startAddress)
        {
            return await ExecuteWithReconnect(async () =>
            {
                return await Task.Run(() => _modbusMaster.ReadInputsAsync(slaveId, startAddress, 1));
            });

        }

        public async Task WriteSingleHoldingRegisterAsync(byte slaveId, ushort address, ushort value)
        {
            await ExecuteWithReconnect(async () =>
            {
                _modbusMaster.Transport.WriteTimeout = 1000; // Уменьшить время ожидания
                await _modbusMaster.WriteSingleRegisterAsync(slaveId, address, value);
            });
        }



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
                    logger.Error($"Потеряно соединение: {ex.Message}. Повторная попытка через 5 секунд...");
                    _isConnected = false;
                    await Task.Delay(TimeSpan.FromSeconds(5));  // Подождать 5 секунд перед повторной попыткой
                    ConnectToModbusServer();  // Повторное подключение
                }
                catch (IOException ex)
                {
                    logger.Error($"Ошибка ввода-вывода: {ex.Message}. Повторная попытка через 5 секунд...");
                    _isConnected = false;
                    await Task.Delay(TimeSpan.FromSeconds(5));  // Подождать 5 секунд перед повторной попыткой
                    ConnectToModbusServer();  // Повторное подключение
                }
                catch (Exception ex)
                {
                    logger.Error($"Ошибка при выполнении операции Modbus: {ex.Message}");
                    throw;  // Логирование и проброс исключения для других потенциальных проблем
                }
            }
        }



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
                    logger.Error($"Потеряно соединение: {ex.Message}. Повторная попытка через 5 секунд...");
                    _isConnected = false;
                    await Task.Delay(TimeSpan.FromSeconds(5));  // Подождать 5 секунд перед повторной попыткой
                    await ConnectToModbusServerAsync();  // Повторное подключение
                }
                catch (Exception ex)
                {
                    logger.Error($"Ошибка при выполнении операции Modbus: {ex.Message}");
                    throw;
                }
            }
        }

        private async Task ConnectToModbusServerAsync()
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
                    logger.Error($"Ошибка подключения: {ex.Message}. Повторная попытка через 5 секунд...");
                    await Task.Delay(TimeSpan.FromSeconds(5));  // Подождать 5 секунд перед повторной попыткой
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
