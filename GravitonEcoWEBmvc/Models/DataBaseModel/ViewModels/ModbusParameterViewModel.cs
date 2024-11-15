using System.ComponentModel.DataAnnotations;

namespace GravitonEcoWEBmvc.Models.DataBaseModel.ViewModels
{
    public class ModbusParameterViewModel
    {
        // Основные данные параметра Modbus
        public int Id { get; set; }

        [Required]
        public string ParametrName { get; set; }

        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public int? CalibrationGroupId { get; set; }
        public string CalibrationGroupName { get; set; }

        public bool IsCalibration { get; set; }

        // Навигационные свойства для отображения групп
        public GroupModel Group { get; set; }               // Основная группа
        public GroupModel CalibrationGroup { get; set; }     // Калибровочная группа (опционально)

        // Основные регистры устройства
        public byte DeviceAddress { get; set; }
        public ushort RegisterCurrentValue { get; set; }
        public ushort RegisterPorog1 { get; set; }
        public ushort RegisterPorog2 { get; set; }
        public ushort RegisterIncrement { get; set; }
        public ushort RegisterPeriod { get; set; }
        public ushort RegisterAlarm1 { get; set; }
        public ushort RegisterAlarm2 { get; set; }
        public ushort RegisterAlarm3 { get; set; }

        // Калибровочные параметры
        public ushort? CalibrationOffset { get; set; }
        public ushort? CalibrationConstant { get; set; }
        public ushort? CalibrationValue { get; set; }
        public ushort? CalibrationPeriod { get; set; }

        // Списки для выбора в UI
        public List<GroupModel> AvailableGroups { get; set; }
        public List<GroupModel> AvailableCalibrationGroups { get; set; }
    }
}
