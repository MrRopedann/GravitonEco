using GravitonEcoV2.Helpers;
using GravitonEcoV2.Updaters;
using GravitonEcoV2.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GravitonEcoV2
{
    public partial class MainForm : Form
    {
        private List<RadioButton> allRadioButtons = new List<RadioButton>();
        private List<SensorUpdater> sensorUpdaters = new List<SensorUpdater>();

        public MainForm()
        {
            InitializeComponent();

            allRadioButtons.Add(radioButton1);
            allRadioButtons.Add(radioButton2);
            allRadioButtons.Add(radioButton3);
            allRadioButtons.Add(radioButton4);
            allRadioButtons.Add(radioButton5);
            allRadioButtons.Add(radioButton6);
            allRadioButtons.Add(radioButton7);
            allRadioButtons.Add(radioButton8);
            allRadioButtons.Add(radioButton9);
            allRadioButtons.Add(radioButton10);
            allRadioButtons.Add(radioButton11);
            allRadioButtons.Add(radioButton12);
            allRadioButtons.Add(radioButton13);
            allRadioButtons.Add(radioButton14);
            allRadioButtons.Add(radioButton15);
            allRadioButtons.Add(radioButton16);
            allRadioButtons.Add(radioButton17);
            allRadioButtons.Add(radioButton18);
            allRadioButtons.Add(radioButton19);
            allRadioButtons.Add(radioButton20);
            allRadioButtons.Add(radioButton21);
            allRadioButtons.Add(radioButton22);

            // Привязываем событие CheckedChanged к обработчику
            foreach (RadioButton radioButton in allRadioButtons)
            {
                radioButton.CheckedChanged += radioButton_CheckedChanged;
            }

            /* Разметка колонок (начало) */
            int[] columnWidths = secondaryContentTableLayoutPanel1.GetColumnWidths();
            int[] rowHeights = secondaryContentTableLayoutPanel1.GetRowHeights();

            int[] columnWidths2 = tableLayoutPanel2.GetColumnWidths();
            int[] rowHeights2 = tableLayoutPanel2.GetRowHeights();

            TableLayoutPanel[] tableLayouts = { secondaryContentTableLayoutPanel2, secondaryContentTableLayoutPanel3, secondaryContentTableLayoutPanel4, secondaryContentTableLayoutPanel5 };

            TableLayoutPanel[] tableLayoutPanels = { tableLayoutPanel2, tableLayoutPanel3 };

            LayoutHelper.ApplyColumnRowLayout(tableLayouts, columnWidths, rowHeights);
            LayoutHelper.ApplyColumnRowLayout(tableLayoutPanels, columnWidths2, rowHeights2);

            /* Разметка колонок (конец) */

            Series series2 = new Series("Series2");
            series2.ChartType = SeriesChartType.Line;
            series2.BorderWidth = 3;
            chart1.ChartAreas[0].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            // Настройка цвета меток на осях
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190))))); // Цвет меток по оси X
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190))))); // Цвет меток по оси Y

            series2.Points.AddXY(0, 0);
            series2.Points.AddXY(1, 20);
            series2.Points.AddXY(2, 35);
            series2.Points.AddXY(3, 15);
            series2.Points.AddXY(4, 10);
            series2.Points.AddXY(5, 20);
            series2.Points.AddXY(6, 65);
            series2.LegendText = "Температура";
            series2.Color = System.Drawing.Color.Red;

            // Добавляем серию к графику
            chart1.Series.Add(series2);

           ModbusConnectionManager modbusConnectionManager = ModbusConnectionManager.Instance;

            ///*Тесты на эмуляторе*/
            ////Task.Run(() => _ = new SensorUpdater(currentAirTemperature, modbusConnectionManager, 1, 5, 1));
            ////Task.Run(() => _ = new PorogUpdater(porog_1_AirTemperature, modbusConnectionManager, 1, 18, 1));
            //var in1 = new PorogInitialize(porog_1_AirTemperature, modbusConnectionManager, 1, 1, 1);

            Task.Run(() =>
                UpdateSensorConnection(modbusConnectionManager)
            );

            ///* Обновление текущих значений */
            //Внешние
            _ = new SensorUpdater(currentAirTemperature, modbusConnectionManager, 2, 5, 1);
            _ = new SensorUpdater(currentRelativeHumidity, modbusConnectionManager, 2, 6, 1);
            _ = new SensorUpdater(currentAtmosphericPressure, modbusConnectionManager, 2, 1, 1);
            _ = new SensorUpdater(currentWindSpeed, modbusConnectionManager, 1, 544, 1);
            _ = new SensorUpdater(currentWindDirection, modbusConnectionManager, 2, 2, 1);
            //Газы
            _ = new SensorUpdater(currentCarbonMonoxide, modbusConnectionManager, 1, 11, 1);
            _ = new SensorUpdater(currentCarbonDioxide, modbusConnectionManager, 1, 10, 1);
            _ = new SensorUpdater(currentNitrogenOxide, modbusConnectionManager, 1, 12, 1);
            _ = new SensorUpdater(currentNitrogenDioxide, modbusConnectionManager, 1, 13, 1);
            _ = new SensorUpdater(currentSulfurDioxide, modbusConnectionManager, 1, 19, 1);
            _ = new SensorUpdater(currentVolatileOrganicCompounds, modbusConnectionManager, 1, 8, 1);
            // PM
            _ = new SensorUpdater(currentParticulateMatterPM1, modbusConnectionManager, 2, 16, 1);
            _ = new SensorUpdater(currentParticulateMatterPM2_5, modbusConnectionManager, 2, 17, 1);
            _ = new SensorUpdater(currentParticulateMatterPM10, modbusConnectionManager, 2, 18, 1);
            // Охранная система
            _ = new SensorUpdater(currentVibrationLevel, modbusConnectionManager, 1, 21, 1);
            _ = new SensorUpdater(currentTiltLevel, modbusConnectionManager, 1, 20, 1);
            //_ = new SensorUpdater(currentTamperSensor, modbusConnectionManager, 3, 2, 1);// Нет инфы по регистрам
            currentTamperSensor.Enabled = false;
            // Внутренее(Не уверен за адреса и регистры)
            //_ = new SensorUpdater(currentTemperatureInSensor, modbusConnectionManager, 1, 5, 1);
            currentTemperatureInSensor.Enabled = false;
            //_ = new SensorUpdater(currentHumidityInSensor, modbusConnectionManager, 1, 6, 1);
            currentHumidityInSensor.Enabled = false;
            //_ = new SensorUpdater(currentSupplyVoltage, modbusConnectionManager, 1, 2, 1);
            currentSupplyVoltage.Enabled = false;
            //_ = new SensorUpdater(currentSamplingSpeed, modbusConnectionManager, 3, 25, 1);
            currentSamplingSpeed.Enabled = false;
            //_ = new SensorUpdater(currentPressureInSensor, modbusConnectionManager, 1, 1, 1);
            currentPressureInSensor.Enabled = false;
            // Сработки парогов

            //var t1 = new PorogUpdater(porog_1_AirTemperature, modbusConnectionManager, 2, 15, 1);
            //var t2 = new PorogUpdater(porog_2_AirTemperature, modbusConnectionManager, 2, 16, 1);
            //var t3 = new PorogUpdater(dx_AirTemperature, modbusConnectionManager, 2, 17, 1);
            //var t4 = new PorogUpdater(dt_AirTemperature, modbusConnectionManager, 2, 18, 1);

            //var t5 = new PorogUpdater(porog_1_RelativeHumidity, modbusConnectionManager, 2, 19, 1);
            //var t6 = new PorogUpdater(porog_2_RelativeHumidity, modbusConnectionManager, 2, 20, 1);
            //var t7 = new PorogUpdater(dx_RelativeHumidity, modbusConnectionManager, 2, 3, 1);
            //var t8 = new PorogUpdater(dt_RelativeHumidity, modbusConnectionManager, 2, 4, 1);

            //var t9 = new PorogUpdater(porog_1_WindSpeed, modbusConnectionManager, 2, 5, 1);
            //var t10 = new PorogUpdater(porog_2_WindSpeed, modbusConnectionManager, 2, 21, 1);
            //var t11 = new PorogUpdater(dx_WindSpeed, modbusConnectionManager, 2, 22, 1);
            //var t12 = new PorogUpdater(dt_WindSpeed, modbusConnectionManager, 2, 23, 1);


            //// Нет регистров
            ////_ = new PorogUpdater( porog_1_AtmosphericPressure, modbusConnectionManager);
            ////_ = new PorogUpdater( porog_2_AtmosphericPressure, modbusConnectionManager);
            ////_ = new PorogUpdater( dx_AtmosphericPressure, modbusConnectionManager);
            ////_ = new PorogUpdater( dt_AtmosphericPressure, modbusConnectionManager);


            //var t13 = new PorogUpdater(porog_1_WindDirection, modbusConnectionManager, 2, 6, 1);
            //var t14 = new PorogUpdater(porog_2_WindDirection, modbusConnectionManager, 2, 7, 1);
            //var t15 = new PorogUpdater(dx_WindDirection, modbusConnectionManager, 2, 8, 1);
            //var t16 = new PorogUpdater(dt_WindDirection, modbusConnectionManager, 1, 30, 1);

            //var t17 = new PorogUpdater(porog_1_CarbonMonoxide, modbusConnectionManager, 1, 31, 1);
            //var t18 = new PorogUpdater(porog_2_CarbonMonoxide, modbusConnectionManager, 1, 32, 1);
            //var t19 = new PorogUpdater(dx_CarbonMonoxide, modbusConnectionManager, 1, 36, 1);
            //var t20 = new PorogUpdater(dt_CarbonMonoxide, modbusConnectionManager, 1, 37, 1);

            //var t21 = new PorogUpdater(porog_1_NitrogenOxide, modbusConnectionManager, 1, 38, 1);
            //var t22 = new PorogUpdater(porog_2_NitrogenOxide, modbusConnectionManager, 1, 39, 1);
            //var t23 = new PorogUpdater(dx_NitrogenOxide, modbusConnectionManager, 1, 40, 1);
            //var t24 = new PorogUpdater(dt_NitrogenOxide, modbusConnectionManager, 1, 41, 1);

            //var t25 = new PorogUpdater(porog_1_NitrogenDioxide, modbusConnectionManager, 1, 57, 1);
            //var t26 = new PorogUpdater(porog_2_NitrogenDioxide, modbusConnectionManager, 1, 58, 1);
            //var t27 = new PorogUpdater(dx_NitrogenDioxide, modbusConnectionManager, 1, 59, 1);
            //var t28 = new PorogUpdater(dt_NitrogenDioxide, modbusConnectionManager, 1, 33, 1);

            //var t29 = new PorogUpdater(porog_1_SulfurDioxide, modbusConnectionManager, 1, 34, 1);
            //var t30 = new PorogUpdater(porog_2_SulfurDioxide, modbusConnectionManager, 1, 35, 1);
            //var t31 = new PorogUpdater(dx_SulfurDioxide, modbusConnectionManager, 1, 24, 1);
            //var t32 = new PorogUpdater(dt_SulfurDioxide, modbusConnectionManager, 1, 25, 1);
            //var t33 = new PorogUpdater(porog_1_CarbonDioxide, modbusConnectionManager, 1, 26, 1);
            //var t34 = new PorogUpdater(porog_2_CarbonDioxide, modbusConnectionManager, 2, 48, 1);
            //var t35 = new PorogUpdater(dx_CarbonDioxide, modbusConnectionManager, 2, 49, 1);
            //var t36 = new PorogUpdater(dt_CarbonDioxide, modbusConnectionManager, 2, 50, 1);
            //var t37 = new PorogUpdater(porog_1_VolatileOrganicCompounds, modbusConnectionManager, 2, 51, 1);
            //var t38 = new PorogUpdater(porog_2_VolatileOrganicCompounds, modbusConnectionManager, 2, 52, 1);
            //var t39 = new PorogUpdater(dx_VolatileOrganicCompounds, modbusConnectionManager, 2, 53, 1);
            //var t40 = new PorogUpdater(dt_VolatileOrganicCompounds, modbusConnectionManager, 2, 54, 1);
            //var t41 = new PorogUpdater(porog_1_ParticulateMatterPM1, modbusConnectionManager, 2, 55, 1);
            //var t42 = new PorogUpdater(porog_2_ParticulateMatterPM1, modbusConnectionManager, 2, 56, 1);
            //var t43 = new PorogUpdater(dx_ParticulateMatterPM1, modbusConnectionManager, 1, 63, 1);
            //var t44 = new PorogUpdater(dt_ParticulateMatterPM1, modbusConnectionManager, 1, 64, 1);
            //var t45 = new PorogUpdater(porog_1_ParticulateMatterPM2_5, modbusConnectionManager, 1, 60, 1);
            //var t46 = new PorogUpdater(porog_2_ParticulateMatterPM2_5, modbusConnectionManager, 1, 61, 1);
            //var t47 = new PorogUpdater(dx_ParticulateMatterPM2_5, modbusConnectionManager, 1, 62, 1);
            //var t48 = new PorogUpdater(dt_ParticulateMatterPM2_5, modbusConnectionManager, 1, 63, 1);
            //var t49 = new PorogUpdater(porog_1_ParticulateMatterPM10, modbusConnectionManager, 1, 64, 1);
            //var t50 = new PorogUpdater(porog_2_ParticulateMatterPM10, modbusConnectionManager, 3, 6, 1);
            //var t51 = new PorogUpdater(dx_ParticulateMatterPM10, modbusConnectionManager, 3, 7, 1);
            //var t52 = new PorogUpdater(dt_ParticulateMatterPM10, modbusConnectionManager, 3, 8, 1);
            //var t53 = new PorogUpdater(porog_1_VibrationLevel, modbusConnectionManager, 1, 17, 1);
            //var t54 = new PorogUpdater(porog_2_VibrationLevel, modbusConnectionManager, 1, 18, 1);
            //var t55 = new PorogUpdater(dx_VibrationLevel, modbusConnectionManager, 1, 19, 1);
            //var t56 = new PorogUpdater(dt_VibrationLevel, modbusConnectionManager, 1, 20, 1);
            //var t57 = new PorogUpdater(porog_1_TiltLevel, modbusConnectionManager, 1, 3, 1);
            //var t58 = new PorogUpdater(porog_2_TiltLevel, modbusConnectionManager, 1, 4, 1);
            //var t59 = new PorogUpdater(dx_TiltLevel, modbusConnectionManager, 1, 5, 1);
            //var t60 = new PorogUpdater(dt_TiltLevel, modbusConnectionManager, 1, 6, 1);
            //var t61 = new PorogUpdater(porog_1_TemperatureInSensor, modbusConnectionManager, 1, 7, 1);
            //var t62 = new PorogUpdater(porog_2_TemperatureInSensor, modbusConnectionManager, 1, 8, 1);
            //var t63 = new PorogUpdater(dx_TemperatureInSensor, modbusConnectionManager, 3, 75, 1);
            //var t64 = new PorogUpdater(dt_TemperatureInSensor, modbusConnectionManager, 3, 76, 1);
            //var t65 = new PorogUpdater(porog_1_HumidityInSensor, modbusConnectionManager, 3, 77, 1);
            //var t66 = new PorogUpdater(porog_2_HumidityInSensor, modbusConnectionManager, 2, 18, 1);
            //var t67 = new PorogUpdater(dx_HumidityInSensor, modbusConnectionManager, 2, 18, 1);
            //var t68 = new PorogUpdater(dt_HumidityInSensor, modbusConnectionManager, 2, 18, 1);
            //var t69 = new PorogUpdater(porog_1_SupplyVoltage, modbusConnectionManager, 2, 18, 1);
            //var t70 = new PorogUpdater(porog_2_SupplyVoltage, modbusConnectionManager, 2, 18, 1);
            //var t71 = new PorogUpdater(dx_SupplyVoltage, modbusConnectionManager, 2, 18, 1);
            //var t72 = new PorogUpdater(dt_SupplyVoltage, modbusConnectionManager, 2, 18, 1);
            //var t73 = new PorogUpdater(porog_1_SamplingSpeed, modbusConnectionManager, 2, 18, 1);
            //var t74 = new PorogUpdater(porog_2_SamplingSpeed, modbusConnectionManager, 2, 18, 1);
            //var t75 = new PorogUpdater(dx_SamplingSpeed, modbusConnectionManager, 2, 18, 1);
            //var t76 = new PorogUpdater(dt_SamplingSpeed, modbusConnectionManager, 2, 18, 1);
            //var t77 = new PorogUpdater(porog_1_PressureInSensor, modbusConnectionManager, 2, 18, 1);
            //var t78 = new PorogUpdater(porog_2_PressureInSensor, modbusConnectionManager, 2, 18, 1);
            //var t79 = new PorogUpdater(dx_PressureInSensor, modbusConnectionManager, 2, 18, 1);
            //var t80 = new PorogUpdater(dt_PressureInSensor, modbusConnectionManager, 2, 18, 1);

            // Нет регистров
            //_ = new PorogUpdater( porog_1_TamperSensor, modbusConnectionManager);
            //_ = new PorogUpdater( porog_2_TamperSensor, modbusConnectionManager);
            //_ = new PorogUpdater( dx_TamperSensor, modbusConnectionManager);
            //_ = new PorogUpdater( dt_TamperSensor, modbusConnectionManager);





            // Иницилизация текущих значений порогов
            //_ = new Porog_1_AirTemperatureInitialize(modbusConnectionManager, porog_1_AirTemperature);
            //_ = new Porog_2_AirTemperatureInitialize(modbusConnectionManager, porog_2_AirTemperature);
            //_ = new DX_AirTemperatureInitialize(modbusConnectionManager, dx_AirTemperature);
            //_ = new DT_AirTemperatureInitialize(modbusConnectionManager, dt_AirTemperature);

            //_ = new Porog_1_RelativeHumidityInitialize(modbusConnectionManager, porog_1_RelativeHumidity);
            //_ = new Porog_2_RelativeHumidityInitialize(modbusConnectionManager, porog_2_RelativeHumidity);
            //_ = new DX_RelativeHumidityInitialize(modbusConnectionManager, dx_RelativeHumidity);
            //_ = new DT_RelativeHumidityInitialize(modbusConnectionManager, dt_RelativeHumidity);

            //// Нет регистров
            ////_ = new Porog_1_AtmosphericPressure(modbusConnectionManager, porog_1_AtmosphericPressure);
            ////_ = new Porog_2_AtmosphericPressure(modbusConnectionManager, porog_2_AtmosphericPressure);
            ////_ = new DX_AtmosphericPressure(modbusConnectionManager, dx_AtmosphericPressure);
            ////_ = new DT_AtmosphericPressure(modbusConnectionManager, dt_AtmosphericPressure);

            //_ = new Porog_1_WindSpeedInitialize(modbusConnectionManager, porog_1_WindSpeed);
            //_ = new Porog_2_WindSpeedInitialize(modbusConnectionManager, porog_2_WindSpeed);
            //_ = new DX_WindSpeedInitialize(modbusConnectionManager, dx_WindSpeed);
            //_ = new DT_WindSpeedInitialize(modbusConnectionManager, dt_WindSpeed);

            //_ = new Porog_1_WindDirectionInitialize(modbusConnectionManager, porog_1_WindDirection);
            //_ = new Porog_2_WindDirectionInitialize(modbusConnectionManager, porog_2_WindDirection);
            //_ = new DX_WindDirectionInitialize(modbusConnectionManager, dx_WindDirection);
            //_ = new DT_WindDirectionInitialize(modbusConnectionManager, dt_WindDirection);

            //_ = new Porog_1_CarbonMonoxideInitialize(modbusConnectionManager, porog_1_CarbonMonoxide);
            //_ = new Porog_2_CarbonMonoxideInitialize(modbusConnectionManager, porog_2_CarbonMonoxide);
            //_ = new DX_CarbonMonoxideInitialize(modbusConnectionManager, dx_CarbonMonoxide);
            //_ = new DT_CarbonMonoxideInitialize(modbusConnectionManager, dt_CarbonMonoxide);

            //_ = new Porog_1_NitrogenOxideInitialize(modbusConnectionManager, porog_1_NitrogenOxide);
            //_ = new Porog_2_NitrogenOxideInitialize(modbusConnectionManager, porog_2_NitrogenOxide);
            //_ = new DX_NitrogenOxideInitialize(modbusConnectionManager, dx_NitrogenOxide);
            //_ = new DT_NitrogenOxideInitialize(modbusConnectionManager, dt_NitrogenOxide);

            //_ = new Porog_1_NitrogenDioxideInitialize(modbusConnectionManager, porog_1_NitrogenDioxide);
            //_ = new Porog_2_NitrogenDioxideInitialize(modbusConnectionManager, porog_2_NitrogenDioxide);
            //_ = new DX_NitrogenDioxideInitialize(modbusConnectionManager, dx_NitrogenDioxide);
            //_ = new DT_NitrogenDioxideInitialize(modbusConnectionManager, dt_NitrogenDioxide);

            //_ = new Porog_1_SulfurDioxideInitialize(modbusConnectionManager, porog_1_SulfurDioxide);
            //_ = new Porog_2_SulfurDioxideInitialize(modbusConnectionManager, porog_2_SulfurDioxide);
            //_ = new DX_SulfurDioxideInitialize(modbusConnectionManager, dx_SulfurDioxide);
            //_ = new DT_SulfurDioxideInitialize(modbusConnectionManager, dt_SulfurDioxide);

            //_ = new Porog_1_CarbonDioxideInitialize(modbusConnectionManager, porog_1_CarbonDioxide);
            //_ = new Porog_2_CarbonDioxideInitialize(modbusConnectionManager, porog_2_CarbonDioxide);
            //_ = new DX_CarbonDioxideInitialize(modbusConnectionManager, dx_CarbonDioxide);
            //_ = new DT_CarbonDioxideInitialize(modbusConnectionManager, dt_CarbonDioxide);

            //_ = new Porog_1_VolatileOrganicCompoundsInitialize(modbusConnectionManager, porog_1_VolatileOrganicCompounds);
            //_ = new Porog_2_VolatileOrganicCompoundsInitialize(modbusConnectionManager, porog_2_VolatileOrganicCompounds);
            //_ = new DX_VolatileOrganicCompoundsInitialize(modbusConnectionManager, dx_VolatileOrganicCompounds);
            //_ = new DT_VolatileOrganicCompoundsInitialize(modbusConnectionManager, dt_VolatileOrganicCompounds);

            //_ = new Porog_1_ParticulateMatterPM1Initialize(modbusConnectionManager, porog_1_ParticulateMatterPM1);
            //_ = new Porog_2_ParticulateMatterPM1Initialize(modbusConnectionManager, porog_2_ParticulateMatterPM1);
            //_ = new DX_ParticulateMatterPM1Initialize(modbusConnectionManager, dx_ParticulateMatterPM1);
            //_ = new DT_ParticulateMatterPM1Initialize(modbusConnectionManager, dt_ParticulateMatterPM1);

            //_ = new Porog_1_ParticulateMatterPM2_5Initialize(modbusConnectionManager, porog_1_ParticulateMatterPM2_5);
            //_ = new Porog_2_ParticulateMatterPM2_5Initialize(modbusConnectionManager, porog_2_ParticulateMatterPM2_5);
            //_ = new DX_ParticulateMatterPM2_5Initialize(modbusConnectionManager, dx_ParticulateMatterPM2_5);
            //_ = new DT_ParticulateMatterPM2_5Initialize(modbusConnectionManager, dt_ParticulateMatterPM2_5);

            //_ = new Porog_1_ParticulateMatterPM10Initialize(modbusConnectionManager, porog_1_ParticulateMatterPM10);
            //_ = new Porog_2_ParticulateMatterPM10Initialize(modbusConnectionManager, porog_2_ParticulateMatterPM10);
            //_ = new DX_ParticulateMatterPM10Initialize(modbusConnectionManager, dx_ParticulateMatterPM10);
            //_ = new DT_ParticulateMatterPM10Initialize(modbusConnectionManager, dt_ParticulateMatterPM10);

            //_ = new Porog_1_VibrationLevelInitialize(modbusConnectionManager, porog_1_VibrationLevel);
            //_ = new Porog_2_VibrationLevelInitialize(modbusConnectionManager, porog_2_VibrationLevel);
            //_ = new DX_VibrationLevelInitialize(modbusConnectionManager, dx_VibrationLevel);
            //_ = new DT_VibrationLevelInitialize(modbusConnectionManager, dt_VibrationLevel);

            //_ = new Porog_1_TiltLevelInitialize(modbusConnectionManager, porog_1_TiltLevel);
            //_ = new Porog_2_TiltLevelInitialize(modbusConnectionManager, porog_2_TiltLevel);
            //_ = new DX_TiltLevelInitialize(modbusConnectionManager, dx_TiltLevel);
            //_ = new DT_TiltLevelInitialize(modbusConnectionManager, dt_TiltLevel);

            //// Нет регистров
            ////_ = new Porog_1_TamperSensorInitialize(modbusConnectionManager, porog_1_TamperSensor);
            ////_ = new Porog_2_TamperSensorInitialize(modbusConnectionManager, porog_2_TamperSensor);
            ////_ = new DX_TamperSensorInitialize(modbusConnectionManager, dx_TamperSensor);
            ////_ = new DT_TamperSensorInitialize(modbusConnectionManager, dt_TamperSensor);

            //_ = new Porog_1_TemperatureInSensorInitialize(modbusConnectionManager, porog_1_TemperatureInSensor);
            //_ = new Porog_2_TemperatureInSensorInitialize(modbusConnectionManager, porog_2_TemperatureInSensor);
            //_ = new DX_TemperatureInSensorInitialize(modbusConnectionManager, dx_TemperatureInSensor);
            //_ = new DT_TemperatureInSensorInitialize(modbusConnectionManager, dt_TemperatureInSensor);

            //_ = new Porog_1_HumidityInSensorInitialize(modbusConnectionManager, porog_1_HumidityInSensor);
            //_ = new Porog_2_HumidityInSensorInitialize(modbusConnectionManager, porog_2_HumidityInSensor);
            //_ = new DX_HumidityInSensorInitialize(modbusConnectionManager, dx_HumidityInSensor);
            //_ = new DT_HumidityInSensorInitialize(modbusConnectionManager, dt_HumidityInSensor);

            //_ = new Porog_1_SupplyVoltageInitialize(modbusConnectionManager, porog_1_SupplyVoltage);
            //_ = new Porog_2_SupplyVoltageInitialize(modbusConnectionManager, porog_2_SupplyVoltage);
            //_ = new DX_SupplyVoltageInitialize(modbusConnectionManager, dx_SupplyVoltage);
            //_ = new DT_SupplyVoltageInitialize(modbusConnectionManager, dt_SupplyVoltage);

            //_ = new Porog_1_SamplingSpeedInitialize(modbusConnectionManager, porog_1_SamplingSpeed);
            //_ = new Porog_2_SamplingSpeedInitialize(modbusConnectionManager, porog_2_SamplingSpeed);
            //_ = new DX_SamplingSpeedInitialize(modbusConnectionManager, dx_SamplingSpeed);
            //_ = new DT_SamplingSpeedInitialize(modbusConnectionManager, dt_SamplingSpeed);

            //_ = new Porog_1_PressureInSensorInitialize(modbusConnectionManager, porog_1_PressureInSensor);
            //_ = new Porog_2_PressureInSensorInitialize(modbusConnectionManager, porog_2_PressureInSensor);
            //_ = new DX_PressureInSensorInitialize(modbusConnectionManager, dx_PressureInSensor);
            //_ = new DT_PressureInSensorInitialize(modbusConnectionManager, dt_PressureInSensor);
        }

        private void SensorUpdater_ValueChanged(object sender, EventArgs e)
        {
            // Обработка события изменения значения датчика
            // Этот метод будет вызываться при каждом срабатывании события ValueChanged
        }

        private void UpdateSensorConnection(ModbusConnectionManager modbusConnectionManager)
        {
            while (true)
            {
                if (modbusConnectionManager.IsDeviceAvailable())
                {
                    isConnectDevise.Image = Properties.Resources.mobile_connection_green;
                }
                else
                {
                    isConnectDevise.Image = Properties.Resources.mobile_connection_red;
                }
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            // При активации одного RadioButton, отключаем остальные
            RadioButton selectedRadioButton = (RadioButton)sender;

            foreach (RadioButton radioButton in allRadioButtons)
            {
                if (radioButton != selectedRadioButton)
                {
                    radioButton.Checked = false;
                }
            }
        }

        private void SettingBtn_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.Show();
        }

        private void NameStation_Click(object sender, EventArgs e)
        {
            LogSensor logSensor = new LogSensor();
            logSensor.Show();
        }
    }
}
