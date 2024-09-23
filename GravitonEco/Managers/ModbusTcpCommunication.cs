using GravitonEco.Models;
using NModbus;
using System.Net.Sockets;

namespace GravitonEco.Managers
{
    public class ModbusTcpCommunication
    {
        private static ModbusTcpCommunication _instance;
        private static readonly object _lock = new object();

        private readonly IModbusMaster _modbusMaster;
        private readonly TcpClient _tcpClient;

        private readonly DeviceConfig _deviceConfig;

        // Закрытый конструктор, чтобы предотвратить создание экземпляров извне
        private ModbusTcpCommunication()
        {
            _deviceConfig = ConfigManager.LoadConfig();
            _tcpClient = new TcpClient(_deviceConfig.IpAddress, _deviceConfig.Port);

            var factory = new ModbusFactory();
            _modbusMaster = factory.CreateMaster(_tcpClient);
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

        // Метод чтения Input Registers
        public ushort[] ReadInputRegisters(byte slaveId, ushort startAddress)
        {
            return _modbusMaster.ReadInputRegisters(slaveId, startAddress, 1);
        }

        // Метод чтения Holding Registers
        public ushort[] ReadHoldingRegisters(byte slaveId, ushort startAddress)
        {
            return _modbusMaster.ReadHoldingRegisters(slaveId, startAddress, 1);
        }

        // Метод чтения Discrete Registers
        public ushort[] ReadDiscreteRegisters(byte slaveId, ushort startAddress)
        {
            bool[] discreteValues = _modbusMaster.ReadInputs(slaveId, startAddress, 1);
            ushort discreteValue = (ushort)(discreteValues[0] ? 1 : 0);
            return new ushort[] { discreteValue };
        }

        // Метод записи в Holding Register
        public void WriteSingleHoldingRegister(byte slaveId, ushort address, ushort value)
        {
            _modbusMaster.WriteSingleRegister(slaveId, address, value);
        }

        // Метод записи в Coil Register
        public void WriteSingleCoil(byte slaveId, ushort address, bool value)
        {
            _modbusMaster.WriteSingleCoil(slaveId, address, value);
        }

        // Метод для записи множества Holding регистров
        public void WriteMultipleHoldingRegisters(byte slaveId, ushort startAddress, ushort[] values)
        {
            _modbusMaster.WriteMultipleRegisters(slaveId, startAddress, values);
        }

        // Метод для записи множества Coil регистров
        public void WriteMultipleCoils(byte slaveId, ushort startAddress, bool[] values)
        {
            _modbusMaster.WriteMultipleCoils(slaveId, startAddress, values);
        }

        // Метод для завершения соединения
        public void Disconnect()
        {
            if (_tcpClient.Connected)
            {
                _tcpClient.Close();
            }
        }
    }
}
