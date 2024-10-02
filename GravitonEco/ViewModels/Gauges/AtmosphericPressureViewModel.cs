using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GravitonEco.Managers;
using GravitonEco.Services;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace GravitonEco.ViewModels.Gauges
{
    public partial class AtmosphericPressureViewModel : BaseModbusViewModel
    {
        public AtmosphericPressureViewModel(ModbusTcpClient modbusTcp, string name)
        : base(modbusTcp, name) { }

        protected override byte SlaveAddress => 0x01; // Указываем адрес устройства

        protected override ushort CurrentValueAddress => 1;   // Адрес для текущего значения
        protected override ushort Porog1Address => 4;       // Адрес для порога 1
        protected override ushort Porog2Address => 5;       // Адрес для порога 2
        protected override ushort IncrementAddress => 6;    // Адрес для инкремента
        protected override ushort PeriodAddress => 7;       // Адрес для периода
        protected override ushort AlarmPorog1Address => 3;    // Адрес для Alarm порога 1
        protected override ushort AlarmPorog2Address => 4;    // Адрес для Alarm порога 2
        protected override ushort AlarmPorog3Address => 5;    // Адрес для Alarm порога 3
    }
}