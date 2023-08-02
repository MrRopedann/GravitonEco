using GravitonEco.Controller;
using GravitonEco.Model;
using GravitonEco.View;

namespace GravitonEco
{
    public partial class MainForm : Form
    {
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
            // Запуск задачи для асинхронного обновления данных
            Dictionary<string, (byte slaveId, ushort address)> parameters = new Dictionary<string, (byte, ushort)>
        {
            { "input_Температура_воздуха", (2, 5) },
            { "input_Относительная_влажность", (2, 6) },
            { "input_Атмосферное_давление", (1, 1) },
            { "input_Скорость_ветра", (1, 7) },
            { "input_Направление_ветра", (2, 2) },
            { "input_Оксид_углерода", (1, 10) },
            { "input_Оксид_азота", (1, 12) },
            { "input_Диоксид_азота", (1, 13) },
            { "input_Диоксид_серы", (1, 19) },
            { "input_Двуокись_углерода", (1, 11) },
            { "input_Летучая_органика", (1, 8) },
            { "input_Твёрдые_частицы_PM1", (1, 16) },
            { "input_Твёрдые_частицы_PM2_5", (1, 17) },
            { "input_Твёрдые_частицы_PM10", (1, 18) },
            { "input_Уровень_вибрации", (1, 21) },
            { "input_Уровень_наклона", (1, 20) },
            { "input_Датчик_вскрытия", (3, 2) },
            { "input_Температура_в_измерителе", (1, 5) },
            { "input_Влажность_в_измерителе", (1, 6) },
            { "input_Давление_в_измерителе", (2, 1) },
            { "input_Скорость_пробоотбора", (3, 25) },
            { "input_Напряжение_питания", (1, 5) },

            {"coil_Температура_Порог_1", (2, 15)},
            {"coil_ТемпиратураПорог2",(2,16)},
            {"coil_Темпиратураdx",(2,17)},
            {"coil_влажностьпорог1",(2,18)},
            {"coil_влажностьпорог2",(2,19)},
            {"coil_влажностьдх",(2,20)},
            {"coil_Давлениепорог1",(2,3)},
            {"coil_Давлениепорог2",(2,4)},
            {"coil_Давлениедх",(2,5)},
            {"coil_Скоростьветрапорог1",(2,21)},
            {"coil_Скоростьветрапорог2",(2,22)},
            {"coil_Скоростьветрадх",(2,23)},
            {"coil_Направлениеветрапорог1",(2,6)},
            {"coil_Направлениеветрапорог2",(2,7)},
            {"coil_Направлениеветрадт",(2,8)},
            {"coil_СОпорог1",(1,30)},
            {"coil_СОпорог2",(1,31)},
            {"coil_СОдт",(1,32)},
            {"coil_NOпорог1",(1,36)},
            {"coil_NOпорог2",(1,37)},
            {"coil_NOдт",(1,38)},
            {"coil_NO2порог1",(1,39)},
            {"coil_NO2порог2",(1,40)},
            {"coil_NO2дт",(1,41)},
            {"coil_SO2порог1",(1,57)},
            {"coil_SO2порог2",(1,58)},
            {"coil_SO2дт",(1,59)},
            {"coil_СО2порог1",(1,33)},
            {"coil_СО2порог2",(1,34)},
            {"coil_СО2дт",(1,35)},
            {"coil_ЛОСпорог1",(1,24)},
            {"coil_ЛОСпорог2",(1,25)},
            {"coil_ЛОСдт",(1,26)},
            {"coil_ПМ1порог1",(1,48)},
            {"coil_ПМ1порог2",(1,49)},
            {"coil_ПМ1дт",(1,50)},
            {"coil_ПМ2_5порог1",(1,51)},
            {"coil_ПМ2_5порог2",(1,52)},
            {"coil_ПМ2_5дт",(1,53)},
            {"coil_ПМ10порог1",(1,54)},
            {"coil_ПМ10порог2",(1,55)},
            {"coil_ПМ10дт",(1,56)},
            {"coil_Вибрацияпорог1",(1,63)},
            {"coil_Вибрацияпорог2",(1,64)},
            {"coil_Вибрациядт",(1,64)},
            {"coil_Наклонпорог1",(1,60)},
            {"coil_Наклонпорог2",(1,61)},
            {"coil_Наклондт",(1,62)},
            {"coil_вскрытиепорог1",(3,6)},
            {"coil_вскрытиепорог2",(3,7)},
            {"coil_вскрытиедт",(3,8)},
            {"coil_Темпиратураизмерителяпорог1",(1,15)},
            {"coil_Темпиратураизмерителяпорог2",(1,16)},
            {"coil_Темпиратураизмерителядт",(1,17)},
            {"coil_Влажностьизмерителяпорог1",(1,18)},
            {"coil_Влажностьизмерителяпорог2",(1,19)},
            {"coil_Влажностьизмерителядт",(1,20)},
            {"coil_Давлениеизмерителяпорог1",(1,3)},
            {"coil_Давлениеизмерителяпорог2",(1,4)},
            {"coil_Давлениеизмерителядт",(1,5)},
            {"coil_Напряжениепорог1",(1,6)},
            {"coil_Напряжениепорог2",(1,7)},
            {"coil_Напряжениедт",(1,8)},
            {"holdingdate_year",(251,262)},
            {"holdingdate_moths",(251,261)},
            {"holdingdate_day",(251,260)},
            {"holdingdate_hour",(251,258)},
            {"holdingdate_minute",(251,257)},
            {"holdingdate_second",(251,256)},
        };
            // Добавьте другие параметры, которые вам нужны


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

            setupZeroCarbonMonoxide.Text = _client.ReadHoldingParametr(1, 520);
            pgc_CarbonMonoxide.Text = _client.ReadHoldingParametr(1, 521);
            acp_CarbonMonoxide.Text = _client.ReadHoldingParametr(1, 522);
            sumZeroCarbonMonoxide.Text = _client.ReadHoldingParametr(1, 523);

            setupZeroNitrogenOxide.Text = _client.ReadHoldingParametr(1, 512);
            pgc_NitrogenOxide.Text = _client.ReadHoldingParametr(1, 513);
            acp_NitrogenOxide.Text = _client.ReadHoldingParametr(1, 514);
            sumZeroNitrogenOxide.Text = _client.ReadHoldingParametr(1, 515);

            setupZeroNitrogenDioxide.Text = _client.ReadHoldingParametr(1, 516);
            pgc_NitrogenDioxide.Text = _client.ReadHoldingParametr(1, 517);
            acp_NitrogenDioxide.Text = _client.ReadHoldingParametr(1, 518);
            sumZeroNitrogenDioxide.Text = _client.ReadHoldingParametr(1, 519);

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
            //setupZeroCarbonMonoxide.KeyDown = _client.ReadHoldingParametr(1, 520);
            pgc_CarbonMonoxide.KeyDown += pgc_CarbonMonoxide_KeyDown;
            acp_CarbonMonoxide.KeyDown += acp_CarbonMonoxide_KeyDown;
            sumZeroCarbonMonoxide.KeyDown += sumZeroCarbonMonoxide_KeyDown;

            setupZeroNitrogenOxide.KeyDown += setupZeroNitrogenOxide_KeyDown;
            pgc_NitrogenOxide.KeyDown += pgc_NitrogenOxide_KeyDown;
            acp_NitrogenOxide.KeyDown += acp_NitrogenOxide_KeyDown;
            sumZeroNitrogenOxide.KeyDown += sumZeroNitrogenOxide_KeyDown;

            setupZeroNitrogenDioxide.KeyDown += setupZeroNitrogenDioxide_KeyDown;
            pgc_NitrogenDioxide.KeyDown += pgc_NitrogenDioxide_KeyDown;
            acp_NitrogenDioxide.KeyDown += acp_NitrogenDioxide_KeyDown;
            sumZeroNitrogenDioxide.KeyDown += sumZeroNitrogenDioxide_KeyDown;


            Task.Run(async () =>
            {
                while (true)
                {
                    Dictionary<string, string> data = await _client.ReadMultipleValuesAsync(parameters);

                    // Вызов метода для обновления данных в основном потоке UI
                    Invoke(new Action(() => UpdateDataOnForm(data)));

                    await Task.Delay(1000); // Приостанавливаем выполнение на 1 секунду перед следующим обновлением данных
                }
            });
        }

        private void UpdateDataOnForm(Dictionary<string, string> data)
        {
            foreach (var kvp in data)
            {
                string paramName = kvp.Key;
                string paramValue = kvp.Value;

                if (paramName == "input_Температура_воздуха")
                {
                    currentAirTemperature.Text = paramValue;
                }
                else if (paramName == "input_Атмосферное_давление")
                {
                    currentAtmosphericPressure.Text = paramValue;
                }
                else if (paramName == "input_Относительная_влажность")
                {
                    currentRelativeHumidity.Text = paramValue;
                }
                else if (paramName == "input_Скорость_ветра")
                {
                    currentWindSpeed.Text = paramValue;
                }
                else if (paramName == "input_Направление_ветра")
                {
                    currentWindDirection.Text = paramValue;
                }
                else if (paramName == "input_Оксид_углерода")
                {
                    currentCarbonMonoxide.Text = paramValue;
                }
                else if (paramName == "input_Оксид_азота")
                {
                    currentNitrogenOxide.Text = paramValue;
                }
                else if (paramName == "input_Диоксид_азота")
                {
                    currentNitrogenDioxide.Text = paramValue;
                }
                else if (paramName == "input_Диоксид_серы")
                {
                    currentSulfurDioxide.Text = paramValue;
                }
                else if (paramName == "input_Двуокись_углерода")
                {
                    currentCarbonDioxide.Text = paramValue;
                }
                else if (paramName == "input_Летучая_органика")
                {
                    currentVolatileOrganicCompounds.Text = paramValue;
                }
                else if (paramName == "input_Твёрдые_частицы_PM1")
                {
                    currentParticulateMatterPM1.Text = paramValue;
                }
                else if (paramName == "input_Твёрдые_частицы_PM2_5")
                {
                    currentParticulateMatterPM2_5.Text = paramValue;
                }
                else if (paramName == "input_Твёрдые_частицы_PM10")
                {
                    currentParticulateMatterPM10.Text = paramValue;
                }
                else if (paramName == "input_Уровень_вибрации")
                {
                    currentVibrationLevel.Text = paramValue;
                }
                else if (paramName == "input_Уровень_наклона")
                {
                    currentTiltLevel.Text = paramValue;
                }
                else if (paramName == "input_Датчик_вскрытия")
                {
                    currentTamperSensor.Text = paramValue;
                }
                else if (paramName == "input_Температура_в_измерителе")
                {
                    currentTemperatureInSensor.Text = paramValue;
                }
                else if (paramName == "input_Влажность_в_измерителе")
                {
                    currentHumidityInSensor.Text = paramValue;
                }
                else if (paramName == "input_Давление_в_измерителе")
                {
                    currentPressureInSensor.Text = paramValue;
                }
                else if (paramName == "input_Скорость_пробоотбора")
                {
                    currentSamplingSpeed.Text = paramValue;
                }
                else if (paramName == "input_Напряжение_питания")
                {
                    currentSupplyVoltage.Text = paramValue;
                }
                if (paramName == "input_Температура_воздуха")
                {
                    currentAirTemperature2.Text = paramValue;
                }
                else if (paramName == "input_Атмосферное_давление")
                {
                    currentAtmosphericPressure2.Text = paramValue;
                }
                else if (paramName == "input_Относительная_влажность")
                {
                    currentRelativeHumidity2.Text = paramValue;
                }
                else if (paramName == "input_Скорость_ветра")
                {
                    currentWindSpeed2.Text = paramValue;
                }
                else if (paramName == "input_Оксид_углерода")
                {
                    currentCarbonMonoxide2.Text = paramValue;
                }
                else if (paramName == "input_Оксид_азота")
                {
                    currentNitrogenOxide2.Text = paramValue;
                }
                else if (paramName == "input_Диоксид_азота")
                {
                    currentNitrogenDioxide2.Text = paramValue;
                }
                else if (paramName == "input_Диоксид_серы")
                {
                    currentSulfurDioxide2.Text = paramValue;
                }
                else if (paramName == "input_Двуокись_углерода")
                {
                    currentCarbonDioxide2.Text = paramValue;
                }
                else if (paramName == "input_Летучая_органика")
                {
                    currentVolatileOrganicCompounds2.Text = paramValue;
                }
                else if (paramName == "coil_Температура_Порог_1")
                {
                    porog_1_AirTemperature.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_ТемпиратураПорог2")
                {
                    porog_2_AirTemperature.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Темпиратураdx")
                {
                    dx_AirTemperature.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_AirTemperature.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_влажностьпорог1")
                {
                    porog_1_RelativeHumidity.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_влажностьпорог2")
                {
                    porog_2_RelativeHumidity.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_влажностьдх")
                {
                    dx_RelativeHumidity.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_RelativeHumidity.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Давлениепорог1")
                {
                    porog_1_AtmosphericPressure.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Давлениепорог2")
                {
                    porog_2_AtmosphericPressure.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Давлениедх")
                {
                    dx_AtmosphericPressure.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_AtmosphericPressure.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Скоростьветрапорог1")
                {
                    porog_1_WindSpeed.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Скоростьветрапорог2")
                {
                    porog_2_WindSpeed.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Скоростьветрадх")
                {
                    dx_WindSpeed.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_WindSpeed.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Направлениеветрапорог1")
                {
                    porog_1_WindDirection.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Направлениеветрапорог2")
                {
                    porog_2_WindDirection.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Направлениеветрадт")
                {
                    dx_WindDirection.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_WindDirection.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_СОпорог1")
                {
                    porog_1_CarbonMonoxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_СОпорог2")
                {
                    porog_2_CarbonMonoxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_СОдт")
                {
                    dt_CarbonMonoxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dx_CarbonMonoxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_NOпорог1")
                {
                    porog_1_NitrogenOxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_NOпорог2")
                {
                    porog_2_NitrogenOxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_NOдт")
                {
                    dx_NitrogenOxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_NitrogenOxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_NO2порог1")
                {
                    porog_1_NitrogenDioxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_NO2порог2")
                {
                    porog_2_NitrogenDioxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_NO2дт")
                {
                    dx_NitrogenDioxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_NitrogenDioxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_SO2порог1")
                {
                    porog_1_SulfurDioxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_SO2порог2")
                {
                    porog_2_SulfurDioxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_SO2дт")
                {
                    dx_SulfurDioxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_SulfurDioxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_СО2порог1")
                {
                    porog_1_CarbonDioxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_СО2порог2")
                {
                    porog_2_CarbonDioxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_СО2дт")
                {
                    dx_CarbonDioxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_CarbonDioxide.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_ЛОСпорог1")
                {
                    porog_1_VolatileOrganicCompounds.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_ЛОСпорог2")
                {
                    porog_2_VolatileOrganicCompounds.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_ЛОСдт")
                {
                    dx_VolatileOrganicCompounds.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_VolatileOrganicCompounds.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_ПМ1порог1")
                {
                    porog_1_ParticulateMatterPM1.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_ПМ1порог2")
                {
                    porog_2_ParticulateMatterPM1.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_ПМ1дт")
                {
                    dx_ParticulateMatterPM1.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_ParticulateMatterPM1.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_ПМ2_5порог1")
                {
                    porog_1_ParticulateMatterPM2_5.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_ПМ2_5порог2")
                {
                    porog_2_ParticulateMatterPM2_5.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_ПМ2_5дт")
                {
                    dx_ParticulateMatterPM2_5.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_ParticulateMatterPM2_5.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_ПМ10порог1")
                {
                    porog_1_ParticulateMatterPM10.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_ПМ10порог2")
                {
                    porog_2_ParticulateMatterPM10.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_ПМ10дт")
                {
                    dx_ParticulateMatterPM10.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_ParticulateMatterPM10.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Вибрацияпорог1")
                {
                    porog_1_VibrationLevel.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Вибрацияпорог2")
                {
                    porog_2_VibrationLevel.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Вибрациядт")
                {
                    dx_VibrationLevel.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_VibrationLevel.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Наклонпорог1")
                {
                    porog_1_TiltLevel.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Наклонпорог2")
                {
                    porog_2_TiltLevel.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Наклондт")
                {
                    dx_TiltLevel.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_TiltLevel.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_вскрытиепорог1")
                {
                    porog_1_TamperSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_вскрытиепорог2")
                {
                    porog_2_TamperSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_вскрытиедт")
                {
                    dx_TamperSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_TamperSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Темпиратураизмерителяпорог1")
                {
                    porog_1_TemperatureInSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Темпиратураизмерителяпорог2")
                {
                    porog_2_TemperatureInSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Темпиратураизмерителядт")
                {
                    dx_TemperatureInSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_TemperatureInSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Влажностьизмерителяпорог1")
                {
                    porog_1_HumidityInSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Влажностьизмерителяпорог2")
                {
                    porog_2_HumidityInSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Влажностьизмерителядт")
                {
                    dx_HumidityInSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_HumidityInSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Давлениеизмерителяпорог1")
                {
                    porog_1_SupplyVoltage.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Давлениеизмерителяпорог2")
                {
                    porog_2_SupplyVoltage.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Давлениеизмерителядт")
                {
                    dx_SupplyVoltage.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_SupplyVoltage.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Напряжениепорог1")
                {
                    porog_1_PressureInSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Напряжениепорог2")
                {
                    porog_2_PressureInSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }
                else if (paramName == "coil_Напряжениедт")
                {
                    dx_PressureInSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    dt_PressureInSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                }

                // Задайте список параметров, которые вы хотите объединить
                List<string> date = new List<string> { "holdingdate_day", "holdingdate_moths", "holdingdate_year" };
                List<string> time = new List<string> { "holdingdate_hour", "holdingdate_minute", "holdingdate_second" };

                // Используйте LINQ для фильтрации значений и объедините только нужные параметры
                string combinedDate = string.Join(".", data.Where(kvp => date.Contains(kvp.Key)).Select(kvp => kvp.Value.Split('-')[0]));
                string combinedTime = string.Join(":", data.Where(kvp => time.Contains(kvp.Key)).Select(kvp => kvp.Value.Split('-')[0]));
                dateSensor.Text = combinedDate + " " + combinedTime;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.Show();
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

        private void setupZeroCarbonMonoxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 520, ushort.Parse(setupZeroCarbonMonoxide.Text));
                setupZeroCarbonMonoxide.Text = _client.ReadHoldingParametr(1, 520);
            }
        }

        private void pgc_CarbonMonoxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 521, ushort.Parse(pgc_CarbonMonoxide.Text));
                pgc_CarbonMonoxide.Text = _client.ReadHoldingParametr(1, 521);
            }
        }

        private void acp_CarbonMonoxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 522, ushort.Parse(acp_CarbonMonoxide.Text));
                acp_CarbonMonoxide.Text = _client.ReadHoldingParametr(1, 522);
            }
        }

        private void sumZeroCarbonMonoxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 523, ushort.Parse(sumZeroCarbonMonoxide.Text));
                sumZeroCarbonMonoxide.Text = _client.ReadHoldingParametr(1, 523);
            }
        }

        private void setupZeroNitrogenOxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 512, ushort.Parse(setupZeroNitrogenOxide.Text));
                setupZeroNitrogenOxide.Text = _client.ReadHoldingParametr(1, 512);
            }
        }

        private void pgc_NitrogenOxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 513, ushort.Parse(pgc_NitrogenOxide.Text));
                pgc_NitrogenOxide.Text = _client.ReadHoldingParametr(1, 513);
            }
        }

        private void acp_NitrogenOxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 514, ushort.Parse(acp_NitrogenOxide.Text));
                acp_NitrogenOxide.Text = _client.ReadHoldingParametr(1, 514);
            }
        }

        private void sumZeroNitrogenOxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 515, ushort.Parse(sumZeroNitrogenOxide.Text));
                sumZeroNitrogenOxide.Text = _client.ReadHoldingParametr(1, 515);
            }
        }

        private void setupZeroNitrogenDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 516, ushort.Parse(setupZeroNitrogenDioxide.Text));
                setupZeroNitrogenDioxide.Text = _client.ReadHoldingParametr(1, 516);
            }
        }

        private void pgc_NitrogenDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 517, ushort.Parse(pgc_NitrogenDioxide.Text));
                pgc_NitrogenDioxide.Text = _client.ReadHoldingParametr(1, 517);
            }
        }

        private void acp_NitrogenDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 518, ushort.Parse(acp_NitrogenDioxide.Text));
                acp_NitrogenDioxide.Text = _client.ReadHoldingParametr(1, 518);
            }
        }

        private void sumZeroNitrogenDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 519, ushort.Parse(sumZeroNitrogenDioxide.Text));
                sumZeroNitrogenDioxide.Text = _client.ReadHoldingParametr(1, 519);
            }
        }
    }
}