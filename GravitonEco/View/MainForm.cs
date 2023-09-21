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
        int x0 = 0;
        int x_acp = 2000;
        int x_gs = 2000;
        // Константа для задержки в миллисекундах
        private int _delaySeconds = 1;

        // Кеш для значений параметров и соответствующих элементов управления
        private Dictionary<string, (byte slaveId, ushort address)> parameterControls = new Dictionary<string, (byte slaveId, ushort address)>();

        // Кеш для другого словаря значений
        private Dictionary<string, (byte slaveId, ushort address)> otherDataCache = new Dictionary<string, (byte slaveId, ushort address)>();
        private Dictionary<string, (byte slaveId, ushort address)> otherDateTimeCache = new Dictionary<string, (byte slaveId, ushort address)>();
        private Dictionary<string, (byte slaveId, ushort address)> otherFormulParametr = new Dictionary<string, (byte slaveId, ushort address)>();



        public MainForm()
        {
            InitializeComponent();
            INIManager manager = new INIManager(@"./Config/setting_device_connection.ini");
            _host = manager.GetPrivateString("DeviceConnectSetting", "Host");
            _port = manager.GetPrivateString("DeviceConnectSetting", "Port");
            _client = new ModbusTCPClient(_host, Int32.Parse(_port));

            apparatVersion.Text = "HV-" + _client.ReadHoldingParametr(251, 244);
            softVersion.Text = "FV-" + _client.ReadHoldingParametr(251, 245);
            serialNumber.Text = "SN-" + _client.ReadHoldingParametr(251, 18) + "" + _client.ReadHoldingParametr(251, 19) + "" + _client.ReadHoldingParametr(251, 20) + "" + _client.ReadHoldingParametr(251, 21) + "" + _client.ReadHoldingParametr(251, 22) + "" + _client.ReadHoldingParametr(251, 23);

            // Запуск задачи для асинхронного обновления данных
            otherDataCache["input_Температура_воздуха"] = (2, 5);
            otherDataCache["input_Температура_воздуха2"] = (1, 5);
            otherDataCache["input_Относительная_влажность"] = (2, 6);
            otherDataCache["input_Относительная_влажность2"] = (4, 5);
            otherDataCache["input_Атмосферное_давление"] = (1, 1);
            otherDataCache["input_Скорость_ветра"] = (1, 7);
            otherDataCache["input_Направление_ветра"] = (2, 2);
            otherDataCache["input_Оксид_углерода"] = (1, 10);
            otherDataCache["input_Оксид_азота"] = (1, 12);
            otherDataCache["input_Диоксид_азота"] = (1, 13);
            otherDataCache["input_Диоксид_серы"] = (1, 19);
            otherDataCache["input_Летучая_органика"] = (1, 8);
            otherDataCache["input_Твёрдые_частицы_PM1"] = (2, 16);
            otherDataCache["input_Твёрдые_частицы_PM2_5"] = (2, 17);
            otherDataCache["input_Твёрдые_частицы_PM10"] = (2, 18);
            otherDataCache["input_Уровень_вибрации"] = (1, 21);
            otherDataCache["input_Уровень_наклона"] = (1, 20);
            otherDataCache["input_Датчик_вскрытия"] = (3, 2);
            otherDataCache["input_Температура_в_измерителе"] = (1, 5);
            otherDataCache["input_Влажность_в_измерителе"] = (1, 6);
            otherDataCache["input_Давление_в_измерителе"] = (2, 1);
            otherDataCache["input_Скорость_пробоотбора"] = (3, 25);
            otherDataCache["input_Напряжение_питания"] = (1, 2);
            otherDataCache["holding_Мощьность_темпиратуры"] = (1, 258);
            otherDataCache["holding_Мощьность_влажность"] = (4, 258);

            otherFormulParametr["input_Двуокись_углерода"] = (1, 11);
            otherFormulParametr["input_Дополнительный_вход_1"] = (1, 7);
            otherFormulParametr["input_Дополнительный_вход_2"] = (2, 2);

            parameterControls["coil_Температура_Порог_1"] = (2, 15);
            parameterControls["coil_ТемпиратураПорог2"] = (2, 16);
            parameterControls["coil_Темпиратураdx"] = (2, 17);
            parameterControls["coil_влажностьпорог1"] = (2, 18);
            parameterControls["coil_влажностьпорог2"] = (2, 19);
            parameterControls["coil_влажностьдх"] = (2, 20);
            parameterControls["coil_Давлениепорог1"] = (2, 3);
            parameterControls["coil_Давлениепорог2"] = (2, 4);
            parameterControls["coil_Давлениедх"] = (2, 5);
            parameterControls["coil_Скоростьветрапорог1"] = (2, 21);
            parameterControls["coil_Скоростьветрапорог2"] = (2, 22);
            parameterControls["coil_Скоростьветрадх"] = (2, 23);
            parameterControls["coil_Направлениеветрапорог1"] = (2, 6);
            parameterControls["coil_Направлениеветрапорог2"] = (2, 7);
            parameterControls["coil_Направлениеветрадт"] = (2, 8);
            parameterControls["coil_СОпорог1"] = (1, 30);
            parameterControls["coil_СОпорог2"] = (1, 31);
            parameterControls["coil_СОдт"] = (1, 32);
            parameterControls["coil_NOпорог1"] = (1, 36);
            parameterControls["coil_NOпорог2"] = (1, 37);
            parameterControls["coil_NOдт"] = (1, 38);
            parameterControls["coil_NO2порог1"] = (1, 39);
            parameterControls["coil_NO2порог2"] = (1, 40);
            parameterControls["coil_NO2дт"] = (1, 41);
            parameterControls["coil_SO2порог1"] = (1, 57);
            parameterControls["coil_SO2порог2"] = (1, 58);
            parameterControls["coil_SO2дт"] = (1, 59);
            parameterControls["coil_СО2порог1"] = (1, 33);
            parameterControls["coil_СО2порог2"] = (1, 34);
            parameterControls["coil_СО2дт"] = (1, 35);
            parameterControls["coil_ЛОСпорог1"] = (1, 24);
            parameterControls["coil_ЛОСпорог2"] = (1, 25);
            parameterControls["coil_ЛОСдт"] = (1, 26);
            parameterControls["coil_ПМ1порог1"] = (2, 48);
            parameterControls["coil_ПМ1порог2"] = (2, 49);
            parameterControls["coil_ПМ1дт"] = (2, 50);
            parameterControls["coil_ПМ2_5порог1"] = (2, 51);
            parameterControls["coil_ПМ2_5порог2"] = (2, 52);
            parameterControls["coil_ПМ2_5дт"] = (2, 53);
            parameterControls["coil_ПМ10порог1"] = (2, 54);
            parameterControls["coil_ПМ10порог2"] = (2, 55);
            parameterControls["coil_ПМ10дт"] = (2, 56);
            parameterControls["coil_Вибрацияпорог1"] = (1, 63);
            parameterControls["coil_Вибрацияпорог2"] = (1, 64);
            parameterControls["coil_Вибрациядт"] = (1, 64);
            parameterControls["coil_Наклонпорог1"] = (1, 60);
            parameterControls["coil_Наклонпорог2"] = (1, 61);
            parameterControls["coil_Наклондт"] = (1, 62);
            parameterControls["coil_вскрытиепорог1"] = (3, 6);
            parameterControls["coil_вскрытиепорог2"] = (3, 7);
            parameterControls["coil_вскрытиедт"] = (3, 8);
            parameterControls["coil_Темпиратураизмерителяпорог1"] = (1, 15);
            parameterControls["coil_Темпиратураизмерителяпорог2"] = (1, 16);
            parameterControls["coil_Темпиратураизмерителядт"] = (1, 17);
            parameterControls["coil_Влажностьизмерителяпорог1"] = (1, 18);
            parameterControls["coil_Влажностьизмерителяпорог2"] = (1, 19);
            parameterControls["coil_Влажностьизмерителядт"] = (1, 20);
            parameterControls["coil_Давлениеизмерителяпорог1"] = (1, 3);
            parameterControls["coil_Давлениеизмерителяпорог2"] = (1, 4);
            parameterControls["coil_Давлениеизмерителядт"] = (1, 5);
            parameterControls["coil_Напряжениепорог1"] = (1, 6);
            parameterControls["coil_Напряжениепорог2"] = (1, 7);
            parameterControls["coil_Напряжениедт"] = (1, 8);
            parameterControls["coil_СкоростьПотокапорог1"] = (3, 75);
            parameterControls["coil_СкоростьПотокапорог2"] = (3, 76);
            parameterControls["coil_СкоростьПотокадт"] = (3, 77);

            otherDateTimeCache["holdingdate_Секунды"] = (251, 256);
            otherDateTimeCache["holdingdate_Минуты"] = (251, 257);
            otherDateTimeCache["holdingdate_Часы"] = (251, 258);
            otherDateTimeCache["holdingdate_День"] = (251, 259);
            otherDateTimeCache["holdingdate_Месяц"] = (251, 260);
            otherDateTimeCache["holdingdate_Год"] = (251, 262);

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

            setupZeroSulfurDioxide.Text = _client.ReadHoldingParametr(1, 524);
            pgc_SulfurDioxide.Text = _client.ReadHoldingParametr(1, 525);
            acp_SulfurDioxide.Text = _client.ReadHoldingParametr(1, 526);
            sumZeroSulfurDioxide.Text = _client.ReadHoldingParametr(1, 527);

            setupZeroVolatileOrganicCompounds.Text = _client.ReadHoldingParametr(1, 529);

            constAtmosphericPressure.Text = _client.ReadHoldingParametr(1, 548);

            setupZeroWindSpeed.Text = _client.ReadHoldingParametr(1, 536);
            constWindSpeed.Text = _client.ReadHoldingParametr(1, 537);
            acp_windSpeed.Text = _client.ReadHoldingParametr(1, 538);
            sumZeroWindSpeed.Text = _client.ReadHoldingParametr(1, 539);

            setupZeroAdditionalInput_2.Text = _client.ReadHoldingParametr(1, 540);
            pgc_AdditionalInput_2.Text = _client.ReadHoldingParametr(1, 541);
            acp_AdditionalInput_2.Text = _client.ReadHoldingParametr(1, 542);
            sumZeroAdditionalInput_2.Text = _client.ReadHoldingParametr(1, 543);

            powerAirTemperature.Text = _client.ReadHoldingParametr(1, 258);
            constAirTemperature.Text = _client.ReadHoldingParametr(1, 259);
            stepAirTemperature.Text = _client.ReadHoldingParametr(1, 260);
            timeAirTemperature.Text = _client.ReadHoldingParametr(1, 261);

            powerRelativeHumidity.Text = _client.ReadHoldingParametr(4, 258);
            constRelativeHumidity.Text = _client.ReadHoldingParametr(4, 259);
            stepRelativeHumidity.Text = _client.ReadHoldingParametr(4, 260);
            timeRelativeHumidity.Text = _client.ReadHoldingParametr(4, 261);

            porog_1_SamplingSpeed.Text = _client.ReadHoldingParametr(3, 100);
            porog_2_SamplingSpeed.Text = _client.ReadHoldingParametr(3, 101);
            dx_SamplingSpeed.Text = _client.ReadHoldingParametr(3, 102);
            dt_SamplingSpeed.Text = _client.ReadHoldingParametr(3, 103);

            acp_NitrogenOxide.Text = x_acp.ToString();
            pgc_NitrogenOxide.Text = x_gs.ToString();
            setupZeroNitrogenOxide.Text = x0.ToString();

            setupZeroCarbonDioxide.Text = _client.ReadHoldingParametr(1, 532).ToString();
            pgc_CarbonDioxide.Text = _client.ReadHoldingParametr(1, 533).ToString();
            acp_CarbonDioxide.Text = _client.ReadHoldingParametr(1, 534).ToString();
            sumZeroCarbonDioxide.Text = _client.ReadHoldingParametr(1, 535).ToString();

            setupZeroCarbonMonoxide.Enabled = false;
            pgc_CarbonMonoxide.Enabled = false;
            acp_CarbonMonoxide.Enabled = false;
            sumZeroCarbonMonoxide.Enabled = false;
            setupZeroNitrogenOxide.Enabled = false;
            pgc_NitrogenOxide.Enabled = false;
            acp_NitrogenOxide.Enabled = false;
            sumZeroNitrogenOxide.Enabled = false;
            setupZeroNitrogenDioxide.Enabled = false;
            pgc_NitrogenDioxide.Enabled = false;
            acp_NitrogenDioxide.Enabled = false;
            sumZeroNitrogenDioxide.Enabled = false;
            setupZeroSulfurDioxide.Enabled = false;
            pgc_SulfurDioxide.Enabled = false;
            acp_SulfurDioxide.Enabled = false;
            sumZeroSulfurDioxide.Enabled = false;
            setupZeroVolatileOrganicCompounds.Enabled = false;
            constAtmosphericPressure.Enabled = false;
            constWindSpeed.Enabled = false;
            powerAirTemperature.Enabled = false;
            constAirTemperature.Enabled = false;
            stepAirTemperature.Enabled = false;
            timeAirTemperature.Enabled = false;
            powerRelativeHumidity.Enabled = false;
            constRelativeHumidity.Enabled = false;
            stepRelativeHumidity.Enabled = false;
            timeRelativeHumidity.Enabled = false;
            setupZeroCarbonDioxide.Enabled = false;
            pgc_CarbonDioxide.Enabled = false;
            acp_CarbonDioxide.Enabled = false;
            sumZeroCarbonDioxide.Enabled = false;
            setupZeroWindSpeed.Enabled = false;
            acp_windSpeed.Enabled = false;
            sumZeroWindSpeed.Enabled = false;
            setupZeroAdditionalInput_2.Enabled = false;
            pgc_AdditionalInput_2.Enabled = false;
            acp_AdditionalInput_2.Enabled = false;
            sumZeroAdditionalInput_2.Enabled = false;
            sumZeroVolatileOrganicCompounds.Enabled = false;

            async Task UpdateDataLoop0()
            {
                while (true)
                {
                    Dictionary<string, string> data = await _client.ReadMultipleValuesAsync(otherDataCache);
                    Invoke(new Action(() => UpdateDataOnForm(data)));

                    await Task.Delay(1000);
                }
            }

            // Запуск задачи для асинхронного обновления данных из другого словаря
            async Task UpdateDataLoop1()
            {
                while (true)
                {
                    Dictionary<string, string> otherData3 = await _client.ReadMultipleValuesAsync(parameterControls);

                    Invoke(new Action(() => UpdateOtherDataOnForm(otherData3)));
                    await Task.Delay(1000);
                }
            }

            async Task UpdateDataLoop2()
            {
                while (true)
                {
                    Dictionary<string, string> otherData2 = await _client.ReadMultipleValuesAsync(otherDateTimeCache);

                    Invoke(new Action(() => UpdateDateTimeOnForm(otherData2)));
                    await Task.Delay(500);
                }
            }

            async Task UpdateDataLoop3()
            {
                while (true)
                {
                    Dictionary<string, string> otherData1 = await _client.ReadMultipleValuesAsync(otherFormulParametr);
                    Invoke(new Action(() => UpdateDataFormul(otherData1)));
                    await Task.Delay(500);
                }
            }

            Task.Run(UpdateDataLoop0);
            Task.Run(UpdateDataLoop1);
            Task.Run(UpdateDataLoop2);
            Task.Run(UpdateDataLoop3);
        }

        private void UpdateDataFormul(Dictionary<string, string> data)
        {
            foreach (var kvp in data)
            {
                string paramName = kvp.Key;
                string paramValue = kvp.Value;

                if (paramName == "input_Двуокись_углерода")
                {
                    currentCarbonDioxide2.Text = paramValue;
                    currentCarbonDioxide.Text = ((Int32.Parse(paramValue) - Int32.Parse(_client.ReadHoldingParametr(1, 532))) * (Convert.ToDouble(Int32.Parse(_client.ReadHoldingParametr(1, 533))) / Convert.ToDouble(Int32.Parse(_client.ReadHoldingParametr(1, 534))))).ToString();
                    //currentCarbonDioxide2.Text = ((Int32.Parse(paramValue) - Int32.Parse(_client.ReadHoldingParametr(1, 532))) * (Convert.ToDouble(Int32.Parse(_client.ReadHoldingParametr(1, 533))) / Convert.ToDouble(Int32.Parse(_client.ReadHoldingParametr(1, 534))))).ToString();
                }
                else if (paramName == "input_Дополнительный_вход_1")
                {
                    currentWindSpeed2.Text = paramValue;
                    currentWindSpeed.Text = ((Int32.Parse(paramValue) - Int32.Parse(_client.ReadHoldingParametr(1, 536))) * (Convert.ToDouble(Int32.Parse(_client.ReadHoldingParametr(1, 537))) / Convert.ToDouble(Int32.Parse(_client.ReadHoldingParametr(1, 538))))).ToString();
                    //currentWindSpeed2.Text = ((Int32.Parse(paramValue) - Int32.Parse(_client.ReadHoldingParametr(1, 536))) * (Convert.ToDouble(Int32.Parse(_client.ReadHoldingParametr(1, 537))) / Convert.ToDouble(Int32.Parse(_client.ReadHoldingParametr(1, 538))))).ToString();
                }
                else if (paramName == "input_Дополнительный_вход_2")
                {
                    additionalInput_2.Text = paramValue;
                    additionalInput_2.Text = ((Int32.Parse(paramValue) - Int32.Parse(_client.ReadHoldingParametr(1, 540))) * (Convert.ToDouble(Int32.Parse(_client.ReadHoldingParametr(1, 541))) / Convert.ToDouble(Int32.Parse(_client.ReadHoldingParametr(1, 542))))).ToString();
                    //additionalInput_2.Text = ((Int32.Parse(paramValue) - Int32.Parse(_client.ReadHoldingParametr(1, 540))) * (Convert.ToDouble(Int32.Parse(_client.ReadHoldingParametr(1, 541))) / Convert.ToDouble(Int32.Parse(_client.ReadHoldingParametr(1, 542))))).ToString();
                }
            }
        }

        private void UpdateDataOnForm(Dictionary<string, string> data)
        {
            foreach (var kvp in data)
            {
                string paramName = kvp.Key;
                string paramValue = kvp.Value;

                if (paramName == "input_Температура_воздуха")
                {
                    currentAirTemperature.Text = ConvertToDouble(paramValue).ToString();
                }
                else if (paramName == "input_Атмосферное_давление")
                {
                    currentAtmosphericPressure.Text = paramValue;
                }
                else if (paramName == "input_Относительная_влажность")
                {
                    currentRelativeHumidity.Text = ConvertToDouble(paramValue).ToString();
                }
                else if (paramName == "input_Относительная_влажность2")
                {
                    currentRelativeHumidity.Text = ConvertToDouble(paramValue).ToString();
                }
                else if (paramName == "input_Скорость_ветра")
                {
                    currentWindSpeed.Text = ConvertToDouble(paramValue).ToString();
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
                    currentVolatileOrganicCompounds.Text = ConvertToDoubleLoc(paramValue).ToString();
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
                    currentTemperatureInSensor.Text = ConvertToDouble(paramValue).ToString();
                }
                else if (paramName == "input_Влажность_в_измерителе")
                {
                    currentHumidityInSensor.Text = ConvertToDouble(paramValue).ToString();
                }
                else if (paramName == "input_Давление_в_измерителе")
                {
                    currentPressureInSensor.Text = paramValue;
                }
                else if (paramName == "input_Скорость_пробоотбора")
                {
                    currentSamplingSpeed.Text = ConvertToDouble(paramValue).ToString();
                }
                else if (paramName == "input_Напряжение_питания")
                {
                    currentSupplyVoltage.Text = ConvertToDouble(paramValue).ToString();
                }
                if (paramName == "input_Температура_воздуха2")
                {
                    currentAirTemperature2.Text = ConvertToDouble(paramValue).ToString();
                }
                else if (paramName == "input_Атмосферное_давление")
                {
                    currentAtmosphericPressure2.Text = paramValue;
                }
                else if (paramName == "input_Относительная_влажность")
                {
                    currentRelativeHumidity2.Text = ConvertToDouble(paramValue).ToString();
                }
                else if (paramName == "input_Скорость_ветра")
                {
                    currentWindSpeed2.Text = ConvertToDouble(paramValue).ToString();
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
                else if (paramName == "input_Летучая_органика")
                {
                    currentVolatileOrganicCompounds2.Text = ConvertToDoubleLoc(paramValue).ToString();
                }
                else if (paramName == "holding_Мощьность_темпиратуры")
                {
                    powerAirTemperature.Text = paramValue;
                }
                else if (paramName == "holding_Мощьность_влажность")
                {
                    powerRelativeHumidity.Text = paramValue;
                }
            }
        }

        private void UpdateDateTimeOnForm(Dictionary<string, string> data)
        {
            string _year = _client.ReadHoldingParametrdate(251, 262).Split('-')[0];
            string _moths = _client.ReadHoldingParametrdate(251, 261).Split('-')[0];
            string _day = _client.ReadHoldingParametrdate(251, 260).Split('-')[0];
            string _hour = _client.ReadHoldingParametrdate(251, 258).Split('-')[0];
            string _minute = _client.ReadHoldingParametrdate(251, 257).Split('-')[0];
            string _second = _client.ReadHoldingParametrdate(251, 256).Split('-')[0];
            dateSensor.Text = _day + "." + _moths + "." + _year + " " + _hour + ":" + _minute + ":" + _second;
        }

        private void UpdateOtherDataOnForm(Dictionary<string, string> data)
        {
            lock (parameterControls)
            {
                foreach (var kvp in data)
                {
                    string paramName = kvp.Key;
                    string paramValue = kvp.Value;

                    if (paramName == "coil_Температура_Порог_1")
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
                        porog_1_PressureInSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    }
                    else if (paramName == "coil_Давлениеизмерителяпорог2")
                    {
                        porog_2_PressureInSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    }
                    else if (paramName == "coil_Давлениеизмерителядт")
                    {
                        dx_PressureInSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                        dt_PressureInSensor.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    }
                    else if (paramName == "coil_Напряжениепорог1")
                    {
                        porog_1_SupplyVoltage.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    }
                    else if (paramName == "coil_Напряжениепорог2")
                    {
                        porog_2_SupplyVoltage.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    }
                    else if (paramName == "coil_Напряжениедт")
                    {
                        dx_SupplyVoltage.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                        dt_SupplyVoltage.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    }
                    else if (paramName == "coil_СкоростьПотокапорог1")
                    {
                        porog_1_SamplingSpeed.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    }
                    else if (paramName == "coil_СкоростьПотокапорог2")
                    {
                        porog_2_SamplingSpeed.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    }
                    else if (paramName == "coil_СкоростьПотокадт")
                    {
                        dx_SamplingSpeed.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                        dt_SamplingSpeed.ForeColor = bool.Parse(paramValue) ? Color.Red : Color.White;
                    }
                }
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
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_AirTemperature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 21, ushort.Parse(porog_2_AirTemperature.Text));
                porog_2_AirTemperature.Text = _client.ReadHoldingParametr(2, 21);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_AirTemperature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 22, ushort.Parse(dx_AirTemperature.Text));
                dx_AirTemperature.Text = _client.ReadHoldingParametr(2, 22);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_AirTemperature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 23, ushort.Parse(dt_AirTemperature.Text));
                dt_AirTemperature.Text = _client.ReadHoldingParametr(2, 23);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_RelativeHumidity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 24, ushort.Parse(porog_1_RelativeHumidity.Text));
                porog_1_RelativeHumidity.Text = _client.ReadHoldingParametr(2, 24);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_RelativeHumidity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 25, ushort.Parse(porog_2_RelativeHumidity.Text));
                porog_2_RelativeHumidity.Text = _client.ReadHoldingParametr(2, 25);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_RelativeHumidity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 26, ushort.Parse(dx_RelativeHumidity.Text));
                dx_RelativeHumidity.Text = _client.ReadHoldingParametr(2, 26);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_RelativeHumidity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 27, ushort.Parse(dt_RelativeHumidity.Text));
                dt_RelativeHumidity.Text = _client.ReadHoldingParametr(2, 27);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_AtmosphericPressure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 4, ushort.Parse(porog_1_AtmosphericPressure.Text));
                porog_1_AtmosphericPressure.Text = _client.ReadHoldingParametr(2, 4);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_AtmosphericPressure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 5, ushort.Parse(porog_2_AtmosphericPressure.Text));
                porog_2_AtmosphericPressure.Text = _client.ReadHoldingParametr(2, 5);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_AtmosphericPressure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 6, ushort.Parse(dx_AtmosphericPressure.Text));
                dx_AtmosphericPressure.Text = _client.ReadHoldingParametr(2, 6);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_AtmosphericPressure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 7, ushort.Parse(dt_AtmosphericPressure.Text));
                dt_AtmosphericPressure.Text = _client.ReadHoldingParametr(2, 7);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_WindSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 28, ushort.Parse(porog_1_WindSpeed.Text));
                porog_1_WindSpeed.Text = _client.ReadHoldingParametr(1, 28);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_WindSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 29, ushort.Parse(porog_2_WindSpeed.Text));
                porog_2_WindSpeed.Text = _client.ReadHoldingParametr(1, 29);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_WindSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 30, ushort.Parse(dx_WindSpeed.Text));
                dx_WindSpeed.Text = _client.ReadHoldingParametr(1, 30);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_WindSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 31, ushort.Parse(dt_WindSpeed.Text));
                dt_WindSpeed.Text = _client.ReadHoldingParametr(1, 31);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_WindDirection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 8, ushort.Parse(porog_1_WindDirection.Text));
                porog_1_WindDirection.Text = _client.ReadHoldingParametr(2, 8);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_WindDirection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 9, ushort.Parse(porog_2_WindDirection.Text));
                porog_2_WindDirection.Text = _client.ReadHoldingParametr(2, 9);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_WindDirection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 10, ushort.Parse(dx_WindDirection.Text));
                dx_WindDirection.Text = _client.ReadHoldingParametr(2, 10);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_WindDirection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 11, ushort.Parse(dt_WindDirection.Text));
                dt_WindDirection.Text = _client.ReadHoldingParametr(2, 11);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_CarbonMonoxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 40, ushort.Parse(porog_1_CarbonMonoxide.Text));
                porog_1_CarbonMonoxide.Text = _client.ReadHoldingParametr(1, 40);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_CarbonMonoxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 41, ushort.Parse(porog_2_CarbonMonoxide.Text));
                porog_2_CarbonMonoxide.Text = _client.ReadHoldingParametr(1, 41);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_CarbonMonoxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 42, ushort.Parse(dx_CarbonMonoxide.Text));
                dx_CarbonMonoxide.Text = _client.ReadHoldingParametr(1, 42);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_CarbonMonoxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 43, ushort.Parse(dt_CarbonMonoxide.Text));
                dt_CarbonMonoxide.Text = _client.ReadHoldingParametr(1, 43);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_NitrogenOxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 48, ushort.Parse(porog_1_NitrogenOxide.Text));
                porog_1_NitrogenOxide.Text = _client.ReadHoldingParametr(1, 48);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_NitrogenOxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 49, ushort.Parse(porog_2_NitrogenOxide.Text));
                porog_2_NitrogenOxide.Text = _client.ReadHoldingParametr(1, 49);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_NitrogenOxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 50, ushort.Parse(dx_NitrogenOxide.Text));
                dx_NitrogenOxide.Text = _client.ReadHoldingParametr(1, 50);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_NitrogenOxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 51, ushort.Parse(dt_NitrogenOxide.Text));
                dt_NitrogenOxide.Text = _client.ReadHoldingParametr(1, 51);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_NitrogenDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 52, ushort.Parse(porog_1_NitrogenDioxide.Text));
                porog_1_NitrogenDioxide.Text = _client.ReadHoldingParametr(1, 52);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_NitrogenDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 53, ushort.Parse(porog_2_NitrogenDioxide.Text));
                porog_2_NitrogenDioxide.Text = _client.ReadHoldingParametr(1, 53);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_NitrogenDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 54, ushort.Parse(dx_NitrogenDioxide.Text));
                dx_NitrogenDioxide.Text = _client.ReadHoldingParametr(1, 54);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_NitrogenDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 55, ushort.Parse(dt_NitrogenDioxide.Text));
                dt_NitrogenDioxide.Text = _client.ReadHoldingParametr(1, 55);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_SulfurDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 76, ushort.Parse(porog_1_SulfurDioxide.Text));
                porog_1_SulfurDioxide.Text = _client.ReadHoldingParametr(1, 76);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_SulfurDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 77, ushort.Parse(porog_2_SulfurDioxide.Text));
                porog_2_SulfurDioxide.Text = _client.ReadHoldingParametr(1, 77);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_SulfurDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 78, ushort.Parse(dx_SulfurDioxide.Text));
                dx_SulfurDioxide.Text = _client.ReadHoldingParametr(1, 78);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_SulfurDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 79, ushort.Parse(dt_SulfurDioxide.Text));
                dt_SulfurDioxide.Text = _client.ReadHoldingParametr(1, 79);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_CarbonDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 44, ushort.Parse(porog_1_CarbonDioxide.Text));
                porog_1_CarbonDioxide.Text = _client.ReadHoldingParametr(1, 44);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_CarbonDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 45, ushort.Parse(porog_2_CarbonDioxide.Text));
                porog_2_CarbonDioxide.Text = _client.ReadHoldingParametr(1, 45);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_CarbonDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 46, ushort.Parse(dx_CarbonDioxide.Text));
                dx_CarbonDioxide.Text = _client.ReadHoldingParametr(1, 46);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_CarbonDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 47, ushort.Parse(dt_CarbonDioxide.Text));
                dt_CarbonDioxide.Text = _client.ReadHoldingParametr(1, 47);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_VolatileOrganicCompounds_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 32, ushort.Parse(porog_1_VolatileOrganicCompounds.Text));
                porog_1_VolatileOrganicCompounds.Text = _client.ReadHoldingParametr(1, 32);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_VolatileOrganicCompounds_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 33, ushort.Parse(porog_2_VolatileOrganicCompounds.Text));
                porog_2_VolatileOrganicCompounds.Text = _client.ReadHoldingParametr(1, 33);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_VolatileOrganicCompounds_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 34, ushort.Parse(dx_VolatileOrganicCompounds.Text));
                dx_VolatileOrganicCompounds.Text = _client.ReadHoldingParametr(1, 34);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_VolatileOrganicCompounds_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 35, ushort.Parse(dt_VolatileOrganicCompounds.Text));
                dt_VolatileOrganicCompounds.Text = _client.ReadHoldingParametr(1, 35);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_ParticulateMatterPM1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 64, ushort.Parse(porog_1_ParticulateMatterPM1.Text));
                porog_1_ParticulateMatterPM1.Text = _client.ReadHoldingParametr(2, 64);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_ParticulateMatterPM1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 65, ushort.Parse(porog_2_ParticulateMatterPM1.Text));
                porog_2_ParticulateMatterPM1.Text = _client.ReadHoldingParametr(2, 65);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_ParticulateMatterPM1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 66, ushort.Parse(dx_ParticulateMatterPM1.Text));
                dx_ParticulateMatterPM1.Text = _client.ReadHoldingParametr(2, 66);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_ParticulateMatterPM1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 67, ushort.Parse(dt_ParticulateMatterPM1.Text));
                dt_ParticulateMatterPM1.Text = _client.ReadHoldingParametr(2, 67);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_ParticulateMatterPM2_5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 68, ushort.Parse(porog_1_ParticulateMatterPM2_5.Text));
                porog_1_ParticulateMatterPM2_5.Text = _client.ReadHoldingParametr(2, 68);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_ParticulateMatterPM2_5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 69, ushort.Parse(porog_2_ParticulateMatterPM2_5.Text));
                porog_2_ParticulateMatterPM2_5.Text = _client.ReadHoldingParametr(2, 69);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_ParticulateMatterPM2_5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 70, ushort.Parse(dx_ParticulateMatterPM2_5.Text));
                dx_ParticulateMatterPM2_5.Text = _client.ReadHoldingParametr(2, 70);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_ParticulateMatterPM2_5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 71, ushort.Parse(dt_ParticulateMatterPM2_5.Text));
                dt_ParticulateMatterPM2_5.Text = _client.ReadHoldingParametr(2, 71);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_ParticulateMatterPM10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 72, ushort.Parse(porog_1_ParticulateMatterPM10.Text));
                porog_1_ParticulateMatterPM10.Text = _client.ReadHoldingParametr(2, 72);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_ParticulateMatterPM10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 73, ushort.Parse(porog_2_ParticulateMatterPM10.Text));
                porog_2_ParticulateMatterPM10.Text = _client.ReadHoldingParametr(2, 73);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_ParticulateMatterPM10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 74, ushort.Parse(dx_ParticulateMatterPM10.Text));
                dx_ParticulateMatterPM10.Text = _client.ReadHoldingParametr(2, 74);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_ParticulateMatterPM10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(2, 75, ushort.Parse(dt_ParticulateMatterPM10.Text));
                dt_ParticulateMatterPM10.Text = _client.ReadHoldingParametr(2, 75);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_VibrationLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 84, ushort.Parse(porog_1_VibrationLevel.Text));
                porog_1_VibrationLevel.Text = _client.ReadHoldingParametr(1, 84);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_VibrationLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 85, ushort.Parse(porog_2_VibrationLevel.Text));
                porog_2_VibrationLevel.Text = _client.ReadHoldingParametr(1, 85);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_VibrationLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 86, ushort.Parse(dx_VibrationLevel.Text));
                dx_VibrationLevel.Text = _client.ReadHoldingParametr(1, 86);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_VibrationLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 87, ushort.Parse(dt_VibrationLevel.Text));
                dt_VibrationLevel.Text = _client.ReadHoldingParametr(1, 87);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_TiltLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 80, ushort.Parse(porog_1_TiltLevel.Text));
                porog_1_TiltLevel.Text = _client.ReadHoldingParametr(1, 80);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_TiltLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 81, ushort.Parse(porog_2_TiltLevel.Text));
                porog_2_TiltLevel.Text = _client.ReadHoldingParametr(1, 81);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_TiltLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 82, ushort.Parse(dx_TiltLevel.Text));
                dx_TiltLevel.Text = _client.ReadHoldingParametr(1, 82);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_TiltLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 83, ushort.Parse(dt_TiltLevel.Text));
                dt_TiltLevel.Text = _client.ReadHoldingParametr(1, 83);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_TamperSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(3, 8, ushort.Parse(porog_1_TamperSensor.Text));
                porog_1_TamperSensor.Text = _client.ReadHoldingParametr(3, 8);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_TamperSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(3, 9, ushort.Parse(porog_2_TamperSensor.Text));
                porog_2_TamperSensor.Text = _client.ReadHoldingParametr(3, 9);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_TamperSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(3, 10, ushort.Parse(dx_TamperSensor.Text));
                dx_TamperSensor.Text = _client.ReadHoldingParametr(3, 10);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_TamperSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(3, 11, ushort.Parse(dt_TamperSensor.Text));
                dt_TamperSensor.Text = _client.ReadHoldingParametr(3, 11);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_TemperatureInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 20, ushort.Parse(porog_1_TemperatureInSensor.Text));
                porog_1_TemperatureInSensor.Text = _client.ReadHoldingParametr(1, 20);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_TemperatureInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 21, ushort.Parse(porog_2_TemperatureInSensor.Text));
                porog_2_TemperatureInSensor.Text = _client.ReadHoldingParametr(1, 21);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_TemperatureInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 22, ushort.Parse(dx_TemperatureInSensor.Text));
                dx_TemperatureInSensor.Text = _client.ReadHoldingParametr(1, 22);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_TemperatureInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 23, ushort.Parse(dt_TemperatureInSensor.Text));
                dt_TemperatureInSensor.Text = _client.ReadHoldingParametr(1, 23);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_HumidityInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 24, ushort.Parse(porog_1_HumidityInSensor.Text));
                porog_1_HumidityInSensor.Text = _client.ReadHoldingParametr(1, 24);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_HumidityInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 25, ushort.Parse(porog_2_HumidityInSensor.Text));
                porog_2_HumidityInSensor.Text = _client.ReadHoldingParametr(1, 25);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_HumidityInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 26, ushort.Parse(dx_HumidityInSensor.Text));
                dx_HumidityInSensor.Text = _client.ReadHoldingParametr(1, 26);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_HumidityInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 27, ushort.Parse(dt_HumidityInSensor.Text));
                dt_HumidityInSensor.Text = _client.ReadHoldingParametr(1, 27);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_SupplyVoltage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 8, ushort.Parse(porog_1_SupplyVoltage.Text));
                porog_1_SupplyVoltage.Text = _client.ReadHoldingParametr(1, 8);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_SupplyVoltage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 9, ushort.Parse(porog_2_SupplyVoltage.Text));
                porog_2_SupplyVoltage.Text = _client.ReadHoldingParametr(1, 9);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_SupplyVoltage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 10, ushort.Parse(dx_SupplyVoltage.Text));
                dx_SupplyVoltage.Text = _client.ReadHoldingParametr(1, 10);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_SupplyVoltage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 11, ushort.Parse(dt_SupplyVoltage.Text));
                dt_SupplyVoltage.Text = _client.ReadHoldingParametr(1, 11);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_1_PressureInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 4, ushort.Parse(porog_1_PressureInSensor.Text));
                porog_1_PressureInSensor.Text = _client.ReadHoldingParametr(1, 4);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_PressureInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 5, ushort.Parse(porog_2_PressureInSensor.Text));
                porog_2_PressureInSensor.Text = _client.ReadHoldingParametr(1, 5);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_PressureInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 6, ushort.Parse(dx_PressureInSensor.Text));
                dx_PressureInSensor.Text = _client.ReadHoldingParametr(1, 6);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_PressureInSensor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 7, ushort.Parse(dt_PressureInSensor.Text));
                dt_PressureInSensor.Text = _client.ReadHoldingParametr(1, 7);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void setupZeroCarbonMonoxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 520, ushort.Parse(setupZeroCarbonMonoxide.Text));
                setupZeroCarbonMonoxide.Text = _client.ReadHoldingParametr(1, 520);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void pgc_CarbonMonoxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 521, ushort.Parse(pgc_CarbonMonoxide.Text));
                pgc_CarbonMonoxide.Text = _client.ReadHoldingParametr(1, 521);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void acp_CarbonMonoxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 522, ushort.Parse(acp_CarbonMonoxide.Text));
                acp_CarbonMonoxide.Text = _client.ReadHoldingParametr(1, 522);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void sumZeroCarbonMonoxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 523, ushort.Parse(sumZeroCarbonMonoxide.Text));
                sumZeroCarbonMonoxide.Text = _client.ReadHoldingParametr(1, 523);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void setupZeroNitrogenOxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 512, ushort.Parse(setupZeroNitrogenOxide.Text));
                setupZeroNitrogenOxide.Text = _client.ReadHoldingParametr(1, 512);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void pgc_NitrogenOxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 513, ushort.Parse(pgc_NitrogenOxide.Text));
                pgc_NitrogenOxide.Text = _client.ReadHoldingParametr(1, 513);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void acp_NitrogenOxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 514, ushort.Parse(acp_NitrogenOxide.Text));
                acp_NitrogenOxide.Text = _client.ReadHoldingParametr(1, 514);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void sumZeroNitrogenOxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 515, ushort.Parse(sumZeroNitrogenOxide.Text));
                sumZeroNitrogenOxide.Text = _client.ReadHoldingParametr(1, 515);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void setupZeroNitrogenDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 516, ushort.Parse(setupZeroNitrogenDioxide.Text));
                setupZeroNitrogenDioxide.Text = _client.ReadHoldingParametr(1, 516);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void pgc_NitrogenDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 517, ushort.Parse(pgc_NitrogenDioxide.Text));
                pgc_NitrogenDioxide.Text = _client.ReadHoldingParametr(1, 517);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void acp_NitrogenDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 518, ushort.Parse(acp_NitrogenDioxide.Text));
                acp_NitrogenDioxide.Text = _client.ReadHoldingParametr(1, 518);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void sumZeroNitrogenDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 519, ushort.Parse(sumZeroNitrogenDioxide.Text));
                sumZeroNitrogenDioxide.Text = _client.ReadHoldingParametr(1, 519);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void setupZeroSulfurDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 524, ushort.Parse(setupZeroSulfurDioxide.Text));
                setupZeroSulfurDioxide.Text = _client.ReadHoldingParametr(1, 524);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void pgc_SulfurDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 525, ushort.Parse(pgc_SulfurDioxide.Text));
                pgc_SulfurDioxide.Text = _client.ReadHoldingParametr(1, 525);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void acp_SulfurDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 526, ushort.Parse(acp_SulfurDioxide.Text));
                acp_SulfurDioxide.Text = _client.ReadHoldingParametr(1, 526);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void sumZeroSulfurDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 527, ushort.Parse(sumZeroSulfurDioxide.Text));
                sumZeroSulfurDioxide.Text = _client.ReadHoldingParametr(1, 527);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void setupZeroVolatileOrganicCompounds_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 529, ushort.Parse(setupZeroVolatileOrganicCompounds.Text));
                setupZeroVolatileOrganicCompounds.Text = _client.ReadHoldingParametr(1, 529);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void constAtmosphericPressure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 548, ushort.Parse(constAtmosphericPressure.Text));
                constAtmosphericPressure.Text = _client.ReadHoldingParametr(1, 548);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void powerAirTemperature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 258, ushort.Parse(powerAirTemperature.Text));
                powerAirTemperature.Text = _client.ReadHoldingParametr(1, 258);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void constAirTemperature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 259, ushort.Parse(constAirTemperature.Text));
                constAirTemperature.Text = _client.ReadHoldingParametr(1, 259);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void stepAirTemperature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 260, ushort.Parse(stepAirTemperature.Text));
                stepAirTemperature.Text = _client.ReadHoldingParametr(1, 260);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void timeAirTemperature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 261, ushort.Parse(timeAirTemperature.Text));
                timeAirTemperature.Text = _client.ReadHoldingParametr(1, 261);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void powerRelativeHumidity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(3, 258, ushort.Parse(powerRelativeHumidity.Text));
                powerRelativeHumidity.Text = _client.ReadHoldingParametr(4, 258);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void constRelativeHumidity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(3, 259, ushort.Parse(constRelativeHumidity.Text));
                constRelativeHumidity.Text = _client.ReadHoldingParametr(4, 259);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void stepRelativeHumidity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(3, 260, ushort.Parse(stepRelativeHumidity.Text));
                stepRelativeHumidity.Text = _client.ReadHoldingParametr(4, 260);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void timeRelativeHumidity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(3, 261, ushort.Parse(timeRelativeHumidity.Text));
                timeRelativeHumidity.Text = _client.ReadHoldingParametr(4, 261);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        bool lockSetting = false;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == _client.ReadHoldingParametr(1, 530) + "" + _client.ReadHoldingParametr(1, 531))
            {
                // Проверяем, была ли уже изменена иконка
                if (lockSetting)
                {
                    // Если иконка уже была изменена, то меняем на исходную
                    pictureBox2.Image = Properties.Resources.password_red; // Замените "original_icon" на имя ресурса иконки по умолчанию
                    setupZeroCarbonMonoxide.Enabled = false;
                    pgc_CarbonMonoxide.Enabled = false;
                    acp_CarbonMonoxide.Enabled = false;
                    sumZeroCarbonMonoxide.Enabled = false;
                    setupZeroNitrogenOxide.Enabled = false;
                    pgc_NitrogenOxide.Enabled = false;
                    acp_NitrogenOxide.Enabled = false;
                    sumZeroNitrogenOxide.Enabled = false;
                    setupZeroNitrogenDioxide.Enabled = false;
                    pgc_NitrogenDioxide.Enabled = false;
                    acp_NitrogenDioxide.Enabled = false;
                    sumZeroNitrogenDioxide.Enabled = false;
                    setupZeroSulfurDioxide.Enabled = false;
                    pgc_SulfurDioxide.Enabled = false;
                    acp_SulfurDioxide.Enabled = false;
                    sumZeroSulfurDioxide.Enabled = false;
                    setupZeroVolatileOrganicCompounds.Enabled = false;
                    constAtmosphericPressure.Enabled = false;
                    constWindSpeed.Enabled = false;
                    powerAirTemperature.Enabled = false;
                    constAirTemperature.Enabled = false;
                    stepAirTemperature.Enabled = false;
                    timeAirTemperature.Enabled = false;
                    powerRelativeHumidity.Enabled = false;
                    constRelativeHumidity.Enabled = false;
                    stepRelativeHumidity.Enabled = false;
                    timeRelativeHumidity.Enabled = false;
                    setupZeroCarbonDioxide.Enabled = false;
                    pgc_CarbonDioxide.Enabled = false;
                    acp_CarbonDioxide.Enabled = false;
                    sumZeroCarbonDioxide.Enabled = false;
                    setupZeroWindSpeed.Enabled = false;
                    acp_windSpeed.Enabled = false;
                    sumZeroWindSpeed.Enabled = false;
                    setupZeroAdditionalInput_2.Enabled = false;
                    pgc_AdditionalInput_2.Enabled = false;
                    acp_AdditionalInput_2.Enabled = false;
                    sumZeroAdditionalInput_2.Enabled = false;
                    sumZeroVolatileOrganicCompounds.Enabled = false;
                }
                else
                {
                    // Если иконка не была изменена, то меняем на новую иконку
                    pictureBox2.Image = Properties.Resources.password_green; // Замените "new_icon" на имя ресурса новой иконки
                    setupZeroCarbonMonoxide.Enabled = true;
                    pgc_CarbonMonoxide.Enabled = true;
                    acp_CarbonMonoxide.Enabled = true;
                    sumZeroCarbonMonoxide.Enabled = true;
                    setupZeroNitrogenOxide.Enabled = true;
                    pgc_NitrogenOxide.Enabled = true;
                    acp_NitrogenOxide.Enabled = true;
                    sumZeroNitrogenOxide.Enabled = true;
                    setupZeroCarbonDioxide.Enabled = true;
                    pgc_CarbonDioxide.Enabled = true;
                    acp_CarbonDioxide.Enabled = true;
                    sumZeroCarbonDioxide.Enabled = true;
                    setupZeroNitrogenDioxide.Enabled = true;
                    pgc_NitrogenDioxide.Enabled = true;
                    acp_NitrogenDioxide.Enabled = true;
                    sumZeroNitrogenDioxide.Enabled = true;
                    setupZeroSulfurDioxide.Enabled = true;
                    pgc_SulfurDioxide.Enabled = true;
                    acp_SulfurDioxide.Enabled = true;
                    sumZeroSulfurDioxide.Enabled = true;
                    setupZeroVolatileOrganicCompounds.Enabled = true;
                    constAtmosphericPressure.Enabled = true;
                    constWindSpeed.Enabled = true;
                    powerAirTemperature.Enabled = true;
                    constAirTemperature.Enabled = true;
                    stepAirTemperature.Enabled = true;
                    timeAirTemperature.Enabled = true;
                    powerRelativeHumidity.Enabled = true;
                    constRelativeHumidity.Enabled = true;
                    stepRelativeHumidity.Enabled = true;
                    timeRelativeHumidity.Enabled = true;
                    setupZeroWindSpeed.Enabled = true;
                    acp_windSpeed.Enabled = true;
                    sumZeroWindSpeed.Enabled = true;
                    setupZeroAdditionalInput_2.Enabled = true;
                    pgc_AdditionalInput_2.Enabled = true;
                    acp_AdditionalInput_2.Enabled = true;
                    sumZeroAdditionalInput_2.Enabled = true;
                    sumZeroVolatileOrganicCompounds.Enabled = true;
                }

                // Инвертируем состояние флага isIconChanged
                lockSetting = !lockSetting;
            }
        }

        public static double ConvertToDouble(string stringValue)
        {
            // Преобразуем строку в целое число
            int integerValue = int.Parse(stringValue);

            // Делим целое число на 10.0, чтобы получить число с плавающей точкой
            double doubleValue = integerValue / 10.0;

            return doubleValue;
        }
        public static double ConvertToDoubleLoc(string stringValue)
        {
            // Преобразуем строку в целое число
            int integerValue = int.Parse(stringValue);

            // Делим целое число на 10.0, чтобы получить число с плавающей точкой
            double doubleValue = integerValue / 100.0;

            return doubleValue;
        }

        private void porog_1_SamplingSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(3, 100, ushort.Parse(porog_1_SamplingSpeed.Text));
                porog_1_SamplingSpeed.Text = _client.ReadHoldingParametr(3, 100);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void porog_2_SamplingSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(3, 101, ushort.Parse(porog_2_SamplingSpeed.Text));
                porog_2_SamplingSpeed.Text = _client.ReadHoldingParametr(3, 101);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dx_SamplingSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(3, 102, ushort.Parse(dx_SamplingSpeed.Text));
                dx_SamplingSpeed.Text = _client.ReadHoldingParametr(3, 102);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void dt_SamplingSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(3, 103, ushort.Parse(dt_SamplingSpeed.Text));
                dt_SamplingSpeed.Text = _client.ReadHoldingParametr(3, 103);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void setupZeroCarbonDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 532, ushort.Parse(setupZeroCarbonDioxide.Text));
                setupZeroCarbonDioxide.Text = _client.ReadHoldingParametr(1, 532);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void pgc_CarbonDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 533, ushort.Parse(pgc_CarbonDioxide.Text));
                pgc_CarbonDioxide.Text = _client.ReadHoldingParametr(1, 533);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void acp_CarbonDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 534, ushort.Parse(acp_CarbonDioxide.Text));
                acp_CarbonDioxide.Text = _client.ReadHoldingParametr(1, 534);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void sumZeroCarbonDioxide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 535, ushort.Parse(sumZeroCarbonDioxide.Text));
                sumZeroCarbonDioxide.Text = _client.ReadHoldingParametr(1, 535);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void setupZeroWindSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 536, ushort.Parse(setupZeroWindSpeed.Text));
                setupZeroWindSpeed.Text = _client.ReadHoldingParametr(1, 536);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void constWindSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 537, ushort.Parse(constWindSpeed.Text));
                constWindSpeed.Text = _client.ReadHoldingParametr(1, 537);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void acp_windSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 538, ushort.Parse(acp_windSpeed.Text));
                acp_windSpeed.Text = _client.ReadHoldingParametr(1, 538);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void sumZeroWindSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 539, ushort.Parse(sumZeroWindSpeed.Text));
                sumZeroWindSpeed.Text = _client.ReadHoldingParametr(1, 539);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void setupZeroAdditionalInput_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 540, ushort.Parse(setupZeroAdditionalInput_2.Text));
                setupZeroAdditionalInput_2.Text = _client.ReadHoldingParametr(1, 540);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void pgc_AdditionalInput_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 541, ushort.Parse(pgc_AdditionalInput_2.Text));
                pgc_AdditionalInput_2.Text = _client.ReadHoldingParametr(1, 541);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void acp_AdditionalInput_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 542, ushort.Parse(acp_AdditionalInput_2.Text));
                acp_AdditionalInput_2.Text = _client.ReadHoldingParametr(1, 542);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }

        private void sumZeroAdditionalInput_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _client.WriteHoldingParametr(1, 543, ushort.Parse(sumZeroAdditionalInput_2.Text));
                sumZeroAdditionalInput_2.Text = _client.ReadHoldingParametr(1, 543);
                MessageBox.Show("Данные отправлены", "Уведомление");
            }
        }
    }
}