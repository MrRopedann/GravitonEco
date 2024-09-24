using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ChartViewModel ChartGauges { get; set; }

        public GaugesViewModel()
        {
            TemperatureGauges = new TemperatureGaugesViewModel();
            RelativeHumidityOutsideGauge = new RelativeHumidityOutsideViewModel();
            AdditionalnputOneGauge = new AdditionalnputOneViewModel();
            AdditionalnputTwoGauge = new AdditionalnputTwoViewModel();
            COGauges = new COViewModel();
            NOGauges = new NOViewModel();
            NO2Gauges = new NO2ViewModel();
            SO2Gauges = new SO2ViewModel();
            CO2Gauges = new CO2ViewModel();
            LOCGauges = new LOCViewModel();
            PM1_0Gauges = new PM1_0ViewModel();
            PM2_5Gauges = new PM2_5ViewModel();
            PM10Gauges = new PM10ViewModel();
            MicroAccelerationsGauges = new MicroAccelerationsViewModel();
            InclineGauges = new InclineViewModel();
            HackingGauges = new HackingViewModel();
            InternalTemperatureGauges = new InternalTemperatureViewModel();
            InternalRelativeHumidityGauges = new InternalRelativeHumidityViewModel();
            VoltageGauges = new VoltageViewModel();
            FlowRateGauges = new FlowRateViewModel();
            InternalAtmosphericPressureGauges = new InternalAtmosphericPressureViewModel();
            ChartGauges = new ChartViewModel();
        }
    }
}
