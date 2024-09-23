using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEco.Models
{
    public class Sensor
    {
        public string Name { get; set; }
        public byte SlaveId { get; set; }
        public ushort StartAddress { get; set; }
        public ushort NumberOfPoints { get; set; }
        public string Mode { get; set; }
    }
}
