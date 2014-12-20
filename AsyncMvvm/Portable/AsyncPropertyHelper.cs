using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Ditto.AsyncMvvm
{
    /// <summary>
    /// Asynchronous property helper.
    /// </summary>
    public class AsyncPropertyHelper
    {
        private readonly PropertyDictionary _properties;
        private readonly Action<string> _onPropertyChanged;

        /// <summary>
        /// Creates a new property helper.
        /// </summary>
        /// <param name="onPropertyChanged">Property change notification delegate.</param>
        public AsyncPropertyHelper(Action<string> onPropertyChanged)
        {
            this._properties = new PropertyDictionary();
            this._onPropertyChanged = onPropertyChanged;
        }

        /// <summary>
        /// Gets the value of a property.
        /// </summary>
        /// <typeparam name="T">Property type.</typeparam>
        /// <param name="getValue">Function to get the value.</param>
        /// <param name="propertyName">Property name.</param>
        /// <returns>The property's value.</returns>
        public T Get<T>(Func<T> getValue, [CallerMemberName] string propertyName = null)
        {
            if (getValue == null)
                throw new ArgumentNullException("getValue");
            return DoGetProperty(getValue, propertyName);
        }

        /// <summary>
        /// Asynchronously gets the value of a property.
        /// </summary>
        /// <typeparam name="T">Property type.</typeparam>
        /// <param name="getValueAsync">Asynchronous function to get the value.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="taskListener">Task listener.</param>
        /// <param name="propertyName">Property name.</param>
        /// <returns>The property's value if the function successfully completed; otherwise, <value>null</value>.</returns>
        public T Get<T>(Func<Task<T>> getValueAsync, CancellationToken cancellationToken = default(CancellationToken),
            ITaskListener taskListener = null, [CallerMemberName] string propertyName = null)
            where T : class
        {
            if (getValueAsync == null)
                throw new ArgumentNullException("getValueAsync");
            if (taskListener == null)
                taskListener = AggregateTaskListener.Empty;
            return DoGetProperty(ct => getValueAsync(), cancellationToken, taskListener, propertyName);
        }

        /// <summary>
        /// Asynchronously gets the value of a property.
        /// </summary>
        /// <typeparam name="T">Property type.</typeparam>
        /// <param name="getValueAsync">Asynchronous function to get the value.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="taskListener">Task listener.</param>
        /// <param name="propertyName">Property name.</param>
        /// <returns>The property's value if the function successfully completed; otherwise, <value>null</value>.</returns>
        public T? Get<T>(Func<Task<T?>> getValueAsync, CancellationToken cancellationToken = default(CancellationToken),
            ITaskListener taskListener = null, [CallerMemberName] string propertyName = null)
            where T : struct
        {
            if (getValueAsync == null)
                throw new ArgumentNullException("getValueAsync");
            if (taskListener == null)
                taskListener = AggregateTaskListener.Empty;
            return DoGetProperty(ct => getValueAsync(), cancellationToken, taskListener, propertyName);
        }

        /// <summary>
        /// Asynchronously gets the value of a property.
        /// </summary>
        /// <typeparam name="T">Property type.</typeparam>
        /// <param name="getValueAsync">Asynchronous function to get the value.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="taskListener">Task listener.</param>
        /// <param name="propertyName">Property name.</param>
        /// <returns>The property's value if the function successfully completed; otherwise, <value>null</value>.</returns>
        public T Get<T>(Func<CancellationToken, Task<T>> getValueAsync, CancellationToken cancellationToken = default(CancellationToken),
            ITaskListener taskListener = null, [CallerMemberName] string propertyName = null)
            where T : class
        {
            if (getValueAsync == null)
                throw new ArgumentNullException("getValueAsync");
            if (taskListener == null)
                taskListener = AggregateTaskListener.Empty;
            return DoGetProperty(getValueAsync, cancellationToken, taskListener, propertyName);
        }

        /// <summary>
        /// Asynchronously gets the value of a property.
        /// </summary>
        /// <typeparam name="T">Property type.</typeparam>
        /// <param name="getValueAsync">Asynchronous function to get the value.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="taskListener">Task listener.</param>
        /// <param name="propertyName">Property name.</param>
        /// <returns>The property's value if the function successfully completed; otherwise, <value>null</value>.</returns>
        public T? Get<T>(Func<CancellationToken, Task<T?>> getValueAsync, CancellationToken cancellationToken = default(CancellationToken),
            ITaskListener taskListener = null, [CallerMemberName] string propertyName = null)
            where T : struct
        {
            if (getValueAsync == null)
                throw new ArgumentNullException("getValueAsync");
            if (taskListener == null)
                taskListener = AggregateTaskListener.Empty;
            return DoGetProperty(getValueAsync, cancellationToken, taskListener, propertyName);
        }

        /// <summary>
        /// Invalidates a specified property or the entire entity.
        /// </summary>
        /// <param name="propertyName">The name of the property to invalidate, or <value>null</value>
        /// or <see cref="String.Empty"/> to invalidate the entire entity.</param>
        public void Invalidate(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                _properties.Clear();
            else
                _properties.Remove(propertyName);
            _onPropertyChanged(propertyName);
        }

        internal T DoGetProperty<T>(Func<T> getValue, string propertyName)
        {
            T value;
            if (!_properties.TryGetValue(propertyName, out value))
                value = DoDoGetProperty(getValue, propertyName);
            return value;
        }

        private T DoDoGetProperty<T>(Func<T> getValue, string propertyName)
        {
            T value = getValue();
            _properties.Add(propertyName, value);
            return value;
        }

        internal T DoGetProperty<T>(Func<CancellationToken, Task<T>> getValueAsync, CancellationToken cancellationToken, ITaskListener taskListener, string propertyName)
        {
            T value;
            if (!_properties.TryGetValue(propertyName, out value))
                DoDoGetProperty(getValueAsync, cancellationToken, taskListener, propertyName);
            return value;
        }

        private void DoDoGetProperty<T>(Func<CancellationToken, Task<T>> getValueAsync, CancellationToken cancellationToken, ITaskListener taskListener, string propertyName)
        {
            _properties.Add(propertyName, null);
            var taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            TaskEx.Run(() => DoGetPropertyAsync(getValueAsync, cancellationToken, taskListener))
                .ContinueWith(task => OnGetPropertyCompleted(task, taskListener, propertyName),
                    cancellationToken, TaskContinuationOptions.None, taskScheduler);
        }

        private static async Task<T> DoGetPropertyAsync<T>(Func<CancellationToken, Task<T>> getValueAsync,
            CancellationToken cancellationToken, ITaskListener taskListener)
        {
            cancellationToken.ThrowIfCancellationRequested();
            taskListener.NotifyTaskStarting();
            return await getValueAsync(cancellationToken).ConfigureAwait(false);
        }

        private void OnGetPropertyCompleted<T>(Task<T> task, ITaskListener taskListener, string propertyName)
        {
            switch (task.Status)
            {
                case TaskStatus.RanToCompletion:
                    OnGetPropertyRanToCompletion(task.Result, taskListener, propertyName);
                    break;
                case TaskStatus.Canceled:
                    OnGetPropertyCanceled(taskListener, propertyName);
                    break;
                case TaskStatus.Faulted:
                    OnGetPropertyFaulted(taskListener, propertyName);
                    break;
                default:
                    break;
            }
        }

        private void OnGetPropertyRanToCompletion<T>(T value, ITaskListener taskListener, string propertyName)
        {
            if (!object.Equals(value, null))
            {
                _properties.SetValue(propertyName, value);
                _onPropertyChanged(propertyName);
            }
            taskListener.NotifyTaskCompleted(true);
        }

        private void OnGetPropertyCanceled(ITaskListener taskListener, string propertyName)
        {
            _properties.Remove(propertyName);
            taskListener.NotifyTaskCompleted(null);
        }

        private void OnGetPropertyFaulted(ITaskListener taskListener, string propertyName)
        {
            _properties.Remove(propertyName);
            taskListener.NotifyTaskCompleted(false);
        }
    }
}
