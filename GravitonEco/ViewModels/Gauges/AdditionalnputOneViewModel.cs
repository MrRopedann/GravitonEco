using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GravitonEco.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Linq;

namespace GravitonEco.ViewModels.Gauges
{
    public partial class AdditionalnputOneViewModel : ObservableObject
    {
        private readonly Brush DefaultColor = Brushes.White;
        private readonly Brush AlarmColor = Brushes.Red;

        private readonly ModbusTcpCommunication _modbusTcpCommunication;
        private readonly DispatcherTimer _pollingTimer;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private ushort currentValue;

        [ObservableProperty]
        private ushort porog1;

        [ObservableProperty]
        private Brush alarmPorog1;

        [ObservableProperty]
        private ushort porog2;

        [ObservableProperty]
        private Brush alarmPorog2;

        [ObservableProperty]
        private ushort increment;

        [ObservableProperty]
        private ushort period;

        [ObservableProperty]
        private Brush alarmPorog3;

        public ICommand WritePorog1Command { get; }

        public AdditionalnputOneViewModel()
        {
            _modbusTcpCommunication = ModbusTcpCommunication.Instance;

            // Настройка таймера для периодического опроса регистров Modbus
            _pollingTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1) // Опрос каждые 1 секунду
            };
            _pollingTimer.Tick += async (sender, args) => await PollRegistersAsync();
            _pollingTimer.Start();
            Name = "Доп вход 1 (осв)";
            AlarmPorog1 = DefaultColor;

            WritePorog1Command = new RelayCommand(WritePorog1Value);

            InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            Porog1 = (await _modbusTcpCommunication.ReadHoldingRegistersAsync(1, 28))[0];
            Porog2 = (await _modbusTcpCommunication.ReadHoldingRegistersAsync(1, 29))[0];
            Increment = (await _modbusTcpCommunication.ReadHoldingRegistersAsync(1, 30))[0];
            Period = (await _modbusTcpCommunication.ReadHoldingRegistersAsync(1, 31))[0];
        }

        private async void WritePorog1Value()
        {
            await _modbusTcpCommunication.WriteSingleHoldingRegisterAsync(2, 20, Porog1);
        }

        private async Task PollRegistersAsync()
        {
            try
            {
                var currentValueTask = Task.Run(() => _modbusTcpCommunication.ReadInputRegistersAsync(1, 7)); // CurrentValue
                var alarmPorog1Task = Task.Run(() => _modbusTcpCommunication.ReadDiscreteRegistersAsync(1, 21)); // AlarmPorog1
                var alarmPorog2Task = Task.Run(() => _modbusTcpCommunication.ReadDiscreteRegistersAsync(1, 22)); // AlarmPorog2
                var alarmPorog3Task = Task.Run(() => _modbusTcpCommunication.ReadDiscreteRegistersAsync(1, 23)); // AlarmPorog3

                await Task.WhenAll(currentValueTask, alarmPorog1Task, alarmPorog2Task, alarmPorog3Task);

                CurrentValue = currentValueTask.Result[0];
                AlarmPorog1 = alarmPorog1Task.Result[0] ? AlarmColor : DefaultColor;
                AlarmPorog2 = alarmPorog2Task.Result[0] ? AlarmColor : DefaultColor;
                AlarmPorog3 = alarmPorog3Task.Result[0] ? AlarmColor : DefaultColor;
            }
            catch (Exception ex)
            {
                // Обработка ошибок
            }
        }

        // Остановка таймера при необходимости
        public void StopPolling()
        {
            _pollingTimer.Stop();
            _modbusTcpCommunication.Disconnect();
        }
    }
}
