using CommunityToolkit.Mvvm.ComponentModel;
using GravitonEco.Managers;
using GravitonEco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEco.ViewModels
{
    public partial class ModbusViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _connectionImage;

        private DeviceConfig _deviceConfig;

        private const string GreenConnectionImage = "/Views/Resources/mobile_connection_green.png";
        private const string RedConnectionImage = "/Views/Resources/mobile_connection_red.png";

        public ModbusViewModel()
        {
            // Установите изображение по умолчанию
            ConnectionImage = RedConnectionImage;
            _deviceConfig = ConfigManager.LoadConfig();
            // Запустите проверку подключения
            CheckConnection();
        }

        private async void CheckConnection()
        {
            while (true)
            {
                bool isConnected = await IsDeviceAvailableAsync(_deviceConfig.IpAddress, _deviceConfig.Port); // Укажите IP и порт вашего устройства
                ConnectionImage = isConnected ? GreenConnectionImage : RedConnectionImage;
                await Task.Delay(5000); // Проверяйте каждые 5 секунд
            }
        }

        private async Task<bool> IsDeviceAvailableAsync(string ipAddress, int port)
        {
            try
            {
                using (var client = new TcpClient())
                {
                    await client.ConnectAsync(ipAddress, port);
                    return true; // Успех подключения
                }
            }
            catch
            {
                return false; // Ошибка подключения
            }
        }

    }
}