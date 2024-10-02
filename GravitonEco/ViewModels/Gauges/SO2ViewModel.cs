using GravitonEco.Services;

namespace GravitonEco.ViewModels.Gauges
{
    public partial class SO2ViewModel : BaseModbusViewModel
    {
        public SO2ViewModel(ModbusTcpClient modbusTcp, string name)
        : base(modbusTcp, name) { }

        protected override byte SlaveAddress => 0x01; // Указываем адрес устройства

        protected override ushort CurrentValueAddress => 19;   // Адрес для текущего значения
        protected override ushort Porog1Address => 76;       // Адрес для порога 1
        protected override ushort Porog2Address => 77;       // Адрес для порога 2
        protected override ushort IncrementAddress => 78;    // Адрес для инкремента
        protected override ushort PeriodAddress => 79;       // Адрес для периода
        protected override ushort AlarmPorog1Address => 57;    // Адрес для Alarm порога 1
        protected override ushort AlarmPorog2Address => 58;    // Адрес для Alarm порога 2
        protected override ushort AlarmPorog3Address => 59;    // Адрес для Alarm порога 3
    }
}