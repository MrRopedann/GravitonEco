using GravitonEco.Models;
using System.IO;
using System.Text.Json;

namespace GravitonEco.Managers
{
    public static class ConfigManager
    {
        private static readonly string AppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GravitonEco", "Settings");
        private static readonly string ConfigFilePath = Path.Combine(AppDataFolder, "SensorSetting.json");
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true // Для форматирования JSON с отступами
        };

        static ConfigManager()
        {
            // Убедитесь, что директория существует
            Directory.CreateDirectory(AppDataFolder);
        }

        public static DeviceConfig LoadConfig()
        {
            if (!File.Exists(ConfigFilePath))
            {
                return new DeviceConfig(); // Вернуть пустую конфигурацию, если файла не существует
            }

            var json = File.ReadAllText(ConfigFilePath);
            return JsonSerializer.Deserialize<DeviceConfig>(json);
        }

        public static void SaveConfig(DeviceConfig config)
        {
            var json = JsonSerializer.Serialize(config, JsonOptions);
            File.WriteAllText(ConfigFilePath, json);
        }
    }
}

