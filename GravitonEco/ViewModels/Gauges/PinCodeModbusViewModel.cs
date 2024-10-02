using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GravitonEco.Services;
using System.Threading.Tasks;
using System.Windows;

namespace GravitonEco.ViewModels.Gauges
{
    public partial class PinCodeModbusViewModel : ObservableObject
    {
        private readonly ModbusTcpClient _modbusTcp;

        [ObservableProperty]
        private bool _passwordCorrect;

        [ObservableProperty]
        private string _password;
        
        [ObservableProperty]
        private string _storedPinCode;

        [ObservableProperty]
        private string _passwordImageSource = "/Views/Resources/password_red.png"; // Изначально изображение красного пароля

        public PinCodeModbusViewModel()
        {
            _modbusTcp = ModbusTcpClient.GetInstance();
        }

        // Команда для проверки пинкода
        [RelayCommand]
        public async void CheckPinCode()
        {
            await _modbusTcp.ConnectAsync();

            // Читаем первый блок пинкода (первые 4 цифры)
            var firstPart = await _modbusTcp.ReadHoldingRegistersAsync(1, 530);
            // Читаем второй блок пинкода (вторые 4 цифры)
            var secondPart = await _modbusTcp.ReadHoldingRegistersAsync(1, 531);

            if (firstPart != null && secondPart != null)
            {
                // Объединяем оба блока пинкода в одну строку
                StoredPinCode = firstPart[0].ToString("D4") + secondPart[0].ToString("D4");

                // Сравниваем введённый пинкод с хранимым
                PasswordCorrect = Password == StoredPinCode;

                // Меняем изображение в зависимости от правильности пинкода
                PasswordImageSource = PasswordCorrect
                    ? "/Views/Resources/password_green.png"
                    : "/Views/Resources/password_red.png";
            }
            else
            {
                MessageBox.Show("Ошибка чтения пинкода с устройства Modbus.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Password = string.Empty;
        }
    }
}
