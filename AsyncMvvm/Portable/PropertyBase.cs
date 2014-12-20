using System;

namespace Ditto.AsyncMvvm
{
    /// <summary>
    /// Base class for properties.
    /// </summary>
    public abstract class PropertyBase<T> : IProperty
    {
        private readonly Action<T, string> _onPropertyChanged;
        private T _value;
        private bool _isValueValid;

        /// <summary>
        /// Creates a new property instance.
        /// </summary>
        /// <param name="onPropertyChanged">Property change notification delegate.</param>
        protected PropertyBase(Action<T, string> onPropertyChanged)
        {
            this._onPropertyChanged = onPropertyChanged;
        }

        /// <summary>
        /// Invalidates the property.
        /// </summary>
        /// <param name="isNotify">Indicates whether the notification delegate will be invoked.</param>
        /// <param name="propertyName">The name of the property.</param>
        public void Invalidate(bool isNotify, string propertyName)
        {
            _value = default(T);
            _isValueValid = false;
            if (isNotify)
                NotifyValueChanged(propertyName);
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        protected T DoGetValue()
        {
            return _value;
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="value">The new property value.</param>
        /// <param name="propertyName">The name of the property.</param>
        protected void DoSetValue(T value, string propertyName)
        {
            if (!object.Equals(_value, value))
            {
                DoSetValue(value);
                NotifyValueChanged(propertyName);
            }
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="value">The new property value.</param>
        protected void DoSetValue(T value)
        {
            _value = value;
            _isValueValid = true;
        }

        /// <summary>
        /// Indicates whether the property value is valid.
        /// </summary>
        protected bool IsValueValid
        {
            get { return _isValueValid; }
        }

        private void NotifyValueChanged(string propertyName)
        {
            _onPropertyChanged(_value, propertyName);
        }
    }
}
