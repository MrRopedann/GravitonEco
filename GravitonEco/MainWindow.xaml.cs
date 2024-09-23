using GravitonEco.ViewModels;
using System.Windows;

namespace GravitonEco
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            DataContext = mainWindowViewModel;
            InitializeComponent();
        }
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}