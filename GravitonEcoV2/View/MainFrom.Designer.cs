namespace GravitonEcoV2
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.HeaderPanel = new System.Windows.Forms.TableLayoutPanel();
            this.isConnectServer = new System.Windows.Forms.PictureBox();
            this.isConnectDevise = new System.Windows.Forms.PictureBox();
            this.SerialNumber = new System.Windows.Forms.Label();
            this.SoftVersion = new System.Windows.Forms.Label();
            this.SettingBtn = new System.Windows.Forms.PictureBox();
            this.NameStation = new System.Windows.Forms.Label();
            this.ApparatVersion = new System.Windows.Forms.Label();
            this.PeriodComboBox = new System.Windows.Forms.ComboBox();
            this.UnlockPinField = new System.Windows.Forms.TextBox();
            this.UnlockImage = new System.Windows.Forms.PictureBox();
            this.DateTimeLabel = new System.Windows.Forms.Label();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.mainContentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.secondaryContentTableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.dt_TemperatureInSensor = new System.Windows.Forms.TextBox();
            this.dt_HumidityInSensor = new System.Windows.Forms.TextBox();
            this.dt_SupplyVoltage = new System.Windows.Forms.TextBox();
            this.dt_SamplingSpeed = new System.Windows.Forms.TextBox();
            this.dt_PressureInSensor = new System.Windows.Forms.TextBox();
            this.dx_PressureInSensor = new System.Windows.Forms.TextBox();
            this.dx_SamplingSpeed = new System.Windows.Forms.TextBox();
            this.dx_SupplyVoltage = new System.Windows.Forms.TextBox();
            this.dx_HumidityInSensor = new System.Windows.Forms.TextBox();
            this.dx_TemperatureInSensor = new System.Windows.Forms.TextBox();
            this.porog_2_TemperatureInSensor = new System.Windows.Forms.TextBox();
            this.porog_2_HumidityInSensor = new System.Windows.Forms.TextBox();
            this.porog_2_SupplyVoltage = new System.Windows.Forms.TextBox();
            this.porog_2_SamplingSpeed = new System.Windows.Forms.TextBox();
            this.porog_2_PressureInSensor = new System.Windows.Forms.TextBox();
            this.porog_1_PressureInSensor = new System.Windows.Forms.TextBox();
            this.porog_1_SamplingSpeed = new System.Windows.Forms.TextBox();
            this.porog_1_SupplyVoltage = new System.Windows.Forms.TextBox();
            this.porog_1_HumidityInSensor = new System.Windows.Forms.TextBox();
            this.porog_1_TemperatureInSensor = new System.Windows.Forms.TextBox();
            this.currentTemperatureInSensor = new System.Windows.Forms.Label();
            this.currentHumidityInSensor = new System.Windows.Forms.Label();
            this.currentSupplyVoltage = new System.Windows.Forms.Label();
            this.currentSamplingSpeed = new System.Windows.Forms.Label();
            this.currentPressureInSensor = new System.Windows.Forms.Label();
            this.temperatureInSensor = new System.Windows.Forms.Label();
            this.humidityInSensor = new System.Windows.Forms.Label();
            this.supplyVoltage = new System.Windows.Forms.Label();
            this.samplingSpeed = new System.Windows.Forms.Label();
            this.pressureInSensor = new System.Windows.Forms.Label();
            this.secondaryContentTableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.radioButton16 = new System.Windows.Forms.RadioButton();
            this.radioButton17 = new System.Windows.Forms.RadioButton();
            this.dt_VibrationLevel = new System.Windows.Forms.TextBox();
            this.dt_TiltLevel = new System.Windows.Forms.TextBox();
            this.dt_TamperSensor = new System.Windows.Forms.TextBox();
            this.dx_TamperSensor = new System.Windows.Forms.TextBox();
            this.dx_TiltLevel = new System.Windows.Forms.TextBox();
            this.dx_VibrationLevel = new System.Windows.Forms.TextBox();
            this.porog_2_VibrationLevel = new System.Windows.Forms.TextBox();
            this.porog_2_TiltLevel = new System.Windows.Forms.TextBox();
            this.porog_2_TamperSensor = new System.Windows.Forms.TextBox();
            this.porog_1_TamperSensor = new System.Windows.Forms.TextBox();
            this.porog_1_TiltLevel = new System.Windows.Forms.TextBox();
            this.porog_1_VibrationLevel = new System.Windows.Forms.TextBox();
            this.currentVibrationLevel = new System.Windows.Forms.Label();
            this.currentTiltLevel = new System.Windows.Forms.Label();
            this.currentTamperSensor = new System.Windows.Forms.Label();
            this.tamperSensor = new System.Windows.Forms.Label();
            this.tiltLevel = new System.Windows.Forms.Label();
            this.vibrationLevel = new System.Windows.Forms.Label();
            this.secondaryContentTableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton18 = new System.Windows.Forms.RadioButton();
            this.radioButton19 = new System.Windows.Forms.RadioButton();
            this.radioButton20 = new System.Windows.Forms.RadioButton();
            this.dt_ParticulateMatterPM10 = new System.Windows.Forms.TextBox();
            this.dt_ParticulateMatterPM2_5 = new System.Windows.Forms.TextBox();
            this.dt_ParticulateMatterPM1 = new System.Windows.Forms.TextBox();
            this.dx_ParticulateMatterPM1 = new System.Windows.Forms.TextBox();
            this.dx_ParticulateMatterPM2_5 = new System.Windows.Forms.TextBox();
            this.dx_ParticulateMatterPM10 = new System.Windows.Forms.TextBox();
            this.porog_2_ParticulateMatterPM10 = new System.Windows.Forms.TextBox();
            this.porog_2_ParticulateMatterPM2_5 = new System.Windows.Forms.TextBox();
            this.porog_2_ParticulateMatterPM1 = new System.Windows.Forms.TextBox();
            this.porog_1_ParticulateMatterPM1 = new System.Windows.Forms.TextBox();
            this.porog_1_ParticulateMatterPM2_5 = new System.Windows.Forms.TextBox();
            this.porog_1_ParticulateMatterPM10 = new System.Windows.Forms.TextBox();
            this.currentParticulateMatterPM10 = new System.Windows.Forms.Label();
            this.currentParticulateMatterPM2_5 = new System.Windows.Forms.Label();
            this.currentParticulateMatterPM1 = new System.Windows.Forms.Label();
            this.particulateMatterPM1 = new System.Windows.Forms.Label();
            this.particulateMatterPM2_5 = new System.Windows.Forms.Label();
            this.particulateMatterPM10 = new System.Windows.Forms.Label();
            this.secondaryContentTableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton21 = new System.Windows.Forms.RadioButton();
            this.radioButton22 = new System.Windows.Forms.RadioButton();
            this.dt_CarbonMonoxide = new System.Windows.Forms.TextBox();
            this.dt_NitrogenOxide = new System.Windows.Forms.TextBox();
            this.dt_NitrogenDioxide = new System.Windows.Forms.TextBox();
            this.dt_SulfurDioxide = new System.Windows.Forms.TextBox();
            this.dt_CarbonDioxide = new System.Windows.Forms.TextBox();
            this.dt_VolatileOrganicCompounds = new System.Windows.Forms.TextBox();
            this.dx_VolatileOrganicCompounds = new System.Windows.Forms.TextBox();
            this.dx_CarbonDioxide = new System.Windows.Forms.TextBox();
            this.dx_SulfurDioxide = new System.Windows.Forms.TextBox();
            this.dx_NitrogenDioxide = new System.Windows.Forms.TextBox();
            this.dx_NitrogenOxide = new System.Windows.Forms.TextBox();
            this.dx_CarbonMonoxide = new System.Windows.Forms.TextBox();
            this.porog_2_CarbonMonoxide = new System.Windows.Forms.TextBox();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.porog_2_NitrogenOxide = new System.Windows.Forms.TextBox();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.porog_2_NitrogenDioxide = new System.Windows.Forms.TextBox();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.porog_2_SulfurDioxide = new System.Windows.Forms.TextBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.porog_2_CarbonDioxide = new System.Windows.Forms.TextBox();
            this.porog_2_VolatileOrganicCompounds = new System.Windows.Forms.TextBox();
            this.porog_1_VolatileOrganicCompounds = new System.Windows.Forms.TextBox();
            this.porog_1_CarbonDioxide = new System.Windows.Forms.TextBox();
            this.porog_1_SulfurDioxide = new System.Windows.Forms.TextBox();
            this.porog_1_NitrogenDioxide = new System.Windows.Forms.TextBox();
            this.porog_1_NitrogenOxide = new System.Windows.Forms.TextBox();
            this.porog_1_CarbonMonoxide = new System.Windows.Forms.TextBox();
            this.currentCarbonMonoxide = new System.Windows.Forms.Label();
            this.currentNitrogenOxide = new System.Windows.Forms.Label();
            this.currentNitrogenDioxide = new System.Windows.Forms.Label();
            this.currentSulfurDioxide = new System.Windows.Forms.Label();
            this.currentCarbonDioxide = new System.Windows.Forms.Label();
            this.currentVolatileOrganicCompounds = new System.Windows.Forms.Label();
            this.volatileOrganicCompounds = new System.Windows.Forms.Label();
            this.carbonDioxide = new System.Windows.Forms.Label();
            this.sulfurDioxide = new System.Windows.Forms.Label();
            this.nitrogenDioxide = new System.Windows.Forms.Label();
            this.nitrogenOxide = new System.Windows.Forms.Label();
            this.carbonMonoxide = new System.Windows.Forms.Label();
            this.secondaryContentTableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.periodLabel = new System.Windows.Forms.Label();
            this.increaseLabel = new System.Windows.Forms.Label();
            this.porog2Label = new System.Windows.Forms.Label();
            this.porog1Label = new System.Windows.Forms.Label();
            this.currentParametrLabel = new System.Windows.Forms.Label();
            this.avgParametrLabel = new System.Windows.Forms.Label();
            this.maxParametrLabel = new System.Windows.Forms.Label();
            this.minParametrLabel = new System.Windows.Forms.Label();
            this.ParametrLabel = new System.Windows.Forms.Label();
            this.airTemperature = new System.Windows.Forms.Label();
            this.relativeHumidity = new System.Windows.Forms.Label();
            this.atmosphericPressure = new System.Windows.Forms.Label();
            this.windSpeed = new System.Windows.Forms.Label();
            this.windDirection = new System.Windows.Forms.Label();
            this.dt_AirTemperature = new System.Windows.Forms.TextBox();
            this.dt_RelativeHumidity = new System.Windows.Forms.TextBox();
            this.dt_AtmosphericPressure = new System.Windows.Forms.TextBox();
            this.dt_WindSpeed = new System.Windows.Forms.TextBox();
            this.dt_WindDirection = new System.Windows.Forms.TextBox();
            this.dx_WindDirection = new System.Windows.Forms.TextBox();
            this.dx_WindSpeed = new System.Windows.Forms.TextBox();
            this.dx_AtmosphericPressure = new System.Windows.Forms.TextBox();
            this.dx_RelativeHumidity = new System.Windows.Forms.TextBox();
            this.dx_AirTemperature = new System.Windows.Forms.TextBox();
            this.porog_2_AirTemperature = new System.Windows.Forms.TextBox();
            this.porog_2_RelativeHumidity = new System.Windows.Forms.TextBox();
            this.porog_2_AtmosphericPressure = new System.Windows.Forms.TextBox();
            this.porog_2_WindSpeed = new System.Windows.Forms.TextBox();
            this.porog_2_WindDirection = new System.Windows.Forms.TextBox();
            this.porog_1_WindDirection = new System.Windows.Forms.TextBox();
            this.porog_1_WindSpeed = new System.Windows.Forms.TextBox();
            this.porog_1_AtmosphericPressure = new System.Windows.Forms.TextBox();
            this.porog_1_RelativeHumidity = new System.Windows.Forms.TextBox();
            this.porog_1_AirTemperature = new System.Windows.Forms.TextBox();
            this.currentAirTemperature = new System.Windows.Forms.Label();
            this.currentRelativeHumidity = new System.Windows.Forms.Label();
            this.currentAtmosphericPressure = new System.Windows.Forms.Label();
            this.currentWindSpeed = new System.Windows.Forms.Label();
            this.currentWindDirection = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.sumZeroCarbonDioxide = new System.Windows.Forms.TextBox();
            this.sumZeroSulfurDioxide = new System.Windows.Forms.TextBox();
            this.sumZeroNitrogenDioxide = new System.Windows.Forms.TextBox();
            this.sumZeroNitrogenOxide = new System.Windows.Forms.TextBox();
            this.sumZeroCarbonMonoxide = new System.Windows.Forms.TextBox();
            this.acp_CarbonDioxide = new System.Windows.Forms.TextBox();
            this.setupZeroVolatileOrganicCompounds = new System.Windows.Forms.TextBox();
            this.acp_SulfurDioxide = new System.Windows.Forms.TextBox();
            this.acp_NitrogenDioxide = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.acp_NitrogenOxide = new System.Windows.Forms.TextBox();
            this.acp_CarbonMonoxide = new System.Windows.Forms.TextBox();
            this.pgc_NitrogenDioxide = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pgc_CarbonDioxide = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pgc_SulfurDioxide = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pgc_CarbonMonoxide = new System.Windows.Forms.TextBox();
            this.pgc_NitrogenOxide = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.currentNitrogenOxide2 = new System.Windows.Forms.Label();
            this.currentCarbonMonoxide2 = new System.Windows.Forms.Label();
            this.currentNitrogenDioxide2 = new System.Windows.Forms.Label();
            this.currentCarbonDioxide2 = new System.Windows.Forms.Label();
            this.currentSulfurDioxide2 = new System.Windows.Forms.Label();
            this.currentVolatileOrganicCompounds2 = new System.Windows.Forms.Label();
            this.setupZeroCarbonMonoxide = new System.Windows.Forms.TextBox();
            this.setupZeroNitrogenOxide = new System.Windows.Forms.TextBox();
            this.setupZeroNitrogenDioxide = new System.Windows.Forms.TextBox();
            this.setupZeroSulfurDioxide = new System.Windows.Forms.TextBox();
            this.setupZeroCarbonDioxide = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label27 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.currentAirTemperature2 = new System.Windows.Forms.Label();
            this.currentAtmosphericPressure2 = new System.Windows.Forms.Label();
            this.currentRelativeHumidity2 = new System.Windows.Forms.Label();
            this.currentWindSpeed2 = new System.Windows.Forms.Label();
            this.powerAirTemperature = new System.Windows.Forms.TextBox();
            this.powerRelativeHumidity = new System.Windows.Forms.TextBox();
            this.constRelativeHumidity = new System.Windows.Forms.TextBox();
            this.constAtmosphericPressure = new System.Windows.Forms.TextBox();
            this.constWindSpeed = new System.Windows.Forms.TextBox();
            this.constAirTemperature = new System.Windows.Forms.TextBox();
            this.stepAirTemperature = new System.Windows.Forms.TextBox();
            this.stepRelativeHumidity = new System.Windows.Forms.TextBox();
            this.timeAirTemperature = new System.Windows.Forms.TextBox();
            this.timeRelativeHumidity = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.isConnectServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.isConnectDevise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnlockImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.mainContentTableLayoutPanel.SuspendLayout();
            this.secondaryContentTableLayoutPanel5.SuspendLayout();
            this.secondaryContentTableLayoutPanel4.SuspendLayout();
            this.secondaryContentTableLayoutPanel3.SuspendLayout();
            this.secondaryContentTableLayoutPanel2.SuspendLayout();
            this.secondaryContentTableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.ColumnCount = 11;
            this.HeaderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.143646F));
            this.HeaderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.21731F));
            this.HeaderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.576427F));
            this.HeaderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.023941F));
            this.HeaderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.99632F));
            this.HeaderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.99632F));
            this.HeaderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.78637F));
            this.HeaderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.155125F));
            this.HeaderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.801477F));
            this.HeaderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.343808F));
            this.HeaderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 317F));
            this.HeaderPanel.Controls.Add(this.isConnectServer, 9, 0);
            this.HeaderPanel.Controls.Add(this.isConnectDevise, 8, 0);
            this.HeaderPanel.Controls.Add(this.SerialNumber, 4, 0);
            this.HeaderPanel.Controls.Add(this.SoftVersion, 3, 0);
            this.HeaderPanel.Controls.Add(this.SettingBtn, 0, 0);
            this.HeaderPanel.Controls.Add(this.NameStation, 1, 0);
            this.HeaderPanel.Controls.Add(this.ApparatVersion, 2, 0);
            this.HeaderPanel.Controls.Add(this.PeriodComboBox, 5, 0);
            this.HeaderPanel.Controls.Add(this.UnlockPinField, 6, 0);
            this.HeaderPanel.Controls.Add(this.UnlockImage, 7, 0);
            this.HeaderPanel.Controls.Add(this.DateTimeLabel, 10, 0);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.RowCount = 1;
            this.HeaderPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HeaderPanel.Size = new System.Drawing.Size(1390, 36);
            this.HeaderPanel.TabIndex = 0;
            // 
            // isConnectServer
            // 
            this.isConnectServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.isConnectServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.isConnectServer.Image = global::GravitonEcoV2.Properties.Resources.mesh_red;
            this.isConnectServer.Location = new System.Drawing.Point(1025, 3);
            this.isConnectServer.Name = "isConnectServer";
            this.isConnectServer.Size = new System.Drawing.Size(40, 30);
            this.isConnectServer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.isConnectServer.TabIndex = 38;
            this.isConnectServer.TabStop = false;
            this.isConnectServer.Tag = "ServerConnecting";
            // 
            // isConnectDevise
            // 
            this.isConnectDevise.Cursor = System.Windows.Forms.Cursors.Hand;
            this.isConnectDevise.Dock = System.Windows.Forms.DockStyle.Fill;
            this.isConnectDevise.Image = global::GravitonEcoV2.Properties.Resources.mobile_connection_red;
            this.isConnectDevise.Location = new System.Drawing.Point(974, 3);
            this.isConnectDevise.Name = "isConnectDevise";
            this.isConnectDevise.Size = new System.Drawing.Size(45, 30);
            this.isConnectDevise.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.isConnectDevise.TabIndex = 9;
            this.isConnectDevise.TabStop = false;
            this.isConnectDevise.Tag = "ModbusConnecting";
            // 
            // SerialNumber
            // 
            this.SerialNumber.AutoSize = true;
            this.SerialNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SerialNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SerialNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 16.25F, System.Drawing.FontStyle.Bold);
            this.SerialNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.SerialNumber.Location = new System.Drawing.Point(504, 0);
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.Size = new System.Drawing.Size(144, 36);
            this.SerialNumber.TabIndex = 4;
            this.SerialNumber.Text = "SN-12345678";
            this.SerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SoftVersion
            // 
            this.SoftVersion.AutoSize = true;
            this.SoftVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SoftVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SoftVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 16.25F, System.Drawing.FontStyle.Bold);
            this.SoftVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.SoftVersion.Location = new System.Drawing.Point(408, 0);
            this.SoftVersion.Name = "SoftVersion";
            this.SoftVersion.Size = new System.Drawing.Size(90, 36);
            this.SoftVersion.TabIndex = 3;
            this.SoftVersion.Text = "FV-0001";
            this.SoftVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingBtn
            // 
            this.SettingBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SettingBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SettingBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingBtn.Image = global::GravitonEcoV2.Properties.Resources.settings;
            this.SettingBtn.Location = new System.Drawing.Point(3, 3);
            this.SettingBtn.Name = "SettingBtn";
            this.SettingBtn.Size = new System.Drawing.Size(38, 30);
            this.SettingBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SettingBtn.TabIndex = 0;
            this.SettingBtn.TabStop = false;
            this.SettingBtn.Click += new System.EventHandler(this.SettingBtn_Click);
            // 
            // NameStation
            // 
            this.NameStation.AutoSize = true;
            this.NameStation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.NameStation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NameStation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameStation.Font = new System.Drawing.Font("Segoe UI Semibold", 16.25F, System.Drawing.FontStyle.Bold);
            this.NameStation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(230)))), ((int)(((byte)(80)))));
            this.NameStation.Location = new System.Drawing.Point(47, 0);
            this.NameStation.Name = "NameStation";
            this.NameStation.Size = new System.Drawing.Size(253, 36);
            this.NameStation.TabIndex = 1;
            this.NameStation.Text = "GRAVITON-ECO";
            this.NameStation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NameStation.Click += new System.EventHandler(this.NameStation_Click);
            // 
            // ApparatVersion
            // 
            this.ApparatVersion.AutoSize = true;
            this.ApparatVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ApparatVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ApparatVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 16.25F, System.Drawing.FontStyle.Bold);
            this.ApparatVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.ApparatVersion.Location = new System.Drawing.Point(306, 0);
            this.ApparatVersion.Name = "ApparatVersion";
            this.ApparatVersion.Size = new System.Drawing.Size(96, 36);
            this.ApparatVersion.TabIndex = 2;
            this.ApparatVersion.Text = "HV-0001";
            this.ApparatVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PeriodComboBox
            // 
            this.PeriodComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PeriodComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PeriodComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PeriodComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PeriodComboBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PeriodComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.PeriodComboBox.FormattingEnabled = true;
            this.PeriodComboBox.Items.AddRange(new object[] {
            "1000",
            "5000",
            "10000"});
            this.PeriodComboBox.Location = new System.Drawing.Point(654, 6);
            this.PeriodComboBox.Name = "PeriodComboBox";
            this.PeriodComboBox.Size = new System.Drawing.Size(144, 23);
            this.PeriodComboBox.TabIndex = 5;
            this.PeriodComboBox.Text = "Период наблюдений";
            // 
            // UnlockPinField
            // 
            this.UnlockPinField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.UnlockPinField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UnlockPinField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnlockPinField.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.UnlockPinField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.UnlockPinField.Location = new System.Drawing.Point(804, 3);
            this.UnlockPinField.Name = "UnlockPinField";
            this.UnlockPinField.PasswordChar = '*';
            this.UnlockPinField.Size = new System.Drawing.Size(120, 23);
            this.UnlockPinField.TabIndex = 6;
            this.UnlockPinField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UnlockImage
            // 
            this.UnlockImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UnlockImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnlockImage.Image = global::GravitonEcoV2.Properties.Resources.password_red;
            this.UnlockImage.Location = new System.Drawing.Point(930, 3);
            this.UnlockImage.Name = "UnlockImage";
            this.UnlockImage.Size = new System.Drawing.Size(38, 30);
            this.UnlockImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UnlockImage.TabIndex = 7;
            this.UnlockImage.TabStop = false;
            // 
            // DateTimeLabel
            // 
            this.DateTimeLabel.AutoSize = true;
            this.DateTimeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.DateTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateTimeLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 16.25F, System.Drawing.FontStyle.Bold);
            this.DateTimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.DateTimeLabel.Location = new System.Drawing.Point(1071, 0);
            this.DateTimeLabel.Name = "DateTimeLabel";
            this.DateTimeLabel.Size = new System.Drawing.Size(316, 36);
            this.DateTimeLabel.TabIndex = 8;
            this.DateTimeLabel.Text = "18.07.2023 20:00";
            this.DateTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 36);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.mainContentTableLayoutPanel);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.MainSplitContainer.Size = new System.Drawing.Size(1390, 622);
            this.MainSplitContainer.SplitterDistance = 707;
            this.MainSplitContainer.TabIndex = 1;
            // 
            // mainContentTableLayoutPanel
            // 
            this.mainContentTableLayoutPanel.ColumnCount = 1;
            this.mainContentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainContentTableLayoutPanel.Controls.Add(this.secondaryContentTableLayoutPanel5, 0, 4);
            this.mainContentTableLayoutPanel.Controls.Add(this.secondaryContentTableLayoutPanel4, 0, 3);
            this.mainContentTableLayoutPanel.Controls.Add(this.secondaryContentTableLayoutPanel3, 0, 2);
            this.mainContentTableLayoutPanel.Controls.Add(this.secondaryContentTableLayoutPanel2, 0, 1);
            this.mainContentTableLayoutPanel.Controls.Add(this.secondaryContentTableLayoutPanel1, 0, 0);
            this.mainContentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainContentTableLayoutPanel.Name = "mainContentTableLayoutPanel";
            this.mainContentTableLayoutPanel.RowCount = 5;
            this.mainContentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.53192F));
            this.mainContentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.93617F));
            this.mainContentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.71631F));
            this.mainContentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.65248F));
            this.mainContentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.69504F));
            this.mainContentTableLayoutPanel.Size = new System.Drawing.Size(707, 622);
            this.mainContentTableLayoutPanel.TabIndex = 0;
            // 
            // secondaryContentTableLayoutPanel5
            // 
            this.secondaryContentTableLayoutPanel5.ColumnCount = 10;
            this.secondaryContentTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.633782F));
            this.secondaryContentTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.06577F));
            this.secondaryContentTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.702315F));
            this.secondaryContentTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.9151F));
            this.secondaryContentTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.040793F));
            this.secondaryContentTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.13561F));
            this.secondaryContentTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.504961F));
            this.secondaryContentTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.38699F));
            this.secondaryContentTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.371554F));
            this.secondaryContentTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.056229F));
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.radioButton10, 0, 4);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.radioButton11, 0, 3);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.radioButton12, 0, 2);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.radioButton13, 0, 1);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.radioButton14, 0, 0);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.dt_TemperatureInSensor, 9, 0);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.dt_HumidityInSensor, 9, 1);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.dt_SupplyVoltage, 9, 2);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.dt_SamplingSpeed, 9, 3);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.dt_PressureInSensor, 9, 4);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.dx_PressureInSensor, 8, 4);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.dx_SamplingSpeed, 8, 3);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.dx_SupplyVoltage, 8, 2);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.dx_HumidityInSensor, 8, 1);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.dx_TemperatureInSensor, 8, 0);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.porog_2_TemperatureInSensor, 7, 0);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.porog_2_HumidityInSensor, 7, 1);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.porog_2_SupplyVoltage, 7, 2);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.porog_2_SamplingSpeed, 7, 3);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.porog_2_PressureInSensor, 7, 4);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.porog_1_PressureInSensor, 6, 4);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.porog_1_SamplingSpeed, 6, 3);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.porog_1_SupplyVoltage, 6, 2);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.porog_1_HumidityInSensor, 6, 1);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.porog_1_TemperatureInSensor, 6, 0);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.currentTemperatureInSensor, 5, 0);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.currentHumidityInSensor, 5, 1);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.currentSupplyVoltage, 5, 2);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.currentSamplingSpeed, 5, 3);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.currentPressureInSensor, 5, 4);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.temperatureInSensor, 1, 0);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.humidityInSensor, 1, 1);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.supplyVoltage, 1, 2);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.samplingSpeed, 1, 3);
            this.secondaryContentTableLayoutPanel5.Controls.Add(this.pressureInSensor, 1, 4);
            this.secondaryContentTableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondaryContentTableLayoutPanel5.Location = new System.Drawing.Point(3, 483);
            this.secondaryContentTableLayoutPanel5.Name = "secondaryContentTableLayoutPanel5";
            this.secondaryContentTableLayoutPanel5.RowCount = 5;
            this.secondaryContentTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.secondaryContentTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.secondaryContentTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.secondaryContentTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.secondaryContentTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.secondaryContentTableLayoutPanel5.Size = new System.Drawing.Size(701, 136);
            this.secondaryContentTableLayoutPanel5.TabIndex = 4;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.BackColor = System.Drawing.Color.Tomato;
            this.radioButton10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton10.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton10.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton10.Location = new System.Drawing.Point(3, 111);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(26, 22);
            this.radioButton10.TabIndex = 48;
            this.radioButton10.TabStop = true;
            this.radioButton10.UseVisualStyleBackColor = false;
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.BackColor = System.Drawing.Color.BlueViolet;
            this.radioButton11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton11.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton11.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton11.Location = new System.Drawing.Point(3, 84);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(26, 21);
            this.radioButton11.TabIndex = 49;
            this.radioButton11.TabStop = true;
            this.radioButton11.UseVisualStyleBackColor = false;
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.BackColor = System.Drawing.Color.Blue;
            this.radioButton12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton12.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton12.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton12.Location = new System.Drawing.Point(3, 57);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(26, 21);
            this.radioButton12.TabIndex = 50;
            this.radioButton12.TabStop = true;
            this.radioButton12.UseVisualStyleBackColor = false;
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.BackColor = System.Drawing.Color.Cyan;
            this.radioButton13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton13.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton13.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton13.Location = new System.Drawing.Point(3, 30);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(26, 21);
            this.radioButton13.TabIndex = 51;
            this.radioButton13.TabStop = true;
            this.radioButton13.UseVisualStyleBackColor = false;
            // 
            // radioButton14
            // 
            this.radioButton14.AutoSize = true;
            this.radioButton14.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.radioButton14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton14.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton14.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton14.Location = new System.Drawing.Point(3, 3);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.Size = new System.Drawing.Size(26, 21);
            this.radioButton14.TabIndex = 52;
            this.radioButton14.TabStop = true;
            this.radioButton14.UseVisualStyleBackColor = false;
            // 
            // dt_TemperatureInSensor
            // 
            this.dt_TemperatureInSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_TemperatureInSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_TemperatureInSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_TemperatureInSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_TemperatureInSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_TemperatureInSensor.Location = new System.Drawing.Point(650, 3);
            this.dt_TemperatureInSensor.Name = "dt_TemperatureInSensor";
            this.dt_TemperatureInSensor.Size = new System.Drawing.Size(48, 23);
            this.dt_TemperatureInSensor.TabIndex = 41;
            this.dt_TemperatureInSensor.Text = "20";
            this.dt_TemperatureInSensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dt_HumidityInSensor
            // 
            this.dt_HumidityInSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_HumidityInSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_HumidityInSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_HumidityInSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_HumidityInSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_HumidityInSensor.Location = new System.Drawing.Point(650, 30);
            this.dt_HumidityInSensor.Name = "dt_HumidityInSensor";
            this.dt_HumidityInSensor.Size = new System.Drawing.Size(48, 23);
            this.dt_HumidityInSensor.TabIndex = 46;
            this.dt_HumidityInSensor.Text = "20";
            this.dt_HumidityInSensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dt_SupplyVoltage
            // 
            this.dt_SupplyVoltage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_SupplyVoltage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_SupplyVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_SupplyVoltage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_SupplyVoltage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_SupplyVoltage.Location = new System.Drawing.Point(650, 57);
            this.dt_SupplyVoltage.Name = "dt_SupplyVoltage";
            this.dt_SupplyVoltage.Size = new System.Drawing.Size(48, 23);
            this.dt_SupplyVoltage.TabIndex = 45;
            this.dt_SupplyVoltage.Text = "20";
            this.dt_SupplyVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dt_SamplingSpeed
            // 
            this.dt_SamplingSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_SamplingSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_SamplingSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_SamplingSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_SamplingSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_SamplingSpeed.Location = new System.Drawing.Point(650, 84);
            this.dt_SamplingSpeed.Name = "dt_SamplingSpeed";
            this.dt_SamplingSpeed.Size = new System.Drawing.Size(48, 23);
            this.dt_SamplingSpeed.TabIndex = 53;
            this.dt_SamplingSpeed.Text = "20";
            this.dt_SamplingSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dt_PressureInSensor
            // 
            this.dt_PressureInSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_PressureInSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_PressureInSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_PressureInSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_PressureInSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_PressureInSensor.Location = new System.Drawing.Point(650, 111);
            this.dt_PressureInSensor.Name = "dt_PressureInSensor";
            this.dt_PressureInSensor.Size = new System.Drawing.Size(48, 23);
            this.dt_PressureInSensor.TabIndex = 57;
            this.dt_PressureInSensor.Text = "20";
            this.dt_PressureInSensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_PressureInSensor
            // 
            this.dx_PressureInSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_PressureInSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_PressureInSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_PressureInSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_PressureInSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_PressureInSensor.Location = new System.Drawing.Point(585, 111);
            this.dx_PressureInSensor.Name = "dx_PressureInSensor";
            this.dx_PressureInSensor.Size = new System.Drawing.Size(59, 23);
            this.dx_PressureInSensor.TabIndex = 56;
            this.dx_PressureInSensor.Text = "20";
            this.dx_PressureInSensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_SamplingSpeed
            // 
            this.dx_SamplingSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_SamplingSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_SamplingSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_SamplingSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_SamplingSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_SamplingSpeed.Location = new System.Drawing.Point(585, 84);
            this.dx_SamplingSpeed.Name = "dx_SamplingSpeed";
            this.dx_SamplingSpeed.Size = new System.Drawing.Size(59, 23);
            this.dx_SamplingSpeed.TabIndex = 52;
            this.dx_SamplingSpeed.Text = "20";
            this.dx_SamplingSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_SupplyVoltage
            // 
            this.dx_SupplyVoltage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_SupplyVoltage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_SupplyVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_SupplyVoltage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_SupplyVoltage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_SupplyVoltage.Location = new System.Drawing.Point(585, 57);
            this.dx_SupplyVoltage.Name = "dx_SupplyVoltage";
            this.dx_SupplyVoltage.Size = new System.Drawing.Size(59, 23);
            this.dx_SupplyVoltage.TabIndex = 49;
            this.dx_SupplyVoltage.Text = "20";
            this.dx_SupplyVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_HumidityInSensor
            // 
            this.dx_HumidityInSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_HumidityInSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_HumidityInSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_HumidityInSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_HumidityInSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_HumidityInSensor.Location = new System.Drawing.Point(585, 30);
            this.dx_HumidityInSensor.Name = "dx_HumidityInSensor";
            this.dx_HumidityInSensor.Size = new System.Drawing.Size(59, 23);
            this.dx_HumidityInSensor.TabIndex = 44;
            this.dx_HumidityInSensor.Text = "20";
            this.dx_HumidityInSensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_TemperatureInSensor
            // 
            this.dx_TemperatureInSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_TemperatureInSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_TemperatureInSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_TemperatureInSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_TemperatureInSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_TemperatureInSensor.Location = new System.Drawing.Point(585, 3);
            this.dx_TemperatureInSensor.Name = "dx_TemperatureInSensor";
            this.dx_TemperatureInSensor.Size = new System.Drawing.Size(59, 23);
            this.dx_TemperatureInSensor.TabIndex = 40;
            this.dx_TemperatureInSensor.Text = "20";
            this.dx_TemperatureInSensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_2_TemperatureInSensor
            // 
            this.porog_2_TemperatureInSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_TemperatureInSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_TemperatureInSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_TemperatureInSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_TemperatureInSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_TemperatureInSensor.Location = new System.Drawing.Point(534, 3);
            this.porog_2_TemperatureInSensor.Name = "porog_2_TemperatureInSensor";
            this.porog_2_TemperatureInSensor.Size = new System.Drawing.Size(45, 23);
            this.porog_2_TemperatureInSensor.TabIndex = 39;
            this.porog_2_TemperatureInSensor.Text = "20";
            this.porog_2_TemperatureInSensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_2_HumidityInSensor
            // 
            this.porog_2_HumidityInSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_HumidityInSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_HumidityInSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_HumidityInSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_HumidityInSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_HumidityInSensor.Location = new System.Drawing.Point(534, 30);
            this.porog_2_HumidityInSensor.Name = "porog_2_HumidityInSensor";
            this.porog_2_HumidityInSensor.Size = new System.Drawing.Size(45, 23);
            this.porog_2_HumidityInSensor.TabIndex = 43;
            this.porog_2_HumidityInSensor.Text = "20";
            this.porog_2_HumidityInSensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_2_SupplyVoltage
            // 
            this.porog_2_SupplyVoltage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_SupplyVoltage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_SupplyVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_SupplyVoltage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_SupplyVoltage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_SupplyVoltage.Location = new System.Drawing.Point(534, 57);
            this.porog_2_SupplyVoltage.Name = "porog_2_SupplyVoltage";
            this.porog_2_SupplyVoltage.Size = new System.Drawing.Size(45, 23);
            this.porog_2_SupplyVoltage.TabIndex = 48;
            this.porog_2_SupplyVoltage.Text = "20";
            this.porog_2_SupplyVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_2_SamplingSpeed
            // 
            this.porog_2_SamplingSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_SamplingSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_SamplingSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_SamplingSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_SamplingSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_SamplingSpeed.Location = new System.Drawing.Point(534, 84);
            this.porog_2_SamplingSpeed.Name = "porog_2_SamplingSpeed";
            this.porog_2_SamplingSpeed.Size = new System.Drawing.Size(45, 23);
            this.porog_2_SamplingSpeed.TabIndex = 51;
            this.porog_2_SamplingSpeed.Text = "20";
            this.porog_2_SamplingSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_2_PressureInSensor
            // 
            this.porog_2_PressureInSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_PressureInSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_PressureInSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_PressureInSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_PressureInSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_PressureInSensor.Location = new System.Drawing.Point(534, 111);
            this.porog_2_PressureInSensor.Name = "porog_2_PressureInSensor";
            this.porog_2_PressureInSensor.Size = new System.Drawing.Size(45, 23);
            this.porog_2_PressureInSensor.TabIndex = 55;
            this.porog_2_PressureInSensor.Text = "20";
            this.porog_2_PressureInSensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_PressureInSensor
            // 
            this.porog_1_PressureInSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_PressureInSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_PressureInSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_PressureInSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_PressureInSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_PressureInSensor.Location = new System.Drawing.Point(489, 111);
            this.porog_1_PressureInSensor.Name = "porog_1_PressureInSensor";
            this.porog_1_PressureInSensor.Size = new System.Drawing.Size(39, 23);
            this.porog_1_PressureInSensor.TabIndex = 54;
            this.porog_1_PressureInSensor.Text = "20";
            this.porog_1_PressureInSensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_SamplingSpeed
            // 
            this.porog_1_SamplingSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_SamplingSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_SamplingSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_SamplingSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_SamplingSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_SamplingSpeed.Location = new System.Drawing.Point(489, 84);
            this.porog_1_SamplingSpeed.Name = "porog_1_SamplingSpeed";
            this.porog_1_SamplingSpeed.Size = new System.Drawing.Size(39, 23);
            this.porog_1_SamplingSpeed.TabIndex = 50;
            this.porog_1_SamplingSpeed.Text = "20";
            this.porog_1_SamplingSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_SupplyVoltage
            // 
            this.porog_1_SupplyVoltage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_SupplyVoltage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_SupplyVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_SupplyVoltage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_SupplyVoltage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_SupplyVoltage.Location = new System.Drawing.Point(489, 57);
            this.porog_1_SupplyVoltage.Name = "porog_1_SupplyVoltage";
            this.porog_1_SupplyVoltage.Size = new System.Drawing.Size(39, 23);
            this.porog_1_SupplyVoltage.TabIndex = 47;
            this.porog_1_SupplyVoltage.Text = "20";
            this.porog_1_SupplyVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_HumidityInSensor
            // 
            this.porog_1_HumidityInSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_HumidityInSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_HumidityInSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_HumidityInSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_HumidityInSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_HumidityInSensor.Location = new System.Drawing.Point(489, 30);
            this.porog_1_HumidityInSensor.Name = "porog_1_HumidityInSensor";
            this.porog_1_HumidityInSensor.Size = new System.Drawing.Size(39, 23);
            this.porog_1_HumidityInSensor.TabIndex = 42;
            this.porog_1_HumidityInSensor.Text = "20";
            this.porog_1_HumidityInSensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_TemperatureInSensor
            // 
            this.porog_1_TemperatureInSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_TemperatureInSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_TemperatureInSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_TemperatureInSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_TemperatureInSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_TemperatureInSensor.Location = new System.Drawing.Point(489, 3);
            this.porog_1_TemperatureInSensor.Name = "porog_1_TemperatureInSensor";
            this.porog_1_TemperatureInSensor.Size = new System.Drawing.Size(39, 23);
            this.porog_1_TemperatureInSensor.TabIndex = 38;
            this.porog_1_TemperatureInSensor.Text = "20";
            this.porog_1_TemperatureInSensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // currentTemperatureInSensor
            // 
            this.currentTemperatureInSensor.AutoSize = true;
            this.currentTemperatureInSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.currentTemperatureInSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentTemperatureInSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentTemperatureInSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentTemperatureInSensor.Location = new System.Drawing.Point(411, 0);
            this.currentTemperatureInSensor.Name = "currentTemperatureInSensor";
            this.currentTemperatureInSensor.Size = new System.Drawing.Size(72, 27);
            this.currentTemperatureInSensor.TabIndex = 26;
            this.currentTemperatureInSensor.Text = "23.9";
            this.currentTemperatureInSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentHumidityInSensor
            // 
            this.currentHumidityInSensor.AutoSize = true;
            this.currentHumidityInSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.currentHumidityInSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentHumidityInSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentHumidityInSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentHumidityInSensor.Location = new System.Drawing.Point(411, 27);
            this.currentHumidityInSensor.Name = "currentHumidityInSensor";
            this.currentHumidityInSensor.Size = new System.Drawing.Size(72, 27);
            this.currentHumidityInSensor.TabIndex = 28;
            this.currentHumidityInSensor.Text = "23.9";
            this.currentHumidityInSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentSupplyVoltage
            // 
            this.currentSupplyVoltage.AutoSize = true;
            this.currentSupplyVoltage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.currentSupplyVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentSupplyVoltage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentSupplyVoltage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentSupplyVoltage.Location = new System.Drawing.Point(411, 54);
            this.currentSupplyVoltage.Name = "currentSupplyVoltage";
            this.currentSupplyVoltage.Size = new System.Drawing.Size(72, 27);
            this.currentSupplyVoltage.TabIndex = 29;
            this.currentSupplyVoltage.Text = "23.9";
            this.currentSupplyVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentSamplingSpeed
            // 
            this.currentSamplingSpeed.AutoSize = true;
            this.currentSamplingSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.currentSamplingSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentSamplingSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentSamplingSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentSamplingSpeed.Location = new System.Drawing.Point(411, 81);
            this.currentSamplingSpeed.Name = "currentSamplingSpeed";
            this.currentSamplingSpeed.Size = new System.Drawing.Size(72, 27);
            this.currentSamplingSpeed.TabIndex = 30;
            this.currentSamplingSpeed.Text = "23.9";
            this.currentSamplingSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentPressureInSensor
            // 
            this.currentPressureInSensor.AutoSize = true;
            this.currentPressureInSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.currentPressureInSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentPressureInSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentPressureInSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentPressureInSensor.Location = new System.Drawing.Point(411, 108);
            this.currentPressureInSensor.Name = "currentPressureInSensor";
            this.currentPressureInSensor.Size = new System.Drawing.Size(72, 28);
            this.currentPressureInSensor.TabIndex = 31;
            this.currentPressureInSensor.Text = "23.9";
            this.currentPressureInSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // temperatureInSensor
            // 
            this.temperatureInSensor.AutoSize = true;
            this.temperatureInSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.temperatureInSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.temperatureInSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.temperatureInSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.temperatureInSensor.Location = new System.Drawing.Point(35, 0);
            this.temperatureInSensor.Name = "temperatureInSensor";
            this.temperatureInSensor.Size = new System.Drawing.Size(163, 27);
            this.temperatureInSensor.TabIndex = 23;
            this.temperatureInSensor.Text = "Температура (- 45 до +45°С)";
            this.temperatureInSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // humidityInSensor
            // 
            this.humidityInSensor.AutoSize = true;
            this.humidityInSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.humidityInSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.humidityInSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.humidityInSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.humidityInSensor.Location = new System.Drawing.Point(35, 27);
            this.humidityInSensor.Name = "humidityInSensor";
            this.humidityInSensor.Size = new System.Drawing.Size(163, 27);
            this.humidityInSensor.TabIndex = 26;
            this.humidityInSensor.Text = "Отн. влажность (0 - 98 %)";
            this.humidityInSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // supplyVoltage
            // 
            this.supplyVoltage.AutoSize = true;
            this.supplyVoltage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.supplyVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.supplyVoltage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.supplyVoltage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.supplyVoltage.Location = new System.Drawing.Point(35, 54);
            this.supplyVoltage.Name = "supplyVoltage";
            this.supplyVoltage.Size = new System.Drawing.Size(163, 27);
            this.supplyVoltage.TabIndex = 24;
            this.supplyVoltage.Text = "Напряжение (8 - 16 В)";
            this.supplyVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // samplingSpeed
            // 
            this.samplingSpeed.AutoSize = true;
            this.samplingSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.samplingSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.samplingSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.samplingSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.samplingSpeed.Location = new System.Drawing.Point(35, 81);
            this.samplingSpeed.Name = "samplingSpeed";
            this.samplingSpeed.Size = new System.Drawing.Size(163, 27);
            this.samplingSpeed.TabIndex = 27;
            this.samplingSpeed.Text = "Скор. потока (0 - 1 л/мин) ";
            this.samplingSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pressureInSensor
            // 
            this.pressureInSensor.AutoSize = true;
            this.pressureInSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pressureInSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pressureInSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pressureInSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.pressureInSensor.Location = new System.Drawing.Point(35, 108);
            this.pressureInSensor.Name = "pressureInSensor";
            this.pressureInSensor.Size = new System.Drawing.Size(163, 28);
            this.pressureInSensor.TabIndex = 25;
            this.pressureInSensor.Text = "Атм. дав-ние (650 - 1200 hPa)";
            this.pressureInSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // secondaryContentTableLayoutPanel4
            // 
            this.secondaryContentTableLayoutPanel4.ColumnCount = 10;
            this.secondaryContentTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.035874F));
            this.secondaryContentTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.66368F));
            this.secondaryContentTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.922823F));
            this.secondaryContentTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.80485F));
            this.secondaryContentTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.040793F));
            this.secondaryContentTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.35612F));
            this.secondaryContentTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.394708F));
            this.secondaryContentTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.497244F));
            this.secondaryContentTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.151048F));
            this.secondaryContentTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.945976F));
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.radioButton15, 0, 2);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.radioButton16, 0, 1);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.radioButton17, 0, 0);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.dt_VibrationLevel, 9, 0);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.dt_TiltLevel, 9, 1);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.dt_TamperSensor, 9, 2);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.dx_TamperSensor, 8, 2);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.dx_TiltLevel, 8, 1);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.dx_VibrationLevel, 8, 0);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.porog_2_VibrationLevel, 7, 0);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.porog_2_TiltLevel, 7, 1);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.porog_2_TamperSensor, 7, 2);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.porog_1_TamperSensor, 6, 2);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.porog_1_TiltLevel, 6, 1);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.porog_1_VibrationLevel, 6, 0);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.currentVibrationLevel, 5, 0);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.currentTiltLevel, 5, 1);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.currentTamperSensor, 5, 2);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.tamperSensor, 1, 2);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.tiltLevel, 1, 1);
            this.secondaryContentTableLayoutPanel4.Controls.Add(this.vibrationLevel, 1, 0);
            this.secondaryContentTableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondaryContentTableLayoutPanel4.Location = new System.Drawing.Point(3, 399);
            this.secondaryContentTableLayoutPanel4.Name = "secondaryContentTableLayoutPanel4";
            this.secondaryContentTableLayoutPanel4.RowCount = 3;
            this.secondaryContentTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.secondaryContentTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.secondaryContentTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.secondaryContentTableLayoutPanel4.Size = new System.Drawing.Size(701, 78);
            this.secondaryContentTableLayoutPanel4.TabIndex = 3;
            // 
            // radioButton15
            // 
            this.radioButton15.AutoSize = true;
            this.radioButton15.BackColor = System.Drawing.Color.Fuchsia;
            this.radioButton15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton15.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton15.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton15.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton15.Location = new System.Drawing.Point(3, 55);
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.Size = new System.Drawing.Size(22, 20);
            this.radioButton15.TabIndex = 53;
            this.radioButton15.TabStop = true;
            this.radioButton15.UseVisualStyleBackColor = false;
            // 
            // radioButton16
            // 
            this.radioButton16.AutoSize = true;
            this.radioButton16.BackColor = System.Drawing.Color.Gold;
            this.radioButton16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton16.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton16.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton16.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton16.Location = new System.Drawing.Point(3, 29);
            this.radioButton16.Name = "radioButton16";
            this.radioButton16.Size = new System.Drawing.Size(22, 20);
            this.radioButton16.TabIndex = 54;
            this.radioButton16.TabStop = true;
            this.radioButton16.UseVisualStyleBackColor = false;
            // 
            // radioButton17
            // 
            this.radioButton17.AutoSize = true;
            this.radioButton17.BackColor = System.Drawing.Color.MediumAquamarine;
            this.radioButton17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton17.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton17.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton17.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton17.Location = new System.Drawing.Point(3, 3);
            this.radioButton17.Name = "radioButton17";
            this.radioButton17.Size = new System.Drawing.Size(22, 20);
            this.radioButton17.TabIndex = 55;
            this.radioButton17.TabStop = true;
            this.radioButton17.UseVisualStyleBackColor = false;
            // 
            // dt_VibrationLevel
            // 
            this.dt_VibrationLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_VibrationLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_VibrationLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_VibrationLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_VibrationLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_VibrationLevel.Location = new System.Drawing.Point(650, 3);
            this.dt_VibrationLevel.Name = "dt_VibrationLevel";
            this.dt_VibrationLevel.Size = new System.Drawing.Size(48, 23);
            this.dt_VibrationLevel.TabIndex = 29;
            this.dt_VibrationLevel.Text = "20";
            this.dt_VibrationLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dt_TiltLevel
            // 
            this.dt_TiltLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_TiltLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_TiltLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_TiltLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_TiltLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_TiltLevel.Location = new System.Drawing.Point(650, 29);
            this.dt_TiltLevel.Name = "dt_TiltLevel";
            this.dt_TiltLevel.Size = new System.Drawing.Size(48, 23);
            this.dt_TiltLevel.TabIndex = 33;
            this.dt_TiltLevel.Text = "20";
            this.dt_TiltLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dt_TamperSensor
            // 
            this.dt_TamperSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_TamperSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_TamperSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_TamperSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_TamperSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_TamperSensor.Location = new System.Drawing.Point(650, 55);
            this.dt_TamperSensor.Name = "dt_TamperSensor";
            this.dt_TamperSensor.Size = new System.Drawing.Size(48, 23);
            this.dt_TamperSensor.TabIndex = 37;
            this.dt_TamperSensor.Text = "20";
            this.dt_TamperSensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_TamperSensor
            // 
            this.dx_TamperSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_TamperSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_TamperSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_TamperSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_TamperSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_TamperSensor.Location = new System.Drawing.Point(586, 55);
            this.dx_TamperSensor.Name = "dx_TamperSensor";
            this.dx_TamperSensor.Size = new System.Drawing.Size(58, 23);
            this.dx_TamperSensor.TabIndex = 36;
            this.dx_TamperSensor.Text = "20";
            this.dx_TamperSensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_TiltLevel
            // 
            this.dx_TiltLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_TiltLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_TiltLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_TiltLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_TiltLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_TiltLevel.Location = new System.Drawing.Point(586, 29);
            this.dx_TiltLevel.Name = "dx_TiltLevel";
            this.dx_TiltLevel.Size = new System.Drawing.Size(58, 23);
            this.dx_TiltLevel.TabIndex = 32;
            this.dx_TiltLevel.Text = "20";
            this.dx_TiltLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_VibrationLevel
            // 
            this.dx_VibrationLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_VibrationLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_VibrationLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_VibrationLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_VibrationLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_VibrationLevel.Location = new System.Drawing.Point(586, 3);
            this.dx_VibrationLevel.Name = "dx_VibrationLevel";
            this.dx_VibrationLevel.Size = new System.Drawing.Size(58, 23);
            this.dx_VibrationLevel.TabIndex = 28;
            this.dx_VibrationLevel.Text = "20";
            this.dx_VibrationLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_2_VibrationLevel
            // 
            this.porog_2_VibrationLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_VibrationLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_VibrationLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_VibrationLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_VibrationLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_VibrationLevel.Location = new System.Drawing.Point(534, 3);
            this.porog_2_VibrationLevel.Name = "porog_2_VibrationLevel";
            this.porog_2_VibrationLevel.Size = new System.Drawing.Size(46, 23);
            this.porog_2_VibrationLevel.TabIndex = 27;
            this.porog_2_VibrationLevel.Text = "20";
            this.porog_2_VibrationLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_2_TiltLevel
            // 
            this.porog_2_TiltLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_TiltLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_TiltLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_TiltLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_TiltLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_TiltLevel.Location = new System.Drawing.Point(534, 29);
            this.porog_2_TiltLevel.Name = "porog_2_TiltLevel";
            this.porog_2_TiltLevel.Size = new System.Drawing.Size(46, 23);
            this.porog_2_TiltLevel.TabIndex = 31;
            this.porog_2_TiltLevel.Text = "20";
            this.porog_2_TiltLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_2_TamperSensor
            // 
            this.porog_2_TamperSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_TamperSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_TamperSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_TamperSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_TamperSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_TamperSensor.Location = new System.Drawing.Point(534, 55);
            this.porog_2_TamperSensor.Name = "porog_2_TamperSensor";
            this.porog_2_TamperSensor.Size = new System.Drawing.Size(46, 23);
            this.porog_2_TamperSensor.TabIndex = 35;
            this.porog_2_TamperSensor.Text = "20";
            this.porog_2_TamperSensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_TamperSensor
            // 
            this.porog_1_TamperSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_TamperSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_TamperSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_TamperSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_TamperSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_TamperSensor.Location = new System.Drawing.Point(490, 55);
            this.porog_1_TamperSensor.Name = "porog_1_TamperSensor";
            this.porog_1_TamperSensor.Size = new System.Drawing.Size(38, 23);
            this.porog_1_TamperSensor.TabIndex = 34;
            this.porog_1_TamperSensor.Text = "20";
            this.porog_1_TamperSensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_TiltLevel
            // 
            this.porog_1_TiltLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_TiltLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_TiltLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_TiltLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_TiltLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_TiltLevel.Location = new System.Drawing.Point(490, 29);
            this.porog_1_TiltLevel.Name = "porog_1_TiltLevel";
            this.porog_1_TiltLevel.Size = new System.Drawing.Size(38, 23);
            this.porog_1_TiltLevel.TabIndex = 30;
            this.porog_1_TiltLevel.Text = "20";
            this.porog_1_TiltLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_VibrationLevel
            // 
            this.porog_1_VibrationLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_VibrationLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_VibrationLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_VibrationLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_VibrationLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_VibrationLevel.Location = new System.Drawing.Point(490, 3);
            this.porog_1_VibrationLevel.Name = "porog_1_VibrationLevel";
            this.porog_1_VibrationLevel.Size = new System.Drawing.Size(38, 23);
            this.porog_1_VibrationLevel.TabIndex = 26;
            this.porog_1_VibrationLevel.Text = "20";
            this.porog_1_VibrationLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // currentVibrationLevel
            // 
            this.currentVibrationLevel.AutoSize = true;
            this.currentVibrationLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.currentVibrationLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentVibrationLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentVibrationLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentVibrationLevel.Location = new System.Drawing.Point(411, 0);
            this.currentVibrationLevel.Name = "currentVibrationLevel";
            this.currentVibrationLevel.Size = new System.Drawing.Size(73, 26);
            this.currentVibrationLevel.TabIndex = 23;
            this.currentVibrationLevel.Text = "23.9";
            this.currentVibrationLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentTiltLevel
            // 
            this.currentTiltLevel.AutoSize = true;
            this.currentTiltLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.currentTiltLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentTiltLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentTiltLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentTiltLevel.Location = new System.Drawing.Point(411, 26);
            this.currentTiltLevel.Name = "currentTiltLevel";
            this.currentTiltLevel.Size = new System.Drawing.Size(73, 26);
            this.currentTiltLevel.TabIndex = 24;
            this.currentTiltLevel.Text = "23.9";
            this.currentTiltLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentTamperSensor
            // 
            this.currentTamperSensor.AutoSize = true;
            this.currentTamperSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.currentTamperSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentTamperSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentTamperSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentTamperSensor.Location = new System.Drawing.Point(411, 52);
            this.currentTamperSensor.Name = "currentTamperSensor";
            this.currentTamperSensor.Size = new System.Drawing.Size(73, 26);
            this.currentTamperSensor.TabIndex = 25;
            this.currentTamperSensor.Text = "23.9";
            this.currentTamperSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tamperSensor
            // 
            this.tamperSensor.AutoSize = true;
            this.tamperSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tamperSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tamperSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tamperSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.tamperSensor.Location = new System.Drawing.Point(31, 52);
            this.tamperSensor.Name = "tamperSensor";
            this.tamperSensor.Size = new System.Drawing.Size(167, 26);
            this.tamperSensor.TabIndex = 21;
            this.tamperSensor.Text = "Взлом (0 - 100 %)";
            this.tamperSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tiltLevel
            // 
            this.tiltLevel.AutoSize = true;
            this.tiltLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tiltLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tiltLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tiltLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.tiltLevel.Location = new System.Drawing.Point(31, 26);
            this.tiltLevel.Name = "tiltLevel";
            this.tiltLevel.Size = new System.Drawing.Size(167, 26);
            this.tiltLevel.TabIndex = 22;
            this.tiltLevel.Text = "Наклон (0 - 45°)";
            this.tiltLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vibrationLevel
            // 
            this.vibrationLevel.AutoSize = true;
            this.vibrationLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.vibrationLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vibrationLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.vibrationLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.vibrationLevel.Location = new System.Drawing.Point(31, 0);
            this.vibrationLevel.Name = "vibrationLevel";
            this.vibrationLevel.Size = new System.Drawing.Size(167, 26);
            this.vibrationLevel.TabIndex = 20;
            this.vibrationLevel.Text = "Микроускорения (0 - 10 м /с)";
            this.vibrationLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // secondaryContentTableLayoutPanel3
            // 
            this.secondaryContentTableLayoutPanel3.ColumnCount = 10;
            this.secondaryContentTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.886398F));
            this.secondaryContentTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.66368F));
            this.secondaryContentTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.922823F));
            this.secondaryContentTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.6946F));
            this.secondaryContentTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.040793F));
            this.secondaryContentTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.24587F));
            this.secondaryContentTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.725469F));
            this.secondaryContentTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.38699F));
            this.secondaryContentTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.371554F));
            this.secondaryContentTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.945976F));
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.radioButton18, 0, 2);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.radioButton19, 0, 1);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.radioButton20, 0, 0);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.dt_ParticulateMatterPM10, 9, 2);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.dt_ParticulateMatterPM2_5, 9, 1);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.dt_ParticulateMatterPM1, 9, 0);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.dx_ParticulateMatterPM1, 8, 0);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.dx_ParticulateMatterPM2_5, 8, 1);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.dx_ParticulateMatterPM10, 8, 2);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.porog_2_ParticulateMatterPM10, 7, 2);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.porog_2_ParticulateMatterPM2_5, 7, 1);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.porog_2_ParticulateMatterPM1, 7, 0);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.porog_1_ParticulateMatterPM1, 6, 0);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.porog_1_ParticulateMatterPM2_5, 6, 1);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.porog_1_ParticulateMatterPM10, 6, 2);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.currentParticulateMatterPM10, 5, 2);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.currentParticulateMatterPM2_5, 5, 1);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.currentParticulateMatterPM1, 5, 0);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.particulateMatterPM1, 1, 0);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.particulateMatterPM2_5, 1, 1);
            this.secondaryContentTableLayoutPanel3.Controls.Add(this.particulateMatterPM10, 1, 2);
            this.secondaryContentTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondaryContentTableLayoutPanel3.Location = new System.Drawing.Point(3, 308);
            this.secondaryContentTableLayoutPanel3.Name = "secondaryContentTableLayoutPanel3";
            this.secondaryContentTableLayoutPanel3.RowCount = 3;
            this.secondaryContentTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.secondaryContentTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.secondaryContentTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.secondaryContentTableLayoutPanel3.Size = new System.Drawing.Size(701, 85);
            this.secondaryContentTableLayoutPanel3.TabIndex = 2;
            // 
            // radioButton18
            // 
            this.radioButton18.AutoSize = true;
            this.radioButton18.BackColor = System.Drawing.Color.PaleGreen;
            this.radioButton18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton18.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton18.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton18.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton18.Location = new System.Drawing.Point(3, 59);
            this.radioButton18.Name = "radioButton18";
            this.radioButton18.Size = new System.Drawing.Size(21, 23);
            this.radioButton18.TabIndex = 56;
            this.radioButton18.TabStop = true;
            this.radioButton18.UseVisualStyleBackColor = false;
            // 
            // radioButton19
            // 
            this.radioButton19.AutoSize = true;
            this.radioButton19.BackColor = System.Drawing.Color.Crimson;
            this.radioButton19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton19.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton19.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton19.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton19.Location = new System.Drawing.Point(3, 31);
            this.radioButton19.Name = "radioButton19";
            this.radioButton19.Size = new System.Drawing.Size(21, 22);
            this.radioButton19.TabIndex = 57;
            this.radioButton19.TabStop = true;
            this.radioButton19.UseVisualStyleBackColor = false;
            // 
            // radioButton20
            // 
            this.radioButton20.AutoSize = true;
            this.radioButton20.BackColor = System.Drawing.Color.Violet;
            this.radioButton20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton20.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton20.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton20.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton20.Location = new System.Drawing.Point(3, 3);
            this.radioButton20.Name = "radioButton20";
            this.radioButton20.Size = new System.Drawing.Size(21, 22);
            this.radioButton20.TabIndex = 58;
            this.radioButton20.TabStop = true;
            this.radioButton20.UseVisualStyleBackColor = false;
            // 
            // dt_ParticulateMatterPM10
            // 
            this.dt_ParticulateMatterPM10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_ParticulateMatterPM10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ParticulateMatterPM10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_ParticulateMatterPM10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_ParticulateMatterPM10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_ParticulateMatterPM10.Location = new System.Drawing.Point(651, 59);
            this.dt_ParticulateMatterPM10.Name = "dt_ParticulateMatterPM10";
            this.dt_ParticulateMatterPM10.Size = new System.Drawing.Size(47, 23);
            this.dt_ParticulateMatterPM10.TabIndex = 60;
            this.dt_ParticulateMatterPM10.Text = "20";
            this.dt_ParticulateMatterPM10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dt_ParticulateMatterPM2_5
            // 
            this.dt_ParticulateMatterPM2_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_ParticulateMatterPM2_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ParticulateMatterPM2_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_ParticulateMatterPM2_5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_ParticulateMatterPM2_5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_ParticulateMatterPM2_5.Location = new System.Drawing.Point(651, 31);
            this.dt_ParticulateMatterPM2_5.Name = "dt_ParticulateMatterPM2_5";
            this.dt_ParticulateMatterPM2_5.Size = new System.Drawing.Size(47, 23);
            this.dt_ParticulateMatterPM2_5.TabIndex = 56;
            this.dt_ParticulateMatterPM2_5.Text = "20";
            this.dt_ParticulateMatterPM2_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dt_ParticulateMatterPM1
            // 
            this.dt_ParticulateMatterPM1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_ParticulateMatterPM1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ParticulateMatterPM1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_ParticulateMatterPM1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_ParticulateMatterPM1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_ParticulateMatterPM1.Location = new System.Drawing.Point(651, 3);
            this.dt_ParticulateMatterPM1.Name = "dt_ParticulateMatterPM1";
            this.dt_ParticulateMatterPM1.Size = new System.Drawing.Size(47, 23);
            this.dt_ParticulateMatterPM1.TabIndex = 52;
            this.dt_ParticulateMatterPM1.Text = "20";
            this.dt_ParticulateMatterPM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_ParticulateMatterPM1
            // 
            this.dx_ParticulateMatterPM1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_ParticulateMatterPM1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_ParticulateMatterPM1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_ParticulateMatterPM1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_ParticulateMatterPM1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_ParticulateMatterPM1.Location = new System.Drawing.Point(586, 3);
            this.dx_ParticulateMatterPM1.Name = "dx_ParticulateMatterPM1";
            this.dx_ParticulateMatterPM1.Size = new System.Drawing.Size(59, 23);
            this.dx_ParticulateMatterPM1.TabIndex = 51;
            this.dx_ParticulateMatterPM1.Text = "20";
            this.dx_ParticulateMatterPM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_ParticulateMatterPM2_5
            // 
            this.dx_ParticulateMatterPM2_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_ParticulateMatterPM2_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_ParticulateMatterPM2_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_ParticulateMatterPM2_5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_ParticulateMatterPM2_5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_ParticulateMatterPM2_5.Location = new System.Drawing.Point(586, 31);
            this.dx_ParticulateMatterPM2_5.Name = "dx_ParticulateMatterPM2_5";
            this.dx_ParticulateMatterPM2_5.Size = new System.Drawing.Size(59, 23);
            this.dx_ParticulateMatterPM2_5.TabIndex = 55;
            this.dx_ParticulateMatterPM2_5.Text = "20";
            this.dx_ParticulateMatterPM2_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_ParticulateMatterPM10
            // 
            this.dx_ParticulateMatterPM10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_ParticulateMatterPM10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_ParticulateMatterPM10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_ParticulateMatterPM10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_ParticulateMatterPM10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_ParticulateMatterPM10.Location = new System.Drawing.Point(586, 59);
            this.dx_ParticulateMatterPM10.Name = "dx_ParticulateMatterPM10";
            this.dx_ParticulateMatterPM10.Size = new System.Drawing.Size(59, 23);
            this.dx_ParticulateMatterPM10.TabIndex = 59;
            this.dx_ParticulateMatterPM10.Text = "20";
            this.dx_ParticulateMatterPM10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_2_ParticulateMatterPM10
            // 
            this.porog_2_ParticulateMatterPM10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_ParticulateMatterPM10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_ParticulateMatterPM10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_ParticulateMatterPM10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_ParticulateMatterPM10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_ParticulateMatterPM10.Location = new System.Drawing.Point(535, 59);
            this.porog_2_ParticulateMatterPM10.Name = "porog_2_ParticulateMatterPM10";
            this.porog_2_ParticulateMatterPM10.Size = new System.Drawing.Size(45, 23);
            this.porog_2_ParticulateMatterPM10.TabIndex = 58;
            this.porog_2_ParticulateMatterPM10.Text = "20";
            this.porog_2_ParticulateMatterPM10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_2_ParticulateMatterPM2_5
            // 
            this.porog_2_ParticulateMatterPM2_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_ParticulateMatterPM2_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_ParticulateMatterPM2_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_ParticulateMatterPM2_5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_ParticulateMatterPM2_5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_ParticulateMatterPM2_5.Location = new System.Drawing.Point(535, 31);
            this.porog_2_ParticulateMatterPM2_5.Name = "porog_2_ParticulateMatterPM2_5";
            this.porog_2_ParticulateMatterPM2_5.Size = new System.Drawing.Size(45, 23);
            this.porog_2_ParticulateMatterPM2_5.TabIndex = 54;
            this.porog_2_ParticulateMatterPM2_5.Text = "20";
            this.porog_2_ParticulateMatterPM2_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_2_ParticulateMatterPM1
            // 
            this.porog_2_ParticulateMatterPM1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_ParticulateMatterPM1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_ParticulateMatterPM1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_ParticulateMatterPM1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_ParticulateMatterPM1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_ParticulateMatterPM1.Location = new System.Drawing.Point(535, 3);
            this.porog_2_ParticulateMatterPM1.Name = "porog_2_ParticulateMatterPM1";
            this.porog_2_ParticulateMatterPM1.Size = new System.Drawing.Size(45, 23);
            this.porog_2_ParticulateMatterPM1.TabIndex = 50;
            this.porog_2_ParticulateMatterPM1.Text = "20";
            this.porog_2_ParticulateMatterPM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_ParticulateMatterPM1
            // 
            this.porog_1_ParticulateMatterPM1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_ParticulateMatterPM1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_ParticulateMatterPM1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_ParticulateMatterPM1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_ParticulateMatterPM1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_ParticulateMatterPM1.Location = new System.Drawing.Point(488, 3);
            this.porog_1_ParticulateMatterPM1.Name = "porog_1_ParticulateMatterPM1";
            this.porog_1_ParticulateMatterPM1.Size = new System.Drawing.Size(41, 23);
            this.porog_1_ParticulateMatterPM1.TabIndex = 49;
            this.porog_1_ParticulateMatterPM1.Text = "20";
            this.porog_1_ParticulateMatterPM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_ParticulateMatterPM2_5
            // 
            this.porog_1_ParticulateMatterPM2_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_ParticulateMatterPM2_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_ParticulateMatterPM2_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_ParticulateMatterPM2_5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_ParticulateMatterPM2_5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_ParticulateMatterPM2_5.Location = new System.Drawing.Point(488, 31);
            this.porog_1_ParticulateMatterPM2_5.Name = "porog_1_ParticulateMatterPM2_5";
            this.porog_1_ParticulateMatterPM2_5.Size = new System.Drawing.Size(41, 23);
            this.porog_1_ParticulateMatterPM2_5.TabIndex = 53;
            this.porog_1_ParticulateMatterPM2_5.Text = "20";
            this.porog_1_ParticulateMatterPM2_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_ParticulateMatterPM10
            // 
            this.porog_1_ParticulateMatterPM10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_ParticulateMatterPM10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_ParticulateMatterPM10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_ParticulateMatterPM10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_ParticulateMatterPM10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_ParticulateMatterPM10.Location = new System.Drawing.Point(488, 59);
            this.porog_1_ParticulateMatterPM10.Name = "porog_1_ParticulateMatterPM10";
            this.porog_1_ParticulateMatterPM10.Size = new System.Drawing.Size(41, 23);
            this.porog_1_ParticulateMatterPM10.TabIndex = 57;
            this.porog_1_ParticulateMatterPM10.Text = "20";
            this.porog_1_ParticulateMatterPM10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // currentParticulateMatterPM10
            // 
            this.currentParticulateMatterPM10.AutoSize = true;
            this.currentParticulateMatterPM10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.currentParticulateMatterPM10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentParticulateMatterPM10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentParticulateMatterPM10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentParticulateMatterPM10.Location = new System.Drawing.Point(410, 56);
            this.currentParticulateMatterPM10.Name = "currentParticulateMatterPM10";
            this.currentParticulateMatterPM10.Size = new System.Drawing.Size(72, 29);
            this.currentParticulateMatterPM10.TabIndex = 22;
            this.currentParticulateMatterPM10.Text = "23.9";
            this.currentParticulateMatterPM10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentParticulateMatterPM2_5
            // 
            this.currentParticulateMatterPM2_5.AutoSize = true;
            this.currentParticulateMatterPM2_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.currentParticulateMatterPM2_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentParticulateMatterPM2_5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentParticulateMatterPM2_5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentParticulateMatterPM2_5.Location = new System.Drawing.Point(410, 28);
            this.currentParticulateMatterPM2_5.Name = "currentParticulateMatterPM2_5";
            this.currentParticulateMatterPM2_5.Size = new System.Drawing.Size(72, 28);
            this.currentParticulateMatterPM2_5.TabIndex = 21;
            this.currentParticulateMatterPM2_5.Text = "23.9";
            this.currentParticulateMatterPM2_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentParticulateMatterPM1
            // 
            this.currentParticulateMatterPM1.AutoSize = true;
            this.currentParticulateMatterPM1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.currentParticulateMatterPM1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentParticulateMatterPM1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentParticulateMatterPM1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentParticulateMatterPM1.Location = new System.Drawing.Point(410, 0);
            this.currentParticulateMatterPM1.Name = "currentParticulateMatterPM1";
            this.currentParticulateMatterPM1.Size = new System.Drawing.Size(72, 28);
            this.currentParticulateMatterPM1.TabIndex = 20;
            this.currentParticulateMatterPM1.Text = "23.9";
            this.currentParticulateMatterPM1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // particulateMatterPM1
            // 
            this.particulateMatterPM1.AutoSize = true;
            this.particulateMatterPM1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.particulateMatterPM1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.particulateMatterPM1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.particulateMatterPM1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.particulateMatterPM1.Location = new System.Drawing.Point(30, 0);
            this.particulateMatterPM1.Name = "particulateMatterPM1";
            this.particulateMatterPM1.Size = new System.Drawing.Size(167, 28);
            this.particulateMatterPM1.TabIndex = 17;
            this.particulateMatterPM1.Text = "PM 1.0 (0 - 1000 мкг / м³)";
            this.particulateMatterPM1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // particulateMatterPM2_5
            // 
            this.particulateMatterPM2_5.AutoSize = true;
            this.particulateMatterPM2_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.particulateMatterPM2_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.particulateMatterPM2_5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.particulateMatterPM2_5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.particulateMatterPM2_5.Location = new System.Drawing.Point(30, 28);
            this.particulateMatterPM2_5.Name = "particulateMatterPM2_5";
            this.particulateMatterPM2_5.Size = new System.Drawing.Size(167, 28);
            this.particulateMatterPM2_5.TabIndex = 19;
            this.particulateMatterPM2_5.Text = "PM 2.5 (0 - 1000 мкг / м³)";
            this.particulateMatterPM2_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // particulateMatterPM10
            // 
            this.particulateMatterPM10.AutoSize = true;
            this.particulateMatterPM10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.particulateMatterPM10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.particulateMatterPM10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.particulateMatterPM10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.particulateMatterPM10.Location = new System.Drawing.Point(30, 56);
            this.particulateMatterPM10.Name = "particulateMatterPM10";
            this.particulateMatterPM10.Size = new System.Drawing.Size(167, 29);
            this.particulateMatterPM10.TabIndex = 18;
            this.particulateMatterPM10.Text = "PM 10 (0 - 1000 мкг / м³)";
            this.particulateMatterPM10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // secondaryContentTableLayoutPanel2
            // 
            this.secondaryContentTableLayoutPanel2.ColumnCount = 10;
            this.secondaryContentTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.886398F));
            this.secondaryContentTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.66368F));
            this.secondaryContentTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.702315F));
            this.secondaryContentTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.80485F));
            this.secondaryContentTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.261301F));
            this.secondaryContentTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.9151F));
            this.secondaryContentTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.945976F));
            this.secondaryContentTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.276736F));
            this.secondaryContentTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.371554F));
            this.secondaryContentTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.835722F));
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.radioButton21, 0, 5);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.radioButton22, 0, 4);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.dt_CarbonMonoxide, 9, 0);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.dt_NitrogenOxide, 9, 1);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.dt_NitrogenDioxide, 9, 2);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.dt_SulfurDioxide, 9, 3);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.dt_CarbonDioxide, 9, 4);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.dt_VolatileOrganicCompounds, 9, 5);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.dx_VolatileOrganicCompounds, 8, 5);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.dx_CarbonDioxide, 8, 4);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.dx_SulfurDioxide, 8, 3);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.dx_NitrogenDioxide, 8, 2);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.dx_NitrogenOxide, 8, 1);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.dx_CarbonMonoxide, 8, 0);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.porog_2_CarbonMonoxide, 7, 0);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.radioButton9, 0, 3);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.porog_2_NitrogenOxide, 7, 1);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.radioButton8, 0, 2);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.porog_2_NitrogenDioxide, 7, 2);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.radioButton7, 0, 1);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.porog_2_SulfurDioxide, 7, 3);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.radioButton6, 0, 0);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.porog_2_CarbonDioxide, 7, 4);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.porog_2_VolatileOrganicCompounds, 7, 5);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.porog_1_VolatileOrganicCompounds, 6, 5);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.porog_1_CarbonDioxide, 6, 4);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.porog_1_SulfurDioxide, 6, 3);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.porog_1_NitrogenDioxide, 6, 2);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.porog_1_NitrogenOxide, 6, 1);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.porog_1_CarbonMonoxide, 6, 0);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.currentCarbonMonoxide, 5, 0);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.currentNitrogenOxide, 5, 1);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.currentNitrogenDioxide, 5, 2);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.currentSulfurDioxide, 5, 3);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.currentCarbonDioxide, 5, 4);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.currentVolatileOrganicCompounds, 5, 5);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.volatileOrganicCompounds, 1, 5);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.carbonDioxide, 1, 4);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.sulfurDioxide, 1, 3);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.nitrogenDioxide, 1, 2);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.nitrogenOxide, 1, 1);
            this.secondaryContentTableLayoutPanel2.Controls.Add(this.carbonMonoxide, 1, 0);
            this.secondaryContentTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondaryContentTableLayoutPanel2.Location = new System.Drawing.Point(3, 160);
            this.secondaryContentTableLayoutPanel2.Name = "secondaryContentTableLayoutPanel2";
            this.secondaryContentTableLayoutPanel2.RowCount = 6;
            this.secondaryContentTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.secondaryContentTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.secondaryContentTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.secondaryContentTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.secondaryContentTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.secondaryContentTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.secondaryContentTableLayoutPanel2.Size = new System.Drawing.Size(701, 142);
            this.secondaryContentTableLayoutPanel2.TabIndex = 1;
            // 
            // radioButton21
            // 
            this.radioButton21.AutoSize = true;
            this.radioButton21.BackColor = System.Drawing.Color.Brown;
            this.radioButton21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton21.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton21.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton21.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton21.Location = new System.Drawing.Point(3, 118);
            this.radioButton21.Name = "radioButton21";
            this.radioButton21.Size = new System.Drawing.Size(21, 21);
            this.radioButton21.TabIndex = 59;
            this.radioButton21.TabStop = true;
            this.radioButton21.UseVisualStyleBackColor = false;
            // 
            // radioButton22
            // 
            this.radioButton22.AutoSize = true;
            this.radioButton22.BackColor = System.Drawing.Color.Peru;
            this.radioButton22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton22.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton22.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton22.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton22.Location = new System.Drawing.Point(3, 95);
            this.radioButton22.Name = "radioButton22";
            this.radioButton22.Size = new System.Drawing.Size(21, 17);
            this.radioButton22.TabIndex = 60;
            this.radioButton22.TabStop = true;
            this.radioButton22.UseVisualStyleBackColor = false;
            // 
            // dt_CarbonMonoxide
            // 
            this.dt_CarbonMonoxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_CarbonMonoxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_CarbonMonoxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_CarbonMonoxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_CarbonMonoxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_CarbonMonoxide.Location = new System.Drawing.Point(651, 3);
            this.dt_CarbonMonoxide.Name = "dt_CarbonMonoxide";
            this.dt_CarbonMonoxide.Size = new System.Drawing.Size(47, 23);
            this.dt_CarbonMonoxide.TabIndex = 29;
            this.dt_CarbonMonoxide.Text = "20";
            this.dt_CarbonMonoxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dt_NitrogenOxide
            // 
            this.dt_NitrogenOxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_NitrogenOxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_NitrogenOxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_NitrogenOxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_NitrogenOxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_NitrogenOxide.Location = new System.Drawing.Point(651, 26);
            this.dt_NitrogenOxide.Name = "dt_NitrogenOxide";
            this.dt_NitrogenOxide.Size = new System.Drawing.Size(47, 23);
            this.dt_NitrogenOxide.TabIndex = 28;
            this.dt_NitrogenOxide.Text = "20";
            this.dt_NitrogenOxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dt_NitrogenDioxide
            // 
            this.dt_NitrogenDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_NitrogenDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_NitrogenDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_NitrogenDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_NitrogenDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_NitrogenDioxide.Location = new System.Drawing.Point(651, 49);
            this.dt_NitrogenDioxide.Name = "dt_NitrogenDioxide";
            this.dt_NitrogenDioxide.Size = new System.Drawing.Size(47, 23);
            this.dt_NitrogenDioxide.TabIndex = 36;
            this.dt_NitrogenDioxide.Text = "20";
            this.dt_NitrogenDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dt_SulfurDioxide
            // 
            this.dt_SulfurDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_SulfurDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_SulfurDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_SulfurDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_SulfurDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_SulfurDioxide.Location = new System.Drawing.Point(651, 72);
            this.dt_SulfurDioxide.Name = "dt_SulfurDioxide";
            this.dt_SulfurDioxide.Size = new System.Drawing.Size(47, 23);
            this.dt_SulfurDioxide.TabIndex = 40;
            this.dt_SulfurDioxide.Text = "20";
            this.dt_SulfurDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dt_CarbonDioxide
            // 
            this.dt_CarbonDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_CarbonDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_CarbonDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_CarbonDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_CarbonDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_CarbonDioxide.Location = new System.Drawing.Point(651, 95);
            this.dt_CarbonDioxide.Name = "dt_CarbonDioxide";
            this.dt_CarbonDioxide.Size = new System.Drawing.Size(47, 23);
            this.dt_CarbonDioxide.TabIndex = 44;
            this.dt_CarbonDioxide.Text = "20";
            this.dt_CarbonDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dt_VolatileOrganicCompounds
            // 
            this.dt_VolatileOrganicCompounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_VolatileOrganicCompounds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_VolatileOrganicCompounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_VolatileOrganicCompounds.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_VolatileOrganicCompounds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_VolatileOrganicCompounds.Location = new System.Drawing.Point(651, 118);
            this.dt_VolatileOrganicCompounds.Name = "dt_VolatileOrganicCompounds";
            this.dt_VolatileOrganicCompounds.Size = new System.Drawing.Size(47, 23);
            this.dt_VolatileOrganicCompounds.TabIndex = 48;
            this.dt_VolatileOrganicCompounds.Text = "20";
            this.dt_VolatileOrganicCompounds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_VolatileOrganicCompounds
            // 
            this.dx_VolatileOrganicCompounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_VolatileOrganicCompounds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_VolatileOrganicCompounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_VolatileOrganicCompounds.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_VolatileOrganicCompounds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_VolatileOrganicCompounds.Location = new System.Drawing.Point(586, 118);
            this.dx_VolatileOrganicCompounds.Name = "dx_VolatileOrganicCompounds";
            this.dx_VolatileOrganicCompounds.Size = new System.Drawing.Size(59, 23);
            this.dx_VolatileOrganicCompounds.TabIndex = 47;
            this.dx_VolatileOrganicCompounds.Text = "20";
            this.dx_VolatileOrganicCompounds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_CarbonDioxide
            // 
            this.dx_CarbonDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_CarbonDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_CarbonDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_CarbonDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_CarbonDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_CarbonDioxide.Location = new System.Drawing.Point(586, 95);
            this.dx_CarbonDioxide.Name = "dx_CarbonDioxide";
            this.dx_CarbonDioxide.Size = new System.Drawing.Size(59, 23);
            this.dx_CarbonDioxide.TabIndex = 43;
            this.dx_CarbonDioxide.Text = "20";
            this.dx_CarbonDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_SulfurDioxide
            // 
            this.dx_SulfurDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_SulfurDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_SulfurDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_SulfurDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_SulfurDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_SulfurDioxide.Location = new System.Drawing.Point(586, 72);
            this.dx_SulfurDioxide.Name = "dx_SulfurDioxide";
            this.dx_SulfurDioxide.Size = new System.Drawing.Size(59, 23);
            this.dx_SulfurDioxide.TabIndex = 39;
            this.dx_SulfurDioxide.Text = "20";
            this.dx_SulfurDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_NitrogenDioxide
            // 
            this.dx_NitrogenDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_NitrogenDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_NitrogenDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_NitrogenDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_NitrogenDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_NitrogenDioxide.Location = new System.Drawing.Point(586, 49);
            this.dx_NitrogenDioxide.Name = "dx_NitrogenDioxide";
            this.dx_NitrogenDioxide.Size = new System.Drawing.Size(59, 23);
            this.dx_NitrogenDioxide.TabIndex = 35;
            this.dx_NitrogenDioxide.Text = "20";
            this.dx_NitrogenDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_NitrogenOxide
            // 
            this.dx_NitrogenOxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_NitrogenOxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_NitrogenOxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_NitrogenOxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_NitrogenOxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_NitrogenOxide.Location = new System.Drawing.Point(586, 26);
            this.dx_NitrogenOxide.Name = "dx_NitrogenOxide";
            this.dx_NitrogenOxide.Size = new System.Drawing.Size(59, 23);
            this.dx_NitrogenOxide.TabIndex = 32;
            this.dx_NitrogenOxide.Text = "20";
            this.dx_NitrogenOxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_CarbonMonoxide
            // 
            this.dx_CarbonMonoxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_CarbonMonoxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_CarbonMonoxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_CarbonMonoxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_CarbonMonoxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_CarbonMonoxide.Location = new System.Drawing.Point(586, 3);
            this.dx_CarbonMonoxide.Name = "dx_CarbonMonoxide";
            this.dx_CarbonMonoxide.Size = new System.Drawing.Size(59, 23);
            this.dx_CarbonMonoxide.TabIndex = 27;
            this.dx_CarbonMonoxide.Text = "20";
            this.dx_CarbonMonoxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_2_CarbonMonoxide
            // 
            this.porog_2_CarbonMonoxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_CarbonMonoxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_CarbonMonoxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_CarbonMonoxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_CarbonMonoxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_CarbonMonoxide.Location = new System.Drawing.Point(535, 3);
            this.porog_2_CarbonMonoxide.Name = "porog_2_CarbonMonoxide";
            this.porog_2_CarbonMonoxide.Size = new System.Drawing.Size(45, 23);
            this.porog_2_CarbonMonoxide.TabIndex = 26;
            this.porog_2_CarbonMonoxide.Text = "20";
            this.porog_2_CarbonMonoxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.BackColor = System.Drawing.Color.Orange;
            this.radioButton9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton9.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton9.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton9.Location = new System.Drawing.Point(3, 72);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(21, 17);
            this.radioButton9.TabIndex = 47;
            this.radioButton9.TabStop = true;
            this.radioButton9.UseVisualStyleBackColor = false;
            // 
            // porog_2_NitrogenOxide
            // 
            this.porog_2_NitrogenOxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_NitrogenOxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_NitrogenOxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_NitrogenOxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_NitrogenOxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_NitrogenOxide.Location = new System.Drawing.Point(535, 26);
            this.porog_2_NitrogenOxide.Name = "porog_2_NitrogenOxide";
            this.porog_2_NitrogenOxide.Size = new System.Drawing.Size(45, 23);
            this.porog_2_NitrogenOxide.TabIndex = 31;
            this.porog_2_NitrogenOxide.Text = "20";
            this.porog_2_NitrogenOxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.BackColor = System.Drawing.Color.Lavender;
            this.radioButton8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton8.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton8.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton8.Location = new System.Drawing.Point(3, 49);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(21, 17);
            this.radioButton8.TabIndex = 46;
            this.radioButton8.TabStop = true;
            this.radioButton8.UseVisualStyleBackColor = false;
            // 
            // porog_2_NitrogenDioxide
            // 
            this.porog_2_NitrogenDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_NitrogenDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_NitrogenDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_NitrogenDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_NitrogenDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_NitrogenDioxide.Location = new System.Drawing.Point(535, 49);
            this.porog_2_NitrogenDioxide.Name = "porog_2_NitrogenDioxide";
            this.porog_2_NitrogenDioxide.Size = new System.Drawing.Size(45, 23);
            this.porog_2_NitrogenDioxide.TabIndex = 34;
            this.porog_2_NitrogenDioxide.Text = "20";
            this.porog_2_NitrogenDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.BackColor = System.Drawing.Color.Turquoise;
            this.radioButton7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton7.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton7.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton7.Location = new System.Drawing.Point(3, 26);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(21, 17);
            this.radioButton7.TabIndex = 45;
            this.radioButton7.TabStop = true;
            this.radioButton7.UseVisualStyleBackColor = false;
            // 
            // porog_2_SulfurDioxide
            // 
            this.porog_2_SulfurDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_SulfurDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_SulfurDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_SulfurDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_SulfurDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_SulfurDioxide.Location = new System.Drawing.Point(535, 72);
            this.porog_2_SulfurDioxide.Name = "porog_2_SulfurDioxide";
            this.porog_2_SulfurDioxide.Size = new System.Drawing.Size(45, 23);
            this.porog_2_SulfurDioxide.TabIndex = 38;
            this.porog_2_SulfurDioxide.Text = "20";
            this.porog_2_SulfurDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.BackColor = System.Drawing.Color.Yellow;
            this.radioButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton6.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton6.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton6.Location = new System.Drawing.Point(3, 3);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(21, 17);
            this.radioButton6.TabIndex = 44;
            this.radioButton6.TabStop = true;
            this.radioButton6.UseVisualStyleBackColor = false;
            // 
            // porog_2_CarbonDioxide
            // 
            this.porog_2_CarbonDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_CarbonDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_CarbonDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_CarbonDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_CarbonDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_CarbonDioxide.Location = new System.Drawing.Point(535, 95);
            this.porog_2_CarbonDioxide.Name = "porog_2_CarbonDioxide";
            this.porog_2_CarbonDioxide.Size = new System.Drawing.Size(45, 23);
            this.porog_2_CarbonDioxide.TabIndex = 42;
            this.porog_2_CarbonDioxide.Text = "20";
            this.porog_2_CarbonDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_2_VolatileOrganicCompounds
            // 
            this.porog_2_VolatileOrganicCompounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_VolatileOrganicCompounds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_VolatileOrganicCompounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_VolatileOrganicCompounds.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_VolatileOrganicCompounds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_VolatileOrganicCompounds.Location = new System.Drawing.Point(535, 118);
            this.porog_2_VolatileOrganicCompounds.Name = "porog_2_VolatileOrganicCompounds";
            this.porog_2_VolatileOrganicCompounds.Size = new System.Drawing.Size(45, 23);
            this.porog_2_VolatileOrganicCompounds.TabIndex = 46;
            this.porog_2_VolatileOrganicCompounds.Text = "20";
            this.porog_2_VolatileOrganicCompounds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_VolatileOrganicCompounds
            // 
            this.porog_1_VolatileOrganicCompounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_VolatileOrganicCompounds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_VolatileOrganicCompounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_VolatileOrganicCompounds.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_VolatileOrganicCompounds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_VolatileOrganicCompounds.Location = new System.Drawing.Point(487, 118);
            this.porog_1_VolatileOrganicCompounds.Name = "porog_1_VolatileOrganicCompounds";
            this.porog_1_VolatileOrganicCompounds.Size = new System.Drawing.Size(42, 23);
            this.porog_1_VolatileOrganicCompounds.TabIndex = 45;
            this.porog_1_VolatileOrganicCompounds.Text = "20";
            this.porog_1_VolatileOrganicCompounds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_CarbonDioxide
            // 
            this.porog_1_CarbonDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_CarbonDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_CarbonDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_CarbonDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_CarbonDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_CarbonDioxide.Location = new System.Drawing.Point(487, 95);
            this.porog_1_CarbonDioxide.Name = "porog_1_CarbonDioxide";
            this.porog_1_CarbonDioxide.Size = new System.Drawing.Size(42, 23);
            this.porog_1_CarbonDioxide.TabIndex = 41;
            this.porog_1_CarbonDioxide.Text = "20";
            this.porog_1_CarbonDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_SulfurDioxide
            // 
            this.porog_1_SulfurDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_SulfurDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_SulfurDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_SulfurDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_SulfurDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_SulfurDioxide.Location = new System.Drawing.Point(487, 72);
            this.porog_1_SulfurDioxide.Name = "porog_1_SulfurDioxide";
            this.porog_1_SulfurDioxide.Size = new System.Drawing.Size(42, 23);
            this.porog_1_SulfurDioxide.TabIndex = 37;
            this.porog_1_SulfurDioxide.Text = "20";
            this.porog_1_SulfurDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_NitrogenDioxide
            // 
            this.porog_1_NitrogenDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_NitrogenDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_NitrogenDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_NitrogenDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_NitrogenDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_NitrogenDioxide.Location = new System.Drawing.Point(487, 49);
            this.porog_1_NitrogenDioxide.Name = "porog_1_NitrogenDioxide";
            this.porog_1_NitrogenDioxide.Size = new System.Drawing.Size(42, 23);
            this.porog_1_NitrogenDioxide.TabIndex = 33;
            this.porog_1_NitrogenDioxide.Text = "20";
            this.porog_1_NitrogenDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_NitrogenOxide
            // 
            this.porog_1_NitrogenOxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_NitrogenOxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_NitrogenOxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_NitrogenOxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_NitrogenOxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_NitrogenOxide.Location = new System.Drawing.Point(487, 26);
            this.porog_1_NitrogenOxide.Name = "porog_1_NitrogenOxide";
            this.porog_1_NitrogenOxide.Size = new System.Drawing.Size(42, 23);
            this.porog_1_NitrogenOxide.TabIndex = 30;
            this.porog_1_NitrogenOxide.Text = "20";
            this.porog_1_NitrogenOxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_CarbonMonoxide
            // 
            this.porog_1_CarbonMonoxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_CarbonMonoxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_CarbonMonoxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_CarbonMonoxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_CarbonMonoxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_CarbonMonoxide.Location = new System.Drawing.Point(487, 3);
            this.porog_1_CarbonMonoxide.Name = "porog_1_CarbonMonoxide";
            this.porog_1_CarbonMonoxide.Size = new System.Drawing.Size(42, 23);
            this.porog_1_CarbonMonoxide.TabIndex = 25;
            this.porog_1_CarbonMonoxide.Text = "20";
            this.porog_1_CarbonMonoxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // currentCarbonMonoxide
            // 
            this.currentCarbonMonoxide.AutoSize = true;
            this.currentCarbonMonoxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.currentCarbonMonoxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentCarbonMonoxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentCarbonMonoxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentCarbonMonoxide.Location = new System.Drawing.Point(411, 0);
            this.currentCarbonMonoxide.Name = "currentCarbonMonoxide";
            this.currentCarbonMonoxide.Size = new System.Drawing.Size(70, 23);
            this.currentCarbonMonoxide.TabIndex = 19;
            this.currentCarbonMonoxide.Text = "23.9";
            this.currentCarbonMonoxide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentNitrogenOxide
            // 
            this.currentNitrogenOxide.AutoSize = true;
            this.currentNitrogenOxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.currentNitrogenOxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentNitrogenOxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentNitrogenOxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentNitrogenOxide.Location = new System.Drawing.Point(411, 23);
            this.currentNitrogenOxide.Name = "currentNitrogenOxide";
            this.currentNitrogenOxide.Size = new System.Drawing.Size(70, 23);
            this.currentNitrogenOxide.TabIndex = 20;
            this.currentNitrogenOxide.Text = "23.9";
            this.currentNitrogenOxide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentNitrogenDioxide
            // 
            this.currentNitrogenDioxide.AutoSize = true;
            this.currentNitrogenDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.currentNitrogenDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentNitrogenDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentNitrogenDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentNitrogenDioxide.Location = new System.Drawing.Point(411, 46);
            this.currentNitrogenDioxide.Name = "currentNitrogenDioxide";
            this.currentNitrogenDioxide.Size = new System.Drawing.Size(70, 23);
            this.currentNitrogenDioxide.TabIndex = 21;
            this.currentNitrogenDioxide.Text = "23.9";
            this.currentNitrogenDioxide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentSulfurDioxide
            // 
            this.currentSulfurDioxide.AutoSize = true;
            this.currentSulfurDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.currentSulfurDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentSulfurDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentSulfurDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentSulfurDioxide.Location = new System.Drawing.Point(411, 69);
            this.currentSulfurDioxide.Name = "currentSulfurDioxide";
            this.currentSulfurDioxide.Size = new System.Drawing.Size(70, 23);
            this.currentSulfurDioxide.TabIndex = 22;
            this.currentSulfurDioxide.Text = "23.9";
            this.currentSulfurDioxide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentCarbonDioxide
            // 
            this.currentCarbonDioxide.AutoSize = true;
            this.currentCarbonDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.currentCarbonDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentCarbonDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentCarbonDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentCarbonDioxide.Location = new System.Drawing.Point(411, 92);
            this.currentCarbonDioxide.Name = "currentCarbonDioxide";
            this.currentCarbonDioxide.Size = new System.Drawing.Size(70, 23);
            this.currentCarbonDioxide.TabIndex = 23;
            this.currentCarbonDioxide.Text = "23.9";
            this.currentCarbonDioxide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentVolatileOrganicCompounds
            // 
            this.currentVolatileOrganicCompounds.AutoSize = true;
            this.currentVolatileOrganicCompounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.currentVolatileOrganicCompounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentVolatileOrganicCompounds.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentVolatileOrganicCompounds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentVolatileOrganicCompounds.Location = new System.Drawing.Point(411, 115);
            this.currentVolatileOrganicCompounds.Name = "currentVolatileOrganicCompounds";
            this.currentVolatileOrganicCompounds.Size = new System.Drawing.Size(70, 27);
            this.currentVolatileOrganicCompounds.TabIndex = 24;
            this.currentVolatileOrganicCompounds.Text = "23.9";
            this.currentVolatileOrganicCompounds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // volatileOrganicCompounds
            // 
            this.volatileOrganicCompounds.AutoSize = true;
            this.volatileOrganicCompounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.volatileOrganicCompounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volatileOrganicCompounds.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.volatileOrganicCompounds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.volatileOrganicCompounds.Location = new System.Drawing.Point(30, 115);
            this.volatileOrganicCompounds.Name = "volatileOrganicCompounds";
            this.volatileOrganicCompounds.Size = new System.Drawing.Size(167, 27);
            this.volatileOrganicCompounds.TabIndex = 13;
            this.volatileOrganicCompounds.Text = "ЛОС (0 - 10 000 ppb)";
            this.volatileOrganicCompounds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // carbonDioxide
            // 
            this.carbonDioxide.AutoSize = true;
            this.carbonDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.carbonDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.carbonDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.carbonDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.carbonDioxide.Location = new System.Drawing.Point(30, 92);
            this.carbonDioxide.Name = "carbonDioxide";
            this.carbonDioxide.Size = new System.Drawing.Size(167, 23);
            this.carbonDioxide.TabIndex = 16;
            this.carbonDioxide.Text = "CO2 (0 - 5 000 ppm)";
            this.carbonDioxide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sulfurDioxide
            // 
            this.sulfurDioxide.AutoSize = true;
            this.sulfurDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.sulfurDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sulfurDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sulfurDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.sulfurDioxide.Location = new System.Drawing.Point(30, 69);
            this.sulfurDioxide.Name = "sulfurDioxide";
            this.sulfurDioxide.Size = new System.Drawing.Size(167, 23);
            this.sulfurDioxide.TabIndex = 13;
            this.sulfurDioxide.Text = "SO2 (0 - 1 000 ppb)";
            this.sulfurDioxide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nitrogenDioxide
            // 
            this.nitrogenDioxide.AutoSize = true;
            this.nitrogenDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.nitrogenDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nitrogenDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nitrogenDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.nitrogenDioxide.Location = new System.Drawing.Point(30, 46);
            this.nitrogenDioxide.Name = "nitrogenDioxide";
            this.nitrogenDioxide.Size = new System.Drawing.Size(167, 23);
            this.nitrogenDioxide.TabIndex = 15;
            this.nitrogenDioxide.Text = "NO2 (0 - 1 000 ppb)";
            this.nitrogenDioxide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nitrogenOxide
            // 
            this.nitrogenOxide.AutoSize = true;
            this.nitrogenOxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nitrogenOxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nitrogenOxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nitrogenOxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.nitrogenOxide.Location = new System.Drawing.Point(30, 23);
            this.nitrogenOxide.Name = "nitrogenOxide";
            this.nitrogenOxide.Size = new System.Drawing.Size(167, 23);
            this.nitrogenOxide.TabIndex = 13;
            this.nitrogenOxide.Text = "NO (0 - 1 000 ppb)";
            this.nitrogenOxide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // carbonMonoxide
            // 
            this.carbonMonoxide.AutoSize = true;
            this.carbonMonoxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.carbonMonoxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.carbonMonoxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.carbonMonoxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.carbonMonoxide.Location = new System.Drawing.Point(30, 0);
            this.carbonMonoxide.Name = "carbonMonoxide";
            this.carbonMonoxide.Size = new System.Drawing.Size(167, 23);
            this.carbonMonoxide.TabIndex = 14;
            this.carbonMonoxide.Text = "CO (0 - 40 000 ppb)";
            this.carbonMonoxide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // secondaryContentTableLayoutPanel1
            // 
            this.secondaryContentTableLayoutPanel1.ColumnCount = 10;
            this.secondaryContentTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.736921F));
            this.secondaryContentTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.90612F));
            this.secondaryContentTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.392603F));
            this.secondaryContentTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.112376F));
            this.secondaryContentTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.108109F));
            this.secondaryContentTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.815078F));
            this.secondaryContentTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.819345F));
            this.secondaryContentTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.672831F));
            this.secondaryContentTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.80654F));
            this.secondaryContentTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.periodLabel, 9, 0);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.increaseLabel, 8, 0);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.porog2Label, 7, 0);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.porog1Label, 6, 0);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.currentParametrLabel, 5, 0);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.avgParametrLabel, 4, 0);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.maxParametrLabel, 3, 0);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.minParametrLabel, 2, 0);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.ParametrLabel, 1, 0);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.airTemperature, 1, 1);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.relativeHumidity, 1, 2);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.atmosphericPressure, 1, 3);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.windSpeed, 1, 4);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.windDirection, 1, 5);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.dt_AirTemperature, 9, 1);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.dt_RelativeHumidity, 9, 2);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.dt_AtmosphericPressure, 9, 3);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.dt_WindSpeed, 9, 4);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.dt_WindDirection, 9, 5);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.dx_WindDirection, 8, 5);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.dx_WindSpeed, 8, 4);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.dx_AtmosphericPressure, 8, 3);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.dx_RelativeHumidity, 8, 2);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.dx_AirTemperature, 8, 1);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.porog_2_AirTemperature, 7, 1);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.porog_2_RelativeHumidity, 7, 2);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.porog_2_AtmosphericPressure, 7, 3);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.porog_2_WindSpeed, 7, 4);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.porog_2_WindDirection, 7, 5);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.porog_1_WindDirection, 6, 5);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.porog_1_WindSpeed, 6, 4);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.porog_1_AtmosphericPressure, 6, 3);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.porog_1_RelativeHumidity, 6, 2);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.porog_1_AirTemperature, 6, 1);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.currentAirTemperature, 5, 1);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.currentRelativeHumidity, 5, 2);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.currentAtmosphericPressure, 5, 3);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.currentWindSpeed, 5, 4);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.currentWindDirection, 5, 5);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.radioButton1, 0, 1);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.radioButton2, 0, 2);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.radioButton3, 0, 3);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.radioButton4, 0, 4);
            this.secondaryContentTableLayoutPanel1.Controls.Add(this.radioButton5, 0, 5);
            this.secondaryContentTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondaryContentTableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.secondaryContentTableLayoutPanel1.Name = "secondaryContentTableLayoutPanel1";
            this.secondaryContentTableLayoutPanel1.RowCount = 6;
            this.secondaryContentTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.secondaryContentTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.secondaryContentTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.secondaryContentTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.secondaryContentTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.secondaryContentTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.secondaryContentTableLayoutPanel1.Size = new System.Drawing.Size(701, 151);
            this.secondaryContentTableLayoutPanel1.TabIndex = 0;
            // 
            // periodLabel
            // 
            this.periodLabel.AutoSize = true;
            this.periodLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.periodLabel.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.periodLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.periodLabel.Location = new System.Drawing.Point(623, 0);
            this.periodLabel.Name = "periodLabel";
            this.periodLabel.Size = new System.Drawing.Size(75, 25);
            this.periodLabel.TabIndex = 8;
            this.periodLabel.Text = "Период";
            this.periodLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // increaseLabel
            // 
            this.increaseLabel.AutoSize = true;
            this.increaseLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.increaseLabel.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.increaseLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.increaseLabel.Location = new System.Drawing.Point(541, 0);
            this.increaseLabel.Name = "increaseLabel";
            this.increaseLabel.Size = new System.Drawing.Size(76, 25);
            this.increaseLabel.TabIndex = 7;
            this.increaseLabel.Text = "Нарастание";
            this.increaseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // porog2Label
            // 
            this.porog2Label.AutoSize = true;
            this.porog2Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog2Label.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.porog2Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.porog2Label.Location = new System.Drawing.Point(474, 0);
            this.porog2Label.Name = "porog2Label";
            this.porog2Label.Size = new System.Drawing.Size(61, 25);
            this.porog2Label.TabIndex = 6;
            this.porog2Label.Text = "Порог 2";
            this.porog2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // porog1Label
            // 
            this.porog1Label.AutoSize = true;
            this.porog1Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog1Label.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.porog1Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.porog1Label.Location = new System.Drawing.Point(413, 0);
            this.porog1Label.Name = "porog1Label";
            this.porog1Label.Size = new System.Drawing.Size(55, 25);
            this.porog1Label.TabIndex = 5;
            this.porog1Label.Text = "Порог 1";
            this.porog1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentParametrLabel
            // 
            this.currentParametrLabel.AutoSize = true;
            this.currentParametrLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentParametrLabel.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.currentParametrLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.currentParametrLabel.Location = new System.Drawing.Point(345, 0);
            this.currentParametrLabel.Name = "currentParametrLabel";
            this.currentParametrLabel.Size = new System.Drawing.Size(62, 25);
            this.currentParametrLabel.TabIndex = 4;
            this.currentParametrLabel.Text = "Текущее";
            this.currentParametrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // avgParametrLabel
            // 
            this.avgParametrLabel.AutoSize = true;
            this.avgParametrLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.avgParametrLabel.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.avgParametrLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.avgParametrLabel.Location = new System.Drawing.Point(289, 0);
            this.avgParametrLabel.Name = "avgParametrLabel";
            this.avgParametrLabel.Size = new System.Drawing.Size(50, 25);
            this.avgParametrLabel.TabIndex = 3;
            this.avgParametrLabel.Text = "Сред.";
            this.avgParametrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // maxParametrLabel
            // 
            this.maxParametrLabel.AutoSize = true;
            this.maxParametrLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maxParametrLabel.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.maxParametrLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.maxParametrLabel.Location = new System.Drawing.Point(240, 0);
            this.maxParametrLabel.Name = "maxParametrLabel";
            this.maxParametrLabel.Size = new System.Drawing.Size(43, 25);
            this.maxParametrLabel.TabIndex = 2;
            this.maxParametrLabel.Text = "Макс.";
            this.maxParametrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // minParametrLabel
            // 
            this.minParametrLabel.AutoSize = true;
            this.minParametrLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minParametrLabel.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.minParametrLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.minParametrLabel.Location = new System.Drawing.Point(182, 0);
            this.minParametrLabel.Name = "minParametrLabel";
            this.minParametrLabel.Size = new System.Drawing.Size(52, 25);
            this.minParametrLabel.TabIndex = 1;
            this.minParametrLabel.Text = "Мин.";
            this.minParametrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ParametrLabel
            // 
            this.ParametrLabel.AutoSize = true;
            this.ParametrLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ParametrLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParametrLabel.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.ParametrLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.ParametrLabel.Location = new System.Drawing.Point(29, 0);
            this.ParametrLabel.Name = "ParametrLabel";
            this.ParametrLabel.Size = new System.Drawing.Size(147, 25);
            this.ParametrLabel.TabIndex = 0;
            this.ParametrLabel.Text = "Параметр";
            this.ParametrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // airTemperature
            // 
            this.airTemperature.AutoSize = true;
            this.airTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.airTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.airTemperature.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.airTemperature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.airTemperature.Location = new System.Drawing.Point(29, 25);
            this.airTemperature.Name = "airTemperature";
            this.airTemperature.Size = new System.Drawing.Size(147, 25);
            this.airTemperature.TabIndex = 9;
            this.airTemperature.Text = "Температура (- 45 до +45°С)";
            this.airTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // relativeHumidity
            // 
            this.relativeHumidity.AutoSize = true;
            this.relativeHumidity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.relativeHumidity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.relativeHumidity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.relativeHumidity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.relativeHumidity.Location = new System.Drawing.Point(29, 50);
            this.relativeHumidity.Name = "relativeHumidity";
            this.relativeHumidity.Size = new System.Drawing.Size(147, 25);
            this.relativeHumidity.TabIndex = 10;
            this.relativeHumidity.Text = "Отн. влажность (0 - 98 %)";
            this.relativeHumidity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // atmosphericPressure
            // 
            this.atmosphericPressure.AutoSize = true;
            this.atmosphericPressure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.atmosphericPressure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.atmosphericPressure.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.atmosphericPressure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.atmosphericPressure.Location = new System.Drawing.Point(29, 75);
            this.atmosphericPressure.Name = "atmosphericPressure";
            this.atmosphericPressure.Size = new System.Drawing.Size(147, 25);
            this.atmosphericPressure.TabIndex = 11;
            this.atmosphericPressure.Text = "Атм. дав-ние (650 - 1200 hPa)";
            this.atmosphericPressure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // windSpeed
            // 
            this.windSpeed.AutoSize = true;
            this.windSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.windSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.windSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.windSpeed.Location = new System.Drawing.Point(29, 100);
            this.windSpeed.Name = "windSpeed";
            this.windSpeed.Size = new System.Drawing.Size(147, 25);
            this.windSpeed.TabIndex = 13;
            this.windSpeed.Text = "Напряжение 1";
            this.windSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // windDirection
            // 
            this.windDirection.AutoSize = true;
            this.windDirection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.windDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windDirection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.windDirection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.windDirection.Location = new System.Drawing.Point(29, 125);
            this.windDirection.Name = "windDirection";
            this.windDirection.Size = new System.Drawing.Size(147, 26);
            this.windDirection.TabIndex = 12;
            this.windDirection.Text = "Напряжение 2";
            this.windDirection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dt_AirTemperature
            // 
            this.dt_AirTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_AirTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_AirTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_AirTemperature.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_AirTemperature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_AirTemperature.Location = new System.Drawing.Point(623, 28);
            this.dt_AirTemperature.Name = "dt_AirTemperature";
            this.dt_AirTemperature.Size = new System.Drawing.Size(75, 23);
            this.dt_AirTemperature.TabIndex = 34;
            this.dt_AirTemperature.Text = "20";
            this.dt_AirTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dt_RelativeHumidity
            // 
            this.dt_RelativeHumidity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_RelativeHumidity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_RelativeHumidity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_RelativeHumidity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_RelativeHumidity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_RelativeHumidity.Location = new System.Drawing.Point(623, 53);
            this.dt_RelativeHumidity.Name = "dt_RelativeHumidity";
            this.dt_RelativeHumidity.Size = new System.Drawing.Size(75, 23);
            this.dt_RelativeHumidity.TabIndex = 35;
            this.dt_RelativeHumidity.Text = "20";
            this.dt_RelativeHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dt_AtmosphericPressure
            // 
            this.dt_AtmosphericPressure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_AtmosphericPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_AtmosphericPressure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_AtmosphericPressure.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_AtmosphericPressure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_AtmosphericPressure.Location = new System.Drawing.Point(623, 78);
            this.dt_AtmosphericPressure.Name = "dt_AtmosphericPressure";
            this.dt_AtmosphericPressure.Size = new System.Drawing.Size(75, 23);
            this.dt_AtmosphericPressure.TabIndex = 36;
            this.dt_AtmosphericPressure.Text = "20";
            this.dt_AtmosphericPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dt_WindSpeed
            // 
            this.dt_WindSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_WindSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_WindSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_WindSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_WindSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_WindSpeed.Location = new System.Drawing.Point(623, 103);
            this.dt_WindSpeed.Name = "dt_WindSpeed";
            this.dt_WindSpeed.Size = new System.Drawing.Size(75, 23);
            this.dt_WindSpeed.TabIndex = 37;
            this.dt_WindSpeed.Text = "20";
            this.dt_WindSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dt_WindDirection
            // 
            this.dt_WindDirection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dt_WindDirection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_WindDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_WindDirection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_WindDirection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dt_WindDirection.Location = new System.Drawing.Point(623, 128);
            this.dt_WindDirection.Name = "dt_WindDirection";
            this.dt_WindDirection.Size = new System.Drawing.Size(75, 23);
            this.dt_WindDirection.TabIndex = 38;
            this.dt_WindDirection.Text = "20";
            this.dt_WindDirection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_WindDirection
            // 
            this.dx_WindDirection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_WindDirection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_WindDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_WindDirection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_WindDirection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_WindDirection.Location = new System.Drawing.Point(541, 128);
            this.dx_WindDirection.Name = "dx_WindDirection";
            this.dx_WindDirection.Size = new System.Drawing.Size(76, 23);
            this.dx_WindDirection.TabIndex = 33;
            this.dx_WindDirection.Text = "20";
            this.dx_WindDirection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_WindSpeed
            // 
            this.dx_WindSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_WindSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_WindSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_WindSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_WindSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_WindSpeed.Location = new System.Drawing.Point(541, 103);
            this.dx_WindSpeed.Name = "dx_WindSpeed";
            this.dx_WindSpeed.Size = new System.Drawing.Size(76, 23);
            this.dx_WindSpeed.TabIndex = 32;
            this.dx_WindSpeed.Text = "20";
            this.dx_WindSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_AtmosphericPressure
            // 
            this.dx_AtmosphericPressure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_AtmosphericPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_AtmosphericPressure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_AtmosphericPressure.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_AtmosphericPressure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_AtmosphericPressure.Location = new System.Drawing.Point(541, 78);
            this.dx_AtmosphericPressure.Name = "dx_AtmosphericPressure";
            this.dx_AtmosphericPressure.Size = new System.Drawing.Size(76, 23);
            this.dx_AtmosphericPressure.TabIndex = 31;
            this.dx_AtmosphericPressure.Text = "20";
            this.dx_AtmosphericPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_RelativeHumidity
            // 
            this.dx_RelativeHumidity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_RelativeHumidity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_RelativeHumidity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_RelativeHumidity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_RelativeHumidity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_RelativeHumidity.Location = new System.Drawing.Point(541, 53);
            this.dx_RelativeHumidity.Name = "dx_RelativeHumidity";
            this.dx_RelativeHumidity.Size = new System.Drawing.Size(76, 23);
            this.dx_RelativeHumidity.TabIndex = 30;
            this.dx_RelativeHumidity.Text = "20";
            this.dx_RelativeHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dx_AirTemperature
            // 
            this.dx_AirTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dx_AirTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dx_AirTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dx_AirTemperature.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dx_AirTemperature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dx_AirTemperature.Location = new System.Drawing.Point(541, 28);
            this.dx_AirTemperature.Name = "dx_AirTemperature";
            this.dx_AirTemperature.Size = new System.Drawing.Size(76, 23);
            this.dx_AirTemperature.TabIndex = 29;
            this.dx_AirTemperature.Text = "20";
            this.dx_AirTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_2_AirTemperature
            // 
            this.porog_2_AirTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_AirTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_AirTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_AirTemperature.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_AirTemperature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_AirTemperature.Location = new System.Drawing.Point(474, 28);
            this.porog_2_AirTemperature.Name = "porog_2_AirTemperature";
            this.porog_2_AirTemperature.Size = new System.Drawing.Size(61, 23);
            this.porog_2_AirTemperature.TabIndex = 24;
            this.porog_2_AirTemperature.Text = "20";
            this.porog_2_AirTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_2_RelativeHumidity
            // 
            this.porog_2_RelativeHumidity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_RelativeHumidity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_RelativeHumidity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_RelativeHumidity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_RelativeHumidity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_RelativeHumidity.Location = new System.Drawing.Point(474, 53);
            this.porog_2_RelativeHumidity.Name = "porog_2_RelativeHumidity";
            this.porog_2_RelativeHumidity.Size = new System.Drawing.Size(61, 23);
            this.porog_2_RelativeHumidity.TabIndex = 25;
            this.porog_2_RelativeHumidity.Text = "20";
            this.porog_2_RelativeHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_2_AtmosphericPressure
            // 
            this.porog_2_AtmosphericPressure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_AtmosphericPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_AtmosphericPressure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_AtmosphericPressure.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_AtmosphericPressure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_AtmosphericPressure.Location = new System.Drawing.Point(474, 78);
            this.porog_2_AtmosphericPressure.Name = "porog_2_AtmosphericPressure";
            this.porog_2_AtmosphericPressure.Size = new System.Drawing.Size(61, 23);
            this.porog_2_AtmosphericPressure.TabIndex = 26;
            this.porog_2_AtmosphericPressure.Text = "20";
            this.porog_2_AtmosphericPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_2_WindSpeed
            // 
            this.porog_2_WindSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_WindSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_WindSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_WindSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_WindSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_WindSpeed.Location = new System.Drawing.Point(474, 103);
            this.porog_2_WindSpeed.Name = "porog_2_WindSpeed";
            this.porog_2_WindSpeed.Size = new System.Drawing.Size(61, 23);
            this.porog_2_WindSpeed.TabIndex = 27;
            this.porog_2_WindSpeed.Text = "20";
            this.porog_2_WindSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_2_WindDirection
            // 
            this.porog_2_WindDirection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_2_WindDirection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_2_WindDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_2_WindDirection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_2_WindDirection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_2_WindDirection.Location = new System.Drawing.Point(474, 128);
            this.porog_2_WindDirection.Name = "porog_2_WindDirection";
            this.porog_2_WindDirection.Size = new System.Drawing.Size(61, 23);
            this.porog_2_WindDirection.TabIndex = 28;
            this.porog_2_WindDirection.Text = "20";
            this.porog_2_WindDirection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_WindDirection
            // 
            this.porog_1_WindDirection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_WindDirection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_WindDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_WindDirection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_WindDirection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_WindDirection.Location = new System.Drawing.Point(413, 128);
            this.porog_1_WindDirection.Name = "porog_1_WindDirection";
            this.porog_1_WindDirection.Size = new System.Drawing.Size(55, 23);
            this.porog_1_WindDirection.TabIndex = 23;
            this.porog_1_WindDirection.Text = "20";
            this.porog_1_WindDirection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_WindSpeed
            // 
            this.porog_1_WindSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_WindSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_WindSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_WindSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_WindSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_WindSpeed.Location = new System.Drawing.Point(413, 103);
            this.porog_1_WindSpeed.Name = "porog_1_WindSpeed";
            this.porog_1_WindSpeed.Size = new System.Drawing.Size(55, 23);
            this.porog_1_WindSpeed.TabIndex = 22;
            this.porog_1_WindSpeed.Text = "20";
            this.porog_1_WindSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_AtmosphericPressure
            // 
            this.porog_1_AtmosphericPressure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_AtmosphericPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_AtmosphericPressure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_AtmosphericPressure.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_AtmosphericPressure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_AtmosphericPressure.Location = new System.Drawing.Point(413, 78);
            this.porog_1_AtmosphericPressure.Name = "porog_1_AtmosphericPressure";
            this.porog_1_AtmosphericPressure.Size = new System.Drawing.Size(55, 23);
            this.porog_1_AtmosphericPressure.TabIndex = 21;
            this.porog_1_AtmosphericPressure.Text = "20";
            this.porog_1_AtmosphericPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_RelativeHumidity
            // 
            this.porog_1_RelativeHumidity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_RelativeHumidity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_RelativeHumidity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_RelativeHumidity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_RelativeHumidity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_RelativeHumidity.Location = new System.Drawing.Point(413, 53);
            this.porog_1_RelativeHumidity.Name = "porog_1_RelativeHumidity";
            this.porog_1_RelativeHumidity.Size = new System.Drawing.Size(55, 23);
            this.porog_1_RelativeHumidity.TabIndex = 20;
            this.porog_1_RelativeHumidity.Text = "20";
            this.porog_1_RelativeHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porog_1_AirTemperature
            // 
            this.porog_1_AirTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.porog_1_AirTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porog_1_AirTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porog_1_AirTemperature.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.porog_1_AirTemperature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.porog_1_AirTemperature.Location = new System.Drawing.Point(413, 28);
            this.porog_1_AirTemperature.Name = "porog_1_AirTemperature";
            this.porog_1_AirTemperature.Size = new System.Drawing.Size(55, 23);
            this.porog_1_AirTemperature.TabIndex = 19;
            this.porog_1_AirTemperature.Text = "20";
            this.porog_1_AirTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // currentAirTemperature
            // 
            this.currentAirTemperature.AutoSize = true;
            this.currentAirTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.currentAirTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentAirTemperature.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentAirTemperature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentAirTemperature.Location = new System.Drawing.Point(345, 25);
            this.currentAirTemperature.Name = "currentAirTemperature";
            this.currentAirTemperature.Size = new System.Drawing.Size(62, 25);
            this.currentAirTemperature.TabIndex = 17;
            this.currentAirTemperature.Text = "23.9";
            this.currentAirTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentRelativeHumidity
            // 
            this.currentRelativeHumidity.AutoSize = true;
            this.currentRelativeHumidity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.currentRelativeHumidity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentRelativeHumidity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentRelativeHumidity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentRelativeHumidity.Location = new System.Drawing.Point(345, 50);
            this.currentRelativeHumidity.Name = "currentRelativeHumidity";
            this.currentRelativeHumidity.Size = new System.Drawing.Size(62, 25);
            this.currentRelativeHumidity.TabIndex = 16;
            this.currentRelativeHumidity.Text = "23.9";
            this.currentRelativeHumidity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentAtmosphericPressure
            // 
            this.currentAtmosphericPressure.AutoSize = true;
            this.currentAtmosphericPressure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.currentAtmosphericPressure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentAtmosphericPressure.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentAtmosphericPressure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentAtmosphericPressure.Location = new System.Drawing.Point(345, 75);
            this.currentAtmosphericPressure.Name = "currentAtmosphericPressure";
            this.currentAtmosphericPressure.Size = new System.Drawing.Size(62, 25);
            this.currentAtmosphericPressure.TabIndex = 15;
            this.currentAtmosphericPressure.Text = "23.9";
            this.currentAtmosphericPressure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentWindSpeed
            // 
            this.currentWindSpeed.AutoSize = true;
            this.currentWindSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.currentWindSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentWindSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentWindSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentWindSpeed.Location = new System.Drawing.Point(345, 100);
            this.currentWindSpeed.Name = "currentWindSpeed";
            this.currentWindSpeed.Size = new System.Drawing.Size(62, 25);
            this.currentWindSpeed.TabIndex = 14;
            this.currentWindSpeed.Text = "23.9";
            this.currentWindSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentWindDirection
            // 
            this.currentWindDirection.AutoSize = true;
            this.currentWindDirection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.currentWindDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentWindDirection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentWindDirection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentWindDirection.Location = new System.Drawing.Point(345, 125);
            this.currentWindDirection.Name = "currentWindDirection";
            this.currentWindDirection.Size = new System.Drawing.Size(62, 26);
            this.currentWindDirection.TabIndex = 18;
            this.currentWindDirection.Text = "23.9";
            this.currentWindDirection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Red;
            this.radioButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton1.Location = new System.Drawing.Point(3, 28);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(20, 19);
            this.radioButton1.TabIndex = 39;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.radioButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton2.Location = new System.Drawing.Point(3, 53);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(20, 19);
            this.radioButton2.TabIndex = 40;
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackColor = System.Drawing.Color.Fuchsia;
            this.radioButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton3.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton3.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton3.Location = new System.Drawing.Point(3, 78);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(20, 19);
            this.radioButton3.TabIndex = 41;
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = false;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.BackColor = System.Drawing.Color.Cyan;
            this.radioButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton4.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton4.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton4.Location = new System.Drawing.Point(3, 103);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(20, 19);
            this.radioButton4.TabIndex = 42;
            this.radioButton4.TabStop = true;
            this.radioButton4.UseVisualStyleBackColor = false;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.BackColor = System.Drawing.Color.Lime;
            this.radioButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButton5.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton5.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.radioButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton5.Location = new System.Drawing.Point(3, 128);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(20, 20);
            this.radioButton5.TabIndex = 43;
            this.radioButton5.TabStop = true;
            this.radioButton5.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.29582F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.59807F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.10611F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(679, 622);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Controls.Add(this.sumZeroCarbonDioxide, 5, 5);
            this.tableLayoutPanel2.Controls.Add(this.sumZeroSulfurDioxide, 5, 4);
            this.tableLayoutPanel2.Controls.Add(this.sumZeroNitrogenDioxide, 5, 3);
            this.tableLayoutPanel2.Controls.Add(this.sumZeroNitrogenOxide, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.sumZeroCarbonMonoxide, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.acp_CarbonDioxide, 4, 5);
            this.tableLayoutPanel2.Controls.Add(this.setupZeroVolatileOrganicCompounds, 2, 6);
            this.tableLayoutPanel2.Controls.Add(this.acp_SulfurDioxide, 4, 4);
            this.tableLayoutPanel2.Controls.Add(this.acp_NitrogenDioxide, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.label16, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.acp_NitrogenOxide, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.acp_CarbonMonoxide, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.pgc_NitrogenDioxide, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.pgc_CarbonDioxide, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.pgc_SulfurDioxide, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.label6, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pgc_CarbonMonoxide, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.pgc_NitrogenOxide, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.label14, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label15, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label17, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label18, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.currentNitrogenOxide2, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.currentCarbonMonoxide2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.currentNitrogenDioxide2, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.currentCarbonDioxide2, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.currentSulfurDioxide2, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.currentVolatileOrganicCompounds2, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.setupZeroCarbonMonoxide, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.setupZeroNitrogenOxide, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.setupZeroNitrogenDioxide, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.setupZeroSulfurDioxide, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.setupZeroCarbonDioxide, 2, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(673, 170);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // sumZeroCarbonDioxide
            // 
            this.sumZeroCarbonDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.sumZeroCarbonDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sumZeroCarbonDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sumZeroCarbonDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sumZeroCarbonDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.sumZeroCarbonDioxide.Location = new System.Drawing.Point(563, 123);
            this.sumZeroCarbonDioxide.Name = "sumZeroCarbonDioxide";
            this.sumZeroCarbonDioxide.Size = new System.Drawing.Size(107, 23);
            this.sumZeroCarbonDioxide.TabIndex = 25;
            this.sumZeroCarbonDioxide.Text = "20";
            this.sumZeroCarbonDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sumZeroSulfurDioxide
            // 
            this.sumZeroSulfurDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.sumZeroSulfurDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sumZeroSulfurDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sumZeroSulfurDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sumZeroSulfurDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.sumZeroSulfurDioxide.Location = new System.Drawing.Point(563, 99);
            this.sumZeroSulfurDioxide.Name = "sumZeroSulfurDioxide";
            this.sumZeroSulfurDioxide.Size = new System.Drawing.Size(107, 23);
            this.sumZeroSulfurDioxide.TabIndex = 37;
            this.sumZeroSulfurDioxide.Text = "20";
            this.sumZeroSulfurDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sumZeroNitrogenDioxide
            // 
            this.sumZeroNitrogenDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.sumZeroNitrogenDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sumZeroNitrogenDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sumZeroNitrogenDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sumZeroNitrogenDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.sumZeroNitrogenDioxide.Location = new System.Drawing.Point(563, 75);
            this.sumZeroNitrogenDioxide.Name = "sumZeroNitrogenDioxide";
            this.sumZeroNitrogenDioxide.Size = new System.Drawing.Size(107, 23);
            this.sumZeroNitrogenDioxide.TabIndex = 25;
            this.sumZeroNitrogenDioxide.Text = "20";
            this.sumZeroNitrogenDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sumZeroNitrogenOxide
            // 
            this.sumZeroNitrogenOxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.sumZeroNitrogenOxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sumZeroNitrogenOxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sumZeroNitrogenOxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sumZeroNitrogenOxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.sumZeroNitrogenOxide.Location = new System.Drawing.Point(563, 51);
            this.sumZeroNitrogenOxide.Name = "sumZeroNitrogenOxide";
            this.sumZeroNitrogenOxide.Size = new System.Drawing.Size(107, 23);
            this.sumZeroNitrogenOxide.TabIndex = 32;
            this.sumZeroNitrogenOxide.Text = "20";
            this.sumZeroNitrogenOxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sumZeroCarbonMonoxide
            // 
            this.sumZeroCarbonMonoxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.sumZeroCarbonMonoxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sumZeroCarbonMonoxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sumZeroCarbonMonoxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sumZeroCarbonMonoxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.sumZeroCarbonMonoxide.Location = new System.Drawing.Point(563, 27);
            this.sumZeroCarbonMonoxide.Name = "sumZeroCarbonMonoxide";
            this.sumZeroCarbonMonoxide.Size = new System.Drawing.Size(107, 23);
            this.sumZeroCarbonMonoxide.TabIndex = 33;
            this.sumZeroCarbonMonoxide.Text = "20";
            this.sumZeroCarbonMonoxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // acp_CarbonDioxide
            // 
            this.acp_CarbonDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.acp_CarbonDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acp_CarbonDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acp_CarbonDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.acp_CarbonDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.acp_CarbonDioxide.Location = new System.Drawing.Point(451, 123);
            this.acp_CarbonDioxide.Name = "acp_CarbonDioxide";
            this.acp_CarbonDioxide.Size = new System.Drawing.Size(106, 23);
            this.acp_CarbonDioxide.TabIndex = 36;
            this.acp_CarbonDioxide.Text = "20";
            this.acp_CarbonDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // setupZeroVolatileOrganicCompounds
            // 
            this.setupZeroVolatileOrganicCompounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.setupZeroVolatileOrganicCompounds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setupZeroVolatileOrganicCompounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupZeroVolatileOrganicCompounds.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.setupZeroVolatileOrganicCompounds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.setupZeroVolatileOrganicCompounds.Location = new System.Drawing.Point(227, 147);
            this.setupZeroVolatileOrganicCompounds.Name = "setupZeroVolatileOrganicCompounds";
            this.setupZeroVolatileOrganicCompounds.Size = new System.Drawing.Size(106, 23);
            this.setupZeroVolatileOrganicCompounds.TabIndex = 25;
            this.setupZeroVolatileOrganicCompounds.Text = "20";
            this.setupZeroVolatileOrganicCompounds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // acp_SulfurDioxide
            // 
            this.acp_SulfurDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.acp_SulfurDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acp_SulfurDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acp_SulfurDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.acp_SulfurDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.acp_SulfurDioxide.Location = new System.Drawing.Point(451, 99);
            this.acp_SulfurDioxide.Name = "acp_SulfurDioxide";
            this.acp_SulfurDioxide.Size = new System.Drawing.Size(106, 23);
            this.acp_SulfurDioxide.TabIndex = 34;
            this.acp_SulfurDioxide.Text = "20";
            this.acp_SulfurDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // acp_NitrogenDioxide
            // 
            this.acp_NitrogenDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.acp_NitrogenDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acp_NitrogenDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acp_NitrogenDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.acp_NitrogenDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.acp_NitrogenDioxide.Location = new System.Drawing.Point(451, 75);
            this.acp_NitrogenDioxide.Name = "acp_NitrogenDioxide";
            this.acp_NitrogenDioxide.Size = new System.Drawing.Size(106, 23);
            this.acp_NitrogenDioxide.TabIndex = 35;
            this.acp_NitrogenDioxide.Text = "20";
            this.acp_NitrogenDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label16.Location = new System.Drawing.Point(3, 144);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 26);
            this.label16.TabIndex = 13;
            this.label16.Text = "ЛОС (ppm) ";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Параметр";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.label2.Location = new System.Drawing.Point(115, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Текущее";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.label3.Location = new System.Drawing.Point(227, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Уст. нуля";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // acp_NitrogenOxide
            // 
            this.acp_NitrogenOxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.acp_NitrogenOxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acp_NitrogenOxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acp_NitrogenOxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.acp_NitrogenOxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.acp_NitrogenOxide.Location = new System.Drawing.Point(451, 51);
            this.acp_NitrogenOxide.Name = "acp_NitrogenOxide";
            this.acp_NitrogenOxide.Size = new System.Drawing.Size(106, 23);
            this.acp_NitrogenOxide.TabIndex = 29;
            this.acp_NitrogenOxide.Text = "20";
            this.acp_NitrogenOxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // acp_CarbonMonoxide
            // 
            this.acp_CarbonMonoxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.acp_CarbonMonoxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acp_CarbonMonoxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acp_CarbonMonoxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.acp_CarbonMonoxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.acp_CarbonMonoxide.Location = new System.Drawing.Point(451, 27);
            this.acp_CarbonMonoxide.Name = "acp_CarbonMonoxide";
            this.acp_CarbonMonoxide.Size = new System.Drawing.Size(106, 23);
            this.acp_CarbonMonoxide.TabIndex = 30;
            this.acp_CarbonMonoxide.Text = "20";
            this.acp_CarbonMonoxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pgc_NitrogenDioxide
            // 
            this.pgc_NitrogenDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pgc_NitrogenDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgc_NitrogenDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgc_NitrogenDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pgc_NitrogenDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pgc_NitrogenDioxide.Location = new System.Drawing.Point(339, 75);
            this.pgc_NitrogenDioxide.Name = "pgc_NitrogenDioxide";
            this.pgc_NitrogenDioxide.Size = new System.Drawing.Size(106, 23);
            this.pgc_NitrogenDioxide.TabIndex = 31;
            this.pgc_NitrogenDioxide.Text = "20";
            this.pgc_NitrogenDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.label4.Location = new System.Drawing.Point(339, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Конц-я ПГС";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pgc_CarbonDioxide
            // 
            this.pgc_CarbonDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pgc_CarbonDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgc_CarbonDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgc_CarbonDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pgc_CarbonDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pgc_CarbonDioxide.Location = new System.Drawing.Point(339, 123);
            this.pgc_CarbonDioxide.Name = "pgc_CarbonDioxide";
            this.pgc_CarbonDioxide.Size = new System.Drawing.Size(106, 23);
            this.pgc_CarbonDioxide.TabIndex = 28;
            this.pgc_CarbonDioxide.Text = "20";
            this.pgc_CarbonDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.label5.Location = new System.Drawing.Point(451, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "Знач-е АЦП";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pgc_SulfurDioxide
            // 
            this.pgc_SulfurDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pgc_SulfurDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgc_SulfurDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgc_SulfurDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pgc_SulfurDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pgc_SulfurDioxide.Location = new System.Drawing.Point(339, 99);
            this.pgc_SulfurDioxide.Name = "pgc_SulfurDioxide";
            this.pgc_SulfurDioxide.Size = new System.Drawing.Size(106, 23);
            this.pgc_SulfurDioxide.TabIndex = 26;
            this.pgc_SulfurDioxide.Text = "20";
            this.pgc_SulfurDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.label6.Location = new System.Drawing.Point(563, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "Расчётный «0»";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label13.Location = new System.Drawing.Point(3, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 24);
            this.label13.TabIndex = 10;
            this.label13.Text = "CO (ppm)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pgc_CarbonMonoxide
            // 
            this.pgc_CarbonMonoxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pgc_CarbonMonoxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgc_CarbonMonoxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgc_CarbonMonoxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pgc_CarbonMonoxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pgc_CarbonMonoxide.Location = new System.Drawing.Point(339, 27);
            this.pgc_CarbonMonoxide.Name = "pgc_CarbonMonoxide";
            this.pgc_CarbonMonoxide.Size = new System.Drawing.Size(106, 23);
            this.pgc_CarbonMonoxide.TabIndex = 27;
            this.pgc_CarbonMonoxide.Text = "20";
            this.pgc_CarbonMonoxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pgc_NitrogenOxide
            // 
            this.pgc_NitrogenOxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pgc_NitrogenOxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgc_NitrogenOxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgc_NitrogenOxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pgc_NitrogenOxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pgc_NitrogenOxide.Location = new System.Drawing.Point(339, 51);
            this.pgc_NitrogenOxide.Name = "pgc_NitrogenOxide";
            this.pgc_NitrogenOxide.Size = new System.Drawing.Size(106, 23);
            this.pgc_NitrogenOxide.TabIndex = 25;
            this.pgc_NitrogenOxide.Text = "20";
            this.pgc_NitrogenOxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label14.Location = new System.Drawing.Point(3, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 24);
            this.label14.TabIndex = 11;
            this.label14.Text = "NO (ppb)";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label15.Location = new System.Drawing.Point(3, 96);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 24);
            this.label15.TabIndex = 12;
            this.label15.Text = "SO2 (ppb)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label17.Location = new System.Drawing.Point(3, 72);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(106, 24);
            this.label17.TabIndex = 14;
            this.label17.Text = "NO2 (ppb)";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label18.Location = new System.Drawing.Point(3, 120);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 24);
            this.label18.TabIndex = 15;
            this.label18.Text = "CO2 (ppm)";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentNitrogenOxide2
            // 
            this.currentNitrogenOxide2.AutoSize = true;
            this.currentNitrogenOxide2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.currentNitrogenOxide2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentNitrogenOxide2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentNitrogenOxide2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentNitrogenOxide2.Location = new System.Drawing.Point(115, 48);
            this.currentNitrogenOxide2.Name = "currentNitrogenOxide2";
            this.currentNitrogenOxide2.Size = new System.Drawing.Size(106, 24);
            this.currentNitrogenOxide2.TabIndex = 19;
            this.currentNitrogenOxide2.Text = "23.9";
            this.currentNitrogenOxide2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentCarbonMonoxide2
            // 
            this.currentCarbonMonoxide2.AutoSize = true;
            this.currentCarbonMonoxide2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.currentCarbonMonoxide2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentCarbonMonoxide2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentCarbonMonoxide2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentCarbonMonoxide2.Location = new System.Drawing.Point(115, 24);
            this.currentCarbonMonoxide2.Name = "currentCarbonMonoxide2";
            this.currentCarbonMonoxide2.Size = new System.Drawing.Size(106, 24);
            this.currentCarbonMonoxide2.TabIndex = 18;
            this.currentCarbonMonoxide2.Text = "23.9";
            this.currentCarbonMonoxide2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentNitrogenDioxide2
            // 
            this.currentNitrogenDioxide2.AutoSize = true;
            this.currentNitrogenDioxide2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.currentNitrogenDioxide2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentNitrogenDioxide2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentNitrogenDioxide2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentNitrogenDioxide2.Location = new System.Drawing.Point(115, 72);
            this.currentNitrogenDioxide2.Name = "currentNitrogenDioxide2";
            this.currentNitrogenDioxide2.Size = new System.Drawing.Size(106, 24);
            this.currentNitrogenDioxide2.TabIndex = 20;
            this.currentNitrogenDioxide2.Text = "23.9";
            this.currentNitrogenDioxide2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentCarbonDioxide2
            // 
            this.currentCarbonDioxide2.AutoSize = true;
            this.currentCarbonDioxide2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.currentCarbonDioxide2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentCarbonDioxide2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentCarbonDioxide2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentCarbonDioxide2.Location = new System.Drawing.Point(115, 120);
            this.currentCarbonDioxide2.Name = "currentCarbonDioxide2";
            this.currentCarbonDioxide2.Size = new System.Drawing.Size(106, 24);
            this.currentCarbonDioxide2.TabIndex = 21;
            this.currentCarbonDioxide2.Text = "23.9";
            this.currentCarbonDioxide2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentSulfurDioxide2
            // 
            this.currentSulfurDioxide2.AutoSize = true;
            this.currentSulfurDioxide2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.currentSulfurDioxide2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentSulfurDioxide2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentSulfurDioxide2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentSulfurDioxide2.Location = new System.Drawing.Point(115, 96);
            this.currentSulfurDioxide2.Name = "currentSulfurDioxide2";
            this.currentSulfurDioxide2.Size = new System.Drawing.Size(106, 24);
            this.currentSulfurDioxide2.TabIndex = 22;
            this.currentSulfurDioxide2.Text = "23.9";
            this.currentSulfurDioxide2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentVolatileOrganicCompounds2
            // 
            this.currentVolatileOrganicCompounds2.AutoSize = true;
            this.currentVolatileOrganicCompounds2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.currentVolatileOrganicCompounds2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentVolatileOrganicCompounds2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentVolatileOrganicCompounds2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentVolatileOrganicCompounds2.Location = new System.Drawing.Point(115, 144);
            this.currentVolatileOrganicCompounds2.Name = "currentVolatileOrganicCompounds2";
            this.currentVolatileOrganicCompounds2.Size = new System.Drawing.Size(106, 26);
            this.currentVolatileOrganicCompounds2.TabIndex = 23;
            this.currentVolatileOrganicCompounds2.Text = "23.9";
            this.currentVolatileOrganicCompounds2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // setupZeroCarbonMonoxide
            // 
            this.setupZeroCarbonMonoxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.setupZeroCarbonMonoxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setupZeroCarbonMonoxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupZeroCarbonMonoxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.setupZeroCarbonMonoxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.setupZeroCarbonMonoxide.Location = new System.Drawing.Point(227, 27);
            this.setupZeroCarbonMonoxide.Name = "setupZeroCarbonMonoxide";
            this.setupZeroCarbonMonoxide.Size = new System.Drawing.Size(106, 23);
            this.setupZeroCarbonMonoxide.TabIndex = 24;
            this.setupZeroCarbonMonoxide.Text = "20";
            this.setupZeroCarbonMonoxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // setupZeroNitrogenOxide
            // 
            this.setupZeroNitrogenOxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.setupZeroNitrogenOxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setupZeroNitrogenOxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupZeroNitrogenOxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.setupZeroNitrogenOxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.setupZeroNitrogenOxide.Location = new System.Drawing.Point(227, 51);
            this.setupZeroNitrogenOxide.Name = "setupZeroNitrogenOxide";
            this.setupZeroNitrogenOxide.Size = new System.Drawing.Size(106, 23);
            this.setupZeroNitrogenOxide.TabIndex = 28;
            this.setupZeroNitrogenOxide.Text = "20";
            this.setupZeroNitrogenOxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // setupZeroNitrogenDioxide
            // 
            this.setupZeroNitrogenDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.setupZeroNitrogenDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setupZeroNitrogenDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupZeroNitrogenDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.setupZeroNitrogenDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.setupZeroNitrogenDioxide.Location = new System.Drawing.Point(227, 75);
            this.setupZeroNitrogenDioxide.Name = "setupZeroNitrogenDioxide";
            this.setupZeroNitrogenDioxide.Size = new System.Drawing.Size(106, 23);
            this.setupZeroNitrogenDioxide.TabIndex = 26;
            this.setupZeroNitrogenDioxide.Text = "20";
            this.setupZeroNitrogenDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // setupZeroSulfurDioxide
            // 
            this.setupZeroSulfurDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.setupZeroSulfurDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setupZeroSulfurDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupZeroSulfurDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.setupZeroSulfurDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.setupZeroSulfurDioxide.Location = new System.Drawing.Point(227, 99);
            this.setupZeroSulfurDioxide.Name = "setupZeroSulfurDioxide";
            this.setupZeroSulfurDioxide.Size = new System.Drawing.Size(106, 23);
            this.setupZeroSulfurDioxide.TabIndex = 27;
            this.setupZeroSulfurDioxide.Text = "20";
            this.setupZeroSulfurDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // setupZeroCarbonDioxide
            // 
            this.setupZeroCarbonDioxide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.setupZeroCarbonDioxide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setupZeroCarbonDioxide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setupZeroCarbonDioxide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.setupZeroCarbonDioxide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.setupZeroCarbonDioxide.Location = new System.Drawing.Point(227, 123);
            this.setupZeroCarbonDioxide.Name = "setupZeroCarbonDioxide";
            this.setupZeroCarbonDioxide.Size = new System.Drawing.Size(106, 23);
            this.setupZeroCarbonDioxide.TabIndex = 25;
            this.setupZeroCarbonDioxide.Text = "20";
            this.setupZeroCarbonDioxide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.Controls.Add(this.label27, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label8, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label9, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label10, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label11, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.label12, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.label25, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label26, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label28, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.currentAirTemperature2, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.currentAtmosphericPressure2, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.currentRelativeHumidity2, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.currentWindSpeed2, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.powerAirTemperature, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.powerRelativeHumidity, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.constRelativeHumidity, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.constAtmosphericPressure, 3, 3);
            this.tableLayoutPanel3.Controls.Add(this.constWindSpeed, 3, 4);
            this.tableLayoutPanel3.Controls.Add(this.constAirTemperature, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.stepAirTemperature, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.stepRelativeHumidity, 4, 2);
            this.tableLayoutPanel3.Controls.Add(this.timeAirTemperature, 5, 1);
            this.tableLayoutPanel3.Controls.Add(this.timeRelativeHumidity, 5, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 179);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(673, 147);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label27.Location = new System.Drawing.Point(3, 116);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(106, 31);
            this.label27.TabIndex = 13;
            this.label27.Text = "Скорость ветра (м/с)";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 29);
            this.label7.TabIndex = 2;
            this.label7.Text = "Параметр";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.label8.Location = new System.Drawing.Point(115, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 29);
            this.label8.TabIndex = 3;
            this.label8.Text = "Текущее";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.label9.Location = new System.Drawing.Point(227, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 29);
            this.label9.TabIndex = 4;
            this.label9.Text = "Мощность %";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Cursor = System.Windows.Forms.Cursors.Default;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.label10.Location = new System.Drawing.Point(339, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 29);
            this.label10.TabIndex = 5;
            this.label10.Text = "Константа";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Cursor = System.Windows.Forms.Cursors.Default;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.label11.Location = new System.Drawing.Point(451, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 29);
            this.label11.TabIndex = 6;
            this.label11.Text = "Шаг измен.";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Cursor = System.Windows.Forms.Cursors.Default;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.label12.Location = new System.Drawing.Point(563, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 29);
            this.label12.TabIndex = 7;
            this.label12.Text = "Время измен.";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label25.Location = new System.Drawing.Point(3, 29);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(106, 29);
            this.label25.TabIndex = 11;
            this.label25.Text = "Температура (°С)";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label26.Location = new System.Drawing.Point(3, 58);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(106, 29);
            this.label26.TabIndex = 12;
            this.label26.Text = "Отн. влажность (%)";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.label28.Location = new System.Drawing.Point(3, 87);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(106, 29);
            this.label28.TabIndex = 14;
            this.label28.Text = "Атм. давление (Hpa)";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentAirTemperature2
            // 
            this.currentAirTemperature2.AutoSize = true;
            this.currentAirTemperature2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.currentAirTemperature2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentAirTemperature2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentAirTemperature2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentAirTemperature2.Location = new System.Drawing.Point(115, 29);
            this.currentAirTemperature2.Name = "currentAirTemperature2";
            this.currentAirTemperature2.Size = new System.Drawing.Size(106, 29);
            this.currentAirTemperature2.TabIndex = 19;
            this.currentAirTemperature2.Text = "23.9";
            this.currentAirTemperature2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentAtmosphericPressure2
            // 
            this.currentAtmosphericPressure2.AutoSize = true;
            this.currentAtmosphericPressure2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.currentAtmosphericPressure2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentAtmosphericPressure2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentAtmosphericPressure2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentAtmosphericPressure2.Location = new System.Drawing.Point(115, 87);
            this.currentAtmosphericPressure2.Name = "currentAtmosphericPressure2";
            this.currentAtmosphericPressure2.Size = new System.Drawing.Size(106, 29);
            this.currentAtmosphericPressure2.TabIndex = 20;
            this.currentAtmosphericPressure2.Text = "23.9";
            this.currentAtmosphericPressure2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentRelativeHumidity2
            // 
            this.currentRelativeHumidity2.AutoSize = true;
            this.currentRelativeHumidity2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.currentRelativeHumidity2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentRelativeHumidity2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentRelativeHumidity2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentRelativeHumidity2.Location = new System.Drawing.Point(115, 58);
            this.currentRelativeHumidity2.Name = "currentRelativeHumidity2";
            this.currentRelativeHumidity2.Size = new System.Drawing.Size(106, 29);
            this.currentRelativeHumidity2.TabIndex = 21;
            this.currentRelativeHumidity2.Text = "23.9";
            this.currentRelativeHumidity2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentWindSpeed2
            // 
            this.currentWindSpeed2.AutoSize = true;
            this.currentWindSpeed2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.currentWindSpeed2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentWindSpeed2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.currentWindSpeed2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.currentWindSpeed2.Location = new System.Drawing.Point(115, 116);
            this.currentWindSpeed2.Name = "currentWindSpeed2";
            this.currentWindSpeed2.Size = new System.Drawing.Size(106, 31);
            this.currentWindSpeed2.TabIndex = 22;
            this.currentWindSpeed2.Text = "23.9";
            this.currentWindSpeed2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // powerAirTemperature
            // 
            this.powerAirTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.powerAirTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.powerAirTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.powerAirTemperature.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.powerAirTemperature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.powerAirTemperature.Location = new System.Drawing.Point(227, 32);
            this.powerAirTemperature.Name = "powerAirTemperature";
            this.powerAirTemperature.Size = new System.Drawing.Size(106, 23);
            this.powerAirTemperature.TabIndex = 26;
            this.powerAirTemperature.Text = "20";
            this.powerAirTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // powerRelativeHumidity
            // 
            this.powerRelativeHumidity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.powerRelativeHumidity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.powerRelativeHumidity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.powerRelativeHumidity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.powerRelativeHumidity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.powerRelativeHumidity.Location = new System.Drawing.Point(227, 61);
            this.powerRelativeHumidity.Name = "powerRelativeHumidity";
            this.powerRelativeHumidity.Size = new System.Drawing.Size(106, 23);
            this.powerRelativeHumidity.TabIndex = 27;
            this.powerRelativeHumidity.Text = "20";
            this.powerRelativeHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // constRelativeHumidity
            // 
            this.constRelativeHumidity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.constRelativeHumidity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.constRelativeHumidity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.constRelativeHumidity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.constRelativeHumidity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.constRelativeHumidity.Location = new System.Drawing.Point(339, 61);
            this.constRelativeHumidity.Name = "constRelativeHumidity";
            this.constRelativeHumidity.Size = new System.Drawing.Size(106, 23);
            this.constRelativeHumidity.TabIndex = 28;
            this.constRelativeHumidity.Text = "20";
            this.constRelativeHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // constAtmosphericPressure
            // 
            this.constAtmosphericPressure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.constAtmosphericPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.constAtmosphericPressure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.constAtmosphericPressure.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.constAtmosphericPressure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.constAtmosphericPressure.Location = new System.Drawing.Point(339, 90);
            this.constAtmosphericPressure.Name = "constAtmosphericPressure";
            this.constAtmosphericPressure.Size = new System.Drawing.Size(106, 23);
            this.constAtmosphericPressure.TabIndex = 29;
            this.constAtmosphericPressure.Text = "20";
            this.constAtmosphericPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // constWindSpeed
            // 
            this.constWindSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.constWindSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.constWindSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.constWindSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.constWindSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.constWindSpeed.Location = new System.Drawing.Point(339, 119);
            this.constWindSpeed.Name = "constWindSpeed";
            this.constWindSpeed.Size = new System.Drawing.Size(106, 23);
            this.constWindSpeed.TabIndex = 30;
            this.constWindSpeed.Text = "20";
            this.constWindSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // constAirTemperature
            // 
            this.constAirTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.constAirTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.constAirTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.constAirTemperature.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.constAirTemperature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.constAirTemperature.Location = new System.Drawing.Point(339, 32);
            this.constAirTemperature.Name = "constAirTemperature";
            this.constAirTemperature.Size = new System.Drawing.Size(106, 23);
            this.constAirTemperature.TabIndex = 31;
            this.constAirTemperature.Text = "20";
            this.constAirTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stepAirTemperature
            // 
            this.stepAirTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.stepAirTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stepAirTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stepAirTemperature.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.stepAirTemperature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.stepAirTemperature.Location = new System.Drawing.Point(451, 32);
            this.stepAirTemperature.Name = "stepAirTemperature";
            this.stepAirTemperature.Size = new System.Drawing.Size(106, 23);
            this.stepAirTemperature.TabIndex = 32;
            this.stepAirTemperature.Text = "20";
            this.stepAirTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stepRelativeHumidity
            // 
            this.stepRelativeHumidity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.stepRelativeHumidity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stepRelativeHumidity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stepRelativeHumidity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.stepRelativeHumidity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.stepRelativeHumidity.Location = new System.Drawing.Point(451, 61);
            this.stepRelativeHumidity.Name = "stepRelativeHumidity";
            this.stepRelativeHumidity.Size = new System.Drawing.Size(106, 23);
            this.stepRelativeHumidity.TabIndex = 33;
            this.stepRelativeHumidity.Text = "20";
            this.stepRelativeHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timeAirTemperature
            // 
            this.timeAirTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.timeAirTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeAirTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeAirTemperature.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.timeAirTemperature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.timeAirTemperature.Location = new System.Drawing.Point(563, 32);
            this.timeAirTemperature.Name = "timeAirTemperature";
            this.timeAirTemperature.Size = new System.Drawing.Size(107, 23);
            this.timeAirTemperature.TabIndex = 34;
            this.timeAirTemperature.Text = "20";
            this.timeAirTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timeRelativeHumidity
            // 
            this.timeRelativeHumidity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.timeRelativeHumidity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeRelativeHumidity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeRelativeHumidity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.timeRelativeHumidity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.timeRelativeHumidity.Location = new System.Drawing.Point(563, 61);
            this.timeRelativeHumidity.Name = "timeRelativeHumidity";
            this.timeRelativeHumidity.Size = new System.Drawing.Size(107, 23);
            this.timeRelativeHumidity.TabIndex = 35;
            this.timeRelativeHumidity.Text = "20";
            this.timeRelativeHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.chart1.BorderSkin.PageColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 332);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(673, 287);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(1390, 658);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.HeaderPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "СТАНЦИЯ ОНЛАЙН МОНИТОРИНГА GRAVITON ECO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.isConnectServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.isConnectDevise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnlockImage)).EndInit();
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.mainContentTableLayoutPanel.ResumeLayout(false);
            this.secondaryContentTableLayoutPanel5.ResumeLayout(false);
            this.secondaryContentTableLayoutPanel5.PerformLayout();
            this.secondaryContentTableLayoutPanel4.ResumeLayout(false);
            this.secondaryContentTableLayoutPanel4.PerformLayout();
            this.secondaryContentTableLayoutPanel3.ResumeLayout(false);
            this.secondaryContentTableLayoutPanel3.PerformLayout();
            this.secondaryContentTableLayoutPanel2.ResumeLayout(false);
            this.secondaryContentTableLayoutPanel2.PerformLayout();
            this.secondaryContentTableLayoutPanel1.ResumeLayout(false);
            this.secondaryContentTableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel HeaderPanel;
        private System.Windows.Forms.PictureBox SettingBtn;
        private System.Windows.Forms.Label NameStation;
        private System.Windows.Forms.Label SerialNumber;
        private System.Windows.Forms.Label SoftVersion;
        private System.Windows.Forms.Label ApparatVersion;
        private System.Windows.Forms.ComboBox PeriodComboBox;
        private System.Windows.Forms.TextBox UnlockPinField;
        private System.Windows.Forms.PictureBox UnlockImage;
        private System.Windows.Forms.Label DateTimeLabel;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.TableLayoutPanel mainContentTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel secondaryContentTableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel secondaryContentTableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel secondaryContentTableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel secondaryContentTableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel secondaryContentTableLayoutPanel2;
        private System.Windows.Forms.Label periodLabel;
        private System.Windows.Forms.Label increaseLabel;
        private System.Windows.Forms.Label porog2Label;
        private System.Windows.Forms.Label porog1Label;
        private System.Windows.Forms.Label currentParametrLabel;
        private System.Windows.Forms.Label avgParametrLabel;
        private System.Windows.Forms.Label maxParametrLabel;
        private System.Windows.Forms.Label minParametrLabel;
        private System.Windows.Forms.Label ParametrLabel;
        private System.Windows.Forms.Label carbonMonoxide;
        private System.Windows.Forms.Label volatileOrganicCompounds;
        private System.Windows.Forms.Label sulfurDioxide;
        private System.Windows.Forms.Label nitrogenOxide;
        private System.Windows.Forms.Label nitrogenDioxide;
        private System.Windows.Forms.Label carbonDioxide;
        private System.Windows.Forms.Label airTemperature;
        private System.Windows.Forms.Label relativeHumidity;
        private System.Windows.Forms.Label atmosphericPressure;
        private System.Windows.Forms.Label windDirection;
        private System.Windows.Forms.Label windSpeed;
        private System.Windows.Forms.Label particulateMatterPM1;
        private System.Windows.Forms.Label particulateMatterPM10;
        private System.Windows.Forms.Label particulateMatterPM2_5;
        private System.Windows.Forms.Label tamperSensor;
        private System.Windows.Forms.Label vibrationLevel;
        private System.Windows.Forms.Label tiltLevel;
        private System.Windows.Forms.Label pressureInSensor;
        private System.Windows.Forms.Label temperatureInSensor;
        private System.Windows.Forms.Label supplyVoltage;
        private System.Windows.Forms.Label humidityInSensor;
        private System.Windows.Forms.Label samplingSpeed;
        private System.Windows.Forms.Label currentTemperatureInSensor;
        private System.Windows.Forms.Label currentHumidityInSensor;
        private System.Windows.Forms.Label currentSupplyVoltage;
        private System.Windows.Forms.Label currentSamplingSpeed;
        private System.Windows.Forms.Label currentPressureInSensor;
        private System.Windows.Forms.Label currentVibrationLevel;
        private System.Windows.Forms.Label currentTiltLevel;
        private System.Windows.Forms.Label currentTamperSensor;
        private System.Windows.Forms.Label currentParticulateMatterPM1;
        private System.Windows.Forms.Label currentParticulateMatterPM2_5;
        private System.Windows.Forms.Label currentParticulateMatterPM10;
        private System.Windows.Forms.Label currentCarbonMonoxide;
        private System.Windows.Forms.Label currentNitrogenOxide;
        private System.Windows.Forms.Label currentNitrogenDioxide;
        private System.Windows.Forms.Label currentSulfurDioxide;
        private System.Windows.Forms.Label currentCarbonDioxide;
        private System.Windows.Forms.Label currentVolatileOrganicCompounds;
        private System.Windows.Forms.Label currentAirTemperature;
        private System.Windows.Forms.Label currentRelativeHumidity;
        private System.Windows.Forms.Label currentAtmosphericPressure;
        private System.Windows.Forms.Label currentWindSpeed;
        private System.Windows.Forms.Label currentWindDirection;
        private System.Windows.Forms.TextBox porog_1_AirTemperature;
        private System.Windows.Forms.TextBox porog_1_RelativeHumidity;
        private System.Windows.Forms.TextBox porog_1_TemperatureInSensor;
        private System.Windows.Forms.TextBox porog_2_TemperatureInSensor;
        private System.Windows.Forms.TextBox porog_1_VibrationLevel;
        private System.Windows.Forms.TextBox porog_2_VibrationLevel;
        private System.Windows.Forms.TextBox dx_VibrationLevel;
        private System.Windows.Forms.TextBox dt_VibrationLevel;
        private System.Windows.Forms.TextBox porog_1_TiltLevel;
        private System.Windows.Forms.TextBox porog_2_TiltLevel;
        private System.Windows.Forms.TextBox dx_TiltLevel;
        private System.Windows.Forms.TextBox dt_TiltLevel;
        private System.Windows.Forms.TextBox porog_1_TamperSensor;
        private System.Windows.Forms.TextBox porog_2_TamperSensor;
        private System.Windows.Forms.TextBox dx_TamperSensor;
        private System.Windows.Forms.TextBox dt_TamperSensor;
        private System.Windows.Forms.TextBox porog_1_ParticulateMatterPM1;
        private System.Windows.Forms.TextBox porog_2_ParticulateMatterPM1;
        private System.Windows.Forms.TextBox dx_ParticulateMatterPM1;
        private System.Windows.Forms.TextBox dt_ParticulateMatterPM1;
        private System.Windows.Forms.TextBox porog_1_ParticulateMatterPM2_5;
        private System.Windows.Forms.TextBox porog_2_ParticulateMatterPM2_5;
        private System.Windows.Forms.TextBox dx_ParticulateMatterPM2_5;
        private System.Windows.Forms.TextBox dt_ParticulateMatterPM2_5;
        private System.Windows.Forms.TextBox porog_1_ParticulateMatterPM10;
        private System.Windows.Forms.TextBox porog_2_ParticulateMatterPM10;
        private System.Windows.Forms.TextBox dx_ParticulateMatterPM10;
        private System.Windows.Forms.TextBox dt_ParticulateMatterPM10;
        private System.Windows.Forms.TextBox porog_1_CarbonMonoxide;
        private System.Windows.Forms.TextBox porog_2_CarbonMonoxide;
        private System.Windows.Forms.TextBox dx_CarbonMonoxide;
        private System.Windows.Forms.TextBox dt_NitrogenOxide;
        private System.Windows.Forms.TextBox dt_CarbonMonoxide;
        private System.Windows.Forms.TextBox porog_1_NitrogenOxide;
        private System.Windows.Forms.TextBox porog_2_NitrogenOxide;
        private System.Windows.Forms.TextBox dx_NitrogenOxide;
        private System.Windows.Forms.TextBox porog_1_NitrogenDioxide;
        private System.Windows.Forms.TextBox porog_2_NitrogenDioxide;
        private System.Windows.Forms.TextBox dx_NitrogenDioxide;
        private System.Windows.Forms.TextBox dt_NitrogenDioxide;
        private System.Windows.Forms.TextBox porog_1_SulfurDioxide;
        private System.Windows.Forms.TextBox porog_2_SulfurDioxide;
        private System.Windows.Forms.TextBox dx_SulfurDioxide;
        private System.Windows.Forms.TextBox dt_SulfurDioxide;
        private System.Windows.Forms.TextBox porog_1_CarbonDioxide;
        private System.Windows.Forms.TextBox porog_2_CarbonDioxide;
        private System.Windows.Forms.TextBox dx_CarbonDioxide;
        private System.Windows.Forms.TextBox dt_CarbonDioxide;
        private System.Windows.Forms.TextBox porog_1_VolatileOrganicCompounds;
        private System.Windows.Forms.TextBox porog_2_VolatileOrganicCompounds;
        private System.Windows.Forms.TextBox dx_VolatileOrganicCompounds;
        private System.Windows.Forms.TextBox dt_VolatileOrganicCompounds;
        private System.Windows.Forms.TextBox porog_1_AtmosphericPressure;
        private System.Windows.Forms.TextBox porog_1_WindSpeed;
        private System.Windows.Forms.TextBox porog_1_WindDirection;
        private System.Windows.Forms.TextBox porog_2_AirTemperature;
        private System.Windows.Forms.TextBox porog_2_RelativeHumidity;
        private System.Windows.Forms.TextBox porog_2_AtmosphericPressure;
        private System.Windows.Forms.TextBox porog_2_WindSpeed;
        private System.Windows.Forms.TextBox porog_2_WindDirection;
        private System.Windows.Forms.TextBox dx_AirTemperature;
        private System.Windows.Forms.TextBox dx_RelativeHumidity;
        private System.Windows.Forms.TextBox dx_AtmosphericPressure;
        private System.Windows.Forms.TextBox dx_WindSpeed;
        private System.Windows.Forms.TextBox dx_WindDirection;
        private System.Windows.Forms.TextBox dt_AirTemperature;
        private System.Windows.Forms.TextBox dt_RelativeHumidity;
        private System.Windows.Forms.TextBox dt_AtmosphericPressure;
        private System.Windows.Forms.TextBox dt_WindSpeed;
        private System.Windows.Forms.TextBox dt_WindDirection;
        private System.Windows.Forms.TextBox dx_TemperatureInSensor;
        private System.Windows.Forms.TextBox dt_TemperatureInSensor;
        private System.Windows.Forms.TextBox porog_1_HumidityInSensor;
        private System.Windows.Forms.TextBox porog_2_HumidityInSensor;
        private System.Windows.Forms.TextBox dx_HumidityInSensor;
        private System.Windows.Forms.TextBox dt_SupplyVoltage;
        private System.Windows.Forms.TextBox dt_HumidityInSensor;
        private System.Windows.Forms.TextBox porog_1_SupplyVoltage;
        private System.Windows.Forms.TextBox porog_2_SupplyVoltage;
        private System.Windows.Forms.TextBox dx_SupplyVoltage;
        private System.Windows.Forms.TextBox porog_1_SamplingSpeed;
        private System.Windows.Forms.TextBox porog_2_SamplingSpeed;
        private System.Windows.Forms.TextBox dx_SamplingSpeed;
        private System.Windows.Forms.TextBox dt_SamplingSpeed;
        private System.Windows.Forms.TextBox porog_1_PressureInSensor;
        private System.Windows.Forms.TextBox porog_2_PressureInSensor;
        private System.Windows.Forms.TextBox dx_PressureInSensor;
        private System.Windows.Forms.TextBox dt_PressureInSensor;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton12;
        private System.Windows.Forms.RadioButton radioButton13;
        private System.Windows.Forms.RadioButton radioButton14;
        private System.Windows.Forms.RadioButton radioButton15;
        private System.Windows.Forms.RadioButton radioButton16;
        private System.Windows.Forms.RadioButton radioButton17;
        private System.Windows.Forms.RadioButton radioButton18;
        private System.Windows.Forms.RadioButton radioButton19;
        private System.Windows.Forms.RadioButton radioButton20;
        private System.Windows.Forms.RadioButton radioButton21;
        private System.Windows.Forms.RadioButton radioButton22;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox sumZeroCarbonDioxide;
        private System.Windows.Forms.TextBox sumZeroSulfurDioxide;
        private System.Windows.Forms.TextBox sumZeroNitrogenDioxide;
        private System.Windows.Forms.TextBox sumZeroNitrogenOxide;
        private System.Windows.Forms.TextBox sumZeroCarbonMonoxide;
        private System.Windows.Forms.TextBox acp_CarbonDioxide;
        private System.Windows.Forms.TextBox setupZeroVolatileOrganicCompounds;
        private System.Windows.Forms.TextBox acp_SulfurDioxide;
        private System.Windows.Forms.TextBox acp_NitrogenDioxide;
        private System.Windows.Forms.TextBox acp_NitrogenOxide;
        private System.Windows.Forms.TextBox acp_CarbonMonoxide;
        private System.Windows.Forms.TextBox pgc_NitrogenDioxide;
        private System.Windows.Forms.TextBox pgc_CarbonDioxide;
        private System.Windows.Forms.TextBox pgc_SulfurDioxide;
        private System.Windows.Forms.TextBox pgc_CarbonMonoxide;
        private System.Windows.Forms.TextBox pgc_NitrogenOxide;
        private System.Windows.Forms.Label currentNitrogenOxide2;
        private System.Windows.Forms.Label currentCarbonMonoxide2;
        private System.Windows.Forms.Label currentNitrogenDioxide2;
        private System.Windows.Forms.Label currentCarbonDioxide2;
        private System.Windows.Forms.Label currentSulfurDioxide2;
        private System.Windows.Forms.Label currentVolatileOrganicCompounds2;
        private System.Windows.Forms.TextBox setupZeroCarbonMonoxide;
        private System.Windows.Forms.TextBox setupZeroNitrogenOxide;
        private System.Windows.Forms.TextBox setupZeroNitrogenDioxide;
        private System.Windows.Forms.TextBox setupZeroSulfurDioxide;
        private System.Windows.Forms.TextBox setupZeroCarbonDioxide;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label currentAirTemperature2;
        private System.Windows.Forms.Label currentAtmosphericPressure2;
        private System.Windows.Forms.Label currentRelativeHumidity2;
        private System.Windows.Forms.Label currentWindSpeed2;
        private System.Windows.Forms.TextBox timeRelativeHumidity;
        private System.Windows.Forms.TextBox powerAirTemperature;
        private System.Windows.Forms.TextBox powerRelativeHumidity;
        private System.Windows.Forms.TextBox constRelativeHumidity;
        private System.Windows.Forms.TextBox constAtmosphericPressure;
        private System.Windows.Forms.TextBox constWindSpeed;
        private System.Windows.Forms.TextBox constAirTemperature;
        private System.Windows.Forms.TextBox stepAirTemperature;
        private System.Windows.Forms.TextBox stepRelativeHumidity;
        private System.Windows.Forms.TextBox timeAirTemperature;
        private System.Windows.Forms.PictureBox isConnectDevise;
        private System.Windows.Forms.PictureBox isConnectServer;
    }
}

