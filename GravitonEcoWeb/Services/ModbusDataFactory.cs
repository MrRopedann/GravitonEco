using GravitonEcoWeb.Model;
using Microsoft.Extensions.Logging;
using System.Reflection.Metadata;
using System.Text.Json;

namespace GravitonEcoWeb.Services
{
    public class ModbusDataFactory
    {
        private readonly ModbusService _modbusService;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<ModbusDataFactory> _logger;
        private readonly CalibrationCalculator _calibrationCalculator; // Используем обобщенный калькулятор
        private List<ModbusConfigParameter> _configParameters;
        private List<CalibrationConfig> _configCalibrationGasParameters;
        private Dictionary<string, bool> _groupStates;
        private Dictionary<string, bool> _groupCalibrationStates;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ModbusDataFactory(
            ModbusService modbusService,
            IWebHostEnvironment env,
            ILogger<ModbusDataFactory> logger,
            IHttpContextAccessor httpContextAccessor,
            CalibrationCalculator calibrationCalculator) // Внедрение класса для расчетов
        {
            _modbusService = modbusService;
            _env = env;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _calibrationCalculator = calibrationCalculator; // Инициализация обобщенного калькулятора
            _groupStates = new Dictionary<string, bool>();
            _groupCalibrationStates = new Dictionary<string, bool>();

            LoadConfig();
            if (_configParameters != null && _configParameters.Any())
            {
                LoadGroupStates();
            }
            else
            {
                _logger.LogWarning("Конфигурация параметров не была загружена, состояния групп не могут быть инициализированы.");
            }

            if (_configCalibrationGasParameters != null && _configCalibrationGasParameters.Any())
            {
                LoadCalibrationGroupStates();
            }
            else
            {
                _logger.LogWarning("Конфигурация калибровки газов не была загружена, состояния групп не могут быть инициализированы.");
            }
        }

        // Метод для получения пересчитанного значения для CO2
        public double GetRecalculatedValue(string paramName)
        {
            var calibrationParam = _configCalibrationGasParameters.FirstOrDefault(p => p.Name == paramName);
            if (calibrationParam == null)
            {
                throw new ArgumentException($"Параметр с именем {paramName} не найден.");
            }

            var measuredValue = _modbusService.ReadHoldingRegisters(calibrationParam.SlaveAddress, calibrationParam.CurrentValueAddress)[0];
            var zeroValue = _modbusService.ReadHoldingRegisters(calibrationParam.SlaveAddress, calibrationParam.SettingZero)[0];
            var referenceValue = _modbusService.ReadHoldingRegisters(calibrationParam.SlaveAddress, calibrationParam.PGSConcentration)[0];
            var acpValue = _modbusService.ReadHoldingRegisters(calibrationParam.SlaveAddress, calibrationParam.ADCValue)[0];

            // Используем универсальный калькулятор для расчета
            return _calibrationCalculator.CalculateCalibrationValue(measuredValue, zeroValue, referenceValue, acpValue);
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

        // Загрузка состояний групп калибровки
        private void LoadCalibrationGroupStates()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var storedCalibrationGroupStates = session.GetString("CalibrationGroupStates");

            if (!string.IsNullOrEmpty(storedCalibrationGroupStates))
            {
                _groupCalibrationStates = JsonSerializer.Deserialize<Dictionary<string, bool>>(storedCalibrationGroupStates);
            }
            else
            {
                if (_configCalibrationGasParameters != null && _configCalibrationGasParameters.Any())
                {
                    _groupCalibrationStates = new Dictionary<string, bool>();
                    foreach (var config in _configCalibrationGasParameters)
                    {
                        if (!_groupCalibrationStates.ContainsKey(config.Group))
                        {
                            _groupCalibrationStates[config.Group] = false; // Все группы по умолчанию свернуты
                        }
                    }
                }
            }
        }


        // Загрузка файла конфигурации с проверкой типов данных
        private void LoadConfig()
        {
            var configPath = Path.Combine(_env.WebRootPath, "config", "modbusConfig.json");
            var configCalibrationPath = Path.Combine(_env.WebRootPath, "config", "modbusColibrationGasConfig.json");

            try
            {
                _logger.LogInformation("Загрузка конфигурации Modbus из {ConfigPath}", configPath);
                _logger.LogInformation("Загрузка конфигурации калибровки газа из {ConfigPath}", configCalibrationPath);

                var configJson = File.ReadAllText(configPath);
                var configCalibrationJson = File.ReadAllText(configCalibrationPath);

                if (!string.IsNullOrEmpty(configJson))
                {
                    _configParameters = JsonSerializer.Deserialize<List<ModbusConfigParameter>>(configJson);
                }

                if (!string.IsNullOrEmpty(configCalibrationJson))
                {
                    _configCalibrationGasParameters = JsonSerializer.Deserialize<List<CalibrationConfig>>(configCalibrationJson);
                }

                if (_configParameters == null || !_configParameters.Any())
                {
                    _logger.LogWarning("Конфигурация Modbus пуста или не была загружена.");
                }

                if (_configCalibrationGasParameters == null || !_configCalibrationGasParameters.Any())
                {
                    _logger.LogWarning("Конфигурация калибровки газа пуста или не была загружена.");
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

                foreach (var config in _configCalibrationGasParameters)
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

        // Метод для получения параметров калибровки, сгруппированных
        public List<CalibrationParameter> GetGasCalibrationParametersGrouped()
        {
            var parameters = new List<CalibrationParameter>();

            foreach (var config in _configCalibrationGasParameters)
            {
                if (_groupCalibrationStates.TryGetValue(config.Group, out var isExpanded) && isExpanded)
                {
                    try
                    {
                        var currentValue = _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress)[0];
                        var settingZero = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.SettingZero)[0];
                        var pgsConcentration = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.PGSConcentration)[0];
                        var adcValue = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.ADCValue)[0];
                        var calculatedZero = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.CalculatedZero)[0];

                        parameters.Add(new CalibrationParameter
                        {
                            Name = config.Name,
                            CurrentValue = currentValue,
                            SettingZero = settingZero,
                            PGSConcentration = pgsConcentration,
                            ADCValue = adcValue,
                            CalculatedZero = calculatedZero,
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

                        // Проверяем, нужно ли калибровать параметр
                        if (config.IsCalibration)
                        {
                            // Найдем соответствующую конфигурацию калибровки по ModbusDeviceID
                            var calibrationConfig = _configCalibrationGasParameters.FirstOrDefault(c => c.ModbusDeviseID == config.Id);

                            if (calibrationConfig != null)
                            {
                                // Получаем данные для пересчета
                                currentValue = _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress)[0];
                                var settingZero = _modbusService.ReadHoldingRegisters(calibrationConfig.SlaveAddress, calibrationConfig.SettingZero)[0];
                                var pgsConcentration = _modbusService.ReadHoldingRegisters(calibrationConfig.SlaveAddress, calibrationConfig.PGSConcentration)[0];
                                var acpConcentration = _modbusService.ReadHoldingRegisters(calibrationConfig.SlaveAddress, calibrationConfig.ADCValue)[0];

                                // Пересчитываем значение с использованием новой формулы CalibrationCalculator
                                currentValue = Math.Round(_calibrationCalculator.CalculateCalibrationValue(currentValue, settingZero, pgsConcentration, acpConcentration), 2);
                            }
                            else
                            {
                                _logger.LogWarning($"Конфигурация калибровки для устройства с ID {config.Id} не найдена");
                                currentValue = 0; // По умолчанию, если конфигурация не найдена
                            }
                        }
                        else
                        {
                            // Для остальных параметров получаем значение напрямую с устройства
                            currentValue = _modbusService.ReadInputRegisters(config.SlaveAddress, config.CurrentValueAddress)[0];
                        }

                        // Получаем остальные параметры напрямую с устройства
                        var porog1 = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.Porog1Address);
                        var porog2 = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.Porog2Address);
                        var increment = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.IncrementAddress);
                        var period = _modbusService.ReadHoldingRegisters(config.SlaveAddress, config.PeriodAddress);
                        var alarmPorog1 = _modbusService.ReadDiscretRegisters(config.SlaveAddress, config.AlarmPorog1Address);
                        var alarmPorog2 = _modbusService.ReadDiscretRegisters(config.SlaveAddress, config.AlarmPorog2Address);
                        var alarmPorog3 = _modbusService.ReadDiscretRegisters(config.SlaveAddress, config.AlarmPorog3Address);

                        // Добавляем параметры в список
                        parameters.Add(new ModbusParameter
                        {
                            Name = config.Name,
                            Min = 0,
                            Max = 0,
                            Average = 0,
                            Current = currentValue, // Используем пересчитанное или прямое значение
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

        // Сохранение состояния групп калибровки
        private void SaveCalibrationGroupStates()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.SetString("CalibrationGroupStates", JsonSerializer.Serialize(_groupCalibrationStates));
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

        // Переключение состояния групп калибровки
        public void SetCalibrationGroupState(string groupName, bool isExpanded)
        {
            if (_groupCalibrationStates.ContainsKey(groupName))
            {
                _groupCalibrationStates[groupName] = isExpanded;
                SaveCalibrationGroupStates();
            }
            else
            {
                _logger.LogWarning($"Группа калибровки {groupName} не найдена");
            }
        }

        // Получение состояния всех групп
        public Dictionary<string, bool> GetGroupStates()
        {
            return _groupStates;
        }

        // Получение состояния всех групп калибровки
        public Dictionary<string, bool> GetCalibrationGroupStates()
        {
            return _groupCalibrationStates;
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

        public void WriteToCalibrationGasDevice(string paramName, string fieldName, ushort value)
        {
            var parameter = _configCalibrationGasParameters.FirstOrDefault(p => p.Name == paramName);
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



    }
}
