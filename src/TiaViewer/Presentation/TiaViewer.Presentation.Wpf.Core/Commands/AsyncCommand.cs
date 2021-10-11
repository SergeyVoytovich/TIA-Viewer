#nullable enable
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TiaViewer.Presentation.Wpf.Commands
{
    public class AsyncCommand : ICommand
    {
        private readonly Func<Task> _action;

        public AsyncCommand(Func<Task> action)
        {
            this._action = action;
        }

        public bool CanExecute(object? parameter)
            => true;

        public void Execute(object? parameter)
        {
            _action();
        }

        public event EventHandler? CanExecuteChanged;

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}