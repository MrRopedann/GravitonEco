using GravitonEco.Controller;
using GravitonEco.Model;
using GravitonEco.View;

namespace GravitonEco
{
    public partial class MainForm : Form
    {
        private DateTimeUpdater dataTimeUpdater;
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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dataTimeUpdater.StartUpdatingData(1);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.Show();
        }
    }
}