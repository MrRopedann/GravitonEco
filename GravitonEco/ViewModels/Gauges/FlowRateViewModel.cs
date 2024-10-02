using GravitonEco.Services;

namespace GravitonEco.ViewModels.Gauges
{
    public partial class FlowRateViewModel : BaseModbusViewModel
    {
        public FlowRateViewModel(ModbusTcpClient modbusTcp, string name)
        : base(modbusTcp, name) { }

        protected override byte SlaveAddress => 0x03; // Указываем адрес устройства

        protected override ushort CurrentValueAddress => 25;   // Адрес для текущего значения
        protected override ushort Porog1Address => 100;       // Адрес для порога 1
        protected override ushort Porog2Address => 101;       // Адрес для порога 2
        protected override ushort IncrementAddress => 102;    // Адрес для инкремента
        protected override ushort PeriodAddress => 103;       // Адрес для периода
        protected override ushort AlarmPorog1Address => 75;    // Адрес для Alarm порога 1
        protected override ushort AlarmPorog2Address => 76;    // Адрес для Alarm порога 2
        protected override ushort AlarmPorog3Address => 77;    // Адрес для Alarm порога 3
    }
}