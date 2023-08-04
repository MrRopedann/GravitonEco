using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEco.Model
{
    public class DeviceSensor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public String NameAtribut { get; set; }
        public int sensorValues { get; set; }
        public string DateDevice { get; set; }
    }
}
