using GravitonEco.Views.Screens;
using System.Windows.Controls;

namespace GravitonEco.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private Control _currentView;

        public Control CurrentView
        {
            get => _currentView;
            set => Set(ref _currentView, value);
        }


        public MainWindowViewModel(MainScreen mainScreen)
        {
            CurrentView = mainScreen;
        }
    }
}
