using GravitonEco.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEco.Model
{
    internal class DataSensorUpdate
    {
        private readonly Label[] labels;
        private System.Threading.Timer[] timers;
        private string _host;
        private string _port;
        private ModbusTCPClient _client;
        

        public DataSensorUpdate(Label[] labels)
        {
            this.labels = labels;
            this.timers = new System.Threading.Timer[labels.Length];

            // Создаем таймеры для каждого элемента Label
            for (int i = 0; i < labels.Length; i++)
            {
                int index = i; // Чтобы захватить значение i в замыкании, создадим локальную переменную index
                timers[i] = new System.Threading.Timer(state => UpdateLabel(index), null, 0, 1000);
            }
        }

        private void UpdateLabel(int index)
        {
            INIManager manager = new INIManager(@"./Config/setting_device_connection.ini");
            _host = manager.GetPrivateString("DeviceConnectSetting", "Host");
            _port = manager.GetPrivateString("DeviceConnectSetting", "Port");
            _client = new ModbusTCPClient(_host, Int32.Parse(_port));

            // Температура воздуха
            UpdateLabelOnMainThread(0, _client.ReadInputParametr(2, 5));
            // Относительная влажность
            UpdateLabelOnMainThread(1, _client.ReadInputParametr(2, 6));
            // Атмосферное давление
            UpdateLabelOnMainThread(2, _client.ReadInputParametr(1, 1));
            // Скорость ветра
            UpdateLabelOnMainThread(3, _client.ReadInputParametr(1, 7));
            //Направление ветра
            UpdateLabelOnMainThread(4, _client.ReadInputParametr(2, 2));
            //Оксид углерода (СО)
            UpdateLabelOnMainThread(5, _client.ReadInputParametr(1, 10));
            //Оксид азота (NO)
            UpdateLabelOnMainThread(6, _client.ReadInputParametr(1, 12));
            //Диоксид азота (NO2)
            UpdateLabelOnMainThread(7, _client.ReadInputParametr(1, 13));
            //Диоксид серы (SO2)
            UpdateLabelOnMainThread(8, _client.ReadInputParametr(1, 19));
            //Двуокись углерода (СО2)
            UpdateLabelOnMainThread(9, _client.ReadInputParametr(1, 11));
            //Летучая органика
            UpdateLabelOnMainThread(10, _client.ReadInputParametr(1,8));
            //Твёрдые частицы PM1
            UpdateLabelOnMainThread(11, _client.ReadInputParametr(1, 16));
            //Твёрдые частицы PM2.5
            UpdateLabelOnMainThread(12, _client.ReadInputParametr(1, 17));
            //Твёрдые частицы PM10
            UpdateLabelOnMainThread(13, _client.ReadInputParametr(1, 18));
            //Уровень вибрации
            UpdateLabelOnMainThread(14, _client.ReadInputParametr(1, 21));
            //Уровень наклона
            UpdateLabelOnMainThread(15, _client.ReadInputParametr(1, 20));
            //Датчик вскрытия
            UpdateLabelOnMainThread(16, _client.ReadInputParametr(3, 2));
            //Температура в измерителе
            UpdateLabelOnMainThread(17, _client.ReadInputParametr(1, 5));
            //Влажность в измерителе
            UpdateLabelOnMainThread(18, _client.ReadInputParametr(1, 6));
            //Давление в измерителе
            UpdateLabelOnMainThread(19, _client.ReadInputParametr(2, 1));
            //Скорость пробоотбора
            UpdateLabelOnMainThread(20, _client.ReadInputParametr(3, 25));
            //Напряжение питания
            UpdateLabelOnMainThread(21, _client.ReadInputParametr(1, 2));
            /*Настройки*/
            // Температура воздуха
            UpdateLabelOnMainThread(22, _client.ReadInputParametr(2, 5));
            // Относительная влажность
            UpdateLabelOnMainThread(23, _client.ReadInputParametr(2, 6));
            // Атмосферное давление
            UpdateLabelOnMainThread(24, _client.ReadInputParametr(1, 1));
            // Скорость ветра
            UpdateLabelOnMainThread(25, _client.ReadInputParametr(1, 7));
            //Оксид углерода (СО)
            UpdateLabelOnMainThread(26, _client.ReadInputParametr(1, 10));
            //Оксид азота (NO)
            UpdateLabelOnMainThread(27, _client.ReadInputParametr(1, 12));
            //Диоксид азота (NO2)
            UpdateLabelOnMainThread(28, _client.ReadInputParametr(1, 13));
            //Диоксид серы (SO2)
            UpdateLabelOnMainThread(29, _client.ReadInputParametr(1, 19));
            //Двуокись углерода (СО2)
            UpdateLabelOnMainThread(30, _client.ReadInputParametr(1, 11));
            //Летучая органика
            UpdateLabelOnMainThread(31, _client.ReadInputParametr(1, 8));
        }

        private void UpdateLabelOnMainThread(int index, string text)
        {
            // Используем Invoke, чтобы обновление текста происходило в главном потоке
            labels[index].Invoke((Action)(() => labels[index].Text = text));
        }
    }
}
