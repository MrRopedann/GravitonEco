using GravitonEco.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEco.Model
{
    internal class DateTimeUpdater
    {
        private System.Threading.Timer timer;
        private string _host;
        private string _port;
        private ModbusTCPClient _client;

        // Температура в измерителе
        public event Action<string> OnCurrentDateTimeInSensorUpdate;

        public DateTimeUpdater()
        {
            timer = new System.Threading.Timer(UpdateData, null, Timeout.Infinite, Timeout.Infinite);
        }

        public void StartUpdatingData(int interval)
        {
            timer.Change(TimeSpan.Zero, TimeSpan.FromSeconds(interval));
        }

        private void UpdateData(object state)
        {
            INIManager manager = new INIManager(@"./Config/setting_device_connection.ini");
            _host = manager.GetPrivateString("DeviceConnectSetting", "Host");
            _port = manager.GetPrivateString("DeviceConnectSetting", "Port");
            _client = new ModbusTCPClient(_host, Int32.Parse(_port));
            string _year = _client.ReadHoldingParametrdate(251, 262).Split('-')[0];
            string _moths = _client.ReadHoldingParametrdate(251, 261).Split('-')[0];
            string _day = _client.ReadHoldingParametrdate(251, 260).Split('-')[0];
            string _hour = _client.ReadHoldingParametrdate(251, 258).Split('-')[0];
            string _minute = _client.ReadHoldingParametrdate(251, 257).Split('-')[0];
            string dateSensor = _day + "." + _moths + "." + _year + " " + _hour + ":" + _minute;

            // Температура воздуха
            int currentAirTemperature = Int32.Parse(_client.ReadInputParametr(2, 5));

            // Дата/Время в измерителе
            OnCurrentDateTimeInSensorUpdate?.Invoke(dateSensor);
        }
    }
}
