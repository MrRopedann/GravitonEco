using GravitonEcoWeb.Model;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace GravitonEcoWeb.Services
{
    public class ModbusDataFactory
    {
        private readonly ModbusService _modbusService;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<ModbusDataFactory> _logger;
        private List<ModbusConfigParameter> _configParameters;
        private Dictionary<string, bool> _groupStates;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ModbusDataFactory(
         ModbusService modbusService,
         IWebHostEnvironment env,
         ILogger<ModbusDataFactory> logger,
         IHttpContextAccessor httpContextAccessor)
        {
            _modbusService = modbusService;
            _env = env;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _groupStates = new Dictionary<string, bool>();

            // Загрузка конфигурации должна быть первой
            LoadConfig();

            // Только после загрузки конфигурации загружаем состояния групп
            if (_configParameters != null && _configParameters.Any())
            {
                LoadGroupStates();
            }
            else
            {
                _logger.LogWarning("Конфигурация параметров не была загружена, состояния групп не могут быть инициализированы.");
            }
        }

        private void LoadGroupStates()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var storedGroupStates = session.GetString("GroupStates");

            if (!string.IsNullOrEmpty(storedGroupStates))
            {
                _groupStates = JsonSerializer.Deserialize<Dictionary<string, bool>>(storedGroupStates);
            }
            else
            {
                // Проверяем, что конфигурация успешно загружена перед доступом
                if (_configParameters != null && _configParameters.Any())
                {
                    _groupStates = new Dictionary<string, bool>();
                    foreach (var config in _configParameters)
                    {
                        if (!_groupStates.ContainsKey(config.Group))
                        {
                            _groupStates[config.Group] = false; // Все группы по умолчанию свернуты
                        }
                    }
                }
                else
                {
                    _logger.LogWarning("Конфигурация параметров пуста, состояния групп не могут быть инициализированы.");
                }
            }
        }


        // Загрузка файла конфигурации с проверкой типов данных
        private void LoadConfig()
        {
            var configPath = Path.Combine(_env.WebRootPath, "config", "modbusConfig.json");

            try
            {
                _logger.LogInformation("Загрузка конфигурации из {ConfigPath}", configPath);
                var configJson = File.ReadAllText(configPath);

                if (!string.IsNullOrEmpty(configJson))
                {
                    _configParameters = JsonSerializer.Deserialize<List<ModbusConfigParameter>>(configJson);
                }

                if (_configParameters == null || !_configParameters.Any())
                {
                    _logger.LogWarning("Конфигурация пуста или не была загружена. Проверьте файл конфигурации.");
                }
                else
                {
                    // Преобразуем строковые значения в числа, если это нужно
                    foreach (var config in _configParameters)
                    {
                        config.SlaveAddress = (byte)ConvertToNumber(config.SlaveAddress.ToString());
                        config.CurrentValueAddress = ConvertToNumber(config.CurrentValueAddress.ToString());
                        config.Porog1Address = ConvertToNumber(config.Porog1Address.ToString());
                        config.Porog2Address = ConvertToNumber(config.Porog2Address.ToString());
                        config.IncrementAddress = ConvertToNumber(config.IncrementAddress.ToString());
                        config.PeriodAddress = ConvertToNumber(config.PeriodAddress.ToString());
                        config.AlarmPorog1Address = ConvertToNumber(config.AlarmPorog1Address.ToString());
                        config.AlarmPorog2Address = ConvertToNumber(config.AlarmPorog2Address.ToString());
                        config.AlarmPorog3Address = ConvertToNumber(config.AlarmPorog3Address.ToString());
                    }

                    _logger.LogInformation("Конфигурация успешно загружена.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при загрузке конфигурации из {ConfigPath}", configPath);
            }
        }

        // Преобразование строкового значения в число (ushort)
        private ushort ConvertToNumber(string input)
        {
            if (ushort.TryParse(input, out var result))
            {
                return result;
            }
            else
            {
                _logger.LogWarning($"Ошибка преобразования строки '{input}' в число. Устанавливается значение по умолчанию 0.");
                return 0; // Значение по умолчанию
            }
        }

        // Метод для загрузки конфигурации калибровки газоанализатора
        public List<CalibrationParameter> GetGasCalibrationParameters()
        {
            var parameters = new List<CalibrationParameter>();
            var configPath = Path.Combine(_env.WebRootPath, "config", "modbusColibrationGasConfig.json");

            try
            {
                var configJson = File.ReadAllText(configPath);
                var configParameters = JsonSerializer.Deserialize<List<CalibrationConfig>>(configJson);

                foreach (var config in configParameters)
                {
                    var currentValue = _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress);
                    var settingZero = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.SettingZero);
                    var pgsConcentration = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.PGSConcentration);
                    var adcValue = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.ADCValue);
                    var calculatedZero = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.CalculatedZero);

                    parameters.Add(new CalibrationParameter
                    {
                        Name = config.Name,
                        CurrentValue = currentValue[0],
                        SettingZero = settingZero[0],
                        PGSConcentration = pgsConcentration[0],
                        ADCValue = adcValue[0],
                        CalculatedZero = calculatedZero[0]
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при загрузке конфигурации калибровки газоанализатора");
            }

            return parameters;
        }

        // Метод для получения параметров для развернутых групп
        public List<ModbusParameter> GetParametersForExpandedGroups()
        {
            var parameters = new List<ModbusParameter>();

            foreach (var config in _configParameters)
            {
                if (_groupStates.TryGetValue(config.Group, out var isExpanded) && isExpanded)
                {
                    try
                    {
                        var currentValue = _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress);
                        var porog1 = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.Porog1Address);
                        var porog2 = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.Porog2Address);
                        var increment = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.IncrementAddress);
                        var period = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.PeriodAddress);
                        var alarmPorog1 = _modbusService.ReadDiscretRegisters(config.SlaveAddress, config.AlarmPorog1Address);
                        var alarmPorog2 = _modbusService.ReadDiscretRegisters(config.SlaveAddress, config.AlarmPorog2Address);
                        var alarmPorog3 = _modbusService.ReadDiscretRegisters(config.SlaveAddress, config.AlarmPorog3Address);

                        parameters.Add(new ModbusParameter
                        {
                            Name = config.Name,
                            Min = 0,
                            Max = 0,
                            Average = 0,
                            Current = currentValue[0],
                            Threshold1 = porog1[0],
                            Threshold2 = porog2[0],
                            Growth = increment[0],
                            Period = period[0],
                            AlarmPorog1 = alarmPorog1[0],
                            AlarmPorog2 = alarmPorog2[0],
                            AlarmPorog3 = alarmPorog3[0],
                            Group = config.Group
                        });
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Ошибка при чтении данных для группы {config.Group}");
                    }
                }
            }

            return parameters;
        }

        // Метод для сохранения состояния групп
        private void SaveGroupStates()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.SetString("GroupStates", JsonSerializer.Serialize(_groupStates));
        }

        // Метод для изменения состояния группы
        public void SetGroupState(string groupName, bool isExpanded)
        {
            if (_groupStates.ContainsKey(groupName))
            {
                _groupStates[groupName] = isExpanded;
                SaveGroupStates();
            }
            else
            {
                _logger.LogWarning($"Группа {groupName} не найдена");
            }
        }

        // Получение состояния всех групп
        public Dictionary<string, bool> GetGroupStates()
        {
            return _groupStates;
        }

        // Метод для записи значения в Modbus устройство
        public void WriteToDevice(string paramName, string fieldName, ushort value)
        {
            var parameter = _configParameters.FirstOrDefault(p => p.Name == paramName);
            if (parameter == null)
            {
                throw new ArgumentException($"Параметр с именем {paramName} не найден.");
            }

            ushort address = fieldName switch
            {
                "Threshold1" => parameter.Porog1Address,
                "Threshold2" => parameter.Porog2Address,
                "Growth" => parameter.IncrementAddress,
                "Period" => parameter.PeriodAddress,
                _ => throw new ArgumentException($"Поле {fieldName} не найдено.")
            };

            try
            {
                _modbusService.WriteSingleRegister(parameter.SlaveAddress, address, value);
                _logger.LogInformation($"Значение {value} записано в поле {fieldName} для параметра {paramName}.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при записи значения {value} в поле {fieldName} для параметра {paramName}.");
                throw;
            }
        }
    }
}
