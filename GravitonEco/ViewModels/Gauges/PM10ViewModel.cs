using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GravitonEco.Managers;
using GravitonEco.Services;
using GravitonEco.ViewModels.Gauges;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace GravitonEco.ViewModels
{
    public partial class PM10ViewModel : BaseModbusViewModel
    {
        public PM10ViewModel(ModbusTcpClient modbusTcp, string name)
        : base(modbusTcp, name) { }

        protected override byte SlaveAddress => 0x02; // Указываем адрес устройства

        protected override ushort CurrentValueAddress => 18;   // Адрес для текущего значения
        protected override ushort Porog1Address => 72;       // Адрес для порога 1
        protected override ushort Porog2Address => 73;       // Адрес для порога 2
        protected override ushort IncrementAddress => 74;    // Адрес для инкремента
        protected override ushort PeriodAddress => 75;       // Адрес для периода
        protected override ushort AlarmPorog1Address => 54;    // Адрес для Alarm порога 1
        protected override ushort AlarmPorog2Address => 55;    // Адрес для Alarm порога 2
        protected override ushort AlarmPorog3Address => 56;    // Адрес для Alarm порога 3
    }
}