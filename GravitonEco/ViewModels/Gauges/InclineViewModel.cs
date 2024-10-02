using GravitonEco.Services;
using GravitonEco.ViewModels.Gauges;

namespace GravitonEco.ViewModels
{
    public partial class InclineViewModel : BaseModbusViewModel
    {
        public InclineViewModel(ModbusTcpClient modbusTcp, string name)
        : base(modbusTcp, name) { }

        protected override byte SlaveAddress => 0x01; // Указываем адрес устройства

        protected override ushort CurrentValueAddress => 20;   // Адрес для текущего значения
        protected override ushort Porog1Address => 80;       // Адрес для порога 1
        protected override ushort Porog2Address => 81;       // Адрес для порога 2
        protected override ushort IncrementAddress => 82;    // Адрес для инкремента
        protected override ushort PeriodAddress => 83;       // Адрес для периода
        protected override ushort AlarmPorog1Address => 60;    // Адрес для Alarm порога 1
        protected override ushort AlarmPorog2Address => 61;    // Адрес для Alarm порога 2
        protected override ushort AlarmPorog3Address => 62;    // Адрес для Alarm порога 3
    }
}