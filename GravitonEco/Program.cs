using GravitonEco.Controller;
using GravitonEco.Model;
using GravitonEco.View;
using System.Net.Sockets;
using System.Windows.Forms;

namespace GravitonEco
{
    internal static class Program
    {
        static string _ipAddresSensor;
        static int _portSensor;
        private static ModbusTCPClient _client;
        
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashForm());
            INIManager manager = new INIManager(@"./Config/setting_device_connection.ini");
            _ipAddresSensor = manager.GetPrivateString("DeviceConnectSetting", "Host");
            _portSensor = Int32.Parse(manager.GetPrivateString("DeviceConnectSetting", "Port"));

            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.ReceiveTimeout = 5000;

                tcpClient.Connect(_ipAddresSensor, _portSensor);
                //MessageBox.Show("Подключение установлено.", "Уведомление");

                tcpClient.Close();
            }
            catch (SocketException)
            {
                Application.Run(new Setting());
                //MessageBox.Show("Не удалось подключиться к серверу.", "Уведомление");
            }
            
            Application.Run(new MainForm());
        }
    }
}