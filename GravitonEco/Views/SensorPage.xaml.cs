using GravitonEco.ViewModels;
using GravitonEco.ViewModels.Gauges;
using System.Windows;
using System.Windows.Controls;

namespace GravitonEco.Views
{
    /// <summary>
    /// Логика взаимодействия для SensorPage.xaml
    /// </summary>
    public partial class SensorPage : Page
    {
        public SensorPage()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as System.Windows.Controls.RadioButton;
            if (radioButton != null && radioButton.Tag != null && DataContext is GaugesViewModel viewModel)
            {
                if (int.TryParse(radioButton.Tag.ToString(), out int chartNumber))
                {
                    viewModel.ChartGauges.SwitchChart(chartNumber); // Вызов метода для переключения графика
                }
            }
        }
    }
}
