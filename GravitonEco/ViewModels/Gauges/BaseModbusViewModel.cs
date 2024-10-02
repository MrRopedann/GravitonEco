using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GravitonEco.Services;
using System.Windows.Input;
using System.Windows.Media;

namespace GravitonEco.ViewModels.Gauges
{
    public abstract partial class BaseModbusViewModel : ObservableObject
    {
        private readonly Brush DefaultColor = Brushes.White;
        private readonly Brush AlarmColor = Brushes.Red;

        private readonly ModbusTcpClient _modbusTcp;
        private bool _isUpdating;

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

        private bool _isInitialized = false;  // Флаг для проверки инициализации HoldingRegisters

        protected BaseModbusViewModel(ModbusTcpClient modbusTcp, string name)
        {
            _modbusTcp = modbusTcp;
            Name = name;

            WritePorog1Command = new RelayCommand(async () => await WritePorog1Async());
            WritePorog2Command = new RelayCommand(async () => await WritePorog2Async());
            WriteIncrementCommand = new RelayCommand(async () => await WriteIncrementAsync());
            WritePeriodCommand = new RelayCommand(async () => await WritePeriodAsync());

            StartUpdatingRegisters();
        }

        protected abstract byte SlaveAddress { get; } // Абстрактное свойство для slaveAddress

        protected abstract ushort CurrentValueAddress { get; }
        protected abstract ushort Porog1Address { get; }
        protected abstract ushort Porog2Address { get; }
        protected abstract ushort IncrementAddress { get; }
        protected abstract ushort PeriodAddress { get; }
        protected abstract ushort AlarmPorog1Address { get; }
        protected abstract ushort AlarmPorog2Address { get; }
        protected abstract ushort AlarmPorog3Address { get; }

        private async Task WritePorog1Async()
        {
            await _modbusTcp.WriteSingleHoldingRegisterAsync(SlaveAddress, Porog1Address, Porog1);
        }

        private async Task WritePorog2Async()
        {
            await _modbusTcp.WriteSingleHoldingRegisterAsync(SlaveAddress, Porog2Address, Porog2);
        }

        private async Task WriteIncrementAsync()
        {
            await _modbusTcp.WriteSingleHoldingRegisterAsync(SlaveAddress, IncrementAddress, Increment);
        }

        private async Task WritePeriodAsync()
        {
            await _modbusTcp.WriteSingleHoldingRegisterAsync(SlaveAddress, PeriodAddress, Period);
        }

        private async void StartUpdatingRegisters()
        {
            _isUpdating = true;
            while (_isUpdating)
            {
                await UpdateValuesAsync();
                await Task.Delay(1000); // Интервал обновления 1 секунда
            }
        }

        private async Task UpdateValuesAsync()
        {
            if (!_isInitialized)
            {
                await InitializeHoldingRegistersAsync();
            }

            // Чтение текущего значения
            var inputRegisterResult = await _modbusTcp.ReadInputRegistersAsync(SlaveAddress, CurrentValueAddress);
            if (inputRegisterResult != null)
                CurrentValue = inputRegisterResult[0];

            // Чтение дискретных сигналов (Alarm)
            var discreteInputsResult = await _modbusTcp.ReadDiscreteRegistersAsync(SlaveAddress, AlarmPorog1Address);
            if (discreteInputsResult != null)
                AlarmPorog1 = discreteInputsResult[0] ? AlarmColor : DefaultColor;

            discreteInputsResult = await _modbusTcp.ReadDiscreteRegistersAsync(SlaveAddress, AlarmPorog2Address);
            if (discreteInputsResult != null)
                AlarmPorog2 = discreteInputsResult[0] ? AlarmColor : DefaultColor;

            discreteInputsResult = await _modbusTcp.ReadDiscreteRegistersAsync(SlaveAddress, AlarmPorog3Address);
            if (discreteInputsResult != null)
                AlarmPorog3 = discreteInputsResult[0] ? AlarmColor : DefaultColor;
        }

        private async Task InitializeHoldingRegistersAsync()
        {
            // Чтение порогов (Holding Registers)
            var holdingRegistersResult = await _modbusTcp.ReadHoldingRegistersAsync(SlaveAddress, Porog1Address);
            if (holdingRegistersResult != null)
                Porog1 = holdingRegistersResult[0];

            holdingRegistersResult = await _modbusTcp.ReadHoldingRegistersAsync(SlaveAddress, Porog2Address);
            if (holdingRegistersResult != null)
                Porog2 = holdingRegistersResult[0];

            holdingRegistersResult = await _modbusTcp.ReadHoldingRegistersAsync(SlaveAddress, IncrementAddress);
            if (holdingRegistersResult != null)
                Increment = holdingRegistersResult[0];

            holdingRegistersResult = await _modbusTcp.ReadHoldingRegistersAsync(SlaveAddress, PeriodAddress);
            if (holdingRegistersResult != null)
                Period = holdingRegistersResult[0];

            _isInitialized = true;  // Устанавливаем флаг инициализации в true
        }

        public void StopUpdating()
        {
            _isUpdating = false;
        }
    }
}