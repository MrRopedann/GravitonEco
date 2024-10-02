using GravitonEco.Services;
using GravitonEco.ViewModels.Gauges;

namespace GravitonEco.ViewModels
{
    public partial class LOCViewModel : BaseModbusViewModel
    {
        public LOCViewModel(ModbusTcpClient modbusTcp, string name)
        : base(modbusTcp, name) { }

        protected override byte SlaveAddress => 0x01; // Указываем адрес устройства

        protected override ushort CurrentValueAddress => 8;   // Адрес для текущего значения
        protected override ushort Porog1Address => 32;       // Адрес для порога 1
        protected override ushort Porog2Address => 33;       // Адрес для порога 2
        protected override ushort IncrementAddress => 34;    // Адрес для инкремента
        protected override ushort PeriodAddress => 35;       // Адрес для периода
        protected override ushort AlarmPorog1Address => 24;    // Адрес для Alarm порога 1
        protected override ushort AlarmPorog2Address => 25;    // Адрес для Alarm порога 2
        protected override ushort AlarmPorog3Address => 26;    // Адрес для Alarm порога 3
    }
}