﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GravitonEco.Managers;
using System.Windows.Media;
using System.Windows.Threading;

namespace GravitonEco.ViewModels
{
    public partial class COViewModel : ObservableObject
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
        public COViewModel()
        {
            _modbusTcpCommunication = ModbusTcpCommunication.Instance;

            // Настройка таймера для периодического опроса регистров Modbus
            _pollingTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1) // Опрос каждые 1 секунду
            };
            _pollingTimer.Tick += async (sender, args) => await PollRegistersAsync();
            _pollingTimer.Start();
            Name = "CO (0 - 40 000 ppb)";
            AlarmPorog1 = DefaultColor;
        }

        private async Task PollRegistersAsync()
        {
            try
            {
                var tasks = new[]
                {
            Task.Run(() => _modbusTcpCommunication.ReadInputRegisters(1, 10)), // CurrentValue
            Task.Run(() => _modbusTcpCommunication.ReadHoldingRegisters(1, 40)), // Porog1
            Task.Run(() => _modbusTcpCommunication.ReadHoldingRegisters(1, 41)), // Porog2
            Task.Run(() => _modbusTcpCommunication.ReadHoldingRegisters(1, 42)), // Increment
            Task.Run(() => _modbusTcpCommunication.ReadHoldingRegisters(1, 43)), // Period
            Task.Run(() => _modbusTcpCommunication.ReadDiscreteRegisters(1, 30)), // AlarmPorog1
            Task.Run(() => _modbusTcpCommunication.ReadDiscreteRegisters(1, 31)), // AlarmPorog2
            Task.Run(() => _modbusTcpCommunication.ReadDiscreteRegisters(1, 32)), // AlarmPorog3
        };

                await Task.WhenAll(tasks);

                CurrentValue = ((ushort[])tasks[0].Result)[0];
                Porog1 = ((ushort[])tasks[1].Result)[0];
                Porog2 = ((ushort[])tasks[2].Result)[0];
                Increment = ((ushort[])tasks[3].Result)[0];
                Period = ((ushort[])tasks[4].Result)[0];

                // Обновление цветов
                AlarmPorog1 = Convert.ToBoolean(((ushort[])tasks[5].Result)[0]) ? AlarmColor : DefaultColor;
                AlarmPorog2 = Convert.ToBoolean(((ushort[])tasks[6].Result)[0]) ? AlarmColor : DefaultColor;
                AlarmPorog3 = Convert.ToBoolean(((ushort[])tasks[7].Result)[0]) ? AlarmColor : DefaultColor;
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
