using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEco.Models
{
    public class DeviceConfig
    {
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public List<SensorConfig> SensorsSetting { get; set; } = new List<SensorConfig>();
        public List<SensorConfig> PorogSetting { get; set; } = new List<SensorConfig>();
        public List<SensorConfig> AlarmSetting { get; set; } = new List<SensorConfig>();
        public List<SensorConfig> CalibrationSetting { get; set; } = new List<SensorConfig>();
        public List<SensorConfig> GravitonDeviseSetting { get; set; } = new List<SensorConfig>();
    }

    public class SensorConfig
    {
        public string Name { get; set; }
        public byte SlaveAddres { get; set; }
        public ushort StartAddres { get; set; }
        public ushort NumberOfPoints { get; set; }
        public string DataType { get; set; }
        public string Space { get; set; }
    }
}
