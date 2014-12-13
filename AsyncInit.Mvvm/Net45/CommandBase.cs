using System;
using System.Windows.Input;

namespace Ditto.AsyncInit.Mvvm
{
    /// <summary>
    /// Base class for types implementing <see cref="ICommand"/>.
    /// </summary>
    public abstract class CommandBase
    {
        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Raises <see cref="CanExecuteChanged"/>.
        /// </summary>
        protected void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
