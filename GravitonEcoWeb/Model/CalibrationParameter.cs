namespace GravitonEcoWeb.Model
{
    public class CalibrationParameter
    {
        public string Name { get; set; }
        public ushort CurrentValue { get; set; }
        public ushort SettingZero { get; set; }
        public ushort PGSConcentration { get; set; }
        public ushort ADCValue { get; set; }
        public ushort CalculatedZero { get; set; }
        public string Group { get; set; }  // Новое свойство для хранения группы
        public int ModbusDeviseID { get; set; }
    }
}
