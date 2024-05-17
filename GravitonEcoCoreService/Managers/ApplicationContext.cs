using GravitonEcoCoreService.Object;
using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEcoCoreService.Managers
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        string pathSensor = @"./Setting/setting_device_connection.ini";
        private readonly Logger logger = LogManager.GetCurrentClassLogger();


        public DbSet<SensorBase> Sensor { get; set; }
        public ApplicationContext()
        {
            try
            {
                Database.EnsureCreated();
            }
            catch (Npgsql.NpgsqlException ex)
            {
                logger.Error("Ошибка полкючения к серверу базы данных.\nТекст ошибки:\n" + ex.Message + "\nStackTrace:" + ex.StackTrace);
            }
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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
