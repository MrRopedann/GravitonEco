using GravitonEcoV2.Managers;
using NModbus;
using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using NLog;

public class ModbusConnectionManager
{
    private static ModbusConnectionManager instance;
    private ModbusFactory modbusFactory;
    private readonly object lockObject = new object(); // Добавляем объект блокировки для потокобезопасности
    private TcpClient tcpClient;
    private readonly Logger logger = LogManager.GetCurrentClassLogger();
    string pathSensor = @"./Setting/setting_device_connection.ini";

    private ModbusConnectionManager()
    {
        InitializeModbusConnection();
    }

    private void InitializeModbusConnection()
    {
        try
        {
            INIManager manager = new INIManager(pathSensor);
            string ipAddressStr = manager.GetPrivateString("DeviceConnectSetting", "Host");
            int port = Int32.Parse(manager.GetPrivateString("DeviceConnectSetting", "Port"));

            IPAddress ipAddress = IPAddress.Parse(ipAddressStr);

            tcpClient = new TcpClient(ipAddress.ToString(), port);
            modbusFactory = new ModbusFactory();
            modbusMaster = modbusFactory.CreateMaster(tcpClient);
        }
        catch (Exception ex)
        {
            //logger.Error($"Ошибка при инициализации подключения: {ex.Message}");
        }
    }

    public static ModbusConnectionManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ModbusConnectionManager();
            }
            return instance;
        }
    }

    private IModbusMaster modbusMaster;
    public IModbusMaster GetModbusMaster()
    {
        lock (lockObject)
        {
            // Проверяем, что у нас есть подключение и оно активно
            if (tcpClient != null && tcpClient.Connected)
            {
                return modbusMaster;
            }
            else
            {
                logger.Warn("Соединение отсутствует. Повторное подключение...");
                InitializeModbusConnection();
                return modbusMaster;
            }
        }
    }

    public bool IsDeviceAvailable()
    {
        lock (lockObject)
        {
            try
            {
                if (tcpClient == null || !tcpClient.Connected)
                {
                    logger.Warn("Соединение отсутствует. Повторное подключение...");
                    InitializeModbusConnection();
                }

                using (TcpClient testTcpClient = new TcpClient())
                {
                    IPEndPoint remoteEndPoint = (IPEndPoint)tcpClient.Client.RemoteEndPoint;
                    IAsyncResult result = testTcpClient.BeginConnect(remoteEndPoint.Address.ToString(), remoteEndPoint.Port, null, null);
                    bool success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2)); // Время ожидания подключения

                    if (success)
                    {
                        testTcpClient.EndConnect(result);
                        //logger.Info("Устройство доступно по TCP.");
                        return true;
                    }
                    else
                    {
                        logger.Error("Не удалось подключиться к устройству по TCP.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Ошибка при проверке доступности устройства: {ex.Message}");
                return false;
            }
        }
    }
}
