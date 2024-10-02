using GravitonEco.Services;

namespace GravitonEco.ViewModels.Gauges
{
    public partial class NO2ViewModel : BaseModbusViewModel
    {
        public NO2ViewModel(ModbusTcpClient modbusTcp, string name)
        : base(modbusTcp, name) { }

        protected override byte SlaveAddress => 0x01; // Указываем адрес устройства

        protected override ushort CurrentValueAddress => 13;   // Адрес для текущего значения
        protected override ushort Porog1Address => 52;       // Адрес для порога 1
        protected override ushort Porog2Address => 53;       // Адрес для порога 2
        protected override ushort IncrementAddress => 54;    // Адрес для инкремента
        protected override ushort PeriodAddress => 55;       // Адрес для периода
        protected override ushort AlarmPorog1Address => 39;    // Адрес для Alarm порога 1
        protected override ushort AlarmPorog2Address => 40;    // Адрес для Alarm порога 2
        protected override ushort AlarmPorog3Address => 41;    // Адрес для Alarm порога 3
    }
}