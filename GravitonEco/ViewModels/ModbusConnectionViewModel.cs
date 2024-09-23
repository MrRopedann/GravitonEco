using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GravitonEco.Managers;
using GravitonEco.Models;
using System.Net.Sockets;
using System.Windows;

namespace GravitonEco.ViewModels
{
    public partial class ModbusConnectionViewModel : ObservableObject
    {
        private DeviceConfig _deviceConfig;

        public ModbusConnectionViewModel()
        {
            _deviceConfig = ConfigManager.LoadConfig();
        }

        public string IpAddress
        {
            get => _deviceConfig.IpAddress;
            set
            {
                _deviceConfig.IpAddress = value;
                OnPropertyChanged();
            }
        }

        public int Port
        {
            get => _deviceConfig.Port;
            set
            {
                _deviceConfig.Port = value;
                OnPropertyChanged();
            }
        }

        [RelayCommand]
        public void SaveSettings()
        {
            ConfigManager.SaveConfig(_deviceConfig);
        }

        [RelayCommand]
        public void LoadSettings()
        {
            ConfigManager.LoadConfig();
        }

        [RelayCommand]
        public void CheckConnection()
        {
            try
            {
                using (TcpClient tcpClient = new TcpClient())
                {
                    // Устанавливаем таймаут на подключение (например, 5 секунд)
                    var result = tcpClient.BeginConnect(IpAddress, Port, null, null);
                    bool success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5));

                    if (!success)
                    {
                        MessageBox.Show("Таймаут подключения!");
                        return;
                    }

                    tcpClient.EndConnect(result);

                    if (tcpClient.Connected)
                    {
                        MessageBox.Show("Подключение успешно!");
                    }
                    else
                    {
                        MessageBox.Show("Сбой подключения!");
                    }
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неожиданная ошибка: {ex.Message}");
            }
        }

    }
}
