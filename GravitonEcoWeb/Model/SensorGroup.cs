namespace GravitonEcoWeb.Model
{
    public class SensorGroup
    {
        public string GroupName { get; set; }
        public List<ModbusParameter> Sensors { get; set; }
        public bool IsCollapsed { get; set; } = false; // Свёрнута ли группа
    }
}
