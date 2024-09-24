using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GravitonEco.Managers;

namespace GravitonEco.ViewModels.Gauges
{
    public partial class ChartViewModel : ObservableObject
    {
        [ObservableProperty]
        private ushort porog1;

        [ObservableProperty]
        private ushort porog2;

        [ObservableProperty]
        private ISeries[] currentSeries; // Выбранная серия данных для графика

        private readonly ObservableCollection<ObservablePoint> _chartValues1; // Данные для первого графика
        private readonly ObservableCollection<ObservablePoint> _chartValues2; // Данные для второго графика

        public ChartViewModel()
        {
            _chartValues1 = new ObservableCollection<ObservablePoint>();
            _chartValues2 = new ObservableCollection<ObservablePoint>();

            // Инициализация графиков
            Series1 = new ISeries[]
            {
                new LineSeries<ObservablePoint>
                {
                    Values = _chartValues1,
                    GeometryStroke = null,
                    GeometryFill = null,
                    DataPadding = new(0, 1)
                }
            };

            Series2 = new ISeries[]
            {
                new LineSeries<ObservablePoint>
                {
                    Values = _chartValues2,
                    GeometryStroke = null,
                    GeometryFill = null,
                    DataPadding = new(0, 1)
                }
            };

            CurrentSeries = Series1; // Изначально выбран первый график

            Task.Run(PollRegistersAsync); // Стартуем асинхронный опрос в конструкторе
        }

        public ISeries[] Series1 { get; set; }
        public ISeries[] Series2 { get; set; }

        public Axis[] XAxes { get; set; } = new Axis[]
        {
            new Axis
            {
                MinStep = 1,
                Labeler = value => value.ToString(),
                MinLimit = 0,
                MaxLimit = 100, // Задаем количество точек на экране
                UnitWidth = 1, // Ширина одного шага
                IsVisible = true
            }
        };

        public Axis[] YAxes { get; set; } = new Axis[]
        {
            new Axis
            {
                MinStep = 1,
                Labeler = value => value.ToString(),
                MinLimit = 0,
                MaxLimit = 300, // Задаем количество точек на экране
                UnitWidth = 1, // Ширина одного шага
                IsVisible = true
            }
        };

        private async Task PollRegistersAsync()
        {
            int timeIndex = 0;

            while (true)
            {
                try
                {
                    // Чтение регистров через singleton-экземпляр ModbusTcpCommunication
                    ushort[] registers1 = await ModbusTcpCommunication.Instance.ReadInputRegistersAsync(2, 5); // Slave ID и адрес
                    ushort[] registers2 = await ModbusTcpCommunication.Instance.ReadInputRegistersAsync(2, 6); // Slave ID и адрес

                    // Обновляем значения в ViewModel
                    Porog1 = registers1[0]; // Первый регистр
                    Porog2 = registers2[0]; // Второй регистр

                    // Выводим считанные значения в консоль для отладки
                    Console.WriteLine($"Porog1: {Porog1}, Porog2: {Porog2}");

                    // Обновляем данные для графиков
                    _chartValues1.Add(new ObservablePoint(timeIndex++, Porog1)); // Данные для первого графика
                    _chartValues2.Add(new ObservablePoint(timeIndex++, Porog2)); // Данные для второго графика

                    // Ограничиваем количество точек на графиках
                    if (_chartValues1.Count > 100)
                    {
                        _chartValues1.RemoveAt(0);
                    }
                    if (_chartValues2.Count > 100)
                    {
                        _chartValues2.RemoveAt(0);
                    }

                    // Увеличиваем диапазон видимости оси X
                    XAxes[0].MinLimit = timeIndex > 100 ? timeIndex - 100 : 0;
                    XAxes[0].MaxLimit = 30;


                }
                catch (Exception ex)
                {
                    // Обработка ошибок Modbus/TCP
                    Console.WriteLine($"Ошибка при чтении регистров Modbus: {ex.Message}");
                }

                await Task.Delay(1000); // Ожидание перед следующим опросом
            }
        }

        // Метод для переключения графиков
        [RelayCommand]
        public void SwitchChart(int chartNumber)
        {
            if (chartNumber == 1)
            {
                CurrentSeries = Series1;
            }
            else if (chartNumber == 2)
            {
                CurrentSeries = Series2;
            }
        }
    }
}
