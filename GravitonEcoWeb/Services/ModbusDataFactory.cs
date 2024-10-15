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
                 IHttpContextAccessor httpContextAccessor)  // Добавляем IHttpContextAccessor
        {
            _modbusService = modbusService;
            _env = env;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;  // Инициализируем httpContextAccessor
            _groupStates = new Dictionary<string, bool>();
            LoadConfig();
            LoadGroupStates();
        }

        // Метод для загрузки состояния групп из сессии
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
                _groupStates = new Dictionary<string, bool>();
                foreach (var config in _configParameters)
                {
                    if (!_groupStates.ContainsKey(config.Group))
                    {
                        _groupStates[config.Group] = false; // Все группы по умолчанию свернуты
                    }
                }
            }
        }

        // Загрузка файла конфигурации
        private void LoadConfig()
        {
            var configPath = Path.Combine(_env.WebRootPath, "config", "modbusConfig.json");

            try
            {
                _logger.LogInformation("Загрузка конфигурации из {ConfigPath}", configPath);
                var configJson = File.ReadAllText(configPath);
                _configParameters = JsonSerializer.Deserialize<List<ModbusConfigParameter>>(configJson);

                // По умолчанию все группы свернуты
                foreach (var config in _configParameters)
                {
                    if (!_groupStates.ContainsKey(config.Group))
                    {
                        _groupStates[config.Group] = false; // Все группы по умолчанию свернуты
                    }
                }

                _logger.LogInformation("Конфигурация успешно загружена.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при загрузке конфигурации из {ConfigPath}", configPath);
            }
        }

        // Метод для загрузки конфигурации калибровки газоанализатора
        public List<CalibrationParameter> GetGasCalibrationParameters()
        {
            var parameters = new List<CalibrationParameter>();
            var configPath = Path.Combine(_env.WebRootPath, "config", "modbusColibrationGasConfig.json");

            try
            {
                // Загрузка конфигурации из файла
                var configJson = File.ReadAllText(configPath);
                var configParameters = JsonSerializer.Deserialize<List<CalibrationConfig>>(configJson);

                foreach (var config in configParameters)
                {
                    // Чтение значений с Modbus
                    var currentValue = _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress);
                    var settingZero = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.SettingZero);
                    var pgsConcentration = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.PGSConcentration);
                    var adcValue = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.ADCValue);
                    var calculatedZero = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.CalculatedZero);

                    // Добавление данных в список параметров
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

        // Получение параметров для развернутых групп
        public List<ModbusParameter> GetParametersForExpandedGroups()
        {
            var parameters = new List<ModbusParameter>();

            foreach (var config in _configParameters)
            {
                _logger.LogInformation("Проверка состояния группы {GroupName}", config.Group);

                if (_groupStates.TryGetValue(config.Group, out var isExpanded))
                {
                    _logger.LogInformation("Группа {GroupName} имеет состояние: {IsExpanded}", config.Group, isExpanded);
                }
                else
                {
                    _logger.LogWarning("Группа {GroupName} не найдена в _groupStates", config.Group);
                }

                if (_groupStates.TryGetValue(config.Group, out isExpanded) && isExpanded)
                {
                    try
                    {
                        _logger.LogInformation("Чтение данных для группы {GroupName}", config.Group);

                        // Считывание данных с Modbus
                        var currentValue = _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress);
                        var porog1 = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.Porog1Address);
                        var porog2 = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.Porog2Address);
                        var increment = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.IncrementAddress);
                        var period = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.PeriodAddress);
                        var alarmPorog1 = _modbusService.ReadDiscretRegisters(config.SlaveAddress, config.AlarmPorog1Address);
                        var alarmPorog2 = _modbusService.ReadDiscretRegisters(config.SlaveAddress, config.AlarmPorog2Address);
                        var alarmPorog3 = _modbusService.ReadDiscretRegisters(config.SlaveAddress, config.AlarmPorog3Address);

                        _logger.LogInformation("Успешное чтение данных для группы {GroupName}", config.Group);

                        // Добавляем данные в список
                        parameters.Add(new ModbusParameter
                        {
                            Name = config.Name,
                            Min = 0,  // Возможно, нужны реальные данные
                            Max = 0,  // Возможно, нужны реальные данные
                            Average = 0,  // Возможно, нужны реальные данные
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

                        _logger.LogInformation("Данные для группы {GroupName} успешно добавлены.", config.Group);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка при чтении данных для группы {GroupName}", config.Group);
                    }
                }
            }

            if (parameters.Count == 0)
            {
                _logger.LogWarning("Параметры не были добавлены для развернутых групп.");
            }

            return parameters;
        }


        // Метод для сохранения состояния групп в сессии
        private void SaveGroupStates()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.SetString("GroupStates", JsonSerializer.Serialize(_groupStates));
        }


        // Метод для переключения состояния группы (свернута/развернута)
        public void SetGroupState(string groupName, bool isExpanded)
        {
            if (_groupStates.ContainsKey(groupName))
            {
                _logger.LogInformation("Изменение состояния группы {GroupName} на {IsExpanded}", groupName, isExpanded);
                _groupStates[groupName] = isExpanded;
                SaveGroupStates();  // Сохраняем состояние в сессию
            }
            else
            {
                _logger.LogWarning("Группа {GroupName} не найдена для изменения состояния.", groupName);
            }
        }

        // Получение состояния всех групп
        public Dictionary<string, bool> GetGroupStates()
        {
            _logger.LogInformation("Получение состояния всех групп.");
            return _groupStates;
        }

        // Метод для записи значения в Modbus устройство
        public void WriteToDevice(string paramName, string fieldName, ushort value)
        {
            var parameter = _configParameters.FirstOrDefault(p => p.Name == paramName);
            if (parameter == null)
            {
                _logger.LogError("Параметр с именем {ParamName} не найден.", paramName);
                throw new ArgumentException($"Параметр с именем {paramName} не найден.");
            }

            // Получаем нужный адрес по имени поля и записываем значение
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
                _logger.LogInformation("Значение {Value} записано в поле {FieldName} для параметра {ParamName}.", value, fieldName, paramName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при записи значения {Value} в поле {FieldName} для параметра {ParamName}.", value, fieldName, paramName);
                throw;
            }
        }
    }
}
