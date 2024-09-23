using CommunityToolkit.Mvvm.ComponentModel;
using System.Runtime.CompilerServices;

namespace GravitonEco.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            return SetProperty(ref field, value, propertyName);
        }
    }
}