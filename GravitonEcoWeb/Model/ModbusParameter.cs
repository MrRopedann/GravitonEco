namespace GravitonEcoWeb.Model
{
    public class ModbusParameter
    {
        public string Name { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int Average { get; set; }
        public int Current { get; set; }
        public int Threshold1 { get; set; }
        public int Threshold2 { get; set; }
        public int Growth { get; set; }
        public int Period { get; set; }

        // Логические свойства для тревожных порогов
        public bool AlarmPorog1 { get; set; }
        public bool AlarmPorog2 { get; set; }
        public bool AlarmPorog3 { get; set; }
    }
}