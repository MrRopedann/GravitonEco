using CommunityToolkit.Mvvm.ComponentModel;
using GravitonEco.Managers;
using System;

namespace GravitonEco.ViewModels
{
    public partial class ModbusViewModel : ObservableObject
    {
        [ObservableProperty]
        private string connectionImage;

        private const string GreenConnectionImage = "/Views/Resources/mobile_connection_green.png";
        private const string RedConnectionImage = "/Views/Resources/mobile_connection_red.png";

        private readonly ModbusTCPClient modbusClient;

        public ModbusViewModel()
        {
            modbusClient = ModbusTCPClient.Instance;
            ConnectionImage = RedConnectionImage; // Установите изображение по умолчанию

            // Подписка на изменения состояния подключения
            modbusClient.Subscribe(isConnected =>
            {
                ConnectionImage = isConnected ? GreenConnectionImage : RedConnectionImage;
            });
        }
    }
}
