using CommunityToolkit.Mvvm.ComponentModel;
using GravitonEco.Services;
using System;
using System.Threading.Tasks;

namespace GravitonEco.ViewModels
{
    public partial class ModbusViewModel : ObservableObject
    {
        // Пути к изображениям
        private const string GreenConnectionImage = "/Views/Resources/mobile_connection_green.png";
        private const string RedConnectionImage = "/Views/Resources/mobile_connection_red.png";

        // Поле, которое будет содержать путь к изображению подключения
        [ObservableProperty]
        private string connectionImage;

        private readonly ModbusTcpClient _modbusClient;

        // Конструктор
        public ModbusViewModel()
        {
            // Установка изображения по умолчанию на "красное" (нет соединения)
            ConnectionImage = RedConnectionImage;

            // Инициализация клиента Modbus
            _modbusClient = ModbusTcpClient.GetInstance();

            // Запускаем периодическую проверку соединения
            StartConnectionMonitoring();
        }

        // Метод для мониторинга состояния соединения
        private async void StartConnectionMonitoring()
        {
            while (true)
            {
                await Task.Delay(5000); // Проверяем соединение каждые 5 секунд
                await UpdateConnectionImage(); // Вызываем метод обновления изображения
            }
        }

        // Метод для обновления состояния подключения
        private async Task UpdateConnectionImage()
        {
            try
            {
                // Проверяем соединение и обновляем изображение
                bool isConnected = await _modbusClient.ConnectAsync();
                ConnectionImage = isConnected ? GreenConnectionImage : RedConnectionImage;
            }
            catch (Exception ex)
            {
                // В случае ошибки показываем красное изображение
                ConnectionImage = RedConnectionImage;
                Console.WriteLine($"Ошибка подключения: {ex.Message}");
            }
        }
    }
}
