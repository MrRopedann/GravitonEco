using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEco.Models
{
    public class SensorGroup
    {
        public string GroupName { get; set; }
        public ObservableCollection<Sensor> Sensors { get; set; } = new ObservableCollection<Sensor>();
    }
}
