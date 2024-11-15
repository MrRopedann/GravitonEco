using GravitonEcoWeb.Enums;

namespace GravitonEcoWeb.Model
{
    public class ModbusParameter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Average { get; set; }
        public double Current { get; set; }
        public int Threshold1 { get; set; }
        public int Threshold2 { get; set; }
        public int Growth { get; set; }
        public int Period { get; set; }
        public bool AlarmPorog1 { get; set; }
        public bool AlarmPorog2 { get; set; }
        public bool AlarmPorog3 { get; set; }
        public string Group { get; set; }  // Новое свойство для хранения группы
        public bool IsCalibration { get; set; }
        public GasType ConverGasType { get; set;} 
    }

}