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
            return DoGet(getValue, propertyName);
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
        {
            if (getValueAsync == null)
                throw new ArgumentNullException("getValueAsync");
            return DoGet(ct => getValueAsync(), cancellationToken, taskListener, propertyName);
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
        {
            if (getValueAsync == null)
                throw new ArgumentNullException("getValueAsync");
            return DoGet(getValueAsync, cancellationToken, taskListener, propertyName);
        }

        /// <summary>
        /// Invalidates a specified property or the entire entity.
        /// </summary>
        /// <param name="propertyName">The name of the property to invalidate, or <value>null</value>
        /// or <see cref="String.Empty"/> to invalidate the entire entity.</param>
        public void Invalidate(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                _properties.Invalidate(false);
                _onPropertyChanged(propertyName);
            }
            else
            {
                var property = GetProperty(propertyName);
                if (property != null)
                    property.Invalidate(true, propertyName);
            }
        }

        /// <summary>
        /// Gets the value of a lazy property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="getValue">The delegate used to calculate the property value.</param>
        /// <param name="propertyName">The name of the property.</param>
        private T DoGet<T>(Func<T> getValue, string propertyName)
        {
            return GetOrAddLazyProperty(getValue, propertyName).GetValue();
        }

        /// <summary>
        /// Gets the value of an asynchronous property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="getValueAsync">The delegate used to calculate the property value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="taskListener">The task listener.</param>
        /// <param name="propertyName">The name of the property.</param>
        private T DoGet<T>(Func<CancellationToken, Task<T>> getValueAsync, CancellationToken cancellationToken, ITaskListener taskListener, string propertyName)
        {
            return GetOrAddAsyncProperty(getValueAsync, propertyName).GetValue(cancellationToken, taskListener, propertyName);
        }

        /// <summary>
        /// Creates a lazy property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="getValue">The delegate used to calculate the property value.</param>
        private LazyProperty<T> CreateLazyProperty<T>(Func<T> getValue)
        {
            return new LazyProperty<T>(NotifyValueChanged, getValue);
        }

        /// <summary>
        /// Creates an asynchronous property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="getValueAsync">The delegate used to calculate the property value.</param>
        private AsyncProperty<T> CreateAsyncProperty<T>(Func<CancellationToken, Task<T>> getValueAsync)
        {
            return new AsyncProperty<T>(NotifyValueChanged, getValueAsync);
        }

        /// <summary>
        /// Retrieves the specified lazy property if it exists; otherwise, creates the lazy property and returns it.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="getValue">The delegate used to calculate the property value.</param>
        /// <param name="propertyName">The name of the property.</param>
        private LazyProperty<T> GetOrAddLazyProperty<T>(Func<T> getValue, string propertyName)
        {
            return GetOrAddProperty(() => CreateLazyProperty(getValue), propertyName);
        }

        /// <summary>
        /// Retrieves the specified asynchronous property if it exists; otherwise, creates the asynchronous property and returns it.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="getValueAsync">The delegate used to calculate the property value.</param>
        /// <param name="propertyName">The name of the property.</param>
        private AsyncProperty<T> GetOrAddAsyncProperty<T>(Func<CancellationToken, Task<T>> getValueAsync, string propertyName)
        {
            return GetOrAddProperty(() => CreateAsyncProperty(getValueAsync), propertyName);
        }

        /// <summary>
        /// Retrieves the specified property if it exists; otherwise, returns <value>null</value>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        private IProperty GetProperty(string propertyName)
        {
            return _properties.GetValueOrDefault(propertyName);
        }

        /// <summary>
        /// Retrieves the specified property if it exists; otherwise, creates the property and returns it.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="createProperty">The delegate used to create the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        private TProperty GetOrAddProperty<TProperty>(Func<TProperty> createProperty, string propertyName)
            where TProperty : IProperty
        {
            return _properties.GetOrAdd(createProperty, propertyName);
        }

        /// <summary>
        /// Notifies on change in property value.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="value">The new value of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        private void NotifyValueChanged<T>(T value, string propertyName)
        {
            _onPropertyChanged(propertyName);
        }
    }
}
