using CommunityToolkit.Mvvm.ComponentModel;
using GravitonEco.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEco.ViewModels.Gauges
{
    public partial class DateTimeViewModel : ObservableObject
    {
        private readonly ModbusTcpClient _modbusTcp;
        private bool _isUpdating;

        [ObservableProperty]
        private string currentDateTime;

        public DateTimeViewModel(ModbusTcpClient modbusTcp)
        {
            _modbusTcp = modbusTcp;
            StartUpdatingDateTime();
        }

        private async void StartUpdatingDateTime()
        {
            _isUpdating = true;
            while (_isUpdating)
            {
                await UpdateDateTimeAsync();
                await Task.Delay(1000); // Интервал обновления 1 секунда
            }
        }

        public void StopUpdating()
        {
            _isUpdating = false;
        }

        private async Task UpdateDateTimeAsync()
        {
            // Чтение всех необходимых регистров
            var secondsResult = await _modbusTcp.ReadHoldingRegistersAsync(251, 256);
            var minutesResult = await _modbusTcp.ReadHoldingRegistersAsync(251, 257);
            var hoursResult = await _modbusTcp.ReadHoldingRegistersAsync(251, 258);
            var dayResult = await _modbusTcp.ReadHoldingRegistersAsync(251, 260);
            var monthResult = await _modbusTcp.ReadHoldingRegistersAsync(251, 261);
            var yearResult = await _modbusTcp.ReadHoldingRegistersAsync(251, 262);

            if (secondsResult != null && minutesResult != null && hoursResult != null &&
                dayResult != null && monthResult != null && yearResult != null)
            {
                // Преобразование BCD в обычные значения
                var seconds = BcdToDecimal(secondsResult[0]);
                var minutes = BcdToDecimal(minutesResult[0]);
                var hours = BcdToDecimal(hoursResult[0]);
                var day = BcdToDecimal(dayResult[0]);
                var month = BcdToDecimal(monthResult[0]);
                var year = BcdToDecimal(yearResult[0]) + 2000; // Предполагаем, что год в формате 00-99

                // Форматирование строки
                CurrentDateTime = $"{day:D2}.{month:D2}.{year} {hours:D2}:{minutes:D2}:{seconds:D2}";
            }
        }

        private int BcdToDecimal(ushort bcd)
        {
            return (bcd >> 4) * 10 + (bcd & 0x0F);
        }
    }
}