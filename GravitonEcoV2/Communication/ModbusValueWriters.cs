using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GravitonEcoV2.Communication
{
    public class ModbusValueWriters : ModbusWritersBase
    {
        private byte _slaveAdress { get; set; }
        private ushort _startAdress { get; set; }
        private ushort _value { get; set; }

        public ModbusValueWriters(ModbusConnectionManager connectionManager, byte slaveAdress, ushort startAdress, ushort value)
            : base(connectionManager)
        {
            _slaveAdress = slaveAdress;
            _startAdress = startAdress;
            _value = value;
        }

        public void WriteRegistersFunction(IModbusMaster modbusMaster)
        {
            modbusMaster.WriteSingleRegisterAsync(_slaveAdress, _startAdress, _value);
        }
    }
}
