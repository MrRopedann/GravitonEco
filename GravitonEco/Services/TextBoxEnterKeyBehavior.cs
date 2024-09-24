using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GravitonEco.Services
{
    public static class TextBoxEnterKeyBehavior
    {
        public static readonly DependencyProperty EnterCommandProperty =
            DependencyProperty.RegisterAttached(
                "EnterCommand",
                typeof(ICommand),
                typeof(TextBoxEnterKeyBehavior),
                new UIPropertyMetadata(null, OnEnterCommandChanged));

        public static void SetEnterCommand(DependencyObject target, ICommand value)
        {
            target.SetValue(EnterCommandProperty, value);
        }

        public static ICommand GetEnterCommand(DependencyObject target)
        {
            return (ICommand)target.GetValue(EnterCommandProperty);
        }

        private static void OnEnterCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                textBox.KeyDown -= OnKeyDown;
                textBox.KeyDown += OnKeyDown;
            }
        }

        private static void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var textBox = sender as TextBox;
                var command = GetEnterCommand(textBox);
                if (command != null && command.CanExecute(null))
                {
                    command.Execute(null);
                }
            }
        }
    }
}