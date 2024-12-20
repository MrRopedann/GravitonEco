﻿using GravitonEcoWeb.Enums;

namespace GravitonEcoWeb.Model
{
    public class ModbusConfigParameter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte SlaveAddress { get; set; }
        public ushort CurrentValueAddress { get; set; }
        public ushort Porog1Address { get; set; }
        public ushort Porog2Address { get; set; }
        public ushort IncrementAddress { get; set; }
        public ushort PeriodAddress { get; set; }
        public ushort AlarmPorog1Address { get; set; }
        public ushort AlarmPorog2Address { get; set; }
        public ushort AlarmPorog3Address { get; set; }
        public string Group { get; set; }
        public bool IsCalibration { get; set; }
        public GasType ConverGasType { get; set; }
    }
}
