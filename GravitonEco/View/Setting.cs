using GravitonEco.Controller;
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
        string path = @"./Config/setting_device_connection.ini";

        public Setting()
        {
            InitializeComponent();
            bool fileExist = File.Exists(path);
            if (fileExist)
            {
                INIManager manager = new INIManager(path);
                ipAddresSensor.Text = manager.GetPrivateString("DeviceConnectSetting", "Host");
                portSensor.Text = manager.GetPrivateString("DeviceConnectSetting", "Port");
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
            TextWriter tw = new StreamWriter(path);
            tw.Close();
            INIManager manager = new INIManager(path);
            manager.WritePrivateString("DeviceConnectSetting", "Host", _ipAddresSensor);
            manager.WritePrivateString("DeviceConnectSetting", "Port", _portSensor.ToString());
            MessageBox.Show("Настройки сохранены", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
