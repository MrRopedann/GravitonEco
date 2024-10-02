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
    public partial class PM2_5ViewModel : BaseModbusViewModel
    {
        public PM2_5ViewModel(ModbusTcpClient modbusTcp, string name)
        : base(modbusTcp, name) { }

        protected override byte SlaveAddress => 0x02; // Указываем адрес устройства

        protected override ushort CurrentValueAddress => 17;   // Адрес для текущего значения
        protected override ushort Porog1Address => 68;       // Адрес для порога 1
        protected override ushort Porog2Address => 69;       // Адрес для порога 2
        protected override ushort IncrementAddress => 70;    // Адрес для инкремента
        protected override ushort PeriodAddress => 71;       // Адрес для периода
        protected override ushort AlarmPorog1Address => 51;    // Адрес для Alarm порога 1
        protected override ushort AlarmPorog2Address => 52;    // Адрес для Alarm порога 2
        protected override ushort AlarmPorog3Address => 53;    // Адрес для Alarm порога 3
    }
}