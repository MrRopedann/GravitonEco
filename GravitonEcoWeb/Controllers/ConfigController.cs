using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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

        // Метод для сохранения конфигурации
        [HttpPost("save-config/{configName}")]
        public async Task<IActionResult> SaveConfig(string configName, [FromBody] JsonDocument jsonDocument)
        {
            var filePath = Path.Combine(_env.WebRootPath, "config", configName);

            try
            {
                var formattedJson = JsonSerializer.Serialize(jsonDocument, new JsonSerializerOptions { WriteIndented = true });
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