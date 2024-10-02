using GravitonEco.Services;

namespace GravitonEco.ViewModels.Gauges
{
    public partial class NOViewModel : BaseModbusViewModel
    {
        public NOViewModel(ModbusTcpClient modbusTcp, string name)
        : base(modbusTcp, name) { }

        protected override byte SlaveAddress => 0x01; // Указываем адрес устройства

        protected override ushort CurrentValueAddress => 12;   // Адрес для текущего значения
        protected override ushort Porog1Address => 48;       // Адрес для порога 1
        protected override ushort Porog2Address => 49;       // Адрес для порога 2
        protected override ushort IncrementAddress => 50;    // Адрес для инкремента
        protected override ushort PeriodAddress => 51;       // Адрес для периода
        protected override ushort AlarmPorog1Address => 36;    // Адрес для Alarm порога 1
        protected override ushort AlarmPorog2Address => 37;    // Адрес для Alarm порога 2
        protected override ushort AlarmPorog3Address => 38;    // Адрес для Alarm порога 3
    }
}