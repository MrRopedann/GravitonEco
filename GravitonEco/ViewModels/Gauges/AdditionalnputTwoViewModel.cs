using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GravitonEco.Managers;
using GravitonEco.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Linq;

namespace GravitonEco.ViewModels.Gauges
{
    public partial class AdditionalnputTwoViewModel : BaseModbusViewModel
    {
        public AdditionalnputTwoViewModel(ModbusTcpClient modbusTcp, string name)
        : base(modbusTcp, name) { }

        protected override byte SlaveAddress => 0x01; // Указываем адрес устройства

        protected override ushort CurrentValueAddress => 2;   // Адрес для текущего значения
        protected override ushort Porog1Address => 8;       // Адрес для порога 1
        protected override ushort Porog2Address => 9;       // Адрес для порога 2
        protected override ushort IncrementAddress => 10;    // Адрес для инкремента
        protected override ushort PeriodAddress => 11;       // Адрес для периода
        protected override ushort AlarmPorog1Address => 6;    // Адрес для Alarm порога 1
        protected override ushort AlarmPorog2Address => 7;    // Адрес для Alarm порога 2
        protected override ushort AlarmPorog3Address => 8;    // Адрес для Alarm порога 3
    }
}
