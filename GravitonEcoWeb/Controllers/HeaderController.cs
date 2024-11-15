using GravitonEcoWeb.Services;
using GravitonEcoWeb.Services.Factorys;
using Microsoft.AspNetCore.Mvc;

namespace GravitonEcoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeaderController : Controller
    {
        private readonly ModbusService _modbusService;
        private readonly StatisticsService _statisticsService;
        private readonly ILogger<HeaderController> _logger;
        private readonly VersionService _versionService;

        public HeaderController(ModbusService modbusService, StatisticsService statisticsService, VersionService versionService, ILogger<HeaderController> logger)
        {
            _modbusService = modbusService;
            _statisticsService = statisticsService;
            _logger = logger;
            _versionService = versionService;
        }

        [HttpGet("check-connection")]
        public IActionResult CheckConnection()
        {
            bool isConnected = _modbusService.CheckConnection();
            return Ok(isConnected);
        }

        [HttpGet("check-internet-connection")]
        public IActionResult CheckInternetConnection()
        {
            bool isConnected = _modbusService.CheckInternetConnection();
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

        [HttpGet("get-device-pincode")]
        public async Task<IActionResult> GetDevicePincode()
        {
            var pincode = await _modbusService.GetDevicePincodeAsync();
            return Ok(pincode);
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

        [HttpGet("get-polling-period")]
        public IActionResult GetPollingPeriod()
        {
            var interval = _statisticsService.GetPollingPeriodSelector();
            return Ok(interval);
        }

        [HttpPost("set-polling-period")]
        public IActionResult SetPollingPeriod([FromBody] PeriodRequest request)
        {
            try
            {
                _statisticsService.SetPollingInterval(request.Period);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка установки периода опроса");
                return BadRequest("Ошибка при изменении периода опроса");
            }
        }

        [HttpGet("get-device-versionprogram")]
        public IActionResult GetDeviceVersionProgram()
        {
            var versionProgramm = _versionService.GetProgramVersion();
            return Ok(versionProgramm);
        }

        [HttpGet("get-checksumm-programm")]
        public IActionResult GetCheckSummProgram()
        {
            var checksummProgramm = _versionService.GetChecksum();
            return Ok(checksummProgramm);
        }

    }

    public class PollingIntervalRequest
    {
        public int IntervalInSeconds { get; set; }
    }

    public class PeriodRequest
    {
        public string Period { get; set; }
    }

}
