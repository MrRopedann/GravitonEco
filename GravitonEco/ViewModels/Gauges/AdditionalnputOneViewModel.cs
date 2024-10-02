using GravitonEco.Services;

namespace GravitonEco.ViewModels.Gauges
{
    public partial class AdditionalnputOneViewModel : BaseModbusViewModel
    {
        public AdditionalnputOneViewModel(ModbusTcpClient modbusTcp, string name)
        : base(modbusTcp, name) { }

        protected override byte SlaveAddress => 0x01; // Указываем адрес устройства

        protected override ushort CurrentValueAddress => 7;   // Адрес для текущего значения
        protected override ushort Porog1Address => 28;       // Адрес для порога 1
        protected override ushort Porog2Address => 29;       // Адрес для порога 2
        protected override ushort IncrementAddress => 30;    // Адрес для инкремента
        protected override ushort PeriodAddress => 31;       // Адрес для периода
        protected override ushort AlarmPorog1Address => 21;    // Адрес для Alarm порога 1
        protected override ushort AlarmPorog2Address => 22;    // Адрес для Alarm порога 2
        protected override ushort AlarmPorog3Address => 23;    // Адрес для Alarm порога 3
    }
}
