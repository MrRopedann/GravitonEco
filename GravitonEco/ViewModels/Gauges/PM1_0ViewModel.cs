using GravitonEco.Services;
using GravitonEco.ViewModels.Gauges;

namespace GravitonEco.ViewModels
{
    public partial class PM1_0ViewModel : BaseModbusViewModel
    {
        public PM1_0ViewModel(ModbusTcpClient modbusTcp, string name)
        : base(modbusTcp, name) { }

        protected override byte SlaveAddress => 0x02; // Указываем адрес устройства

        protected override ushort CurrentValueAddress => 16;   // Адрес для текущего значения
        protected override ushort Porog1Address => 40;       // Адрес для порога 1
        protected override ushort Porog2Address => 41;       // Адрес для порога 2
        protected override ushort IncrementAddress => 42;    // Адрес для инкремента
        protected override ushort PeriodAddress => 43;       // Адрес для периода
        protected override ushort AlarmPorog1Address => 48;    // Адрес для Alarm порога 1
        protected override ushort AlarmPorog2Address => 49;    // Адрес для Alarm порога 2
        protected override ushort AlarmPorog3Address => 50;    // Адрес для Alarm порога 3
    }
}