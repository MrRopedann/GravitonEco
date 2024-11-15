using GravitonEcoWEBmvc.Services.BackgroundServices;
using GravitonEcoWEBmvc.Services.DataBase;
using GravitonEcoWEBmvc.Services.ModbusTCP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GravitonEcoWEBmvc.Controllers.Device
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModbusController : ControllerBase
    {
        private readonly ModbusTCPServices _modbusService;
        private readonly ModbusBackgroundService _modbusBackgroundService;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<ModbusController> _logger;

        public ModbusController(ModbusBackgroundService modbusBackgroundService, ModbusTCPServices modbusService, IServiceScopeFactory scopeFactory, ILogger<ModbusController> logger)
        {
            _modbusBackgroundService = modbusBackgroundService;
            _modbusService = modbusService;
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        [HttpGet("read-porog-parameters")]
        public async Task<IActionResult> ReadPorogParameters()
        {
            var porogParameters = await _modbusBackgroundService.ReadPorogParametersAsync();
            return Ok(porogParameters);
        }

        [HttpGet("read-calibration-parameters")]
        public async Task<IActionResult> ReadCalibrationParameters()
        {
            var calibrationParameters = await _modbusBackgroundService.ReadCalibrationParametersAsync();
            return Ok(calibrationParameters);
        }

        [HttpPost("update-alarm-polling-status")]
        public IActionResult UpdateAlarmPollingStatus([FromBody] bool isEnabled)
        {
            _modbusBackgroundService.UpdateAlarmPollingStatus(isEnabled);
            return Ok();
        }

        [HttpPost("write-parameter")]
        public IActionResult WriteParameter([FromBody] WriteParameterRequest request)
        {
            try
            {
                // Получаем адрес Modbus для указанного параметра и поля
                var modbusAddress = GetModbusAddressForField(request.Id, request.Field);

                if (modbusAddress.HasValue)
                {
                    // Записываем значение в Modbus, передавая addresDevise, registerAddress и значение
                    _modbusService.WriteSingleRegister(
                        modbusAddress.Value.SlaveAddress,
                        modbusAddress.Value.RegisterAddress,
                        (ushort)request.Value
                    );
                }
                else
                {
                    _logger.LogWarning($"Не удалось получить адрес Modbus для параметра Id={request.Id} и поля '{request.Field}'. Проверьте настройки и конфигурацию.");
                    return BadRequest($"Не удалось получить адрес Modbus для параметра Id={request.Id} и поля '{request.Field}'.");
                }

                return Ok(); // Возвращаем статус успешного выполнения
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при записи в Modbus.");
                return StatusCode(500, "Ошибка при записи значения в Modbus.");
            }
        }

        private (byte SlaveAddress, ushort RegisterAddress)? GetModbusAddressForField(int paramId, string field)
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<SqliteDbContext>();

            // Загружаем параметр с нужными адресами регистров и калибровочными данными
            var parameter = dbContext.ModbusParametrs
                .Include(p => p.Group)
                .Include(p => p.CalibrationGroup)
                .FirstOrDefault(p => p.Id == paramId);

            if (parameter != null)
            {
                // Определение адреса и регистра для различных полей
                return field switch
                {
                    // Основные параметры устройства
                    "CurrentValue" => ((byte)parameter.DeviceAddress, (ushort)parameter.RegisterCurrentValue),
                    "Porog1Value" => ((byte)parameter.DeviceAddress, (ushort)parameter.RegisterPorog1),
                    "Porog2Value" => ((byte)parameter.DeviceAddress, (ushort)parameter.RegisterPorog2),
                    "IncrementValue" => ((byte)parameter.DeviceAddress, (ushort)parameter.RegisterIncrement),
                    "PeriodValue" => ((byte)parameter.DeviceAddress, (ushort)parameter.RegisterPeriod),

                    // Калибровочные параметры (если параметр является калибровочным)
                    "CalibrationSettingZero" when parameter.CalibrationGroupId.HasValue =>
                        ((byte)parameter.DeviceAddress, (ushort)parameter.RegisterOffset),
                    "CalibrationPGSConcentration" when parameter.CalibrationGroupId.HasValue =>
                        ((byte)parameter.DeviceAddress, (ushort)parameter.RegisterConstant),
                    "CalibrationADCValue" when parameter.CalibrationGroupId.HasValue =>
                        ((byte)parameter.DeviceAddress, (ushort)parameter.RegisterValue),
                    "CalibrationCalculatedZero" when parameter.CalibrationGroupId.HasValue =>
                        ((byte)parameter.DeviceAddress, (ushort)parameter.RegisterCalibrationPeriod),

                    _ => null
                };
            }

            _logger.LogWarning($"Параметр с Id={paramId} не найден в базе данных.");
            return null;
        }
    }


        public class WriteParameterRequest
    {
        public int Id { get; set; }
        public string Field { get; set; }
        public int Value { get; set; }
    }
}
