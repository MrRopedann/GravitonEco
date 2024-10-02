using GravitonEco.Services;

namespace GravitonEco.ViewModels.Gauges
{
    public partial class RelativeHumidityOutsideViewModel : BaseModbusViewModel
    {
        public RelativeHumidityOutsideViewModel(ModbusTcpClient modbusTcp, string name)
        : base(modbusTcp, name) { }

        protected override byte SlaveAddress => 0x02; // Указываем адрес устройства

        protected override ushort CurrentValueAddress => 6;   // Адрес для текущего значения
        protected override ushort Porog1Address => 24;       // Адрес для порога 1
        protected override ushort Porog2Address => 25;       // Адрес для порога 2
        protected override ushort IncrementAddress => 26;    // Адрес для инкремента
        protected override ushort PeriodAddress => 27;       // Адрес для периода
        protected override ushort AlarmPorog1Address => 18;    // Адрес для Alarm порога 1
        protected override ushort AlarmPorog2Address => 19;    // Адрес для Alarm порога 2
        protected override ushort AlarmPorog3Address => 20;    // Адрес для Alarm порога 3
    }
}