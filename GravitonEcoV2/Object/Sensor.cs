using NLog;
using System.ComponentModel;

namespace GravitonEcoV2.Object
{
    [DefaultProperty("alias")]
    public class Sensor
    {
        [Category("Sensor Setting")]
        public string alias { get; set; }
        [Category("Sensor Setting")]
        public byte slaveAddress { get; set; }
        [Category("Sensor Setting")]
        public ushort startAddress { get; set; }
        [Category("Sensor Setting")]
        public ushort numberOfPoints { get; set; }

        public Sensor(string alias, byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            this.alias = alias;
            this.slaveAddress = slaveAddress;
            this.startAddress = startAddress;
            this.numberOfPoints = numberOfPoints;
        }
    }
}
