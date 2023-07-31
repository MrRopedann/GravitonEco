using GravitonEco.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEco.Model
{
    public class DataUpdater
    {
        private System.Threading.Timer timer;
        private string _host;
        private string _port;
        private ModbusTCPClient _client;

        // Температура в измерителе
        public event Action<int> OnCurrentTemperatureInSensorUpdate;

        // Влажность в измерителе
        public event Action<int> OnCurrentHumidityInSensorUpdate;

        // Давление в измерителе
        public event Action<int> OnCurrentPressureInSensorUpdate;

        // Скорость пробоотбора
        public event Action<int> OnCurrentSamplingSpeedUpdate;

        // Напряжение питания
        public event Action<int> OnCurrentSupplyVoltageUpdate;

        // Температура воздуха
        public event Action<int> OnCurrentAirTemperatureUpdate;

        // Относительная влажность
        public event Action<int> OnCurrentRelativeHumidityUpdate;

        // Атмосферное давление
        public event Action<int> OnCurrentAtmosphericPressureUpdate;

        // Скорость ветра
        public event Action<int> OnCurrentWindSpeedUpdate;

        // Направление ветра
        public event Action<int> OnCurrentWindDirectionUpdate;

        // Оксид углерода (СО)
        public event Action<int> OnCurrentCarbonMonoxideUpdate;

        // Оксид азота (NO)
        public event Action<int> OnCurrentNitrogenOxideUpdate;

        // Диоксид азота (NO2)
        public event Action<int> OnCurrentNitrogenDioxideUpdate;

        // Диоксид серы (SO2)
        public event Action<int> OnCurrentSulfurDioxideUpdate;

        // Двуокись углерода (СО2)
        public event Action<int> OnCurrentCarbonDioxideUpdate;

        // Летучая органика
        public event Action<int> OnCurrentVolatileOrganicCompoundsUpdate;

        // Твёрдые частицы PM1
        public event Action<int> OnCurrentParticulateMatterPM1Update;

        // Твёрдые частицы PM2.5
        public event Action<int> OnCurrentParticulateMatterPM2_5Update;

        // Твёрдые частицы PM10
        public event Action<int> OnCurrentParticulateMatterPM10Update;

        // Уровень вибрации
        public event Action<int> OnCurrentVibrationLevelUpdate;

        // Уровень наклона
        public event Action<int> OnCurrentTiltLevelUpdate;

        // Датчик вскрытия
        public event Action<int> OnCurrentTamperSensorUpdate;

        public DataUpdater()
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

            // Температура воздуха
            int currentAirTemperature = Int32.Parse(_client.ReadInputParametr(2, 5));

            // Относительная влажность
            int currentRelativeHumidity = Int32.Parse(_client.ReadInputParametr(2, 6));

            // Атмосферное давление
            int currentAtmosphericPressure = Int32.Parse(_client.ReadInputParametr(1, 1));
            
            // Скорость ветра
            int currentWindSpeed = Int32.Parse(_client.ReadInputParametr(1, 7));

            // Направление ветра
            int currentWindDirection = Int32.Parse(_client.ReadInputParametr(2, 2));

            // Оксид углерода (СО)
            int currentCarbonMonoxide = Int32.Parse(_client.ReadInputParametr(1, 10));

            // Оксид азота (NO)
            int currentNitrogenOxide = Int32.Parse(_client.ReadInputParametr(1, 12));

            // Диоксид азота (NO2)
            int currentNitrogenDioxide = Int32.Parse(_client.ReadInputParametr(1, 13));

            // Диоксид серы (SO2)
            int currentSulfurDioxide = Int32.Parse(_client.ReadInputParametr(1, 19));

            // Двуокись углерода (СО2)
            int currentCarbonDioxide = Int32.Parse(_client.ReadInputParametr(1, 11));

            // Летучая органика
            int currentVolatileOrganicCompounds = Int32.Parse(_client.ReadInputParametr(1, 8));

            // Твёрдые частицы PM1
            int currentParticulateMatterPM1 = Int32.Parse(_client.ReadInputParametr(1, 16));

            // Твёрдые частицы PM2.5
            int currentParticulateMatterPM2_5 = Int32.Parse(_client.ReadInputParametr(1, 17));

            // Твёрдые частицы PM10
            int currentParticulateMatterPM10 = Int32.Parse(_client.ReadInputParametr(1, 18));

            // Уровень вибрации
            int currentVibrationLevel = Int32.Parse(_client.ReadInputParametr(1, 21));

            // Уровень наклона
            int currentTiltLevel = Int32.Parse(_client.ReadInputParametr(1, 20));

            // Датчик вскрытия
            int currentTamperSensor = Int32.Parse(_client.ReadInputParametr(3, 2));

            // Температура в измерителе
            int currentTemperatureInSensor = Int32.Parse(_client.ReadInputParametr(1, 5));

            // Влажность в измерителе
            int currentHumidityInSensor = Int32.Parse(_client.ReadInputParametr(1, 6));

            // Давление в измерителе
            int currentPressureInSensor = Int32.Parse(_client.ReadInputParametr(2, 1));

            // Скорость пробоотбора
            int currentSamplingSpeed = Int32.Parse(_client.ReadInputParametr(3, 25));

            // Напряжение питания
            int currentSupplyVoltage = Int32.Parse(_client.ReadInputParametr(1, 2));

            // Температура в измерителе
            OnCurrentTemperatureInSensorUpdate?.Invoke(currentTemperatureInSensor);

            // Влажность в измерителе
            OnCurrentHumidityInSensorUpdate?.Invoke(currentHumidityInSensor);

            // Давление в измерителе
            OnCurrentPressureInSensorUpdate?.Invoke(currentPressureInSensor);

            // Скорость пробоотбора
            OnCurrentSamplingSpeedUpdate?.Invoke(currentSamplingSpeed);

            // Напряжение питания
            OnCurrentSupplyVoltageUpdate?.Invoke(currentSupplyVoltage);

            // Температура воздуха
            OnCurrentAirTemperatureUpdate?.Invoke(currentAirTemperature);

            // Относительная влажность
            OnCurrentRelativeHumidityUpdate?.Invoke(currentRelativeHumidity);

            // Атмосферное давление
            OnCurrentAtmosphericPressureUpdate?.Invoke(currentAtmosphericPressure);

            // Скорость ветра
            OnCurrentWindSpeedUpdate?.Invoke(currentWindSpeed);

            // Направление ветра
            OnCurrentWindDirectionUpdate?.Invoke(currentWindDirection);

            // Оксид углерода (СО)
            OnCurrentCarbonMonoxideUpdate?.Invoke(currentCarbonMonoxide);

            // Оксид азота (NO)
            OnCurrentNitrogenOxideUpdate?.Invoke(currentNitrogenOxide);

            // Диоксид азота (NO2)
            OnCurrentNitrogenDioxideUpdate?.Invoke(currentNitrogenDioxide);

            // Диоксид серы (SO2)
            OnCurrentSulfurDioxideUpdate?.Invoke(currentSulfurDioxide);

            // Двуокись углерода (СО2)
            OnCurrentCarbonDioxideUpdate?.Invoke(currentCarbonDioxide);

            // Летучая органика
            OnCurrentVolatileOrganicCompoundsUpdate?.Invoke(currentVolatileOrganicCompounds);

            // Твёрдые частицы PM1
            OnCurrentParticulateMatterPM1Update?.Invoke(currentParticulateMatterPM1);

            // Твёрдые частицы PM2.5
            OnCurrentParticulateMatterPM2_5Update?.Invoke(currentParticulateMatterPM2_5);

            // Твёрдые частицы PM10
            OnCurrentParticulateMatterPM10Update?.Invoke(currentParticulateMatterPM10);

            // Уровень вибрации
            OnCurrentVibrationLevelUpdate?.Invoke(currentVibrationLevel);

            // Уровень наклона
            OnCurrentTiltLevelUpdate?.Invoke(currentTiltLevel);

            // Датчик вскрытия
            OnCurrentTamperSensorUpdate?.Invoke(currentTamperSensor);
        }
    }
}
