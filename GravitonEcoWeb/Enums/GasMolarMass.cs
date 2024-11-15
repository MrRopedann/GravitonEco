namespace GravitonEcoWeb.Enums
{
    public enum GasType
    {
        CO,
        NO,
        NO2,
        SO2
    }

    public static class GasProperties
    {
        public static readonly Dictionary<GasType, double> MolarMasses = new Dictionary<GasType, double>
        {
            { GasType.CO, 28.01 },
            { GasType.NO, 30.01 },
            { GasType.NO2, 46.01 },
            { GasType.SO2, 64.06 }
        };
    }

}
