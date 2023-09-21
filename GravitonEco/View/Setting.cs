using GravitonEco.Controller;
using GravitonEco.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GravitonEco.View
{
    public partial class Setting : Form
    {
        string _ipAddresSensor;
        int _portSensor;
        string _ipAddresDb;
        int _portDb;
        string _dataBaseName;
        string _dataBaseUserName;
        string _dataBasePasswort;
        string path = @"./Config/setting_device_connection.ini";
        private ModbusTCPClient _client;
        private string _host;
        private string _port;

        public Setting()
        {
            InitializeComponent();
            bool fileExist = File.Exists(path);
            if (fileExist)
            {
                INIManager manager = new INIManager(path);
                ipAddresSensor.Text = manager.GetPrivateString("DeviceConnectSetting", "Host");
                portSensor.Text = manager.GetPrivateString("DeviceConnectSetting", "Port");

                ipAddresDb.Text = manager.GetPrivateString("DataBaseConnectSetting", "IpAddresDb");
                portDb.Text = manager.GetPrivateString("DataBaseConnectSetting", "PortDb");
                dataBaseName.Text = manager.GetPrivateString("DataBaseConnectSetting", "DataBaseName");
                dataBaseUserName.Text = manager.GetPrivateString("DataBaseConnectSetting", "DataBaseUserName");
                dataBasePasswort.Text = manager.GetPrivateString("DataBaseConnectSetting", "DataBasePasswort");
            }
        }

        private void checkSensorConnection_Click(object sender, EventArgs e)
        {
            _ipAddresSensor = ipAddresSensor.Text;
            _portSensor = Int32.Parse(portSensor.Text);

            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.ReceiveTimeout = 5000;

                tcpClient.Connect(_ipAddresSensor, _portSensor);
                MessageBox.Show("Подключение установлено.", "Уведомление");

                tcpClient.Close();
            }
            catch (SocketException)
            {
                MessageBox.Show("Не удалось подключиться к серверу.", "Уведомление");
            }
        }

        private void saveSensorConnection_Click(object sender, EventArgs e)
        {
            _ipAddresSensor = ipAddresSensor.Text;
            _portSensor = Int32.Parse(portSensor.Text);

            INIManager manager = new INIManager(path);
            manager.WritePrivateString("DeviceConnectSetting", "Host", _ipAddresSensor);
            manager.WritePrivateString("DeviceConnectSetting", "Port", _portSensor.ToString());
            MessageBox.Show("Настройки сохранены", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveDataBaseConnection_Click(object sender, EventArgs e)
        {
            //_ipAddresSensor = ipAddresSensor.Text;
            //_portSensor = Int32.Parse(portSensor.Text);
            _ipAddresDb = ipAddresDb.Text;
            _portDb = Int32.Parse(portDb.Text);
            _dataBaseName = dataBaseName.Text;
            _dataBaseUserName = dataBaseName.Text;
            _dataBasePasswort = dataBasePasswort.Text;

            INIManager manager = new INIManager(path);
            //manager.WritePrivateString("DeviceConnectSetting", "Host", _ipAddresSensor);
            //manager.WritePrivateString("DeviceConnectSetting", "Port", _portSensor.ToString());
            manager.WritePrivateString("DataBaseConnectSetting", "IpAddresDb", _ipAddresDb);
            manager.WritePrivateString("DataBaseConnectSetting", "PortDb", _portDb.ToString());
            manager.WritePrivateString("DataBaseConnectSetting", "DataBaseName", _dataBaseName);
            manager.WritePrivateString("DataBaseConnectSetting", "DataBaseUserName", _dataBaseUserName);
            manager.WritePrivateString("DataBaseConnectSetting", "DataBasePasswort", _dataBasePasswort);
            MessageBox.Show("Настройки сохранены", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            INIManager manager = new INIManager(path);
            _host = manager.GetPrivateString("DeviceConnectSetting", "Host");
            _port = manager.GetPrivateString("DeviceConnectSetting", "Port");
            _client = new ModbusTCPClient(_host, Int32.Parse(_port));
            if (oldPassword.Text == _client.ReadHoldingParametr(1, 530) + "" + _client.ReadHoldingParametr(1, 531))
            {
                char[] tempCharPassword = newPassword.Text.ToCharArray();
                ushort oneBlockPassword = ushort.Parse(tempCharPassword[0] + "" + tempCharPassword[1] + "" + tempCharPassword[2] + "" + tempCharPassword[3]);
                ushort twoBlockPassword = ushort.Parse(tempCharPassword[4] + "" + tempCharPassword[5] + "" + tempCharPassword[6] + "" + tempCharPassword[7]);
                _client.WriteHoldingParametr(1, 530, oneBlockPassword);
                _client.WriteHoldingParametr(1, 531, twoBlockPassword);
                MessageBox.Show("Пароль перезаписан\n Новый пароль: " + _client.ReadHoldingParametr(1, 530) + "" + _client.ReadHoldingParametr(1, 531), "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Старый пароль не верный!\n Старый пароль: "+ _client.ReadHoldingParametr(1, 530) + "" + _client.ReadHoldingParametr(1, 531), "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
