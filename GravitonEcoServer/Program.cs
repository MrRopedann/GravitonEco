using GravitonEcoServer.Managers;
using GravitonEcoServer.Updaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEcoServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            TcpServer server = new TcpServer();
            server.server();
            ModbusConnectionManager modbusConnectionManager = ModbusConnectionManager.Instance;
            Task.Run(() => StartSensorupdate());
            Console.WriteLine("\n_______________________________________________________\n");
            Console.ReadKey();
        }

       static void StartSensorupdate()
       {
            ModbusConnectionManager modbusConnectionManager = ModbusConnectionManager.Instance;
            _ = new SensorUpdater("Темпиратура", modbusConnectionManager, 2, 5, 1);
            _ = new SensorUpdater("Влажность",modbusConnectionManager, 2, 6, 1);
            _ = new SensorUpdater("Давление", modbusConnectionManager, 2, 1, 1);
            _ = new SensorUpdater("Напряжение_1", modbusConnectionManager, 2, 2, 1);
            _ = new SensorUpdater("Напряжение_2", modbusConnectionManager, 1, 544, 1);
            
        }
    }
}
