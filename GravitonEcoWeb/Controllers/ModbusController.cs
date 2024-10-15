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
        private readonly ILogger<ModbusController> _logger;

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
            var parameters = _modbusDataFactory.GetParametersForExpandedGroups();
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
        [HttpPost("toggle-group")]
        public IActionResult ToggleGroup([FromBody] ToggleGroupRequest request)
        {
            try
            {
                _modbusDataFactory.SetGroupState(request.GroupName, request.IsExpanded);

                // Возвращаем корректный ответ в формате JSON
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при изменении состояния группы {GroupName}", request.GroupName);
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        // Метод для получения текущего интервала опроса
        [HttpGet("get-polling-interval")]
        public IActionResult GetPollingInterval()
        {
            var interval = _modbusService.GetPollingInterval();
            return Ok(interval); // Возвращаем интервал в секундах
        }

        // Метод для установки нового интервала опроса
        [HttpPost("set-polling-interval")]
        public IActionResult SetPollingInterval([FromBody] PollingIntervalRequest request)
        {
            try
            {
                _modbusService.SetPollingInterval(request.IntervalInSeconds);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка установки интервала опроса");
                return BadRequest("Ошибка при изменении интервала опроса");
            }
        }

        [HttpGet("get-calibration-parameters")]
        public IActionResult GetGasCalibrationParameters()
        {
            var calibrationParameters = _modbusDataFactory.GetGasCalibrationParameters();
            return Ok(calibrationParameters);
        }
    }

    // Модель для приема данных из POST-запроса
    public class PollingIntervalRequest
    {
        public int IntervalInSeconds { get; set; } // Интервал опроса в секундах
    }
    // Модель для запроса записи
    public class ModbusWriteRequest
    {
        public string ParamName { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }
    }

    public class ToggleGroupRequest
    {
        public string GroupName { get; set; }  // Название группы
        public bool IsExpanded { get; set; }   // Состояние группы (развернута или свернута)
    }


}
