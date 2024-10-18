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

        // Конструктор с внедрением всех зависимостей
        public ModbusController(ModbusService modbusService, ModbusDataFactory modbusDataFactory, ILogger<ModbusController> logger)
        {
            _modbusService = modbusService;
            _modbusDataFactory = modbusDataFactory;
            _logger = logger;
        }

        [HttpGet("check-connection")]
        public IActionResult CheckConnection()
        {
            bool isConnected = _modbusService.CheckConnection();
            return Ok(isConnected);
        }

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

        [HttpGet("get-calibration-parameters")]
        public IActionResult GetGasCalibrationParameters()
        {
            try
            {
                var calibrationParametersGrouped = _modbusDataFactory.GetGasCalibrationParametersGrouped();
                return Ok(calibrationParametersGrouped);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения параметров калибровки");
                return StatusCode(500, "Ошибка при получении параметров калибровки");
            }
        }

        [HttpPost("write")]
        public IActionResult WriteModbusValue([FromBody] ModbusWriteRequest request)
        {
            try
            {
                ushort value = ushort.Parse(request.Value);
                _modbusDataFactory.WriteToDevice(request.ParamName, request.FieldName, value);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка записи Modbus");
                return BadRequest($"Ошибка записи: {ex.Message}");
            }
        }

        [HttpPost("write-calibration-gas")]
        public IActionResult WriteModbusCalibrationGasValue([FromBody] ModbusWriteRequest request)
        {
            try
            {
                ushort value = ushort.Parse(request.Value);
                _modbusDataFactory.WriteToCalibrationGasDevice(request.ParamName, request.FieldName, value);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка записи параметров калибровки");
                return BadRequest($"Ошибка записи: {ex.Message}");
            }
        }

        [HttpPost("toggle-group")]
        public IActionResult ToggleGroup([FromBody] ToggleGroupRequest request)
        {
            try
            {
                _modbusDataFactory.SetGroupState(request.GroupName, request.IsExpanded);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при изменении состояния группы {request.GroupName}");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpGet("get-polling-interval")]
        public IActionResult GetPollingInterval()
        {
            var interval = _modbusService.GetPollingInterval();
            return Ok(interval);
        }

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


    }

    public class PollingIntervalRequest
    {
        public int IntervalInSeconds { get; set; }
    }

    public class ModbusWriteRequest
    {
        public string ParamName { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }
    }

    public class ToggleGroupRequest
    {
        public string GroupName { get; set; }
        public bool IsExpanded { get; set; }
    }
}
