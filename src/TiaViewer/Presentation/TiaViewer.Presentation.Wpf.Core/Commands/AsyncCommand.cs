#nullable enable
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TiaViewer.Presentation.Wpf.Commands
{
    /// <summary>
    /// Async command
    /// </summary>
    public class AsyncCommand : ICommand
    {
        #region Fields

        private readonly Func<Task> _action;

        #endregion


        #region Events

        public event EventHandler? CanExecuteChanged;

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion


        #region Constructors

        /// <summary>
        /// Initialized new instance
        /// </summary>
        /// <param name="action">Action to execution</param>
        public AsyncCommand(Func<Task> action)
        {
            _action = action;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Can execute
        /// </summary>
        /// <param name="parameter">Command parameter</param>
        /// <returns>All times true</returns>
        public bool CanExecute(object? parameter)
            => true;

        /// <summary>
        /// Execute command
        /// </summary>
        /// <param name="parameter">Command parameter</param>
        public void Execute(object? parameter)
        {
            _action();
        }

        #endregion

        
    }
}