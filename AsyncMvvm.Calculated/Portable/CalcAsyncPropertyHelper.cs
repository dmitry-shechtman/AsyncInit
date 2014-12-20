using Ditto.AsyncMvvm.Calculated.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Ditto.AsyncMvvm.Calculated
{
    /// <summary>
    /// Asynchronous and calculated property helper.
    /// </summary>
    public class CalcAsyncPropertyHelper : AsyncPropertyHelperBase, ICalcAsyncPropertyHelper
    {
        private readonly CalculatedProperties.PropertyHelper _propertyHelper;

        /// <summary>
        /// Creates a new property helper instance.
        /// </summary>
        /// <param name="onPropertyChanged">Property change notification delegate.</param>
        public CalcAsyncPropertyHelper(Action<string> onPropertyChanged)
            : base(onPropertyChanged)
        {
            this._propertyHelper = new CalculatedProperties.PropertyHelper(NotifyPropertyChanged);
        }

        /// <summary>
        /// Creates a new property helper instance.
        /// </summary>
        /// <param name="onPropertyChanged">Property change notification delegate.</param>
        public CalcAsyncPropertyHelper(Action<PropertyChangedEventArgs> onPropertyChanged)
            : base(Adapt(onPropertyChanged))
        {
            this._propertyHelper = new CalculatedProperties.PropertyHelper(onPropertyChanged);
        }

        /// <summary>
        /// Gets the value of a trigger property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="value">The initial value of the property.</param>
        /// <param name="comparer">The optional equality comparer.</param>
        /// <param name="propertyName">The name of the property.</param>
        public T Get<T>(T value, IEqualityComparer<T> comparer = null, [CallerMemberName] string propertyName = null)
        {
            return Get(() => value, comparer, propertyName);
        }

        /// <summary>
        /// Sets the value of a trigger property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="value">The new value of the property.</param>
        /// <param name="comparer">The optional equality comparer.</param>
        /// <param name="propertyName">The name of the property.</param>
        public void Set<T>(T value, IEqualityComparer<T> comparer = null, [CallerMemberName] string propertyName = null)
        {
            GetOrAddLazyProperty(() => value, comparer, propertyName).SetValue(value, propertyName);
        }

        /// <summary>
        /// Gets the value of a calculated property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="calculateValue">The delegate used to calculate the property value.</param>
        /// <param name="propertyName">The name of the property.</param>
        public T Calculated<T>(Func<T> calculateValue, [CallerMemberName] string propertyName = null)
        {
            return _propertyHelper.Calculated(calculateValue, propertyName);
        }

        /// <summary>
        /// Invalidates the specified property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns><value>true</value> if successful.</returns>
        public override bool Invalidate<T>(string propertyName)
        {
            if (base.Invalidate<T>(propertyName))
                return true;
            var calculatedProperty = _propertyHelper.GetCalculatedProperty<T>(propertyName);
            if (calculatedProperty == null)
                return false;
            calculatedProperty.Invalidate();
            return true;
        }

        /// <summary>
        /// Creates a lazy property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="getValue">The delegate used to calculate the property value.</param>
        /// <param name="comparer">The equality comparer.</param>
        protected override ILazyProperty<T> CreateLazyProperty<T>(Func<T> getValue, IEqualityComparer<T> comparer)
        {
            var property = base.CreateLazyProperty(getValue, comparer);
            return new LazyTriggerProperty<T>(NotifyPropertyChanged, property);
        }

        /// <summary>
        /// Creates an asynchronous property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="getValueAsync">The delegate used to calculate the property value.</param>
        /// <param name="comparer">The equality comparer.</param>
        protected override IAsyncProperty<T> CreateAsyncProperty<T>(Func<CancellationToken, Task<T>> getValueAsync, IEqualityComparer<T> comparer)
        {
            var property = base.CreateAsyncProperty(getValueAsync, comparer);
            return new AsyncTriggerProperty<T>(NotifyPropertyChanged, property);
        }

        /// <summary>
        /// Retrieves the specified property if it exists; otherwise, returns <value>null</value>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        protected override IProperty GetProperty(string propertyName)
        {
            if (propertyName == null)
                throw new ArgumentNullException("propertyName");
            var triggerPropertyName = "$" + propertyName;
            var triggerProperty = _propertyHelper.GetTriggerProperty<IProperty>(triggerPropertyName);
            if (triggerProperty == null)
                return null;
            return triggerProperty.GetValue(triggerPropertyName);
        }

        /// <summary>
        /// Retrieves the specified property if it exists; otherwise, creates the property and returns it.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="createProperty">The delegate used to create the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        protected override TProperty GetOrAddProperty<TProperty>(Func<TProperty> createProperty, string propertyName)
        {
            if (propertyName == null)
                throw new ArgumentNullException("propertyName");
            var triggerPropertyName = "$" + propertyName;
            return (TProperty)_propertyHelper.Get(() => createProperty(), null, triggerPropertyName);
        }

        /// <summary>
        /// Notifies on change in property value.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="value">The new value of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        protected override void NotifyValueChanged<T>(T value, string propertyName)
        {
            var proxy = GetProperty(propertyName) as ITriggerProperty<T>;
            proxy.NotifyValueChanged(value, propertyName);
        }

        /// <summary>
        /// Invalidates the entire entity.
        /// </summary>
        /// <exception cref="NotSupportedException"/>
        protected override void InvalidateEntity()
        {
            throw new NotSupportedException();
        }

        private void NotifyPropertyChanged(PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged(e.PropertyName);
        }

        private static Action<string> Adapt(Action<PropertyChangedEventArgs> onPropertyChanged)
        {
            if (onPropertyChanged == null)
                throw new ArgumentNullException("onPropertyChanged");
            return pn => onPropertyChanged(new PropertyChangedEventArgs(pn));
        }
    }
}
