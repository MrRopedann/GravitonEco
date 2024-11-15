using GravitonEcoWEBmvc.Models.DataBaseModel;

public class DeviceModel
{
    public int Id { get; set; }             // ID устройства
    public string NameParametr { get; set; } // Название параметра

    // Свойства группы
    public int GroupId { get; set; }         // ID группы
    public string GroupName { get; set; }    // Название группы
    public int DisplayFormat { get; set; }   // Формат отображения группы

    // Основные параметры устройства
    public double CurrentValue { get; set; }    // Текущее значение
    public int Porog1Value { get; set; }     // Порог 1
    public int Porog2Value { get; set; }     // Порог 2
    public int IncrementValue { get; set; }  // Инкремент
    public int PeriodValue { get; set; }     // Период
    public bool Alarm1Value { get; set; }    // Тревога 1
    public bool Alarm2Value { get; set; }    // Тревога 2
    public bool Alarm3Value { get; set; }    // Тревога 3

    // Дополнительные свойства для калибровочных параметров


    // Калибровочные параметры
    public int CalibrationGroupId { get; set; }      // ID калибровочной группы
    public string CalibrationGroupName { get; set; }  // Название калибровочной группы
    public int CalibrationOffset { get; set; }  // Регистр настройки нуля
    public int CalibrationConstant { get; set; } // Концентрация ПГС
    public int CalibrationValue { get; set; }     // Значение АЦП
    public int CalibrationPeriod { get; set; } // Вычисленный ноль

    public bool IsCalibration { get; set; } // Флаг, показывающий, является ли параметр калибровочным
    public bool IsReserved { get; set; } // Флаг, показывающий, является ли параметр калибровочным

    public ushort? ReservedAddress { get; set; }
}
