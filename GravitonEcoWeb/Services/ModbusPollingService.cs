using GravitonEcoWeb.Model.DataBaseModel;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GravitonEcoWeb.Services
{
    public class ModbusPollingService : BackgroundService
    {
        private readonly ModbusService _modbusService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ModbusPollingService> _logger;
        private readonly ModbusConfigService _configService;
        const bool IsReadDataBase = true;



        public ModbusPollingService(
            ModbusService modbusService,
            IServiceProvider serviceProvider,
            ILogger<ModbusPollingService> logger,
            ModbusConfigService configService)
        {
            _modbusService = modbusService;
            _serviceProvider = serviceProvider;
            _logger = logger;
            _configService = configService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await PollDeviceAndSaveDataAsync();
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken); // Пауза в 10 секунд
            }
        }

        private async Task PollDeviceAndSaveDataAsync()
        {
            if (IsReadDataBase)
            {

                using var scope = _serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<SqliteDbContext>();

                foreach (var config in _configService.ConfigParameters)
                {
                    try
                    {
                        double currentValue;
                        switch (config.Id)
                        {
                            case 1:
                                currentValue = _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress)[0] / 10.0;
                                break;
                            case 2:
                                currentValue = _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress)[0] / 10.0;
                                break;
                            case 3:
                                currentValue = _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress)[0] / 10.0;
                                break;
                            case 19:
                                currentValue = _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress)[0] / 10.0;
                                break;
                            case 20:
                                currentValue = _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress)[0] / 10.0;
                                break;
                            default:
                                currentValue = _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress)[0];
                                break;
                        }

                        string deviceDateTime = await _modbusService.GetDeviceDateTimeAsync();
                        var deviceData = new ModbusParametrModel
                        {
                            NameParametr = config.Name,
                            GlobalDateTime = DateTime.UtcNow.ToUniversalTime(),
                            DeviceDateTime = DateTime.Parse(deviceDateTime).ToUniversalTime(), // При необходимости изменить на фактическое устройство время
                            DeviceId = config.Id,
                            DeviceParametr = currentValue
                        };

                        dbContext.ModbusParameters.Add(deviceData);
                        await dbContext.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Ошибка при чтении данных для параметра {config.Name}");
                    }
                }
            }
        }
    }
}