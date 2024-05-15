using GravitonEcoCoreService.Object;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEcoCoreService.Managers
{
    public class ApplicationContext : DbContext
    {
        string pathSensor = @"./Setting/setting_device_connection.ini";

        public DbSet<SensorBase> SensorTemperature { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            INIManager manager = new INIManager(pathSensor);
            string _db_ip = manager.GetPrivateString("DataBaseConnectSetting", "IpAddresDb");
            int _db_port = Convert.ToInt32(manager.GetPrivateString("DataBaseConnectSetting", "PortDb"));
            string _db_Name = manager.GetPrivateString("DataBaseConnectSetting", "DataBaseName");
            string _db_userName = manager.GetPrivateString("DataBaseConnectSetting", "DataBaseUserName");
            string _db_password = manager.GetPrivateString("DataBaseConnectSetting", "DataBasePasswort");
            optionsBuilder.UseNpgsql($"Host={_db_ip};Port={_db_port};Database={_db_Name};Username={_db_userName};Password={_db_password}");
        }
    }
}
