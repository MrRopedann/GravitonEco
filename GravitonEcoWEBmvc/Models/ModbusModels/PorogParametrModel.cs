namespace GravitonEcoWEBmvc.Models.ModbusModels
{
    public class PorogParametrModel
    {
        public int Id { get; set; }           // ID устройства
        public string NameParametr { get; set; } // Название параметра
        public string GroupName { get; set; }  // Название группы
        public int GroupId { get; set; }       // ID группы
        public int Porog1Value { get; set; }
        public int Porog2Value { get; set; }
        public int IncrementValue { get; set; }
        public int PeriodValue { get; set; }
    }
}
