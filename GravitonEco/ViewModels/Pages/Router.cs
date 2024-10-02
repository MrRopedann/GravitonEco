using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using GravitonEco.Services;
using GravitonEco.Views;
using GravitonEco.ViewModels.Gauges;


namespace GravitonEco.ViewModels.Pages
{
    public partial class Router : BaseViewModel
    {
        [ObservableProperty]
        private Page _currentView;

        private readonly ServiceProvider _componentProvider;

        public ModbusViewModel ModbusConnection { get; set; }

        public DateTimeViewModel DateTimeModbus { get; set; }

        public Router(IServiceProvider serviceProvider)
        {
            ModbusConnection = new ModbusViewModel();
            DateTimeModbus = new DateTimeViewModel(ModbusTcpClient.GetInstance());
            _componentProvider = (ServiceProvider)serviceProvider;
            OpenSensorPage();
        }

        private void Open<TPage>()
           where TPage : Page
        {
            CurrentView = _componentProvider.GetService<TPage>();
        }

        [RelayCommand]
        private void OpenSensorPage() => Open<SensorPage>();

        [RelayCommand]
        private void OpenSettingPage() => Open<SettingPage>();

        [RelayCommand]
        private void OpenTopMenuPage() => Open<SettingPage>();
    }
}
