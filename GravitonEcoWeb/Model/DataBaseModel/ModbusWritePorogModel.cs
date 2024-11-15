using System.ComponentModel.DataAnnotations.Schema;

namespace GravitonEcoWeb.Model.DataBaseModel
{
    public class ModbusWritePorogModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string NameParametr { get; set; }
        public string PorogType { get; set; }
        public DateTime GlobalDateTime { get; set; }
        public DateTime DeviceDateTime { get; set; }
        public double OldPorogParametr { get; set; }
        public double NewPorogParametr { get; set; }
    }
}
