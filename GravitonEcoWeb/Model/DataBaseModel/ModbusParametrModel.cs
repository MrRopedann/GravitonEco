using System.ComponentModel.DataAnnotations.Schema;

namespace GravitonEcoWeb.Model.DataBaseModel
{
    public class ModbusParametrModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string NameParametr { get; set; }
        public DateTime GlobalDateTime { get; set; }
        public DateTime DeviceDateTime { get; set; }
        public int DeviceId { get; set; }
        public double DeviceParametr { get; set; }
    }
}
