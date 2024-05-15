using GravitonEcoCoreService.Managers;
using GravitonEcoCoreService.Object;
using Newtonsoft.Json;
using NLog;
using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEcoCoreService.Updaters
{
    public abstract class ModbusUpdaterBase
    {
        //protected readonly Control control;
        protected readonly string alias;
        protected readonly ModbusConnectionManager connectionManager;
        private int taskDelay = 30000;
        private CancellationTokenSource cancellationTokenSource;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        string pathSensor = @"./Setting/setting_device_connection.ini";


        public ModbusUpdaterBase(string alias, ModbusConnectionManager connectionManager)
        {
            //this.control = control ?? throw new ArgumentNullException(nameof(control))
            this.alias = alias;
            this.connectionManager = connectionManager ?? throw new ArgumentNullException(nameof(connectionManager));
            this.cancellationTokenSource = new CancellationTokenSource();
            StartUpdating();
            //this.control.HandleCreated += (_, __) => StartUpdating();
            //this.control.HandleDestroyed += (_, __) => StopUpdating();
        }

        protected abstract Task UpdateAsync();

        protected async Task UpdateControlAsync(object value)
        {
            await Task.Run(() =>
            {
                INIManager manager = new INIManager(pathSensor);
                taskDelay = Convert.ToInt32(manager.GetPrivateString("DeviceConnectSetting", "UpdateTimeValueSensorMc"));

                List<SensorConfiguration> sensorConfigurations = ReadSensorConfigurationsFromFile("setting\\ModbusSensorSetting.json");

                foreach (var config in sensorConfigurations)
                {
                    //Console.WriteLine($"Value of sensor '{config.Alias}' changed: {value}");

                            // Создаем экземпляр контекста данных
                            using (var context = new ApplicationContext())
                            {
                                // Создаем объект SensorData и добавляем его в набор сущностей
                                var sensorData = new SensorBase
                                {
                                    Alias = config.Alias,
                                    Value = Convert.ToInt32(value),
                                    Timestamp = DateTime.Now.ToUniversalTime(),
                                    TimeSensor = DateTime.Now.ToUniversalTime()
                                };

                                context.SensorTemperature.Add(sensorData);

                                // Сохраняем изменения в базе данных
                                context.SaveChanges();
                            }
                }


                Console.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + "Получено значение: " + alias + " = " + value.ToString());

                return value.ToString();
            });
            await Task.Delay(taskDelay);

        }

        protected async Task UpdateRegistersAsync(Func<IModbusMaster, Task<ushort[]>> readRegistersFunc)
        {
            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                try
                {
                    IModbusMaster modbusMaster = connectionManager.GetModbusMaster();
                    ushort[] registers = await readRegistersFunc(modbusMaster);
                    string newValue = registers[0].ToString();

                    await UpdateControlAsync(newValue);
                }
                catch (Exception ex)
                {
                    logger.Error($"Ошибка передачи данных: {ex.Message}");
                }

                await Task.Delay(taskDelay);
            }
        }

        protected async Task UpdateRegistersAsync(Func<IModbusMaster, Task<bool[]>> readRegistersFunc)
        {
            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                try
                {
                    IModbusMaster modbusMaster = connectionManager.GetModbusMaster();
                    bool[] registers = await readRegistersFunc(modbusMaster);
                    string newValue = registers[0].ToString();

                    await UpdateControlAsync(newValue);
                }
                catch (Exception ex)
                {
                    logger.Error($"Ошибка передачи данных: {ex.Message}");
                }

                await Task.Delay(taskDelay);
            }
        }

        static List<SensorConfiguration> ReadSensorConfigurationsFromFile(string fileName)
        {
            try
            {
                // Read data from the file
                string jsonString = File.ReadAllText(fileName);

                // Deserialize data into a list of SensorConfiguration
                List<SensorConfiguration> configurations = JsonConvert.DeserializeObject<List<SensorConfiguration>>(jsonString);

                return configurations;
            }
            catch (Exception ex)
            {
                //logger.Error($"Error reading configuration file: {ex.Message}");
                return new List<SensorConfiguration>();
            }
        }

        public void StartUpdating()
        {
            cancellationTokenSource = new CancellationTokenSource();
            Task.Run(() => UpdateAsync());
        }

        public void StopUpdating()
        {
            cancellationTokenSource.Cancel();
        }
    }
}
