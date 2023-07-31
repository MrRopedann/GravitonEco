using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEco.Model
{
    public class ModbusTCPClient
    {
        private string _ipAddress;
        private int _port;
        private TcpClient _tcpClient;
        private ModbusFactory _modbusFactory;
        private IModbusMaster _modbusMaster;

        public ModbusTCPClient(string ipAddress, int port)
        {
            _ipAddress = ipAddress;
            _port = port;
            _tcpClient = new TcpClient(_ipAddress, _port);
            _modbusFactory = new ModbusFactory();
            _modbusMaster = _modbusFactory.CreateMaster(_tcpClient);
        }

        public string ReadHoldingParametrdate(byte slaveId, ushort address)
        {
            ushort[] registers = _modbusMaster.ReadHoldingRegisters(slaveId, address, 1);
            for (int index = 0; index < registers.Length; index++)
            {
                byte[] bytes = BitConverter.GetBytes(registers[index]);
                string hexString = BitConverter.ToString(bytes);

                return hexString;
            }
            _modbusMaster.Dispose();
            return "";
        }

        public string ReadInputParametr(byte slaveId, ushort address)
        {
            ushort[] registers = _modbusMaster.ReadInputRegisters(slaveId, address, 1);

            for (int index = 0; index < registers.Length; index++)
            {
                return registers[index].ToString();
            }
            _modbusMaster.Dispose();
            return "";
        }

        public string ReadHoldingParametr(byte slaveId, ushort address)
        {
            ushort[] registers = _modbusMaster.ReadHoldingRegisters(slaveId, address, 1);

            for (int index = 0; index < registers.Length; index++)
            {
                return registers[index].ToString();
            }
            _modbusMaster.Dispose();
            return "";
        }

        public string ReadCoilParametr(byte slaveId, ushort address)
        {
            bool[] registers = _modbusMaster.ReadInputs(slaveId, address, 1);

            for (int index = 0; index < registers.Length; index++)
            {
                return registers[index].ToString();
            }
            _modbusMaster.Dispose();
            return "";
        }

        public void WriteHoldingParametr(byte slaveId, ushort address, ushort value)
        {
            _modbusMaster.WriteSingleRegister(slaveId, address, value);
        }
    }
}
