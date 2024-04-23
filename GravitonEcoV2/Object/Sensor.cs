using System.ComponentModel;

namespace GravitonEcoV2.Object
{
    [DefaultProperty("Alias")]
    public class Sensor
    {
        public string Alias { get; set; }
        public int SlaveAddress { get; set; }
        public int StartAddress { get; set; }
        public int NumberOfPoint { get; set; }

    }
}