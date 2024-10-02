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
    public partial class COViewModel : BaseModbusViewModel
    {
        public COViewModel(ModbusTcpClient modbusTcp, string name)
        : base(modbusTcp, name) { }

        protected override byte SlaveAddress => 0x01; // Указываем адрес устройства

        protected override ushort CurrentValueAddress => 10;   // Адрес для текущего значения
        protected override ushort Porog1Address => 40;       // Адрес для порога 1
        protected override ushort Porog2Address => 41;       // Адрес для порога 2
        protected override ushort IncrementAddress => 42;    // Адрес для инкремента
        protected override ushort PeriodAddress => 43;       // Адрес для периода
        protected override ushort AlarmPorog1Address => 30;    // Адрес для Alarm порога 1
        protected override ushort AlarmPorog2Address => 31;    // Адрес для Alarm порога 2
        protected override ushort AlarmPorog3Address => 32;    // Адрес для Alarm порога 3
    }
}