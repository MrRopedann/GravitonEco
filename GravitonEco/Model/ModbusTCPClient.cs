using GravitonEco.View;
using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public event EventHandler<string> DataUpdatedEvent;


        public ModbusTCPClient(string ipAddress, int port)
        {
            _ipAddress = ipAddress;
            _port = port;
            try
            {
                _tcpClient = new TcpClient(_ipAddress, _port);
            }
            catch(Exception ex)
            {
                Setting setting = new Setting();
                setting.Show();
            }
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

        public async Task WriteHoldingParametrAsync(byte slaveId, ushort address, ushort value)
        {
            await _modbusMaster.WriteSingleRegisterAsync(slaveId, address, value);
        }

        public async Task<Dictionary<string, string>> ReadMultipleValuesAsync(Dictionary<string, (byte slaveId, ushort address)> parameters)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            var tasks = new List<Task>();
            foreach (var kvp in parameters)
            {
                string paramName = kvp.Key;
                byte slaveId = kvp.Value.slaveId;
                ushort address = kvp.Value.address;

                tasks.Add(Task.Run(async () =>
                {
                    string value = "";

                    if (paramName.StartsWith("holding_"))
                    {
                        value = await ReadHoldingParameterAsync(slaveId, address);
                    }
                    else if (paramName.StartsWith("input_"))
                    {
                        value = await ReadInputParameterAsync(slaveId, address);
                    }
                    else if (paramName.StartsWith("coil_"))
                    {
                        value = await ReadCoilParameterAsync(slaveId, address);
                    }

                    lock (result) // Защита словаря для параллельного доступа
                    {
                        result[paramName] = value;
                    }
                }));
            }

            await Task.WhenAll(tasks);

            return result;
        }

        public async Task<string> ReadHoldingParameterAsync(byte slaveId, ushort address)
        {
            ushort[] registers = await _modbusMaster.ReadHoldingRegistersAsync(slaveId, address, 1);
            return registers[0].ToString();
        }

        public async Task<string> ReadInputParameterAsync(byte slaveId, ushort address)
        {
            ushort[] registers = await _modbusMaster.ReadInputRegistersAsync(slaveId, address, 1);
            return registers[0].ToString();
        }

        public async Task<string> ReadCoilParameterAsync(byte slaveId, ushort address)
        {
            bool[] registers = await _modbusMaster.ReadInputsAsync(slaveId, address, 1);
            return registers[0].ToString();
        }
    }
}
