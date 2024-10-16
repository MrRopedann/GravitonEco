using GravitonEco.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEco.ViewModels.Gauges
{
    public class CalibrationCOViewModel : BaseModbusViewModel
    {
        public CalibrationCOViewModel(ModbusTcpClient modbusTcp, string name)
        : base(modbusTcp, name) { }

        protected override byte SlaveAddress => 0x01; // Указываем адрес устройства

        protected override ushort CurrentValueAddress => 10;   // Адрес для текущего значения
        protected override ushort Porog1Address => 520;       // Адрес для порога 1
        protected override ushort Porog2Address => 521;       // Адрес для порога 2
        protected override ushort IncrementAddress => 522;    // Адрес для инкремента
        protected override ushort PeriodAddress => 523;       // Адрес для периода
        protected override ushort AlarmPorog1Address => 30;    // Адрес для Alarm порога 1
        protected override ushort AlarmPorog2Address => 31;    // Адрес для Alarm порога 2
        protected override ushort AlarmPorog3Address => 32;    // Адрес для Alarm порога 3
    }
}
