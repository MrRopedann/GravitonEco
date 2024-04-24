using GravitonEcoV2.Object;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GravitonEcoV2.View
{
    public partial class ModbusSettings : Form
    {
        const string PATH = @"C:\ProgramData\GravitonEco\ModbusSensorSetting.json";

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public ModbusSettings()
        {
            InitializeComponent();
            List<SensorConfiguration> Sensor = ReadSensorConfigurationsFromFile(PATH);

            Sensor[] SensorArr = new Sensor[Sensor.Count];

            int index = 0;
            foreach (var config in Sensor)
            {
                
                var sensor = new Sensor(config.Alias, config.SlaveAddress, config.StartAddress, config.NumberOfPoints);
                SensorArr[index] = sensor;
                index++;
            }

            propertyGrid1.SelectedObjects = SensorArr;
        }

        // Method to read sensor configurations from JSON file
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
                logger.Error($"Error reading configuration file: {ex.Message}");
                return new List<SensorConfiguration>();
            }
        }
    }
}
