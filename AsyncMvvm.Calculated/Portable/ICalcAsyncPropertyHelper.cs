using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Ditto.AsyncMvvm.Calculated
{
    /// <summary>
    /// Interface for asynchronous and calculated property helpers.
    /// </summary>
    public interface ICalcAsyncPropertyHelper : IAsyncPropertyHelper
    {
        /// <summary>
        /// Gets the value of a trigger property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="value">The initial value of the property.</param>
        /// <param name="comparer">The optional equality comparer.</param>
        /// <param name="propertyName">The name of the property.</param>
        T Get<T>(T value, IEqualityComparer<T> comparer = null, [CallerMemberName] string propertyName = null);

        /// <summary>
        /// Sets the value of a trigger property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="value">The new value of the property.</param>
        /// <param name="comparer">The optional equality comparer.</param>
        /// <param name="propertyName">The name of the property.</param>
        void Set<T>(T value, IEqualityComparer<T> comparer = null, [CallerMemberName] string propertyName = null);

        /// <summary>
        /// Gets the value of a calculated property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="calculateValue">The delegate used to calculate the property value.</param>
        /// <param name="propertyName">The name of the property.</param>
        T Calculated<T>(Func<T> calculateValue, [CallerMemberName] string propertyName = null);
    }
}
