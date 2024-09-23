using GravitonEco.ViewModels.Pages;
using System.Windows.Controls;

namespace GravitonEco.Views.Screens
{
    /// <summary>
    /// Логика взаимодействия для MainScreen.xaml
    /// </summary>
    public partial class MainScreen : UserControl
    {
        private Router _routerViewModel;
        public MainScreen()
        {
            InitializeComponent();
        }
        public MainScreen(Router router)
        {
            _routerViewModel = router;
            DataContext = _routerViewModel;
            InitializeComponent();
        }
    }
}
