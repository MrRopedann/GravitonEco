using GravitonEcoWeb.Model;
using System.Text.Json;

namespace GravitonEcoWeb.Services.Factorys
{
    public class ModbusDataFactory
    {
        private readonly ModbusService _modbusService;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<ModbusDataFactory> _logger;
        private List<ModbusConfigParameter> _configParameters;
        private List<CalibrationConfig> _configCalibrationParameters;
        private List<ConvertationGasConfig> _configConvertationParameters;
        private readonly CalibrationCalculator _calibrationCalculator;
        private Dictionary<string, bool> _groupStates;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly StatisticsService _statisticsService;
        const int TaskDeleyModbus = 500;


        public ModbusDataFactory(
            ModbusService modbusService,
            IWebHostEnvironment env,
            ILogger<ModbusDataFactory> logger,
            IHttpContextAccessor httpContextAccessor,
            CalibrationCalculator calibrationCalculator,
            StatisticsService statisticsService) // Внедрение класса для расчетов
        {
            _modbusService = modbusService;
            _env = env;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _calibrationCalculator = calibrationCalculator;
            _groupStates = new Dictionary<string, bool>();
            _statisticsService = statisticsService;

            LoadConfig();
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
            var configCalibrationPath = Path.Combine(_env.WebRootPath, "config", "modbusColibrationGasConfig.json");
            var configConvertationPath = Path.Combine(_env.WebRootPath, "config", "GasConvertationMolarMas.json");

            try
            {
                _logger.LogInformation("Загрузка конфигурации Modbus из {ConfigPath}", configPath);
                var configJson = File.ReadAllText(configPath);
                var configCalibrationJson = File.ReadAllText(configCalibrationPath);
                var configConvertationJson = File.ReadAllText(configConvertationPath);

                if (!string.IsNullOrEmpty(configJson))
                {
                    _configParameters = JsonSerializer.Deserialize<List<ModbusConfigParameter>>(configJson);
                    _configCalibrationParameters = JsonSerializer.Deserialize<List<CalibrationConfig>>(configCalibrationJson);
                    _configConvertationParameters = JsonSerializer.Deserialize<List<ConvertationGasConfig>>(configConvertationJson);
                }

                if (_configParameters == null || !_configParameters.Any())
                {
                    _logger.LogWarning("Конфигурация Modbus пуста или не была загружена.");
                }

                // Преобразуем строковые значения в числа
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

                foreach (var config in _configCalibrationParameters)
                {
                    config.SlaveAddress = (byte)ConvertToNumber(config.SlaveAddress.ToString());
                    config.CurrentValueAddress = ConvertToNumber(config.CurrentValueAddress.ToString());
                    config.SettingZero = ConvertToNumber(config.SettingZero.ToString());
                    config.PGSConcentration = ConvertToNumber(config.PGSConcentration.ToString());
                    config.ADCValue = ConvertToNumber(config.ADCValue.ToString());
                    config.CalculatedZero = ConvertToNumber(config.CalculatedZero.ToString());
                }

                foreach (var config in _configConvertationParameters)
                {
                    config.Name = config.Name;
                    config.MolarMasses = config.MolarMasses;
                }

                _logger.LogInformation("Конфигурация успешно загружена.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при загрузке конфигурации.");
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

        public List<ModbusParameter> GetParametersForExpandedGroups()
        {
            var parameters = new List<ModbusParameter>();

            foreach (var config in _configParameters)
            {
                if (_groupStates.TryGetValue(config.Group, out var isExpanded) && isExpanded)
                {
                    try
                    {
                        double currentValue;
                        switch (config.Id)
                        {
                            case 1:
                                currentValue = GetCurrentValue(config) / 10;
                                break;
                            case 2:
                                currentValue = GetCurrentValue(config) / 10;
                                break;
                            case 3:
                                currentValue = GetCurrentValue(config) / 10;
                                break;
                            case 19:
                                currentValue = GetCurrentValue(config) / 10;
                                break;
                            case 20:
                                currentValue = GetCurrentValue(config) / 10;
                                break;
                            default:
                                currentValue = GetCurrentValue(config);
                                break;
                        }
                        var otherParameters = GetOtherParameters(config);
                        double min = _statisticsService.CalculateMinForLastHour(config.Id);
                        double max = _statisticsService.CalculateMaxForLastHour(config.Id);
                        double average = Math.Round(_statisticsService.CalculateAverageForLastHour(config.Id), 2);


                        parameters.Add(new ModbusParameter
                        {
                            Name = config.Name,
                            Min = min,
                            Max = max,
                            Average = average,
                            Current = currentValue,
                            Threshold1 = otherParameters.Threshold1,
                            Threshold2 = otherParameters.Threshold2,
                            Growth = otherParameters.Growth,
                            Period = otherParameters.Period,
                            AlarmPorog1 = otherParameters.AlarmPorog1,
                            AlarmPorog2 = otherParameters.AlarmPorog2,
                            AlarmPorog3 = otherParameters.AlarmPorog3,
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

        private double GetCurrentValue(ModbusConfigParameter config)
        {
            if (config.IsCalibration)
            {
                return GetCalibratedValue(config);
            }
            else if (config.ConverGasType != null)
            {
                return GetConvertedGasValue(config);
            }
            else
            {
                // Если калибровка и конвертация не требуются, читаем текущее значение напрямую
                return _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress)[0];
            }
        }

        private double GetCalibratedValue(ModbusConfigParameter config)
        {
            var calibrationConfig = _configCalibrationParameters.FirstOrDefault(c => c.ModbusDeviseID == config.Id);
            if (calibrationConfig == null)
            {
                _logger.LogWarning($"Конфигурация калибровки для устройства с ID {config.Id} не найдена");
                return 0; // Значение по умолчанию, если конфигурация не найдена
            }

            double currentValue = _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress)[0];
            var settingZero = _modbusService.ReadHoldingRegisters(calibrationConfig.SlaveAddress, calibrationConfig.SettingZero)[0];
            var pgsConcentration = _modbusService.ReadHoldingRegisters(calibrationConfig.SlaveAddress, calibrationConfig.PGSConcentration)[0];
            var acpConcentration = _modbusService.ReadHoldingRegisters(calibrationConfig.SlaveAddress, calibrationConfig.ADCValue)[0];

            // Пересчитываем значение с использованием новой формулы CalibrationCalculator
            return Math.Round(_calibrationCalculator.CalculateCalibrationValue(currentValue, settingZero, pgsConcentration, acpConcentration), 2);
        }

        private double GetConvertedGasValue(ModbusConfigParameter config)
        {
            // Проверяем, активирована ли конвертация для группы "Газоанализатор"
            bool requireConversion = ShouldConvertGas(config);

            if (!requireConversion)
            {
                _logger.LogInformation($"Конвертация для газа с ID {config.Id} не требуется. Используется прямое значение.");
                return _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress)[0];
            }

            var gasConfig = _configConvertationParameters.FirstOrDefault(g => g.ModbusDeviseID == config.Id);

            if (gasConfig == null)
            {
                _logger.LogWarning($"Тип газа для устройства с ID {config.Id} не найден в конфигурации. Используется прямое значение без конвертации.");
                return _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress)[0];
            }

            var calibrationConfig = _configCalibrationParameters.FirstOrDefault(c => c.ModbusDeviseID == 0);
            if (calibrationConfig == null)
            {
                _logger.LogWarning($"Конфигурация калибровки для устройства с ID {config.Id} не найдена.");
                return _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress)[0];
            }

            var temperature = _modbusService.ReadHoldingRegisters(calibrationConfig.SlaveAddress, calibrationConfig.PGSConcentration)[0];
            var concentration = _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress)[0];

            _logger.LogInformation($"Расчет для газа {gasConfig.Name} с молекулярной массой {gasConfig.MolarMasses}, концентрацией {concentration} и температурой {temperature}");

            return Math.Round(_calibrationCalculator.CalculateMolarWeight(concentration, gasConfig.MolarMasses, temperature), 2);
        }

        // Метод для проверки необходимости конвертации
        private bool ShouldConvertGas(ModbusConfigParameter config)
        {
            string conversionSetting = _httpContextAccessor.HttpContext.Session.GetString("convertToMolarMass") ?? "false";
            bool convertToMolarMass = bool.Parse(conversionSetting);

            return config.Group == "Газоанализатор" && convertToMolarMass;
        }





        private (int Threshold1, int Threshold2, int Growth, int Period, bool AlarmPorog1, bool AlarmPorog2, bool AlarmPorog3) GetOtherParameters(ModbusConfigParameter config)
        {
            var porog1 = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.Porog1Address)[0];
            var porog2 = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.Porog2Address)[0];
            var increment = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.IncrementAddress)[0];
            var period = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.PeriodAddress)[0];
            var alarmPorog1 = _modbusService.ReadDiscretRegisters(config.SlaveAddress, config.AlarmPorog1Address)[0];
            var alarmPorog2 = _modbusService.ReadDiscretRegisters(config.SlaveAddress, config.AlarmPorog2Address)[0];
            var alarmPorog3 = _modbusService.ReadDiscretRegisters(config.SlaveAddress, config.AlarmPorog3Address)[0];

            return (porog1, porog2, increment, period, alarmPorog1, alarmPorog2, alarmPorog3);
        }



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
