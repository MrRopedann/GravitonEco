using GravitonEco.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEco.Model
{
    public class TextBoxUpdater
    {
        private TextBox[] textBoxes;
        private System.Threading.Timer[] timers;
        private string _host;
        private string _port;
        private ModbusTCPClient _client;

        public TextBoxUpdater(TextBox[] textBoxes)
        {
            this.textBoxes = textBoxes;
            this.timers = new System.Threading.Timer[textBoxes.Length];

            // Создаем таймеры для каждого элемента TextBox
            for (int i = 0; i < textBoxes.Length; i++)
            {
                int index = i; // Чтобы захватить значение i в замыкании, создадим локальную переменную index
                timers[i] = new System.Threading.Timer(state => UpdateTextBox(index), null, 0, 1000);
            }
        }

        private void UpdateTextBox(int index)
        {
            INIManager manager = new INIManager(@"./Config/setting_device_connection.ini");
            _host = manager.GetPrivateString("DeviceConnectSetting", "Host");
            _port = manager.GetPrivateString("DeviceConnectSetting", "Port");
            _client = new ModbusTCPClient(_host, Int32.Parse(_port));

            UpdateTextBoxOnMainThread(0, _client.ReadCoilParametr(2, 15)); // Темпиратура Порог 1
            UpdateTextBoxOnMainThread(1, _client.ReadCoilParametr(2, 16)); // Темпиратура Порог 2
            UpdateTextBoxOnMainThread(2, _client.ReadCoilParametr(2, 17)); // Темпиратура dx
            UpdateTextBoxOnMainThread(3, _client.ReadCoilParametr(2, 17)); // Темпиратура dt
            UpdateTextBoxOnMainThread(4, _client.ReadCoilParametr(2, 18)); // влажность порог 1
            UpdateTextBoxOnMainThread(5, _client.ReadCoilParametr(2, 19)); // влажность порог 2
            UpdateTextBoxOnMainThread(6, _client.ReadCoilParametr(2, 20)); // влажность дх
            UpdateTextBoxOnMainThread(7, _client.ReadCoilParametr(2, 20)); // влажность дт
            UpdateTextBoxOnMainThread(8, _client.ReadCoilParametr(2, 3)); // Давление порог 1
            UpdateTextBoxOnMainThread(9, _client.ReadCoilParametr(2, 4)); // Давление порог 2
            UpdateTextBoxOnMainThread(10, _client.ReadCoilParametr(2, 5)); // Давление дх
            UpdateTextBoxOnMainThread(11, _client.ReadCoilParametr(2, 5)); // Давление дт
            UpdateTextBoxOnMainThread(12, _client.ReadCoilParametr(2, 21)); //Скорость ветра порог 1
            UpdateTextBoxOnMainThread(13, _client.ReadCoilParametr(2, 22)); //Скорость ветра порог 2
            UpdateTextBoxOnMainThread(14, _client.ReadCoilParametr(2, 23)); //Скорость ветра дх
            UpdateTextBoxOnMainThread(15, _client.ReadCoilParametr(2, 23)); //Скорость ветра дт
            UpdateTextBoxOnMainThread(16, _client.ReadCoilParametr(2, 6)); // Направление ветра порог 1
            UpdateTextBoxOnMainThread(17, _client.ReadCoilParametr(2, 7)); // Направление ветра порог 2
            UpdateTextBoxOnMainThread(18, _client.ReadCoilParametr(2, 8)); // Направление ветра дт
            UpdateTextBoxOnMainThread(19, _client.ReadCoilParametr(2, 8)); // Направление ветра дх
            UpdateTextBoxOnMainThread(20, _client.ReadCoilParametr(1, 30)); // СО порог 1
            UpdateTextBoxOnMainThread(21, _client.ReadCoilParametr(1, 31)); // СО порог 2
            UpdateTextBoxOnMainThread(22, _client.ReadCoilParametr(1, 32)); // СО дт
            UpdateTextBoxOnMainThread(23, _client.ReadCoilParametr(1, 32)); // СО дх
            UpdateTextBoxOnMainThread(24, _client.ReadCoilParametr(1, 36)); // NO порог 1
            UpdateTextBoxOnMainThread(25, _client.ReadCoilParametr(1, 37)); // NO порог 2
            UpdateTextBoxOnMainThread(26, _client.ReadCoilParametr(1, 38)); // NO дт
            UpdateTextBoxOnMainThread(27, _client.ReadCoilParametr(1, 38)); // NO дх
            UpdateTextBoxOnMainThread(28, _client.ReadCoilParametr(1, 39)); // NO2 порог 1
            UpdateTextBoxOnMainThread(29, _client.ReadCoilParametr(1, 40)); // NO2 порог 2
            UpdateTextBoxOnMainThread(30, _client.ReadCoilParametr(1, 41)); // NO2 дт
            UpdateTextBoxOnMainThread(31, _client.ReadCoilParametr(1, 41)); // NO2 дх
            UpdateTextBoxOnMainThread(32, _client.ReadCoilParametr(1, 57)); // SO2 порог 1
            UpdateTextBoxOnMainThread(33, _client.ReadCoilParametr(1, 58)); // SO2 порог 2
            UpdateTextBoxOnMainThread(34, _client.ReadCoilParametr(1, 59)); // SO2 дт
            UpdateTextBoxOnMainThread(35, _client.ReadCoilParametr(1, 59)); // SO2 дх
            UpdateTextBoxOnMainThread(36, _client.ReadCoilParametr(1, 33)); // СО2 порог 1
            UpdateTextBoxOnMainThread(37, _client.ReadCoilParametr(1, 34)); // СО2 порог 2
            UpdateTextBoxOnMainThread(38, _client.ReadCoilParametr(1, 35)); // СО2 дт
            UpdateTextBoxOnMainThread(39, _client.ReadCoilParametr(1, 35)); // СО2 дх
            UpdateTextBoxOnMainThread(40, _client.ReadCoilParametr(1, 24)); // ЛОС порог 1
            UpdateTextBoxOnMainThread(41, _client.ReadCoilParametr(1, 25)); // ЛОС порог 2
            UpdateTextBoxOnMainThread(42, _client.ReadCoilParametr(1, 26)); // ЛОС дт
            UpdateTextBoxOnMainThread(43, _client.ReadCoilParametr(1, 26)); // ЛОС дх
            UpdateTextBoxOnMainThread(44, _client.ReadCoilParametr(1, 48)); // ПМ1 порог 1
            UpdateTextBoxOnMainThread(45, _client.ReadCoilParametr(1, 49)); // ПМ1 порог 2
            UpdateTextBoxOnMainThread(46, _client.ReadCoilParametr(1, 50)); // ПМ1 дт
            UpdateTextBoxOnMainThread(47, _client.ReadCoilParametr(1, 50)); // ПМ1 дх
            UpdateTextBoxOnMainThread(48, _client.ReadCoilParametr(1, 51)); // ПМ2_5 порог 1
            UpdateTextBoxOnMainThread(49, _client.ReadCoilParametr(1, 52)); // ПМ2_5 порог 2
            UpdateTextBoxOnMainThread(50, _client.ReadCoilParametr(1, 53)); // ПМ2_5 дт
            UpdateTextBoxOnMainThread(51, _client.ReadCoilParametr(1, 53)); // ПМ2_5 дх
            UpdateTextBoxOnMainThread(52, _client.ReadCoilParametr(1, 54)); // ПМ10 порог 1
            UpdateTextBoxOnMainThread(53, _client.ReadCoilParametr(1, 55)); // ПМ10 порог 2
            UpdateTextBoxOnMainThread(54, _client.ReadCoilParametr(1, 56)); // ПМ10 дт
            UpdateTextBoxOnMainThread(55, _client.ReadCoilParametr(1, 56)); // ПМ10 дх
            UpdateTextBoxOnMainThread(56, _client.ReadCoilParametr(1, 63)); // Вибрация порог 1
            UpdateTextBoxOnMainThread(57, _client.ReadCoilParametr(1, 64)); // Вибрация порог 2
            UpdateTextBoxOnMainThread(58, _client.ReadCoilParametr(1, 64)); // Вибрация дт
            UpdateTextBoxOnMainThread(59, _client.ReadCoilParametr(1, 64)); // Вибрация дх
            UpdateTextBoxOnMainThread(60, _client.ReadCoilParametr(1, 60)); // Наклон порог 1
            UpdateTextBoxOnMainThread(61, _client.ReadCoilParametr(1, 61)); // Наклон порог 2
            UpdateTextBoxOnMainThread(62, _client.ReadCoilParametr(1, 62)); // Наклон дт
            UpdateTextBoxOnMainThread(61, _client.ReadCoilParametr(1, 62)); // Наклон дх
            UpdateTextBoxOnMainThread(62, _client.ReadCoilParametr(3, 6)); // вскрытие порог 1
            UpdateTextBoxOnMainThread(63, _client.ReadCoilParametr(3, 7)); // вскрытие порог 2
            UpdateTextBoxOnMainThread(64, _client.ReadCoilParametr(3, 8)); // вскрытие дт
            UpdateTextBoxOnMainThread(65, _client.ReadCoilParametr(3, 8)); // вскрытие дх
            UpdateTextBoxOnMainThread(66, _client.ReadCoilParametr(1, 15)); // Темпиратура измерителя порог 1
            UpdateTextBoxOnMainThread(67, _client.ReadCoilParametr(1, 16)); // Темпиратура измерителя порог 2
            UpdateTextBoxOnMainThread(68, _client.ReadCoilParametr(1, 17)); // Темпиратура измерителя дт
            UpdateTextBoxOnMainThread(69, _client.ReadCoilParametr(1, 17)); // Темпиратура измерителя дх
            UpdateTextBoxOnMainThread(70, _client.ReadCoilParametr(1, 18)); // Влажность измерителя порог 1
            UpdateTextBoxOnMainThread(71, _client.ReadCoilParametr(1, 19)); // Влажность измерителя порог 2
            UpdateTextBoxOnMainThread(72, _client.ReadCoilParametr(1, 20)); // Влажность измерителя дт
            UpdateTextBoxOnMainThread(73, _client.ReadCoilParametr(1, 20)); // Влажность измерителя дх
            UpdateTextBoxOnMainThread(74, _client.ReadCoilParametr(1, 3)); // Давление измерителя порог 1
            UpdateTextBoxOnMainThread(75, _client.ReadCoilParametr(1, 4)); // Давление измерителя порог 2
            UpdateTextBoxOnMainThread(76, _client.ReadCoilParametr(1, 5)); // Давление измерителя дт
            UpdateTextBoxOnMainThread(77, _client.ReadCoilParametr(1, 5)); // Давление измерителя дх
            UpdateTextBoxOnMainThread(78, _client.ReadCoilParametr(1, 6)); // Напряжение порог 1
            UpdateTextBoxOnMainThread(79, _client.ReadCoilParametr(1, 7)); // Напряжение порог 2
            UpdateTextBoxOnMainThread(80, _client.ReadCoilParametr(1, 8)); // Напряжение дт
            UpdateTextBoxOnMainThread(81, _client.ReadCoilParametr(1, 8)); // Напряжение дх
        }

        private void UpdateTextBoxOnMainThread(int index, string valueFromDevice)
        {
            // Используем Invoke, чтобы обновление цвета текста происходило в главном потоке
            textBoxes[index].Invoke((Action)(() => UpdateTextBoxColor(textBoxes[index], valueFromDevice)));
        }

        private void UpdateTextBoxColor(TextBox textBox, string valueFromDevice)
        {
            textBox.ForeColor = Boolean.Parse(valueFromDevice) ? Color.Red : Color.White;
        }

    }

}
