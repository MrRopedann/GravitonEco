using System.Text.Json;

namespace GravitonEcoWeb.Model.DataBaseModel
{
    public class DatabaseConfig
    {
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public string DbName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PeriodUpdate { get; set; }

        public static DatabaseConfig LoadDatabaseConfig()
        {
            var configPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/config/DataBaseConnection.json");
            var jsonString = File.ReadAllText(configPath);
            var databaseConfig = JsonSerializer.Deserialize<List<DatabaseConfig>>(jsonString)?.FirstOrDefault();
            return databaseConfig;
        }
    }
}
