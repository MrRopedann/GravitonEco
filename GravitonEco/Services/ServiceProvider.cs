using GravitonEco.ViewModels.Pages;
using GravitonEco.ViewModels;
using GravitonEco.Views.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jab;
using System.Windows;

namespace GravitonEco.Services
{

    public interface IObsoleteStuffProvider
    {
    }

    public interface ICommonServiceProvider
    {
    }

    public interface IConfiguratorProvider
    {
    }

    [ServiceProvider]
    [Import<IViewModelProvider>]
    [Import<IViewProvider>]
    [Import<IViewHelperProvider>]
    // [Import<ICommonServiceProvider>]
    //[Import<IObsoleteStuffProvider>]
    //[Import<IConfiguratorProvider>]

    public sealed partial class ServiceProvider : ICommonServiceProvider, IObsoleteStuffProvider, IConfiguratorProvider, IViewModelProvider
    {

    }
}
