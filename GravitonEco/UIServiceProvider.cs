using GravitonEco.ViewModels.Pages;
using GravitonEco.ViewModels;
using GravitonEco.Views.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jab;
using GravitonEco.Views;

namespace GravitonEco
{
    [ServiceProviderModule]
    [Singleton(typeof(SensorPage))]
    [Transient(typeof(SettingPage))]

    [Transient(typeof(MainScreen))]
    [Transient(typeof(MainWindow))]
    public interface IViewProvider;

    [ServiceProviderModule]
    [Singleton(typeof(MainWindowViewModel))]

    public interface IViewModelProvider
    {
    }

    [ServiceProviderModule]
    [Singleton(typeof(Router))]
    //[Singleton(typeof(MonitorComponentFactory))]
    public interface IViewHelperProvider;

}
