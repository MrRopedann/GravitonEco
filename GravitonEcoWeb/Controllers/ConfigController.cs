using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using GravitonEcoWeb.Model;  // Убедитесь, что пространство имен правильное для ваших моделей

namespace GravitonEcoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public ConfigController(IWebHostEnvironment env)
        {
            _env = env;
        }

        // Метод для получения конфигурации
        [HttpGet("get-config/{configName}")]
        public async Task<IActionResult> GetConfig(string configName)
        {
            var filePath = Path.Combine(_env.WebRootPath, "config", configName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Конфигурационный файл не найден.");
            }

            var json = await System.IO.File.ReadAllTextAsync(filePath);
            return Ok(json);
        }

        // Метод для сохранения конфигурации для Modbus
        [HttpPost("save-config/modbusConfig.json")]
        public async Task<IActionResult> SaveModbusConfig([FromBody] List<ModbusConfigParameter> config)
        {
            var filePath = Path.Combine(_env.WebRootPath, "config", "modbusConfig.json");

            try
            {
                var formattedJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
                await System.IO.File.WriteAllTextAsync(filePath, formattedJson);
                return Ok("Конфигурация успешно сохранена.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка при сохранении файла: {ex.Message}");
            }
        }

        // Метод для сохранения конфигурации для Газовой Калибровки
        [HttpPost("save-config/modbusColibrationGasConfig.json")]
        public async Task<IActionResult> SaveGasConfig([FromBody] List<CalibrationConfig> config)
        {
            var filePath = Path.Combine(_env.WebRootPath, "config", "modbusColibrationGasConfig.json");

            try
            {
                var formattedJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
                await System.IO.File.WriteAllTextAsync(filePath, formattedJson);
                return Ok("Конфигурация успешно сохранена.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка при сохранении файла: {ex.Message}");
            }
        }
    }
}
