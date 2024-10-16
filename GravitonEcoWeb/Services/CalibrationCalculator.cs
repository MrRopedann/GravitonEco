namespace GravitonEcoWeb.Services
{
    public class CalibrationCalculator
    {
        // Метод для расчета значения по общей формуле
        public double CalculateCalibrationValue(double currentValue, double settingZero, double pgsConcentration, double acpConcentration)
{
    // Проверяем, чтобы не произошло деление на ноль
    if (pgsConcentration == 0)
    {
        throw new DivideByZeroException("Концентрация ПГС (Xгс) не может быть равна 0.");
    }

    double result = (currentValue - settingZero) / (acpConcentration / pgsConcentration);

    return result;
}

    }
}
