using System.ComponentModel.DataAnnotations.Schema;

namespace GravitonEcoWEBmvc.Models.DataBaseModel
{
    public class ModbusParametrModel
    {
        /// <summary>
        /// Идентификатор датчика
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Название параметра
        /// </summary>
        public string ParametrName { get; set; }

        /// <summary>
        /// Основная группа
        /// </summary>
        public int GroupId { get; set; }
        [ForeignKey(nameof(GroupId))]
        public GroupModel Group { get; set; }

        /// <summary>
        /// Калибровочная группа
        /// </summary>
        public int? CalibrationGroupId { get; set; }
        [ForeignKey(nameof(CalibrationGroupId))]
        public GroupModel CalibrationGroup { get; set; }

        /// <summary>
        /// Указание на то, требуется ли калибровка
        /// </summary>
        public bool IsCalibration { get; set; }

        // Основные параметры устройства

        /// <summary>
        /// Адрес устройства
        /// </summary>
        public byte DeviceAddress { get; set; }

        /// <summary>
        /// Регистр текущего значения
        /// </summary>
        public ushort RegisterCurrentValue { get; set; }
        /// <summary>
        /// Регистр порог 1
        /// </summary>
        public ushort RegisterPorog1 { get; set; }
        /// <summary>
        /// Регистр порог 2
        /// </summary>
        public ushort RegisterPorog2 { get; set; }
        /// <summary>
        /// Регистр нарастание
        /// </summary>
        public ushort RegisterIncrement { get; set; }
        /// <summary>
        /// Регистр период
        /// </summary>
        public ushort RegisterPeriod { get; set; }

        // Регистры тревог

        /// <summary>
        /// Регистр сработка 1
        /// </summary>
        public ushort RegisterAlarm1 { get; set; }
        /// <summary>
        /// Регистр сработка 2
        /// </summary>
        public ushort RegisterAlarm2 { get; set; }
        /// <summary>
        /// Регистр сработка 3
        /// </summary>
        public ushort RegisterAlarm3 { get; set; }

        // Калибровочные регистры
        /// <summary>
        /// Регистр отсчет
        /// </summary>
        public ushort? RegisterOffset { get; set; }
        /// <summary>
        /// Регистр константа
        /// </summary>
        public ushort? RegisterConstant { get; set; }
        /// <summary>
        /// Регистр значение
        /// </summary>
        public ushort? RegisterValue { get; set; }
        /// <summary>
        /// Регистр период калибровки
        /// </summary>
        public ushort? RegisterCalibrationPeriod { get; set; }

        // Резервные параметры
        /// <summary>
        /// Флаг зарезервированного устройства
        /// </summary>
        public bool IsReserved { get; set; }
        /// <summary>
        /// Резервный адрес, если применимо
        /// </summary>
        public ushort? ReservedAddress { get; set; }
    }

}
