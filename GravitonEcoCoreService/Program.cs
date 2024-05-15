using GravitonEcoCoreService.Managers;
using GravitonEcoCoreService.Object;
using GravitonEcoCoreService.Updaters;
using Newtonsoft.Json;
using NLog;

public class Program
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    static void Main(string[] args)
    {
        TcpServer server = new TcpServer();
        server.server();
        ModbusConnectionManager modbusConnectionManager = ModbusConnectionManager.Instance;
        Task.Run(() => StartSensorupdate());
        Console.WriteLine("\n_______________________________________________________\n");
        Console.ReadKey();
    }

    static async void StartSensorupdate()
    {
        ModbusConnectionManager modbusConnectionManager = ModbusConnectionManager.Instance;
        

        _ = new SensorUpdater("Темпиратура", modbusConnectionManager, 2, 5, 1);
        _ = new SensorUpdater("Влажность", modbusConnectionManager, 2, 6, 1);
        _ = new SensorUpdater("Давление", modbusConnectionManager, 2, 1, 1);
        _ = new SensorUpdater("Напряжение_1", modbusConnectionManager, 2, 2, 1);
        _ = new SensorUpdater("Напряжение_2", modbusConnectionManager, 1, 544, 1);

    }

    
}

