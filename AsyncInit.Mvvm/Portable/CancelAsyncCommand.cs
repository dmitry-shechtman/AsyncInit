using System;
using System.Threading;
using System.Windows.Input;

namespace Ditto.AsyncInit.Mvvm
{
    /// <summary>
    /// Command for cancelling an asynchronous operation.
    /// </summary>
    public class CancelAsyncCommand : CommandBase, ICommand, IDisposable, ITaskListener
    {
        private bool _isRunning;
        private CancellationTokenSource _cts = new CancellationTokenSource();

        /// <summary>
        /// Releases all associated resources.
        /// </summary>
        public void Dispose()
        {
            _cts.Dispose();
        }

        /// <summary>
        /// Cancellation token.
        /// </summary>
        public CancellationToken CancellationToken
        {
            get { return _cts.Token; }
        }

        /// <summary>
        /// Cancels the asynchronous operation.
        /// </summary>
        /// <param name="parameter">Ignored.</param>
        public void Execute(object parameter)
        {
            _cts.Cancel();
            RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Gets a value indicating whether the asynchronous operation can be canceled.
        /// </summary>
        /// <param name="parameter">Ignored.</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _isRunning && !_cts.IsCancellationRequested;
        }

        /// <summary>
        /// Notifies the command on task start.
        /// </summary>
        public void NotifyTaskStarting()
        {
            _isRunning = true;
            if (_cts.IsCancellationRequested)
            {
                _cts.Dispose();
                _cts = new CancellationTokenSource();
            }
            RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Notifies the command on task completion.
        /// </summary>
        /// <param name="isSuccess"><value>true</value> if successful, <value>false</value> if faulted,
        /// or <value>null</value> if canceled.</param>
        public void NotifyTaskCompleted(bool? isSuccess)
        {
            _isRunning = false;
            RaiseCanExecuteChanged();
        }
    }
}
