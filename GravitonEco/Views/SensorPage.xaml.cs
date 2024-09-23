using GravitonEco.ViewModels.Gauges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var textBox = sender as TextBox;
                if (textBox != null && textBox.DataContext is TemperatureGaugesViewModel viewModel)
                {
                    var propertyName = textBox.Name;
                    viewModel.WriteToModbusCommand.Execute(propertyName);
                    MessageBox.Show("Значение записанно!");
                }
            }
        }
    }
}
