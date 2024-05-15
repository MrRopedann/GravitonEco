using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonEcoCoreService.Object
{
    public class SensorBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } // Идентификатор записи
        public string Alias { get; set; } // Наименование датчика
        public int Value { get; set; } // Значение датчика
        public DateTime Timestamp { get; set; } // Временная метка
        public DateTime TimeSensor { get; set; } // Временная метка датчика
    }
}
