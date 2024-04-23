using GravitonEcoV2.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace GravitonEcoV2.View
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
        string pathSensor = @"./Setting/setting_device_connection.ini";

        public Setting()
        {
            InitializeComponent();
            bool fileExist = File.Exists(pathSensor);
            if (fileExist)
            {
                INIManager manager = new INIManager(pathSensor);
                ipAddresSensor.Text = manager.GetPrivateString("DeviceConnectSetting", "Host");
                portSensor.Text = manager.GetPrivateString("DeviceConnectSetting", "Port");

                ipAddresDb.Text = manager.GetPrivateString("DataBaseConnectSetting", "IpAddresDb");
                portDb.Text = manager.GetPrivateString("DataBaseConnectSetting", "PortDb");
                dataBaseName.Text = manager.GetPrivateString("DataBaseConnectSetting", "DataBaseName");
                dataBaseUserName.Text = manager.GetPrivateString("DataBaseConnectSetting", "DataBaseUserName");
                dataBasePasswort.Text = manager.GetPrivateString("DataBaseConnectSetting", "DataBasePasswort");
            }
        }

        private void CheckDeviceConnection_Click(object sender, EventArgs e)
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

        private void SaveDeviceConnection_Click(object sender, EventArgs e)
        {
            _ipAddresSensor = ipAddresSensor.Text;
            _portSensor = Int32.Parse(portSensor.Text);

            INIManager manager = new INIManager(pathSensor);
            manager.WritePrivateString("DeviceConnectSetting", "Host", _ipAddresSensor);
            manager.WritePrivateString("DeviceConnectSetting", "Port", _portSensor.ToString());
            MessageBox.Show("Настройки сохранены", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveDataBaseConnection_Click(object sender, EventArgs e)
        {
            //_ipAddresSensor = ipAddresSensor.Text;
            //_portSensor = Int32.Parse(portSensor.Text);
            _ipAddresDb = ipAddresDb.Text;
            _portDb = Int32.Parse(portDb.Text);
            _dataBaseName = dataBaseName.Text;
            _dataBaseUserName = dataBaseName.Text;
            _dataBasePasswort = dataBasePasswort.Text;

            INIManager manager = new INIManager(pathSensor);
            //manager.WritePrivateString("DeviceConnectSetting", "Host", _ipAddresSensor);
            //manager.WritePrivateString("DeviceConnectSetting", "Port", _portSensor.ToString());
            manager.WritePrivateString("DataBaseConnectSetting", "IpAddresDb", _ipAddresDb);
            manager.WritePrivateString("DataBaseConnectSetting", "PortDb", _portDb.ToString());
            manager.WritePrivateString("DataBaseConnectSetting", "DataBaseName", _dataBaseName);
            manager.WritePrivateString("DataBaseConnectSetting", "DataBaseUserName", _dataBaseUserName);
            manager.WritePrivateString("DataBaseConnectSetting", "DataBasePasswort", _dataBasePasswort);
            MessageBox.Show("Настройки сохранены", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
