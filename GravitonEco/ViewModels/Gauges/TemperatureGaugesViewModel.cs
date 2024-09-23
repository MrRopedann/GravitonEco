using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GravitonEco.Managers;
using System.Windows.Media;
using System.Windows.Threading;

namespace GravitonEco.ViewModels.Gauges
{
    public partial class TemperatureGaugesViewModel : ObservableObject
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
        public TemperatureGaugesViewModel()
        {
            _modbusTcpCommunication = ModbusTcpCommunication.Instance;

            // Настройка таймера для периодического опроса регистров Modbus
            _pollingTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1) // Опрос каждые 1 секунду
            };
            _pollingTimer.Tick += async (sender, args) => await PollRegistersAsync();
            _pollingTimer.Start();
            Name = "Температура внеш(-45 до +45°С)";
            AlarmPorog1 = DefaultColor;
        }

        [RelayCommand]
        private void WriteToModbus(string propertyName)
        {
            try
            {
                switch (propertyName)
                {
                    case nameof(Porog1):
                        _modbusTcpCommunication.WriteSingleHoldingRegister(2, 20, Porog1);
                        break;
                    case nameof(Porog2):
                        _modbusTcpCommunication.WriteSingleHoldingRegister(2, 21, Porog2);
                        break;
                    case nameof(Increment):
                        _modbusTcpCommunication.WriteSingleHoldingRegister(2, 22, Increment);
                        break;
                    case nameof(Period):
                        _modbusTcpCommunication.WriteSingleHoldingRegister(2, 23, Period);
                        break;
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок
            }
        }

        private async Task PollRegistersAsync()
        {
            try
            {
                var tasks = new[]
                {
            Task.Run(() => _modbusTcpCommunication.ReadInputRegisters(2, 5)), // CurrentValue
            Task.Run(() => _modbusTcpCommunication.ReadHoldingRegisters(2, 20)), // Porog1
            Task.Run(() => _modbusTcpCommunication.ReadHoldingRegisters(2, 21)), // Porog2
            Task.Run(() => _modbusTcpCommunication.ReadHoldingRegisters(2, 22)), // Increment
            Task.Run(() => _modbusTcpCommunication.ReadHoldingRegisters(2, 23)), // Period
            Task.Run(() => _modbusTcpCommunication.ReadDiscreteRegisters(2, 15)), // AlarmPorog1
            Task.Run(() => _modbusTcpCommunication.ReadDiscreteRegisters(2, 16)), // AlarmPorog2
            Task.Run(() => _modbusTcpCommunication.ReadDiscreteRegisters(2, 17)), // AlarmPorog3
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