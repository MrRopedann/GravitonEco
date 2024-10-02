using GravitonEco.Services;
using GravitonEco.ViewModels.Gauges;

namespace GravitonEco.ViewModels
{
    public partial class MicroAccelerationsViewModel : BaseModbusViewModel
    {
        public MicroAccelerationsViewModel(ModbusTcpClient modbusTcp, string name)
        : base(modbusTcp, name) { }

        protected override byte SlaveAddress => 0x01; // Указываем адрес устройства

        protected override ushort CurrentValueAddress => 21;   // Адрес для текущего значения
        protected override ushort Porog1Address => 84;       // Адрес для порога 1
        protected override ushort Porog2Address => 85;       // Адрес для порога 2
        protected override ushort IncrementAddress => 86;    // Адрес для инкремента
        protected override ushort PeriodAddress => 87;       // Адрес для периода
        protected override ushort AlarmPorog1Address => 63;    // Адрес для Alarm порога 1
        protected override ushort AlarmPorog2Address => 64;    // Адрес для Alarm порога 2
        protected override ushort AlarmPorog3Address => 65;    // Адрес для Alarm порога 3
    }
}