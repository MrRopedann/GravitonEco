using GravitonEcoV2.Helpers;
using GravitonEcoV2.Managers;
using GravitonEcoV2.Updaters;
using GravitonEcoV2.View;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
            InitializeStartComponent();

            ModbusConnectionManager modbusConnectionManager = ModbusConnectionManager.Instance;
            ServerConnectionManager serverConnectionManager = ServerConnectionManager.Instance;

            Task.Run(() => UpdateServerAndSensorConnection(serverConnectionManager, modbusConnectionManager));
            

            ///* Обновление текущих значений */
            //Внешние
            _ = new SensorUpdater(currentAirTemperature, modbusConnectionManager, 2, 5, 1);
            _ = new SensorUpdater(currentRelativeHumidity, modbusConnectionManager, 2, 6, 1);
            _ = new SensorUpdater(currentAtmosphericPressure, modbusConnectionManager, 2, 1, 1);
            _ = new SensorUpdater(currentWindSpeed, modbusConnectionManager, 1, 544, 1);
            _ = new SensorUpdater(currentWindDirection, modbusConnectionManager, 2, 2, 1);

        }

        private void SensorUpdater_ValueChanged(object sender, EventArgs e)
        {
            // Обработка события изменения значения датчика
            // Этот метод будет вызываться при каждом срабатывании события ValueChanged
        }

        private void UpdateServerAndSensorConnection(ServerConnectionManager serverConnection, ModbusConnectionManager modbusConnectionManager)
        {
            while (true)
            {
                if (serverConnection.IsDeviceAvailable())
                {
                    isConnectServer.Image = Properties.Resources.mesh_green;
                }
                else
                {
                    isConnectServer.Image = Properties.Resources.mesh_red;
                }

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

        private void currentAirTemperature_TextChanged(object sender, EventArgs e)
        {
            DateTime timenow = DateTime.Now;

            if (radioButton1.Checked)
            {
                
                chart1.Series.FindByName("Temperature").Points.AddXY(timenow.ToString("hh:mm:ss"), Convert.ToDouble(currentAirTemperature.Text));
                chart1.Series.FindByName("Humidity").Points.AddXY(timenow.ToString("hh:mm:ss"), Convert.ToDouble(currentRelativeHumidity.Text));
            }
        }

        private bool isLeftButtonPressed = false;
        private Point mouseDown = Point.Empty;


        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isLeftButtonPressed)
            {
                var result = chart1.HitTest(e.X, e.Y);

                if (result.ChartElementType == System.Windows.Forms.DataVisualization.Charting.ChartElementType.PlottingArea)
                {
                    var oldXValue = result.ChartArea.AxisX.PixelPositionToValue(mouseDown.X);
                    var newXValue = result.ChartArea.AxisX.PixelPositionToValue(e.X);

                    chart1.ChartAreas[0].AxisX.ScaleView.Position += oldXValue - newXValue;
                    mouseDown.X = e.X;
                }
            }
        }

        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isLeftButtonPressed = false;
                mouseDown = Point.Empty;
            }
        }

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isLeftButtonPressed = true;
                mouseDown = e.Location;

            }
        }

        private void InitializeStartComponent()
        {
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

            int[] columnWidths = secondaryContentTableLayoutPanel1.GetColumnWidths();
            int[] rowHeights = secondaryContentTableLayoutPanel1.GetRowHeights();

            int[] columnWidths2 = tableLayoutPanel2.GetColumnWidths();
            int[] rowHeights2 = tableLayoutPanel2.GetRowHeights();

            TableLayoutPanel[] tableLayouts = { secondaryContentTableLayoutPanel2, secondaryContentTableLayoutPanel3, secondaryContentTableLayoutPanel4, secondaryContentTableLayoutPanel5 };

            TableLayoutPanel[] tableLayoutPanels = { tableLayoutPanel2, tableLayoutPanel3 };

            LayoutHelper.ApplyColumnRowLayout(tableLayouts, columnWidths, rowHeights);
            LayoutHelper.ApplyColumnRowLayout(tableLayoutPanels, columnWidths2, rowHeights2);

            chart1.ChartAreas[0].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190))))); // Цвет меток по оси X
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190))))); // Цвет меток по оси Y

            chart1.ChartAreas[0].Position.Auto = false;
            //chart1.ChartAreas[0].InnerPlotPosition.Auto = false;
            chart1.ChartAreas[0].CursorX.AutoScroll = true;
            chart1.ChartAreas[0].CursorY.AutoScroll = true;
            chart1.ChartAreas[0].AxisY.Maximum = 36;
            chart1.ChartAreas[0].AxisY.Minimum = 0;

            Series series2 = new Series("Temperature");
            series2.ChartType = SeriesChartType.Line;
            series2.BorderWidth = 3;
            series2.LegendText = "Температура";
            series2.Color = System.Drawing.Color.Red;
            chart1.Series.Add(series2);

            Series series3 = new Series("Humidity");
            series3.ChartType = SeriesChartType.Line;
            series3.BorderWidth = 3;
            series3.LegendText = "Влажность";
            series3.Color = System.Drawing.Color.Blue;
            chart1.Series.Add(series3);
        }
    }
}
