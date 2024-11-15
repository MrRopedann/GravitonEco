using System.ComponentModel.DataAnnotations.Schema;

namespace GravitonEcoWEBmvc.Models.DataBaseModel
{
    public class GroupModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string GroupName { get; set; }
        public int DisplayFormat { get; set; }

        // Параметры, связанные с этой группой
        public ICollection<ModbusParametrModel> ModbusParametrs { get; set; }

        // Параметры, которые используют эту группу как калибровочную
        public ICollection<ModbusParametrModel> CalibrationParameters { get; set; }
    }
}
