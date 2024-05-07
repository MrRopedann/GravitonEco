using NLog;
using NModbus.Device;
using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Management.Instrumentation;

namespace GravitonEcoV2.Managers
{
    public class ServerConnectionManager
    {
        private static ServerConnectionManager instance;
        private TcpClient tcpClient;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly object lockObject = new object();

        private ServerConnectionManager()
        {
            InitializeServerConnection();
        }
        
        private void InitializeServerConnection()
        {
            try
            {
                //INIManager manager = new INIManager(pathSensor);
                //string ipAddressStr = manager.GetPrivateString("DeviceConnectSetting", "Host");
                //int port = Int32.Parse(manager.GetPrivateString("DeviceConnectSetting", "Port"));

                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

                tcpClient = new TcpClient(ipAddress.ToString(), 8888);
            }
            catch (Exception ex)
            {
                logger.Error($"Ошибка при инициализации подключения: {ex.Message}");
            }
        }

        public static ServerConnectionManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServerConnectionManager();
                }
                return instance;
            }
        }

        public bool IsDeviceAvailable()
        {
            if (tcpClient == null || !tcpClient.Connected || tcpClient is null)
            {
                logger.Warn("Соединение отсутствует. Повторное подключение...");
                InitializeServerConnection();
                return false;
            }
            else 
            {
                return true;
            }
        }
    }

    
}
