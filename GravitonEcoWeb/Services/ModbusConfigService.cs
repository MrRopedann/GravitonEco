using GravitonEcoWeb.Model;
using System.Text.Json;

namespace GravitonEcoWeb.Services
{
    public class ModbusConfigService
    {
        private readonly IWebHostEnvironment _env;
        public List<ModbusConfigParameter> ConfigParameters { get; private set; }

        public ModbusConfigService(IWebHostEnvironment env)
        {
            _env = env;
            LoadConfig();
        }

        private void LoadConfig()
        {
            var configPath = Path.Combine(_env.WebRootPath, "config", "modbusConfig.json");
            var configJson = File.ReadAllText(configPath);
            ConfigParameters = JsonSerializer.Deserialize<List<ModbusConfigParameter>>(configJson) ?? new List<ModbusConfigParameter>();
        }
    }
}
