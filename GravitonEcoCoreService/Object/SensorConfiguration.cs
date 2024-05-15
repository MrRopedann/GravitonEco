using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEcoCoreService.Object
{
    public struct SensorConfiguration
    {
        public string Alias { get; set; }
        public byte SlaveAddress { get; set; }
        public ushort StartAddress { get; set; }
        public ushort NumberOfPoints { get; set; }
    }
}
