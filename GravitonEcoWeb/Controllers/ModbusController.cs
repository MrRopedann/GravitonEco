using GravitonEcoWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace GravitonEcoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModbusController : ControllerBase
    {
        private readonly ModbusService _modbusService;

        public ModbusController(ModbusService modbusService)
        {
            _modbusService = modbusService;
        }

        [HttpGet("check-connection")]
        public IActionResult CheckConnection()
        {
            bool isConnected = _modbusService.CheckConnection();
            return Ok(isConnected);
        }

        // Добавляем метод для получения текущего времени с устройства
        [HttpGet("get-device-time")]
        public async Task<IActionResult> GetDeviceTime()
        {
            var dateTime = await _modbusService.GetDeviceDateTimeAsync();
            return Ok(dateTime);
        }

        [HttpGet("get-device-serialnumber")]
        public async Task<IActionResult> GetDeviceSerialNumber()
        {
            var serialNumber = await _modbusService.GetDeviceSerialNumberAsync();
            return Ok(serialNumber);
        }
    }
}
