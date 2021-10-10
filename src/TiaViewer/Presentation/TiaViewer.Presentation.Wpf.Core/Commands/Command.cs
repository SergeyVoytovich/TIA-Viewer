#nullable enable
using System;
using System.Windows.Input;

namespace TiaViewer.Presentation.Wpf.Commands
{
    public class Command<T> : ICommand
    {
        private readonly Action<T> _action;

        public Command(Action<T> action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public bool CanExecute(object? parameter)
            => true;

        public void Execute(object? parameter)
            => _action((parameter is T p ? p : default)!);

        public event EventHandler? CanExecuteChanged;

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}