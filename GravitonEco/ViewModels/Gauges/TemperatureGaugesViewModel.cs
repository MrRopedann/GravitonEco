using GravitonEco.Services;

namespace GravitonEco.ViewModels.Gauges
{
    public partial class TemperatureGaugesViewModel : BaseModbusViewModel
    {
        public TemperatureGaugesViewModel(ModbusTcpClient modbusTcp, string name)
        : base(modbusTcp, name) { }

        protected override byte SlaveAddress => 0x02; // Указываем адрес устройства

        protected override ushort CurrentValueAddress => 5;   // Адрес для текущего значения
        protected override ushort Porog1Address => 20;       // Адрес для порога 1
        protected override ushort Porog2Address => 21;       // Адрес для порога 2
        protected override ushort IncrementAddress => 22;    // Адрес для инкремента
        protected override ushort PeriodAddress => 23;       // Адрес для периода
        protected override ushort AlarmPorog1Address => 15;    // Адрес для Alarm порога 1
        protected override ushort AlarmPorog2Address => 16;    // Адрес для Alarm порога 2
        protected override ushort AlarmPorog3Address => 17;    // Адрес для Alarm порога 3
    }
}