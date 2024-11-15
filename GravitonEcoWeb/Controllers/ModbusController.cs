using GravitonEcoWeb.Services;
using GravitonEcoWeb.Services.Factorys;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Единственный конструктор, принимающий все зависимости
        public ModbusController(ModbusService modbusService, ModbusDataFactory modbusDataFactory, ILogger<ModbusController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _modbusService = modbusService;
            _modbusDataFactory = modbusDataFactory;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
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
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при изменении состояния группы {request.GroupName}");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpPost("set-molar-mass-conversion")]
        public IActionResult SetMolarMassConversion([FromBody] MolarMassConversionRequest request)
        {
            try
            {
                _httpContextAccessor.HttpContext.Session.SetString("convertToMolarMass", request.ShouldConvert.ToString());
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при установке флага конвертации молярной массы");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
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

    public class MolarMassConversionRequest
    {
        public bool ShouldConvert { get; set; }
    }
}
