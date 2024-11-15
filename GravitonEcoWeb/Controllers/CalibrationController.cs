using GravitonEcoWeb.Services;
using GravitonEcoWeb.Services.Factorys;
using Microsoft.AspNetCore.Mvc;

namespace GravitonEcoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalibrationController : ControllerBase
    {
        private readonly ModbusService _modbusService;
        private readonly ModbusCalibrationFactory _modbusCalibrationFactory;
        private readonly ILogger<ModbusController> _logger;

        public CalibrationController(ModbusService modbusService, ModbusCalibrationFactory modbusCalibrationFactory, ILogger<ModbusController> logger)
        {
            _modbusService = modbusService;
            _modbusCalibrationFactory = modbusCalibrationFactory;
            _logger = logger;
        }

        [HttpPost("write-calibration-parametr")]
        public IActionResult WriteModbusCalibrationValue([FromBody] ModbusCalibrationWriteRequest request)
        {
            try
            {
                ushort value = ushort.Parse(request.Value);
                _modbusCalibrationFactory.WriteToCalibrationDevice(request.ParamName, request.FieldName, value);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка записи: {ex.Message}");
            }
        }

        [HttpGet("get-calibration-parameters")]
        public IActionResult GetParameters()
        {
            var parameters = _modbusCalibrationFactory.GetCalibrationParametersGroups();
            return Ok(parameters);
        }

        [HttpPost("toggle-calibration-group")]
        public IActionResult ToggleCalibrationGroup([FromBody] ToggleCalibrationGroupRequest request)
        {
            try
            {
                _modbusCalibrationFactory.SetGroupCalibrationState(request.GroupName, request.IsExpandedCalibraton);

                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при изменении состояния группы {request.GroupName}");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }

    public class ModbusCalibrationWriteRequest
    {
        public string ParamName { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }
    }

    public class ToggleCalibrationGroupRequest
    {
        public string GroupName { get; set; }
        public bool IsExpandedCalibraton { get; set; }
    }

    public class CorrectPincodeModbusDevise
    { 
        public bool IsCorrectPincode { get; set; }
    }
}
