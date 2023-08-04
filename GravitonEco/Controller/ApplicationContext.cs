using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GravitonEco.Model;
using System.Net;
using System.IO;

namespace GravitonEco.Controller
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<DeviceSensor> DeviceSensors { get; set; }
        public DbSet<DevicePorog> DevicePorogs { get; set; }

        public ApplicationContext()
        {
            try
            {
                Database.EnsureCreated();
            }
            catch (Npgsql.NpgsqlException ex)
            {
                Console.WriteLine("Ошибка полкючения к серверу базы данных.\nТекст ошибки:\n" + ex.Message);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                string path = @"./Config/setting_device_connection.ini";
                INIManager manager = new INIManager(path);
                string ipAddresDb = manager.GetPrivateString("DataBaseConnectSetting", "IpAddresDb");
                string portDb = manager.GetPrivateString("DataBaseConnectSetting", "PortDb");
                string dataBaseName = manager.GetPrivateString("DataBaseConnectSetting", "DataBaseName");
                string dataBaseUserName = manager.GetPrivateString("DataBaseConnectSetting", "DataBaseUserName");
                string dataBasePasswort = manager.GetPrivateString("DataBaseConnectSetting", "DataBasePasswort");
                string connectionString = "Host=" + ipAddresDb + ";Port=" + portDb + ";Database=" + dataBaseName + ";Username=" + dataBaseUserName + ";Password=" + dataBasePasswort;
                optionsBuilder.UseNpgsql(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка базы данных.\nТекст ошибки:\n" + ex.Message);
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                ChangeTracker.DetectChanges();
                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка базы данных.\nТекст ошибки:\n" + ex.Message);
                return 0;
            }
        }

        public async Task<Dictionary<string, SensorDataStats>> GetSensorDataStatsForLastTwoHoursAsync()
        {
            // Получаем текущее время и время 2 часа назад
            DateTime now = DateTime.Now;
            DateTime twoHoursAgo = now.AddHours(-2);

            var result = await DeviceSensors
                .Where(e => e.Date >= twoHoursAgo && e.Date <= now)
                .GroupBy(e => e.NameAtribut)
                .Select(g => new SensorDataStats
                {
                    NameAtribut = g.Key,
                    MinValue = g.Min(e => e.sensorValues),
                    MaxValue = g.Max(e => e.sensorValues),
                    AverageValue = g.Average(e => e.sensorValues)
                })
                .ToDictionaryAsync(stats => stats.NameAtribut, stats => stats);

            return result;
        }

    }
}