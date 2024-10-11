using GravitonEcoWeb.Model;
using System.Text.Json;

namespace GravitonEcoWeb.Services
{
    public class ModbusDataFactory
    {
        private readonly ModbusService _modbusService;
        private readonly IWebHostEnvironment _env;
        private List<ModbusConfigParameter> _configParameters;

        public ModbusDataFactory(ModbusService modbusService, IWebHostEnvironment env)
        {
            _modbusService = modbusService;
            _env = env;
            LoadConfig();
        }

        // Загрузка файла конфигурации
        private void LoadConfig()
        {
            var configPath = Path.Combine(_env.WebRootPath, "config", "modbusConfig.json");
            var configJson = File.ReadAllText(configPath);
            _configParameters = JsonSerializer.Deserialize<List<ModbusConfigParameter>>(configJson);
        }

        // Получение параметров для чтения
        public List<ModbusParameter> GetParameters()
        {
            var parameters = new List<ModbusParameter>();

            foreach (var config in _configParameters)
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
                    AlarmPorog3 = alarmPorog3[0]
                });
            }

            return parameters;
        }

        // Метод для записи значения в Modbus устройство
        public void WriteToDevice(string paramName, string fieldName, ushort value)
        {
            var parameter = _configParameters.FirstOrDefault(p => p.Name == paramName);
            if (parameter == null)
            {
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

            _modbusService.WriteSingleRegister(parameter.SlaveAddress, address, value);
        }
    }
}
