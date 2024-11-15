using GravitonEcoWeb.Model;
using System.Text.Json;

namespace GravitonEcoWeb.Services.Factorys
{
    public class ModbusCalibrationFactory
    {
        private readonly ModbusService _modbusService;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<ModbusCalibrationFactory> _logger;
        private List<CalibrationConfig> _configCalibrationParameters;
        private Dictionary<string, bool> _groupStates;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ModbusCalibrationFactory(
           ModbusService modbusService,
           IWebHostEnvironment env,
           ILogger<ModbusCalibrationFactory> logger,
           IHttpContextAccessor httpContextAccessor) // Внедрение класса для расчетов
        {
            _modbusService = modbusService;
            _env = env;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _groupStates = new Dictionary<string, bool>();

            LoadConfig();
            if (_configCalibrationParameters != null && _configCalibrationParameters.Any())
            {
                LoadGroupStates();
            }
            else
            {
                _logger.LogWarning("Конфигурация параметров не была загружена, состояния групп не могут быть инициализированы.");
            }
        }

        // Загрузка файла конфигурации с проверкой типов данных
        private void LoadConfig()
        {
            var configCalibrationPath = Path.Combine(_env.WebRootPath, "config", "modbusColibrationGasConfig.json");

            try
            {
                _logger.LogInformation("Загрузка конфигурации калибровки газа из {ConfigPath}", configCalibrationPath);

                var configCalibrationJson = File.ReadAllText(configCalibrationPath);

                if (!string.IsNullOrEmpty(configCalibrationJson))
                {
                    _configCalibrationParameters = JsonSerializer.Deserialize<List<CalibrationConfig>>(configCalibrationJson);
                }

                if (_configCalibrationParameters == null || !_configCalibrationParameters.Any())
                {
                    _logger.LogWarning("Конфигурация калибровки газа пуста или не была загружена.");
                }

                foreach (var config in _configCalibrationParameters)
                {
                    config.SlaveAddress = (byte)ConvertToNumber(config.SlaveAddress.ToString());
                    config.CurrentValueAddress = ConvertToNumber(config.CurrentValueAddress.ToString());
                    config.SettingZero = ConvertToNumber(config.SettingZero.ToString());
                    config.PGSConcentration = ConvertToNumber(config.PGSConcentration.ToString());
                    config.ADCValue = ConvertToNumber(config.ADCValue.ToString());
                    config.CalculatedZero = ConvertToNumber(config.CalculatedZero.ToString());
                }

                _logger.LogInformation("Конфигурация успешно загружена.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при загрузке конфигурации.");
            }
        }

        private ushort ConvertToNumber(string input)
        {
            if (ushort.TryParse(input, out var result))
            {
                return result;
            }
            else
            {
                _logger.LogWarning($"Ошибка преобразования строки '{input}' в число. Устанавливается значение по умолчанию 0.");
                return 0;
            }
        }

        public CalibrationConfig GetConfigForGroup(string groupName)
        {
            return _configCalibrationParameters?.FirstOrDefault(config => config.Group == groupName);
        }

        private void LoadGroupStates()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var storedGroupStates = session.GetString("GroupCalibrationStates");

            if (!string.IsNullOrEmpty(storedGroupStates))
            {
                _groupStates = JsonSerializer.Deserialize<Dictionary<string, bool>>(storedGroupStates);
            }
            else
            {
                // Проверяем, что конфигурация успешно загружена перед доступом
                if (_configCalibrationParameters != null && _configCalibrationParameters.Any())
                {
                    _groupStates = new Dictionary<string, bool>();
                    foreach (var config in _configCalibrationParameters)
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

        private void SaveGroupCalibrationStates()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.SetString("GroupCalibrationStates", JsonSerializer.Serialize(_groupStates));
        }

        public void SetGroupCalibrationState(string groupName, bool IsExpandedCalibraton)
        {
            if (_groupStates.ContainsKey(groupName))
            {
                _groupStates[groupName] = IsExpandedCalibraton;
                SaveGroupCalibrationStates();
            }
            else
            {
                _logger.LogWarning($"Группа {groupName} не найдена");
            }
        }

        // Получение состояния всех групп
        public Dictionary<string, bool> GetGroupCalibrationStates()
        {
            return _groupStates;
        }

        public void WriteToCalibrationDevice(string paramName, string fieldName, ushort value)
        {
            var parameter = _configCalibrationParameters.FirstOrDefault(p => p.Name == paramName);
            if (parameter == null)
            {
                throw new ArgumentException($"Параметр с именем {paramName} не найден.");
            }

            ushort address = fieldName switch
            {
                "SettingZero" => parameter.SettingZero,
                "PGSConcentration" => parameter.PGSConcentration,
                "ADCValue" => parameter.ADCValue,
                "CalculatedZero" => parameter.CalculatedZero,
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


        public List<CalibrationParameter> GetCalibrationParametersGroups()
        {
            var parameters = new List<CalibrationParameter>();

            foreach (var config in _configCalibrationParameters)
            {
                if (_groupStates.TryGetValue(config.Group, out var isExpanded) && isExpanded)
                {
                    try
                    {
                        var currentValue = _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress);
                        if (currentValue.Length > 0)
                        {
                            _logger.LogInformation($"CurrentValue for {config.Name}: {currentValue[0]}");
                        }
                        else
                        {
                            _logger.LogWarning($"No data found for CurrentValue for {config.Name}");
                        }
                        _logger.LogInformation($"Adding parameter {config.Name}, CurrentValue: {currentValue[0]}");
                        var settingZero = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.SettingZero);
                        var pgsConcentration = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.PGSConcentration);
                        var adcValue = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.ADCValue);
                        var calculatedZero = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.CalculatedZero);

                        // Добавляем параметры в список
                        parameters.Add(new CalibrationParameter
                        {
                            Name = config.Name,
                            CurrentValue = currentValue[0],
                            SettingZero = settingZero[0],
                            PGSConcentration = pgsConcentration[0],
                            ADCValue = adcValue[0],
                            CalculatedZero = calculatedZero[0],
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
    }
}
