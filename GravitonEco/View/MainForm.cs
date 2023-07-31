using GravitonEco.Controller;
using GravitonEco.Model;
using GravitonEco.View;

namespace GravitonEco
{
    public partial class MainForm : Form
    {
        private DateTimeUpdater dataTimeUpdater;
        private DataUpdater dataUpdater;
        private string _host;
        private string _port;
        private ModbusTCPClient _client;

        public MainForm()
        {
            InitializeComponent();
            INIManager manager = new INIManager(@"./Config/setting_device_connection.ini");
            _host = manager.GetPrivateString("DeviceConnectSetting", "Host");
            _port = manager.GetPrivateString("DeviceConnectSetting", "Port");
            _client = new ModbusTCPClient(_host, Int32.Parse(_port));
            apparatVersion.Text = _client.ReadInputParametr(251, 65284);
            softVersion.Text = _client.ReadInputParametr(251, 65285);
            serialNumber.Text = _client.ReadInputParametr(251, 65280) + "-" + _client.ReadInputParametr(251, 65281);
            dataTimeUpdater = new DateTimeUpdater();

            dataTimeUpdater.OnCurrentDateTimeInSensorUpdate += UpdateCurrentDateTimeInSensorLabel;

            dataUpdater = new DataUpdater();

            porog_1_AirTemperature.Text = _client.ReadHoldingParametr(2, 20);
            porog_2_AirTemperature.Text = _client.ReadHoldingParametr(2, 21);
            dx_AirTemperature.Text = _client.ReadHoldingParametr(2, 22);
            dt_AirTemperature.Text = _client.ReadHoldingParametr(2, 23);

            porog_1_RelativeHumidity.Text = _client.ReadHoldingParametr(2, 24);
            porog_2_RelativeHumidity.Text = _client.ReadHoldingParametr(2, 25);
            dx_RelativeHumidity.Text = _client.ReadHoldingParametr(2, 26);
            dt_RelativeHumidity.Text = _client.ReadHoldingParametr(2, 27);

            porog_1_AtmosphericPressure.Text = _client.ReadHoldingParametr(2, 4);
            porog_2_AtmosphericPressure.Text = _client.ReadHoldingParametr(2, 5);
            dx_AtmosphericPressure.Text = _client.ReadHoldingParametr(2, 6);
            dt_AtmosphericPressure.Text = _client.ReadHoldingParametr(2, 7);

            porog_1_WindSpeed.Text = _client.ReadHoldingParametr(1, 28);
            porog_2_WindSpeed.Text = _client.ReadHoldingParametr(1, 29);
            dx_WindSpeed.Text = _client.ReadHoldingParametr(1, 30);
            dt_WindSpeed.Text = _client.ReadHoldingParametr(1, 31);

            porog_1_WindDirection.Text = _client.ReadHoldingParametr(2, 8);
            porog_2_WindDirection.Text = _client.ReadHoldingParametr(2, 9);
            dx_WindDirection.Text = _client.ReadHoldingParametr(2, 10);
            dt_WindDirection.Text = _client.ReadHoldingParametr(2, 11);

            porog_1_CarbonMonoxide.Text = _client.ReadHoldingParametr(1, 40);
            porog_2_CarbonMonoxide.Text = _client.ReadHoldingParametr(1, 41);
            dt_CarbonMonoxide.Text = _client.ReadHoldingParametr(1, 42);
            dx_CarbonMonoxide.Text = _client.ReadHoldingParametr(1, 43);

            porog_1_NitrogenOxide.Text = _client.ReadHoldingParametr(1, 48);
            porog_2_NitrogenOxide.Text = _client.ReadHoldingParametr(1, 49);
            dx_NitrogenOxide.Text = _client.ReadHoldingParametr(1, 50);
            dt_NitrogenOxide.Text = _client.ReadHoldingParametr(1, 51);

            porog_1_NitrogenDioxide.Text = _client.ReadHoldingParametr(1, 52);
            porog_2_NitrogenDioxide.Text = _client.ReadHoldingParametr(1, 53);
            dx_NitrogenDioxide.Text = _client.ReadHoldingParametr(1, 54);
            dt_NitrogenDioxide.Text = _client.ReadHoldingParametr(1, 55);

            porog_1_SulfurDioxide.Text = _client.ReadHoldingParametr(1, 76);
            porog_2_SulfurDioxide.Text = _client.ReadHoldingParametr(1, 77);
            dx_SulfurDioxide.Text = _client.ReadHoldingParametr(1, 78);
            dt_SulfurDioxide.Text = _client.ReadHoldingParametr(1, 79);

            porog_1_CarbonDioxide.Text = _client.ReadHoldingParametr(1, 44);
            porog_2_CarbonDioxide.Text = _client.ReadHoldingParametr(1, 45);
            dx_CarbonDioxide.Text = _client.ReadHoldingParametr(1, 46);
            dt_CarbonDioxide.Text = _client.ReadHoldingParametr(1, 47);

            porog_1_VolatileOrganicCompounds.Text = _client.ReadHoldingParametr(1, 32);
            porog_2_VolatileOrganicCompounds.Text = _client.ReadHoldingParametr(1, 33);
            dx_VolatileOrganicCompounds.Text = _client.ReadHoldingParametr(1, 34);
            dt_VolatileOrganicCompounds.Text = _client.ReadHoldingParametr(1, 35);

            porog_1_ParticulateMatterPM1.Text = _client.ReadHoldingParametr(2, 64);
            porog_2_ParticulateMatterPM1.Text = _client.ReadHoldingParametr(2, 65);
            dx_ParticulateMatterPM1.Text = _client.ReadHoldingParametr(2, 66);
            dt_ParticulateMatterPM1.Text = _client.ReadHoldingParametr(2, 67);

            porog_1_ParticulateMatterPM2_5.Text = _client.ReadHoldingParametr(2, 68);
            porog_2_ParticulateMatterPM2_5.Text = _client.ReadHoldingParametr(2, 69);
            dx_ParticulateMatterPM2_5.Text = _client.ReadHoldingParametr(2, 70);
            dt_ParticulateMatterPM2_5.Text = _client.ReadHoldingParametr(2, 71);

            porog_1_ParticulateMatterPM10.Text = _client.ReadHoldingParametr(2, 72);
            porog_2_ParticulateMatterPM10.Text = _client.ReadHoldingParametr(2, 73);
            dx_ParticulateMatterPM10.Text = _client.ReadHoldingParametr(2, 74);
            dt_ParticulateMatterPM10.Text = _client.ReadHoldingParametr(2, 75);

            porog_1_VibrationLevel.Text = _client.ReadHoldingParametr(1, 84);
            porog_2_VibrationLevel.Text = _client.ReadHoldingParametr(1, 85);
            dx_VibrationLevel.Text = _client.ReadHoldingParametr(1, 86);
            dt_VibrationLevel.Text = _client.ReadHoldingParametr(1, 87);

            porog_1_TiltLevel.Text = _client.ReadHoldingParametr(1, 80);
            porog_2_TiltLevel.Text = _client.ReadHoldingParametr(1, 81);
            dx_TiltLevel.Text = _client.ReadHoldingParametr(1, 82);
            dt_TiltLevel.Text = _client.ReadHoldingParametr(1, 83);

            porog_1_TamperSensor.Text = _client.ReadHoldingParametr(3, 8);
            porog_2_TamperSensor.Text = _client.ReadHoldingParametr(3, 9);
            dx_TamperSensor.Text = _client.ReadHoldingParametr(3, 10);
            dt_TamperSensor.Text = _client.ReadHoldingParametr(3, 11);

            porog_1_TemperatureInSensor.Text = _client.ReadHoldingParametr(1, 20);
            porog_2_TemperatureInSensor.Text = _client.ReadHoldingParametr(1, 21);
            dx_TemperatureInSensor.Text = _client.ReadHoldingParametr(1, 22);
            dt_TemperatureInSensor.Text = _client.ReadHoldingParametr(1, 23);

            porog_1_HumidityInSensor.Text = _client.ReadHoldingParametr(1, 24);
            porog_2_HumidityInSensor.Text = _client.ReadHoldingParametr(1, 25);
            dx_HumidityInSensor.Text = _client.ReadHoldingParametr(1, 26);
            dt_HumidityInSensor.Text = _client.ReadHoldingParametr(1, 27);

            porog_1_SupplyVoltage.Text = _client.ReadHoldingParametr(1, 8);
            porog_2_SupplyVoltage.Text = _client.ReadHoldingParametr(1, 9);
            dx_SupplyVoltage.Text = _client.ReadHoldingParametr(1, 10);
            dt_SupplyVoltage.Text = _client.ReadHoldingParametr(1, 11);

            porog_1_PressureInSensor.Text = _client.ReadHoldingParametr(1, 4);
            porog_2_PressureInSensor.Text = _client.ReadHoldingParametr(1, 5);
            dx_PressureInSensor.Text = _client.ReadHoldingParametr(1, 6);
            dt_PressureInSensor.Text = _client.ReadHoldingParametr(1, 7);


            // Температура в измерителе
            dataUpdater.OnCurrentTemperatureInSensorUpdate += UpdateCurrentTemperatureInSensorLabel;

            // Влажность в измерителе
            dataUpdater.OnCurrentHumidityInSensorUpdate += UpdateCurrentHumidityInSensorLabel;

            // Давление в измерителе
            dataUpdater.OnCurrentPressureInSensorUpdate += UpdateCurrentPressureInSensorLabel;

            // Скорость пробоотбора
            dataUpdater.OnCurrentSamplingSpeedUpdate += UpdateCurrentSamplingSpeedLabel;

            // Напряжение питания
            dataUpdater.OnCurrentSupplyVoltageUpdate += UpdateCurrentSupplyVoltageLabel;

            // Температура воздуха
            dataUpdater.OnCurrentAirTemperatureUpdate += UpdateCurrentAirTemperatureLabel;

            // Относительная влажность
            dataUpdater.OnCurrentRelativeHumidityUpdate += UpdateCurrentRelativeHumidityLabel;

            // Атмосферное давление
            dataUpdater.OnCurrentAtmosphericPressureUpdate += UpdateCurrentAtmosphericPressureLabel;

            // Скорость ветра
            dataUpdater.OnCurrentWindSpeedUpdate += UpdateCurrentWindSpeedLabel;

            // Направление ветра
            dataUpdater.OnCurrentWindDirectionUpdate += UpdateCurrentWindDirectionLabel;

            // Оксид углерода (СО)
            dataUpdater.OnCurrentCarbonMonoxideUpdate += UpdateCurrentCarbonMonoxideLabel;

            // Оксид азота (NO)
            dataUpdater.OnCurrentNitrogenOxideUpdate += UpdateCurrentNitrogenOxideLabel;

            // Диоксид азота (NO2)
            dataUpdater.OnCurrentNitrogenDioxideUpdate += UpdateCurrentNitrogenDioxideLabel;

            // Диоксид серы (SO2)
            dataUpdater.OnCurrentSulfurDioxideUpdate += UpdateCurrentSulfurDioxideLabel;

            // Двуокись углерода (СО2)
            dataUpdater.OnCurrentCarbonDioxideUpdate += UpdateCurrentCarbonDioxideLabel;

            // Летучая органика
            dataUpdater.OnCurrentVolatileOrganicCompoundsUpdate += UpdateCurrentVolatileOrganicCompoundsLabel;

            // Твёрдые частицы PM1
            dataUpdater.OnCurrentParticulateMatterPM1Update += UpdateCurrentParticulateMatterPM1Label;

            // Твёрдые частицы PM2.5
            dataUpdater.OnCurrentParticulateMatterPM2_5Update += UpdateCurrentParticulateMatterPM2_5Label;

            // Твёрдые частицы PM10
            dataUpdater.OnCurrentParticulateMatterPM10Update += UpdateCurrentParticulateMatterPM10Label;

            // Уровень вибрации
            dataUpdater.OnCurrentVibrationLevelUpdate += UpdateCurrentVibrationLevelLabel;

            // Уровень наклона
            dataUpdater.OnCurrentTiltLevelUpdate += UpdateCurrentTiltLevelLabel;

            // Датчик вскрытия
            dataUpdater.OnCurrentTamperSensorUpdate += UpdateCurrentTamperSensorLabel;

            porog_1_AirTemperature.KeyDown += porog_1_AirTemperature_KeyDown;
            porog_1_RelativeHumidity.KeyDown += porog_1_RelativeHumidity_KeyDown;
            porog_1_AtmosphericPressure.KeyDown += porog_1_AtmosphericPressure_KeyDown;
            porog_2_AirTemperature.KeyDown += porog_2_AirTemperature_KeyDown;
            porog_2_RelativeHumidity.KeyDown += porog_2_RelativeHumidity_KeyDown;
            porog_2_AtmosphericPressure.KeyDown += porog_2_AtmosphericPressure_KeyDown;
            dx_AirTemperature.KeyDown += dx_AirTemperature_KeyDown;
            dx_RelativeHumidity.KeyDown += dx_RelativeHumidity_KeyDown;
            porog_1_WindDirection.KeyDown += porog_1_WindDirection_KeyDown;
            porog_1_WindSpeed.KeyDown += porog_1_WindSpeed_KeyDown;
            porog_2_WindSpeed.KeyDown += porog_2_WindSpeed_KeyDown;
            dx_WindDirection.KeyDown += dx_WindDirection_KeyDown;
            dx_AtmosphericPressure.KeyDown += dx_AtmosphericPressure_KeyDown;
            dt_AirTemperature.KeyDown += dt_AirTemperature_KeyDown;
            dt_RelativeHumidity.KeyDown += dt_RelativeHumidity_KeyDown;
            dt_AtmosphericPressure.KeyDown += dt_AtmosphericPressure_KeyDown;
            dt_WindSpeed.KeyDown += dt_WindSpeed_KeyDown;
            dx_WindSpeed.KeyDown += dx_WindSpeed_KeyDown;
            dt_WindDirection.KeyDown += dt_WindDirection_KeyDown;
            porog_1_VolatileOrganicCompounds.KeyDown += porog_1_VolatileOrganicCompounds_KeyDown;
            porog_1_CarbonMonoxide.KeyDown += porog_1_CarbonMonoxide_KeyDown;
            porog_1_NitrogenOxide.KeyDown += porog_1_NitrogenOxide_KeyDown;
            porog_1_NitrogenDioxide.KeyDown += porog_1_NitrogenDioxide_KeyDown;
            porog_1_SulfurDioxide.KeyDown += porog_1_SulfurDioxide_KeyDown;
            porog_1_CarbonDioxide.KeyDown += porog_1_CarbonDioxide_KeyDown;
            porog_2_CarbonDioxide.KeyDown += porog_2_CarbonDioxide_KeyDown;
            porog_2_SulfurDioxide.KeyDown += porog_2_SulfurDioxide_KeyDown;
            porog_2_NitrogenDioxide.KeyDown += porog_2_NitrogenDioxide_KeyDown;
            porog_2_NitrogenOxide.KeyDown += porog_2_NitrogenOxide_KeyDown;
            porog_2_CarbonMonoxide.KeyDown += porog_2_CarbonMonoxide_KeyDown;
            dx_CarbonMonoxide.KeyDown += dx_CarbonMonoxide_KeyDown;
            dx_NitrogenOxide.KeyDown += dx_NitrogenOxide_KeyDown;
            dx_NitrogenDioxide.KeyDown += dx_NitrogenDioxide_KeyDown;
            dx_SulfurDioxide.KeyDown += dx_SulfurDioxide_KeyDown;
            dx_CarbonDioxide.KeyDown += dx_CarbonDioxide_KeyDown;
            dx_VolatileOrganicCompounds.KeyDown += dx_VolatileOrganicCompounds_KeyDown;
            porog_2_VolatileOrganicCompounds.KeyDown += porog_2_VolatileOrganicCompounds_KeyDown;
            dt_VolatileOrganicCompounds.KeyDown += dt_VolatileOrganicCompounds_KeyDown;
            dt_CarbonDioxide.KeyDown += dt_CarbonDioxide_KeyDown;
            dt_SulfurDioxide.KeyDown += dt_SulfurDioxide_KeyDown;
            dt_NitrogenDioxide.KeyDown += dt_NitrogenDioxide_KeyDown;
            dt_NitrogenOxide.KeyDown += dt_NitrogenOxide_KeyDown;
            dt_CarbonMonoxide.KeyDown += dt_CarbonMonoxide_KeyDown;
            porog_1_ParticulateMatterPM10.KeyDown += porog_1_ParticulateMatterPM10_KeyDown;
            porog_1_ParticulateMatterPM1.KeyDown += porog_1_ParticulateMatterPM1_KeyDown;
            porog_1_ParticulateMatterPM2_5.KeyDown += porog_1_ParticulateMatterPM2_5_KeyDown;
            porog_2_ParticulateMatterPM1.KeyDown += porog_2_ParticulateMatterPM1_KeyDown;
            porog_2_ParticulateMatterPM2_5.KeyDown += porog_2_ParticulateMatterPM2_5_KeyDown;
            porog_2_ParticulateMatterPM10.KeyDown += porog_2_ParticulateMatterPM10_KeyDown;
            dx_ParticulateMatterPM1.KeyDown += dx_ParticulateMatterPM1_KeyDown;
            dx_ParticulateMatterPM2_5.KeyDown += dx_ParticulateMatterPM2_5_KeyDown;
            dx_ParticulateMatterPM10.KeyDown += dx_ParticulateMatterPM10_KeyDown;
            dt_ParticulateMatterPM1.KeyDown += dt_ParticulateMatterPM1_KeyDown;
            dt_ParticulateMatterPM2_5.KeyDown += dt_ParticulateMatterPM2_5_KeyDown;
            dt_ParticulateMatterPM10.KeyDown += dt_ParticulateMatterPM10_KeyDown;
            dt_TamperSensor.KeyDown += dt_TamperSensor_KeyDown;
            dx_TamperSensor.KeyDown += dx_TamperSensor_KeyDown;
            porog_2_TamperSensor.KeyDown += porog_2_TamperSensor_KeyDown;
            porog_1_TamperSensor.KeyDown += porog_1_TamperSensor_KeyDown;
            dt_TiltLevel.KeyDown += dt_TiltLevel_KeyDown;
            dx_TiltLevel.KeyDown += dx_TiltLevel_KeyDown;
            porog_2_TiltLevel.KeyDown += porog_2_TiltLevel_KeyDown;
            porog_1_TiltLevel.KeyDown += porog_1_TiltLevel_KeyDown;
            dt_VibrationLevel.KeyDown += dt_VibrationLevel_KeyDown;
            dx_VibrationLevel.KeyDown += dx_VibrationLevel_KeyDown;
            porog_2_VibrationLevel.KeyDown += porog_2_VibrationLevel_KeyDown;
            porog_1_VibrationLevel.KeyDown += porog_1_VibrationLevel_KeyDown;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dataTimeUpdater.StartUpdatingData(1);
            dataUpdater.StartUpdatingData(1);
        }

        private void UpdateCurrentDateTimeInSensorLabel(string obj)
        {

            if (InvokeRequired)
            {
                try
                {
                    Invoke(new Action<string>(UpdateCurrentDateTimeInSensorLabel), obj);
                }
                catch (Exception ex) { }
                return;
            }
            dateSensor.Text = obj;
        }

        List<double> listAirTemperature = new List<double>();

        private void UpdateCurrentAirTemperatureLabel(int obj)
        {

            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentAirTemperatureLabel), obj);
                return;
            }
            double temperature = obj / 10.0;
            currentAirTemperature.Text = temperature.ToString();
            listAirTemperature.Add(temperature);
            try
            {
                avgAirTemperature.Text = listAirTemperature.Average().ToString("F1");
                maxAirTemperature.Text = listAirTemperature.Max().ToString("F1");
                minAirTemperature.Text = listAirTemperature.Min().ToString("F1");
            }
            catch (Exception ex) { }
        }

        List<double> listRelativeHumidity = new List<double>();

        private void UpdateCurrentRelativeHumidityLabel(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentRelativeHumidityLabel), obj);
                return;
            }
            double temperature = obj / 10.0; // Преобразование к типу double и деление на 10
            currentRelativeHumidity.Text = temperature.ToString();
            listRelativeHumidity.Add(temperature);
            try
            {
                avgRelativeHumidity.Text = listRelativeHumidity.Average().ToString("F1");
                maxRelativeHumidity.Text = listRelativeHumidity.Max().ToString();
                minRelativeHumidity.Text = listRelativeHumidity.Min().ToString();
            }
            catch (Exception ex) { }
        }

        List<double> listAtmosphericPressure = new List<double>();

        private void UpdateCurrentAtmosphericPressureLabel(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentAtmosphericPressureLabel), obj);
                return;
            }
            double temperature = obj / 10.0; // Преобразование к типу double и деление на 10
            currentAtmosphericPressure.Text = temperature.ToString();
            listAtmosphericPressure.Add(temperature);
            try
            {
                avgAtmosphericPressure.Text = listAtmosphericPressure.Average().ToString("F1");
                maxAtmosphericPressure.Text = listAtmosphericPressure.Max().ToString();
                minAtmosphericPressure.Text = listAtmosphericPressure.Min().ToString();
            }
            catch (Exception ex) { }
        }

        List<double> listCurrentWindSpeed = new List<double>();

        private void UpdateCurrentWindSpeedLabel(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentWindSpeedLabel), obj);
                return;
            }
            double temperature = obj / 1000.0; // Преобразование к типу double и деление на 10
            currentWindSpeed.Text = temperature.ToString("F1");
            listCurrentWindSpeed.Add(temperature);
            try
            {
                avgWindSpeed.Text = listCurrentWindSpeed.Average().ToString("F1");
                maxWindSpeed.Text = listCurrentWindSpeed.Max().ToString("F1");
                minWindSpeed.Text = listCurrentWindSpeed.Min().ToString("F1");
            }
            catch (Exception ex) { }
        }

        List<int> listCurrentWindDirection = new List<int>();

        private void UpdateCurrentWindDirectionLabel(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentWindDirectionLabel), obj);
                return;
            }
            int temperature = obj; // Преобразование к типу double и деление на 10
            currentWindDirection.Text = temperature.ToString();
            listCurrentWindDirection.Add(temperature);
            try
            {
                avgWindDirection.Text = listCurrentWindDirection.Average().ToString("F1");
                maxWindDirection.Text = listCurrentWindDirection.Max().ToString();
                minWindDirection.Text = listCurrentWindDirection.Min().ToString();
            }
            catch (Exception ex) { }
        }

        List<double> listCarbonMonoxide = new List<double>();

        private void UpdateCurrentCarbonMonoxideLabel(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentCarbonMonoxideLabel), obj);
                return;
            }
            double temperature = obj / 10.0; // Преобразование к типу double и деление на 10
            currentCarbonMonoxide.Text = temperature.ToString("F1");
            listCarbonMonoxide.Add(temperature);
            try
            {
                avgCarbonMonoxide.Text = listCarbonMonoxide.Average().ToString("F1");
                maxCarbonMonoxide.Text = listCarbonMonoxide.Max().ToString("F1");
                minCarbonMonoxide.Text = listCarbonMonoxide.Min().ToString("F1");
            }
            catch (Exception ex) { }
        }

        List<double> listNitrogenOxide = new List<double>();

        private void UpdateCurrentNitrogenOxideLabel(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentNitrogenOxideLabel), obj);
                return;
            }
            double temperature = obj / 10.0; // Преобразование к типу double и деление на 10
            currentNitrogenOxide.Text = temperature.ToString("F1");
            listNitrogenOxide.Add(temperature);
            try
            {
                avgNitrogenOxide.Text = listNitrogenOxide.Average().ToString("F1");
                maxNitrogenOxide.Text = listNitrogenOxide.Max().ToString("F1");
                minNitrogenOxide.Text = listNitrogenOxide.Min().ToString("F1");
            }
            catch (Exception ex) { }
        }

        List<double> listNitrogenDioxide = new List<double>();

        private void UpdateCurrentNitrogenDioxideLabel(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentNitrogenDioxideLabel), obj);
                return;
            }
            double temperature = obj / 10.0; // Преобразование к типу double и деление на 10
            currentNitrogenDioxide.Text = temperature.ToString("F1");
            listNitrogenDioxide.Add(temperature);
            try
            {
                avgNitrogenDioxide.Text = listNitrogenDioxide.Average().ToString("F1");
                maxNitrogenDioxide.Text = listNitrogenDioxide.Max().ToString("F1");
                minNitrogenDioxide.Text = listNitrogenDioxide.Min().ToString("F1");
            }
            catch (Exception ex) { }
        }

        List<double> listSulfurDioxide = new List<double>();

        private void UpdateCurrentSulfurDioxideLabel(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentSulfurDioxideLabel), obj);
                return;
            }
            double temperature = obj / 10.0; // Преобразование к типу double и деление на 10
            currentSulfurDioxide.Text = temperature.ToString("F1");
            listSulfurDioxide.Add(temperature);
            try
            {
                avgSulfurDioxide.Text = listSulfurDioxide.Average().ToString("F1");
                maxSulfurDioxide.Text = listSulfurDioxide.Max().ToString("F1");
                minSulfurDioxide.Text = listSulfurDioxide.Min().ToString("F1");
            }
            catch (Exception ex) { }
        }

        List<double> listCarbonDioxide = new List<double>();

        private void UpdateCurrentCarbonDioxideLabel(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentCarbonDioxideLabel), obj);
                return;
            }
            double temperature = obj / 10.0; // Преобразование к типу double и деление на 10
            currentCarbonDioxide.Text = temperature.ToString("F1");
            listCarbonDioxide.Add(temperature);
            try
            {
                avgCarbonDioxide.Text = listCarbonDioxide.Average().ToString("F1");
                maxCarbonDioxide.Text = listCarbonDioxide.Max().ToString("F1");
                minCarbonDioxide.Text = listCarbonDioxide.Min().ToString("F1");
            }
            catch (Exception ex) { }
        }

        List<double> listVolatileOrganicCompounds = new List<double>();

        private void UpdateCurrentVolatileOrganicCompoundsLabel(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentVolatileOrganicCompoundsLabel), obj);
                return;
            }
            double temperature = obj / 10.0; // Преобразование к типу double и деление на 10
            currentVolatileOrganicCompounds.Text = temperature.ToString("F1");
            listVolatileOrganicCompounds.Add(temperature);
            try
            {
                avgVolatileOrganicCompounds.Text = listVolatileOrganicCompounds.Average().ToString("F1");
                maxVolatileOrganicCompounds.Text = listVolatileOrganicCompounds.Max().ToString("F1");
                minVolatileOrganicCompounds.Text = listVolatileOrganicCompounds.Min().ToString("F1");
            }
            catch (Exception ex) { }
        }

        List<int> listParticulateMatterPM1 = new List<int>();

        private void UpdateCurrentParticulateMatterPM1Label(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentParticulateMatterPM1Label), obj);
                return;
            }
            int temperature = obj; // Преобразование к типу double и деление на 10
            currentParticulateMatterPM1.Text = temperature.ToString();
            listParticulateMatterPM1.Add(temperature);
            try
            {
                avgParticulateMatterPM1.Text = listParticulateMatterPM1.Average().ToString("F1");
                maxParticulateMatterPM1.Text = listParticulateMatterPM1.Max().ToString();
                minParticulateMatterPM1.Text = listParticulateMatterPM1.Min().ToString();
            }
            catch (Exception ex) { }
        }

        List<int> listParticulateMatterPM2_5 = new List<int>();

        private void UpdateCurrentParticulateMatterPM2_5Label(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentParticulateMatterPM2_5Label), obj);
                return;
            }
            int temperature = obj; // Преобразование к типу double и деление на 10
            currentParticulateMatterPM2_5.Text = temperature.ToString();
            listParticulateMatterPM2_5.Add(temperature);
            try
            {
                avgParticulateMatterPM2_5.Text = listParticulateMatterPM2_5.Average().ToString("F1");
                maxParticulateMatterPM2_5.Text = listParticulateMatterPM2_5.Max().ToString();
                minParticulateMatterPM2_5.Text = listParticulateMatterPM2_5.Min().ToString();
            }
            catch (Exception ex) { }
        }

        List<int> listParticulateMatterPM10 = new List<int>();

        private void UpdateCurrentParticulateMatterPM10Label(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentParticulateMatterPM10Label), obj);
                return;
            }
            int temperature = obj; // Преобразование к типу double и деление на 10
            currentParticulateMatterPM10.Text = temperature.ToString();
            listParticulateMatterPM10.Add(temperature);
            try
            {
                avgParticulateMatterPM10.Text = listParticulateMatterPM10.Average().ToString("F1");
                maxParticulateMatterPM10.Text = listParticulateMatterPM10.Max().ToString();
                minParticulateMatterPM10.Text = listParticulateMatterPM10.Min().ToString();
            }
            catch (Exception ex) { }
        }

        List<double> listVibrationLevel = new List<double>();

        private void UpdateCurrentVibrationLevelLabel(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentVibrationLevelLabel), obj);
                return;
            }
            double temperature = obj / 10.0; // Преобразование к типу double и деление на 10
            currentVibrationLevel.Text = temperature.ToString("F1");
            listVibrationLevel.Add(temperature);
            try
            {
                avgVibrationLevel.Text = listVibrationLevel.Average().ToString("F1");
                maxVibrationLevel.Text = listVibrationLevel.Max().ToString("F1");
                minVibrationLevel.Text = listVibrationLevel.Min().ToString("F1");
            }
            catch (Exception ex) { }
        }

        List<double> listTiltLevel = new List<double>();

        private void UpdateCurrentTiltLevelLabel(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentTiltLevelLabel), obj);
                return;
            }
            double temperature = obj / 10.0; // Преобразование к типу double и деление на 10
            currentTiltLevel.Text = temperature.ToString("F1");
            listTiltLevel.Add(temperature);
            try
            {
                avgTiltLevel.Text = listTiltLevel.Average().ToString("F1");
                maxTiltLevel.Text = listTiltLevel.Max().ToString("F1");
                minTiltLevel.Text = listTiltLevel.Min().ToString("F1");
            }
            catch (Exception ex) { }
        }

        List<double> listTamperSensor = new List<double>();

        private void UpdateCurrentTamperSensorLabel(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentTamperSensorLabel), obj);
                return;
            }
            double temperature = obj / 10.0; // Преобразование к типу double и деление на 10
            currentTamperSensor.Text = temperature.ToString("F1");
            listTamperSensor.Add(temperature);
            try
            {
                avgTamperSensor.Text = listTamperSensor.Average().ToString("F1");
                maxTamperSensor.Text = listTamperSensor.Max().ToString("F1");
                minTamperSensor.Text = listTamperSensor.Min().ToString("F1");
            }
            catch (Exception ex) { }
        }

        List<double> listTemperatureInSensor = new List<double>();

        private void UpdateCurrentTemperatureInSensorLabel(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new Action<int>(UpdateCurrentTemperatureInSensorLabel), obj);
                    return;
                }
                catch (Exception ex) { }
            }
            double temperature = obj / 10.0; // Преобразование к типу double и деление на 10
            currentTemperatureInSensor.Text = temperature.ToString("F1");
            listTemperatureInSensor.Add(temperature);
            try
            {
                avgTemperatureInSensor.Text = listTemperatureInSensor.Average().ToString("F1");
                maxTemperatureInSensor.Text = listTemperatureInSensor.Max().ToString("F1");
                minTemperatureInSensor.Text = listTemperatureInSensor.Min().ToString("F1");
            }
            catch (Exception ex) { }
        }

        List<double> listHumidityInSensor = new List<double>();

        private void UpdateCurrentHumidityInSensorLabel(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentHumidityInSensorLabel), obj);
                return;
            }
            double temperature = obj / 10.0; // Преобразование к типу double и деление на 10
            currentHumidityInSensor.Text = temperature.ToString("F1");
            listHumidityInSensor.Add(temperature);
            try
            {
                avgHumidityInSensor.Text = listHumidityInSensor.Average().ToString("F1");
                maxHumidityInSensor.Text = listHumidityInSensor.Max().ToString("F1");
                minHumidityInSensor.Text = listHumidityInSensor.Min().ToString("F1");
            }
            catch (Exception ex) { }
            currentHumidityInSensor.Text = obj.ToString();
        }

        List<double> listPressureInSensor = new List<double>();

        private void UpdateCurrentPressureInSensorLabel(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentPressureInSensorLabel), obj);
                return;
            }
            double temperature = obj / 10.0; // Преобразование к типу double и деление на 10
            currentPressureInSensor.Text = temperature.ToString("F1");
            listPressureInSensor.Add(temperature);
            try
            {
                avgPressureInSensor.Text = listPressureInSensor.Average().ToString("F1");
                maxPressureInSensor.Text = listPressureInSensor.Max().ToString("F1");
                minPressureInSensor.Text = listPressureInSensor.Min().ToString("F1");
            }
            catch (Exception ex) { }
        }

        List<double> listSamplingSpeed = new List<double>();

        private void UpdateCurrentSamplingSpeedLabel(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentSamplingSpeedLabel), obj);
                return;
            }
            double temperature = obj / 10.0; // Преобразование к типу double и деление на 10
            currentSamplingSpeed.Text = temperature.ToString("F1");
            listSamplingSpeed.Add(temperature);
            try
            {
                avgSamplingSpeed.Text = listSamplingSpeed.Average().ToString("F1");
                maxSamplingSpeed.Text = listSamplingSpeed.Max().ToString("F1");
                minSamplingSpeed.Text = listSamplingSpeed.Min().ToString("F1");
            }
            catch (Exception ex) { }
        }

        List<double> listSupplyVoltage = new List<double>();

        private void UpdateCurrentSupplyVoltageLabel(int obj)
        {
            // Обновление метки для температуры воздуха
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCurrentSupplyVoltageLabel), obj);
                return;
            }
            double temperature = obj / 10.0; // Преобразование к типу double и деление на 10
            currentSupplyVoltage.Text = temperature.ToString("F1");
            listSupplyVoltage.Add(temperature);
            try
            {
                avgSupplyVoltage.Text = listSupplyVoltage.Average().ToString("F1");
                maxSupplyVoltage.Text = listSupplyVoltage.Max().ToString("F1");
                minSupplyVoltage.Text = listSupplyVoltage.Min().ToString("F1");
            }
            catch (Exception ex) { }
        }

        private void porog_1_AirTemperature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 20, ushort.Parse(porog_1_AirTemperature.Text));
                porog_1_AirTemperature.Text = _client.ReadHoldingParametr(2, 20);
            }
        }

        private void porog_2_AirTemperature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 21, ushort.Parse(porog_2_AirTemperature.Text));
                porog_2_AirTemperature.Text = _client.ReadHoldingParametr(2, 21);
            }
        }

        private void dx_AirTemperature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 22, ushort.Parse(dx_AirTemperature.Text));
                dx_AirTemperature.Text = _client.ReadHoldingParametr(2, 22);
            }
        }

        private void dt_AirTemperature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 23, ushort.Parse(dt_AirTemperature.Text));
                dt_AirTemperature.Text = _client.ReadHoldingParametr(2, 23);
            }
        }

        private void porog_1_RelativeHumidity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 24, ushort.Parse(porog_1_RelativeHumidity.Text));
                porog_1_RelativeHumidity.Text = _client.ReadHoldingParametr(2, 24);
            }
        }

        private void porog_2_RelativeHumidity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 25, ushort.Parse(porog_2_RelativeHumidity.Text));
                porog_2_RelativeHumidity.Text = _client.ReadHoldingParametr(2, 25);
            }
        }

        private void dx_RelativeHumidity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 26, ushort.Parse(dx_RelativeHumidity.Text));
                dx_RelativeHumidity.Text = _client.ReadHoldingParametr(2, 26);
            }
        }

        private void dt_RelativeHumidity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 27, ushort.Parse(dt_RelativeHumidity.Text));
                dt_RelativeHumidity.Text = _client.ReadHoldingParametr(2, 27);
            }
        }

        private void porog_1_AtmosphericPressure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 4, ushort.Parse(porog_1_AtmosphericPressure.Text));
                porog_1_AtmosphericPressure.Text = _client.ReadHoldingParametr(2, 4);
            }
        }

        private void porog_2_AtmosphericPressure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 5, ushort.Parse(porog_2_AtmosphericPressure.Text));
                porog_2_AtmosphericPressure.Text = _client.ReadHoldingParametr(2, 5);
            }
        }

        private void dx_AtmosphericPressure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 6, ushort.Parse(dx_AtmosphericPressure.Text));
                dx_AtmosphericPressure.Text = _client.ReadHoldingParametr(2, 6);
            }
        }

        private void dt_AtmosphericPressure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 7, ushort.Parse(dt_AtmosphericPressure.Text));
                dt_AtmosphericPressure.Text = _client.ReadHoldingParametr(2, 7);
            }
        }

        private void porog_1_WindSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 28, ushort.Parse(porog_1_WindSpeed.Text));
                porog_1_WindSpeed.Text = _client.ReadHoldingParametr(1, 28);
            }
        }

        private void porog_2_WindSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 29, ushort.Parse(porog_2_WindSpeed.Text));
                porog_2_WindSpeed.Text = _client.ReadHoldingParametr(1, 29);
            }
        }

        private void dx_WindSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 30, ushort.Parse(dx_WindSpeed.Text));
                dx_WindSpeed.Text = _client.ReadHoldingParametr(1, 30);
            }
        }

        private void dt_WindSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 31, ushort.Parse(dt_WindSpeed.Text));
                dt_WindSpeed.Text = _client.ReadHoldingParametr(1, 31);
            }
        }

        private void porog_1_WindDirection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 8, ushort.Parse(porog_1_WindDirection.Text));
                porog_1_WindDirection.Text = _client.ReadHoldingParametr(2, 8);
            }
        }

        private void porog_2_WindDirection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 9, ushort.Parse(porog_2_WindDirection.Text));
                porog_2_WindDirection.Text = _client.ReadHoldingParametr(2, 9);
            }
        }

        private void dx_WindDirection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 10, ushort.Parse(dx_WindDirection.Text));
                dx_WindDirection.Text = _client.ReadHoldingParametr(2, 10);
            }
        }

        private void dt_WindDirection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 11, ushort.Parse(dt_WindDirection.Text));
                dt_WindDirection.Text = _client.ReadHoldingParametr(2, 11);
            }
        }

        private void porog_1_CarbonMonoxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 40, ushort.Parse(porog_1_CarbonMonoxide.Text));
                porog_1_CarbonMonoxide.Text = _client.ReadHoldingParametr(1, 40);
            }
        }

        private void porog_2_CarbonMonoxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 41, ushort.Parse(porog_2_CarbonMonoxide.Text));
                porog_2_CarbonMonoxide.Text = _client.ReadHoldingParametr(1, 41);
            }
        }

        private void dx_CarbonMonoxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 42, ushort.Parse(dx_CarbonMonoxide.Text));
                dx_CarbonMonoxide.Text = _client.ReadHoldingParametr(1, 42);
            }
        }

        private void dt_CarbonMonoxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 43, ushort.Parse(dt_CarbonMonoxide.Text));
                dt_CarbonMonoxide.Text = _client.ReadHoldingParametr(1, 43);
            }
        }

        private void porog_1_NitrogenOxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 48, ushort.Parse(porog_1_NitrogenOxide.Text));
                porog_1_NitrogenOxide.Text = _client.ReadHoldingParametr(1, 48);
            }
        }

        private void porog_2_NitrogenOxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 49, ushort.Parse(porog_2_NitrogenOxide.Text));
                porog_2_NitrogenOxide.Text = _client.ReadHoldingParametr(1, 49);
            }
        }

        private void dx_NitrogenOxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 50, ushort.Parse(dx_NitrogenOxide.Text));
                dx_NitrogenOxide.Text = _client.ReadHoldingParametr(1, 50);
            }
        }

        private void dt_NitrogenOxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 51, ushort.Parse(dt_NitrogenOxide.Text));
                dt_NitrogenOxide.Text = _client.ReadHoldingParametr(1, 51);
            }
        }

        private void porog_1_NitrogenDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 52, ushort.Parse(porog_1_NitrogenDioxide.Text));
                porog_1_NitrogenDioxide.Text = _client.ReadHoldingParametr(1, 52);
            }
        }

        private void porog_2_NitrogenDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 53, ushort.Parse(porog_2_NitrogenDioxide.Text));
                porog_2_NitrogenDioxide.Text = _client.ReadHoldingParametr(1, 53);
            }
        }

        private void dx_NitrogenDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 54, ushort.Parse(dx_NitrogenDioxide.Text));
                dx_NitrogenDioxide.Text = _client.ReadHoldingParametr(1, 54);
            }
        }

        private void dt_NitrogenDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 55, ushort.Parse(dt_NitrogenDioxide.Text));
                dt_NitrogenDioxide.Text = _client.ReadHoldingParametr(1, 55);
            }
        }

        private void porog_1_SulfurDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 76, ushort.Parse(porog_1_SulfurDioxide.Text));
                porog_1_SulfurDioxide.Text = _client.ReadHoldingParametr(1, 76);
            }
        }

        private void porog_2_SulfurDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 77, ushort.Parse(porog_2_SulfurDioxide.Text));
                porog_2_SulfurDioxide.Text = _client.ReadHoldingParametr(1, 77);
            }
        }

        private void dx_SulfurDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 78, ushort.Parse(dx_SulfurDioxide.Text));
                dx_SulfurDioxide.Text = _client.ReadHoldingParametr(1, 78);
            }
        }

        private void dt_SulfurDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 79, ushort.Parse(dt_SulfurDioxide.Text));
                dt_SulfurDioxide.Text = _client.ReadHoldingParametr(1, 79);
            }
        }

        private void porog_1_CarbonDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 44, ushort.Parse(porog_1_CarbonDioxide.Text));
                porog_1_CarbonDioxide.Text = _client.ReadHoldingParametr(1, 44);
            }
        }

        private void porog_2_CarbonDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 45, ushort.Parse(porog_2_CarbonDioxide.Text));
                porog_2_CarbonDioxide.Text = _client.ReadHoldingParametr(1, 45);
            }
        }

        private void dx_CarbonDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 46, ushort.Parse(dx_CarbonDioxide.Text));
                dx_CarbonDioxide.Text = _client.ReadHoldingParametr(1, 46);
            }
        }

        private void dt_CarbonDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 47, ushort.Parse(dt_CarbonDioxide.Text));
                dt_CarbonDioxide.Text = _client.ReadHoldingParametr(1, 47);
            }
        }

        private void porog_1_VolatileOrganicCompounds_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 32, ushort.Parse(porog_1_VolatileOrganicCompounds.Text));
                porog_1_VolatileOrganicCompounds.Text = _client.ReadHoldingParametr(1, 33);
            }
        }

        private void porog_2_VolatileOrganicCompounds_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 33, ushort.Parse(porog_2_VolatileOrganicCompounds.Text));
                porog_2_VolatileOrganicCompounds.Text = _client.ReadHoldingParametr(1, 33);
            }
        }

        private void dx_VolatileOrganicCompounds_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 34, ushort.Parse(dx_VolatileOrganicCompounds.Text));
                dx_VolatileOrganicCompounds.Text = _client.ReadHoldingParametr(1, 34);
            }
        }

        private void dt_VolatileOrganicCompounds_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 35, ushort.Parse(dt_VolatileOrganicCompounds.Text));
                dt_VolatileOrganicCompounds.Text = _client.ReadHoldingParametr(1, 35);
            }
        }

        private void porog_1_ParticulateMatterPM1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 64, ushort.Parse(porog_1_ParticulateMatterPM1.Text));
                porog_1_ParticulateMatterPM1.Text = _client.ReadHoldingParametr(2, 64);
            }
        }

        private void porog_2_ParticulateMatterPM1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 65, ushort.Parse(porog_2_ParticulateMatterPM1.Text));
                porog_2_ParticulateMatterPM1.Text = _client.ReadHoldingParametr(2, 65);
            }
        }

        private void dx_ParticulateMatterPM1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 66, ushort.Parse(dx_ParticulateMatterPM1.Text));
                dx_ParticulateMatterPM1.Text = _client.ReadHoldingParametr(2, 66);
            }
        }

        private void dt_ParticulateMatterPM1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 67, ushort.Parse(dt_ParticulateMatterPM1.Text));
                dt_ParticulateMatterPM1.Text = _client.ReadHoldingParametr(2, 67);
            }
        }

        private void porog_1_ParticulateMatterPM2_5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 68, ushort.Parse(porog_1_ParticulateMatterPM2_5.Text));
                porog_1_ParticulateMatterPM2_5.Text = _client.ReadHoldingParametr(2, 68);
            }
        }

        private void porog_2_ParticulateMatterPM2_5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 69, ushort.Parse(porog_2_ParticulateMatterPM2_5.Text));
                porog_2_ParticulateMatterPM2_5.Text = _client.ReadHoldingParametr(2, 69);
            }
        }

        private void dx_ParticulateMatterPM2_5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 70, ushort.Parse(dx_ParticulateMatterPM2_5.Text));
                dx_ParticulateMatterPM2_5.Text = _client.ReadHoldingParametr(2, 70);
            }
        }

        private void dt_ParticulateMatterPM2_5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 71, ushort.Parse(dt_ParticulateMatterPM2_5.Text));
                dt_ParticulateMatterPM2_5.Text = _client.ReadHoldingParametr(2, 71);
            }
        }

        private void porog_1_ParticulateMatterPM10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 72, ushort.Parse(porog_1_ParticulateMatterPM10.Text));
                porog_1_ParticulateMatterPM10.Text = _client.ReadHoldingParametr(2, 72);
            }
        }

        private void porog_2_ParticulateMatterPM10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 73, ushort.Parse(porog_2_ParticulateMatterPM10.Text));
                porog_2_ParticulateMatterPM10.Text = _client.ReadHoldingParametr(2, 73);
            }
        }

        private void dx_ParticulateMatterPM10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 74, ushort.Parse(dx_ParticulateMatterPM10.Text));
                dx_ParticulateMatterPM10.Text = _client.ReadHoldingParametr(2, 74);
            }
        }

        private void dt_ParticulateMatterPM10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 75, ushort.Parse(dt_ParticulateMatterPM10.Text));
                dt_ParticulateMatterPM10.Text = _client.ReadHoldingParametr(2, 75);
            }
        }

        private void porog_1_VibrationLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 84, ushort.Parse(porog_1_VibrationLevel.Text));
                porog_1_VibrationLevel.Text = _client.ReadHoldingParametr(1, 84);
            }
        }

        private void porog_2_VibrationLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 85, ushort.Parse(porog_2_VibrationLevel.Text));
                porog_2_VibrationLevel.Text = _client.ReadHoldingParametr(1, 85);
            }
        }

        private void dx_VibrationLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 86, ushort.Parse(dx_VibrationLevel.Text));
                dx_VibrationLevel.Text = _client.ReadHoldingParametr(1, 86);
            }
        }

        private void dt_VibrationLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 87, ushort.Parse(dt_VibrationLevel.Text));
                dt_VibrationLevel.Text = _client.ReadHoldingParametr(1, 87);
            }
        }

        private void porog_1_TiltLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 80, ushort.Parse(porog_1_TiltLevel.Text));
                porog_1_TiltLevel.Text = _client.ReadHoldingParametr(1, 80);
            }
        }

        private void porog_2_TiltLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 81, ushort.Parse(porog_2_TiltLevel.Text));
                porog_2_TiltLevel.Text = _client.ReadHoldingParametr(1, 81);
            }
        }

        private void dx_TiltLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 82, ushort.Parse(dx_TiltLevel.Text));
                dx_TiltLevel.Text = _client.ReadHoldingParametr(1, 82);
            }
        }

        private void dt_TiltLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 83, ushort.Parse(dt_TiltLevel.Text));
                dt_TiltLevel.Text = _client.ReadHoldingParametr(1, 83);
            }
        }

        private void porog_1_TamperSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(3, 8, ushort.Parse(porog_1_TamperSensor.Text));
                porog_1_TamperSensor.Text = _client.ReadHoldingParametr(3, 8);
            }
        }

        private void porog_2_TamperSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(3, 9, ushort.Parse(porog_2_TamperSensor.Text));
                porog_2_TamperSensor.Text = _client.ReadHoldingParametr(3, 9);
            }
        }

        private void dx_TamperSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(3, 10, ushort.Parse(dx_TamperSensor.Text));
                dx_TamperSensor.Text = _client.ReadHoldingParametr(3, 10);
            }
        }

        private void dt_TamperSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(3, 11, ushort.Parse(dt_TamperSensor.Text));
                dt_TamperSensor.Text = _client.ReadHoldingParametr(3, 11);
            }
        }

        private void porog_1_TemperatureInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 20, ushort.Parse(porog_1_TemperatureInSensor.Text));
                porog_1_TemperatureInSensor.Text = _client.ReadHoldingParametr(1, 20);
            }
        }

        private void porog_2_TemperatureInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 21, ushort.Parse(porog_2_TemperatureInSensor.Text));
                porog_2_TemperatureInSensor.Text = _client.ReadHoldingParametr(1, 21);
            }
        }

        private void dx_TemperatureInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 22, ushort.Parse(dx_TemperatureInSensor.Text));
                dx_TemperatureInSensor.Text = _client.ReadHoldingParametr(1, 22);
            }
        }

        private void dt_TemperatureInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 23, ushort.Parse(dt_TemperatureInSensor.Text));
                dt_TemperatureInSensor.Text = _client.ReadHoldingParametr(1, 23);
            }
        }

        private void porog_1_HumidityInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 24, ushort.Parse(porog_1_HumidityInSensor.Text));
                porog_1_HumidityInSensor.Text = _client.ReadHoldingParametr(1, 24);
            }
        }

        private void porog_2_HumidityInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 25, ushort.Parse(porog_2_HumidityInSensor.Text));
                porog_2_HumidityInSensor.Text = _client.ReadHoldingParametr(1, 25);
            }
        }

        private void dx_HumidityInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 26, ushort.Parse(dx_HumidityInSensor.Text));
                dx_HumidityInSensor.Text = _client.ReadHoldingParametr(1, 26);
            }
        }

        private void dt_HumidityInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 27, ushort.Parse(dt_HumidityInSensor.Text));
                dt_HumidityInSensor.Text = _client.ReadHoldingParametr(1, 27);
            }
        }

        private void porog_1_SupplyVoltage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 8, ushort.Parse(porog_1_SupplyVoltage.Text));
                porog_1_SupplyVoltage.Text = _client.ReadHoldingParametr(1, 8);
            }
        }

        private void porog_2_SupplyVoltage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 9, ushort.Parse(porog_2_SupplyVoltage.Text));
                porog_2_SupplyVoltage.Text = _client.ReadHoldingParametr(1, 9);
            }
        }

        private void dx_SupplyVoltage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 10, ushort.Parse(dx_SupplyVoltage.Text));
                dx_SupplyVoltage.Text = _client.ReadHoldingParametr(1, 10);
            }
        }

        private void dt_SupplyVoltage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 11, ushort.Parse(dt_SupplyVoltage.Text));
                dt_SupplyVoltage.Text = _client.ReadHoldingParametr(1, 11);
            }
        }

        private void porog_1_PressureInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 4, ushort.Parse(porog_1_PressureInSensor.Text));
                porog_1_PressureInSensor.Text = _client.ReadHoldingParametr(1, 4);
            }
        }

        private void porog_2_PressureInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 5, ushort.Parse(porog_2_PressureInSensor.Text));
                porog_2_PressureInSensor.Text = _client.ReadHoldingParametr(1, 5);
            }
        }

        private void dx_PressureInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 6, ushort.Parse(dx_PressureInSensor.Text));
                dx_PressureInSensor.Text = _client.ReadHoldingParametr(1, 6);
            }
        }

        private void dt_PressureInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 7, ushort.Parse(dt_PressureInSensor.Text));
                dt_PressureInSensor.Text = _client.ReadHoldingParametr(1, 7);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.Show();
        }
    }
}