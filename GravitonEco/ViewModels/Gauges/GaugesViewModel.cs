using GravitonEco.Services;

namespace GravitonEco.ViewModels.Gauges
{
    public class GaugesViewModel : BaseViewModel
    {
        public TemperatureGaugesViewModel TemperatureGauges { get; set; }

        public RelativeHumidityOutsideViewModel RelativeHumidityOutsideGauge { get; set; }
        public AdditionalnputOneViewModel AdditionalnputOneGauge { get; set; }
        public AdditionalnputTwoViewModel AdditionalnputTwoGauge { get; set; }

        public COViewModel COGauges { get; set; }
        public NOViewModel NOGauges { get; set; }
        public NO2ViewModel NO2Gauges { get; set; }
        public SO2ViewModel SO2Gauges { get; set; }
        public CO2ViewModel CO2Gauges { get; set; }
        public LOCViewModel LOCGauges { get; set; }
        public PM1_0ViewModel PM1_0Gauges { get; set; }
        public PM2_5ViewModel PM2_5Gauges { get; set; }

        public PM10ViewModel PM10Gauges { get; set; }
        public MicroAccelerationsViewModel MicroAccelerationsGauges { get; set; }
        public InclineViewModel InclineGauges { get; set; }
        public HackingViewModel HackingGauges { get; set; }
        public InternalTemperatureViewModel InternalTemperatureGauges { get; set; }
        public InternalRelativeHumidityViewModel InternalRelativeHumidityGauges { get; set; }
        public VoltageViewModel VoltageGauges { get; set; }
        public FlowRateViewModel FlowRateGauges { get; set; }
        public InternalAtmosphericPressureViewModel InternalAtmosphericPressureGauges { get; set; }
        public AtmosphericPressureViewModel AtmosphericPressureGauges { get; set; }


        public GaugesViewModel()
        {
            TemperatureGauges = new TemperatureGaugesViewModel(ModbusTcpClient.GetInstance(), "Темпиратура");
            RelativeHumidityOutsideGauge = new RelativeHumidityOutsideViewModel(ModbusTcpClient.GetInstance(), "Отн. влажность внеш (0 - 98 %)");
            AdditionalnputOneGauge = new AdditionalnputOneViewModel(ModbusTcpClient.GetInstance(), "Доп вход 1 (осв)");
            AdditionalnputTwoGauge = new AdditionalnputTwoViewModel(ModbusTcpClient.GetInstance(), "Доп вход 2");
            COGauges = new COViewModel(ModbusTcpClient.GetInstance(), "CO (0 - 40 000 ppb)");
            NOGauges = new NOViewModel(ModbusTcpClient.GetInstance(), "NO (0 - 1 000 ppb)");
            NO2Gauges = new NO2ViewModel(ModbusTcpClient.GetInstance(), "NO2 (0 - 1 000 ppb)");
            SO2Gauges = new SO2ViewModel(ModbusTcpClient.GetInstance(), "SO2 (0 - 1 000 ppb)");
            CO2Gauges = new CO2ViewModel(ModbusTcpClient.GetInstance(), "CO2 (0 - 5 000 ppm)");
            LOCGauges = new LOCViewModel(ModbusTcpClient.GetInstance(), "ЛОС (0 - 10 000 ppb)");
            PM1_0Gauges = new PM1_0ViewModel(ModbusTcpClient.GetInstance(), "PM 1.0 (0 - 1000 мкг / м³)");
            PM2_5Gauges = new PM2_5ViewModel(ModbusTcpClient.GetInstance(), "PM 2.5 (0 - 1000 мкг / м³)");
            PM10Gauges = new PM10ViewModel(ModbusTcpClient.GetInstance(), "PM 10 (0 - 1000 мкг / м³)");
            MicroAccelerationsGauges = new MicroAccelerationsViewModel(ModbusTcpClient.GetInstance(), "Микроускорения (0 - 10 м/с)");
            InclineGauges = new InclineViewModel(ModbusTcpClient.GetInstance(), "Наклон (0 - 45°)");
            HackingGauges = new HackingViewModel(ModbusTcpClient.GetInstance(), "Взлом (0 - 100 %)");
            InternalTemperatureGauges = new InternalTemperatureViewModel(ModbusTcpClient.GetInstance(), "Температура (- 45 до +45°С)");
            InternalRelativeHumidityGauges = new InternalRelativeHumidityViewModel(ModbusTcpClient.GetInstance(), "Отн. влажность (0 - 98 %)");
            VoltageGauges = new VoltageViewModel(ModbusTcpClient.GetInstance(), "Напряжение (8 - 16 В)");
            FlowRateGauges = new FlowRateViewModel(ModbusTcpClient.GetInstance(), "Скор. потока (0 - 1 л/мин)");
            InternalAtmosphericPressureGauges = new InternalAtmosphericPressureViewModel(ModbusTcpClient.GetInstance(), "Атм. дав-ние (650 - 1200 hPa)");
        }
    }
}
