using GravitonEcoWEBmvc.Models.DataBaseModel;
using GravitonEcoWEBmvc.Services.DataBase;
using GravitonEcoWEBmvc.Services.ModbusTCP;
using GravitonEcoWEBmvc.Services.SignalR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace GravitonEcoWEBmvc.Services.BackgroundServices
{
    public class ModbusBackgroundService : BackgroundService
    {
        private readonly ILogger<ModbusBackgroundService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ModbusTCPServices _modbusService;
        private readonly IHubContext<DeviceHub> _hubContext;
        private readonly TimeSpan _pollingInterval = TimeSpan.FromSeconds(5); // Интервал опроса
        private List<DeviceModel> _devices = new List<DeviceModel>();
        private bool _isAlarmPollingEnabled = false;

        public ModbusBackgroundService(ILogger<ModbusBackgroundService> logger, IServiceScopeFactory scopeFactory, ModbusTCPServices modbusService, IHubContext<DeviceHub> hubContext)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            _modbusService = modbusService;
            _hubContext = hubContext;
        }

        public void UpdateAlarmPollingStatus(bool isEnabled)
        {
            _isAlarmPollingEnabled = isEnabled;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<SqliteDbContext>();

                    // Обновляем текущее состояние устройств и значения Alarm (если включен AlarmPolling)
                    // Измените выполнение LINQ-запроса, чтобы извлечь данные из базы данных
                    _devices = dbContext.ModbusParametrs
                        .Include(param => param.Group)
                        .Include(param => param.CalibrationGroup)
                        .Select(param => new DeviceModel
                        {
                            Id = param.Id,
                            NameParametr = param.ParametrName,
                            GroupId = param.Group.Id,
                            DisplayFormat = param.Group.DisplayFormat,
                            GroupName = param.Group.GroupName,
                            CalibrationGroupId = param.CalibrationGroup != null ? param.CalibrationGroup.Id : 0,
                            CalibrationGroupName = param.CalibrationGroup != null ? param.CalibrationGroup.GroupName : null,
                            CurrentValue = _modbusService.ReadInputRegisters(
                                    (byte)param.DeviceAddress,
                                    (ushort)param.RegisterCurrentValue
                                  )[0],
                            Alarm1Value = false,
                            Alarm2Value = false,
                            Alarm3Value = false,
                            IsCalibration = param.IsCalibration,
                            CalibrationOffset = param.RegisterOffset ?? 0,
                            CalibrationConstant = param.RegisterConstant ?? 0,
                            CalibrationValue = param.RegisterValue ?? 0,
                        })
                        .ToList();


                    // Если включен AlarmPolling, обновляем значения Alarm
                    if (_isAlarmPollingEnabled)
                    {
                        foreach (var device in _devices)
                        {
                            var addressRegisters = dbContext.ModbusParametrs
                                .FirstOrDefault(param => param.Id == device.Id);

                            if (addressRegisters != null)
                            {
                                device.Alarm1Value = _modbusService.ReadDiscretRegisters(
                                    (byte)addressRegisters.DeviceAddress,
                                    (ushort)addressRegisters.RegisterAlarm1
                                )[0];

                                device.Alarm2Value = _modbusService.ReadDiscretRegisters(
                                    (byte)addressRegisters.DeviceAddress,
                                    (ushort)addressRegisters.RegisterAlarm2
                                )[0];

                                device.Alarm3Value = _modbusService.ReadDiscretRegisters(
                                    (byte)addressRegisters.DeviceAddress,
                                    (ushort)addressRegisters.RegisterAlarm3
                                )[0];
                            }
                        }
                    }

                    foreach (var device in _devices)
                    {
                        if (device.IsCalibration && device.CalibrationConstant != null)
                        {
                            device.CurrentValue = CalculateCalibrationValue(
                                device.CurrentValue,
                                device.CalibrationOffset,
                                device.CalibrationConstant,
                                device.CalibrationValue
                            );
                        }
                    }

                    // Отправляем обновленные данные клиентам через SignalR
                    await _hubContext.Clients.All.SendAsync("ReceiveDeviceUpdates", _devices);
                }

                await Task.Delay(_pollingInterval, stoppingToken);
            }
        }

        public double CalculateCalibrationValue(double currentValue, double settingZero, double pgsConcentration, double acpConcentration)
        {
            // Проверяем, чтобы не произошло деление на ноль
            if (pgsConcentration == 0)
            {
                throw new DivideByZeroException("Концентрация ПГС (Xгс) не может быть равна 0.");
            }

            double result = (currentValue - settingZero) / (acpConcentration / pgsConcentration);

            return result;
        }


        // Метод для чтения пороговых значений по запросу
        public async Task<List<DeviceModel>> ReadPorogParametersAsync()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SqliteDbContext>();

                // Считываем пороговые значения только по запросу
                var porogParameters = dbContext.ModbusParametrs
                    .Include(param => param.Group)
                    .Select(param => new DeviceModel
                    {
                        Id = param.Id,
                        NameParametr = param.ParametrName,
                        GroupId = param.Group.Id,
                        GroupName = param.Group.GroupName,
                        DisplayFormat = param.Group.DisplayFormat,
                        Porog1Value = _modbusService.ReadHoldingRegisters(
                            (byte)param.DeviceAddress,
                            (ushort)param.RegisterPorog1
                        )[0],
                        Porog2Value = _modbusService.ReadHoldingRegisters(
                            (byte)param.DeviceAddress,
                            (ushort)param.RegisterPorog2
                        )[0],
                        IncrementValue = _modbusService.ReadHoldingRegisters(
                            (byte)param.DeviceAddress,
                            (ushort)param.RegisterIncrement
                        )[0],
                        PeriodValue = _modbusService.ReadHoldingRegisters(
                            (byte)param.DeviceAddress,
                            (ushort)param.RegisterPeriod
                        )[0]
                    })
                    .ToList();

                return porogParameters;
            }
        }

        // Метод для чтения пороговых значений по запросу
        public async Task<List<DeviceModel>> ReadCalibrationParametersAsync()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SqliteDbContext>();

                var calibrationParameters = dbContext.ModbusParametrs
                    .Include(param => param.CalibrationGroup) // Подключение только к таблице групп
                    .Select(param => new DeviceModel
                    {
                        Id = param.Id,
                        NameParametr = param.ParametrName,
                        GroupId = param.GroupId,
                        CalibrationGroupId = param.CalibrationGroupId ?? 0,
                        GroupName = param.Group.GroupName,
                        CalibrationGroupName = param.CalibrationGroup.GroupName, // если есть связь с группой калибровки
                        DisplayFormat = param.Group.DisplayFormat,

                        // Чтение калибровочных параметров
                        CalibrationOffset = param.RegisterOffset.HasValue
                            ? _modbusService.ReadHoldingRegisters((byte)param.DeviceAddress, param.RegisterOffset.Value)[0]
                            : 0,

                        CalibrationConstant = param.RegisterConstant.HasValue
                            ? _modbusService.ReadHoldingRegisters((byte)param.DeviceAddress, param.RegisterConstant.Value)[0]
                            : 0,

                        CalibrationValue = param.RegisterValue.HasValue
                            ? _modbusService.ReadHoldingRegisters((byte)param.DeviceAddress, param.RegisterValue.Value)[0]
                            : 0,

                        CalibrationPeriod = param.RegisterCalibrationPeriod.HasValue
                            ? _modbusService.ReadHoldingRegisters((byte)param.DeviceAddress, param.RegisterCalibrationPeriod.Value)[0]
                            : 0
                    })
                    .ToList();

                return calibrationParameters;
            }
        }




        // Метод для получения текущего списка устройств
        public List<DeviceModel> GetDevices()
        {
            return _devices;
        }
    }
}
