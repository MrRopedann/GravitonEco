public class CalibrationConfig
{
    public string Name { get; set; }
    public byte SlaveAddress { get; set; }
    public ushort CurrentValueAddress { get; set; }
    public ushort SettingZero { get; set; }
    public ushort PGSConcentration { get; set; }
    public ushort ADCValue { get; set; }
    public ushort CalculatedZero { get; set; }
    public string Group { get; set; }
    public int ModbusDeviseID { get; set; }
    public List<string> ColumnNames { get; set; }
}
