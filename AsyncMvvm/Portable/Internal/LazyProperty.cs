using System;
using System.Collections.Generic;

namespace Ditto.AsyncMvvm.Internal
{
    /// <summary>
    /// Lazy property.
    /// </summary>
    /// <typeparam name="T">The type of the property value.</typeparam>
    public class LazyProperty<T> : PropertyBase<T>
    {
        private readonly Func<T> _getValue;

        /// <summary>
        /// Creates a new lazy property instance.
        /// </summary>
        /// <param name="onValueChanged">Value change notification delegate.</param>
        /// <param name="getValue">The delegate used to calculate the property value.</param>
        /// <param name="comparer">The optional equality comparer.</param>
        public LazyProperty(Action<T, string> onValueChanged, Func<T> getValue, IEqualityComparer<T> comparer)
            : base(onValueChanged, comparer)
        {
            this._getValue = getValue;
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        public T GetValue()
        {
            if (!IsValueValid)
                CalculateValue();
            return DoGetValue();
        }

        private void CalculateValue()
        {
            var value = _getValue();
            DoSetValue(value);
        }
    }
}
