using System.ComponentModel.DataAnnotations.Schema;

namespace GravitonEcoWEBmvc.Models.DataBaseModel
{
    public class DeviceConnectionModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string IpAddres { get; set; }
        public int Port { get; set; }
    }
}
