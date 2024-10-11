using GravitonEcoWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace GravitonEcoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModbusController : ControllerBase
    {
        private readonly ModbusService _modbusService;
        private readonly ModbusDataFactory _modbusDataFactory;

        public ModbusController(ModbusService modbusService, ModbusDataFactory modbusDataFactory )
        {
            _modbusService = modbusService;
            _modbusDataFactory = modbusDataFactory;
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

        [HttpGet("get-parameters")]
        public IActionResult GetParameters()
        {
            var parameters = _modbusDataFactory.GetParameters();
            return Ok(parameters);
        }

        [HttpPost("write")]
        public IActionResult WriteModbusValue([FromBody] ModbusWriteRequest request)
        {
            try
            {
                // Используем фабрику для записи значения в Modbus устройство
                ushort value = ushort.Parse(request.Value);
                _modbusDataFactory.WriteToDevice(request.ParamName, request.FieldName, value);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка записи: {ex.Message}");
            }
        }

    }
    // Модель для запроса записи
    public class ModbusWriteRequest
    {
        public string ParamName { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }
    }
}
