using GravitonEco.Services;
using System.Configuration;
using System.Data;
using System.Windows;

namespace GravitonEco
{
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; } = new();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = ServiceProvider.GetService<MainWindow>();
            //var driver = ServiceProvider.GetService<ModelDriver>();

            // start background data collector
            //driver.Start();

            MainWindow.Show();
        }
    }

}
