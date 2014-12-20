using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ditto.AsyncMvvm
{
    /// <summary>
    /// Asynchronous property.
    /// </summary>
    /// <typeparam name="T">The type of the property value.</typeparam>
    public class AsyncProperty<T> : PropertyBase<T>
    {
        private readonly Func<CancellationToken, Task<T>> _getValueAsync;
        private bool _isCalculating;

        /// <summary>
        /// Creates a new asynchronous property instance.
        /// </summary>
        /// <param name="onPropertyChanged">Property change notification delegate.</param>
        /// <param name="getValueAsync">The delegate used to calculate the property value.</param>
        public AsyncProperty(Action<T, string> onPropertyChanged, Func<CancellationToken, Task<T>> getValueAsync)
            : base(onPropertyChanged)
        {
            this._getValueAsync = getValueAsync;
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="token">The optional cancellation token.</param>
        /// <param name="listener">The optional task listener.</param>
        /// <param name="propertyName">The name of the property.</param>
        public T GetValue(CancellationToken token, ITaskListener listener, string propertyName)
        {
            if (!IsValueValid)
                CalculateValue(token, listener, propertyName);
            return DoGetValue();
        }

        private void CalculateValue(CancellationToken token, ITaskListener listener, string propertyName)
        {
            if (!_isCalculating)
            {
                _isCalculating = true;
                StartGetValue(token, listener, propertyName);
            }
        }

        private void StartGetValue(CancellationToken token, ITaskListener listener, string propertyName)
        {
            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            listener = listener ?? AggregateTaskListener.Empty;
            listener.NotifyTaskStarting();
            TaskEx.Run(() => _getValueAsync(token))
                .ContinueWith(task => OnGetValueCompleted(task, listener, propertyName),
                    CancellationToken.None, TaskContinuationOptions.None, scheduler);
        }

        private void OnGetValueCompleted(Task<T> task, ITaskListener listener, string propertyName)
        {
            switch (task.Status)
            {
                case TaskStatus.RanToCompletion:
                    OnGetValueRanToCompletion(task.Result, listener, propertyName);
                    break;
                case TaskStatus.Canceled:
                    OnGetValueCanceled(listener, propertyName);
                    break;
                case TaskStatus.Faulted:
                    OnGetValueFaulted(listener, propertyName);
                    break;
                default:
                    break;
            }
            _isCalculating = false;
        }

        private void OnGetValueRanToCompletion(T value, ITaskListener listener, string propertyName)
        {
            DoSetValue(value, propertyName);
            listener.NotifyTaskCompleted(true);
        }

        private void OnGetValueCanceled(ITaskListener listener, string propertyName)
        {
            listener.NotifyTaskCompleted(null);
        }

        private void OnGetValueFaulted(ITaskListener listener, string propertyName)
        {
            listener.NotifyTaskCompleted(false);
        }
    }
}
