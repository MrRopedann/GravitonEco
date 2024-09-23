using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEco.Models
{
    public enum ModbusMode
    {
        ReadCoils,
        ReadHoldingRegisters,
        ReadInputRegisters,
        ReadInputs,
        ReadWriteMultipleRegisters,
        WriteMultipleCoils,
        WriteMultipleRegisters,
        WriteSingleCoil,
        WriteSingleRegister
    }
}
