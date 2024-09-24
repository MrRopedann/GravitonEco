﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GravitonEco.Managers;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace GravitonEco.ViewModels.Gauges
{
    public partial class RelativeHumidityOutsideViewModel : ObservableObject
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
        public ICommand WritePorog2Command { get; }
        public ICommand WriteIncrementCommand { get; }
        public ICommand WritePeriodCommand { get; }
        public RelativeHumidityOutsideViewModel()
        {
            _modbusTcpCommunication = ModbusTcpCommunication.Instance;

            // Настройка таймера для периодического опроса регистров Modbus
            _pollingTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1) // Опрос каждые 1 секунду
            };
            _pollingTimer.Tick += async (sender, args) => await PollRegistersAsync();
            _pollingTimer.Start();
            Name = "Отн. влажность внеш (0 - 98 %)";
            AlarmPorog1 = DefaultColor;
            WritePorog1Command = new RelayCommand(WritePorog1Value);
            WritePorog2Command = new RelayCommand(WritePorog2Value);
            WriteIncrementCommand = new RelayCommand(WriteIncrementValue);
            WritePeriodCommand = new RelayCommand(WritePeriodValue);

            InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            Porog1 = (await _modbusTcpCommunication.ReadHoldingRegistersAsync(2, 24))[0];
            Porog2 = (await _modbusTcpCommunication.ReadHoldingRegistersAsync(2, 25))[0];
            Increment = (await _modbusTcpCommunication.ReadHoldingRegistersAsync(2, 26))[0];
            Period = (await _modbusTcpCommunication.ReadHoldingRegistersAsync(2, 27))[0];
        }

        private async void WritePorog1Value()
        {
            await _modbusTcpCommunication.WriteSingleHoldingRegisterAsync(2, 24, Porog1);
        }

        private async void WritePorog2Value()
        {
            await _modbusTcpCommunication.WriteSingleHoldingRegisterAsync(2, 25, Porog2);
        }

        private async void WriteIncrementValue()
        {
            await _modbusTcpCommunication.WriteSingleHoldingRegisterAsync(2, 26, Increment);
        }

        private async void WritePeriodValue()
        {
            await _modbusTcpCommunication.WriteSingleHoldingRegisterAsync(2, 27, Period);
        }

        private async Task PollRegistersAsync()
        {
            try
            {
                var currentValueTask = Task.Run(() => _modbusTcpCommunication.ReadInputRegistersAsync(2, 6)); // CurrentValue
                var alarmPorog1Task = Task.Run(() => _modbusTcpCommunication.ReadDiscreteRegistersAsync(2, 18)); // AlarmPorog1
                var alarmPorog2Task = Task.Run(() => _modbusTcpCommunication.ReadDiscreteRegistersAsync(2, 19)); // AlarmPorog2
                var alarmPorog3Task = Task.Run(() => _modbusTcpCommunication.ReadDiscreteRegistersAsync(2, 20)); // AlarmPorog3

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