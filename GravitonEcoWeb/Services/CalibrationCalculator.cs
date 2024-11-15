using GravitonEcoWeb.Enums;

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

        public double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        public double CalculateMolarWeight(double concentration, double molarMass, double temperatureCelsius, double pressure = 101325)
        {
            const double coefficient = 0.12 * 1e-3; // Верный коэффициент 0.12 * 10^-3

            // Конвертируем температуру из Цельсия в Кельвины
            double temperatureKelvin = temperatureCelsius / 10 + 273.15;

            // Применяем формулу с использованием переданной молекулярной массы и давления по умолчанию
            return (coefficient * concentration * molarMass * pressure) / temperatureKelvin;
        }



    }
}
