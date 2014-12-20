using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Ditto.AsyncMvvm
{
    /// <summary>
    /// Asynchronous property helper.
    /// </summary>
    public interface IAsyncPropertyHelper
    {
        /// <summary>
        /// Gets the value of a lazy property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="getValue">The delegate used to calculate the property value.</param>
        /// <param name="comparer">The optional equality comparer.</param>
        /// <param name="propertyName">The name of the property.</param>
        T Get<T>(Func<T> getValue, IEqualityComparer<T> comparer = null, [CallerMemberName] string propertyName = null);

        /// <summary>
        /// Gets the value of an asynchronous property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="getValueAsync">The delegate used to calculate the property value.</param>
        /// <param name="listener">The optional task listener.</param>
        /// <param name="comparer">The optional equality comparer.</param>
        /// <param name="propertyName">The name of the property.</param>
        T Get<T>(Func<Task<T>> getValueAsync, ITaskListener listener = null, IEqualityComparer<T> comparer = null,
            [CallerMemberName] string propertyName = null);

        /// <summary>
        /// Gets the value of an asynchronous property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="getValueAsync">The delegate used to calculate the property value.</param>
        /// <param name="token">The optional cancellation token.</param>
        /// <param name="listener">The optional task listener.</param>
        /// <param name="comparer">The optional equality comparer.</param>
        /// <param name="propertyName">The name of the property.</param>
        T Get<T>(Func<CancellationToken, Task<T>> getValueAsync, CancellationToken token = default(CancellationToken),
            ITaskListener listener = null, IEqualityComparer<T> comparer = null, [CallerMemberName] string propertyName = null);

        /// <summary>
        /// Invalidates a specified property or the entire entity.
        /// </summary>
        /// <param name="propertyName">The name of the property to invalidate, or <value>null</value>
        /// or <see cref="String.Empty"/> to invalidate the entire entity.</param>
        void Invalidate([CallerMemberName] string propertyName = null);

        /// <summary>
        /// Retrieves the specified lazy property if it exists; otherwise, returns <value>null</value>.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        ILazyProperty<T> GetLazyProperty<T>([CallerMemberName] string propertyName = null);

        /// <summary>
        /// Retrieves the specified asynchronous property if it exists; otherwise, returns <value>null</value>.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        IAsyncProperty<T> GetAsyncProperty<T>([CallerMemberName] string propertyName = null);

        /// <summary>
        /// Retrieves the specified lazy property if it exists; otherwise, creates the lazy property and returns it.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="getValue">The delegate used to calculate the property value.</param>
        /// <param name="comparer">The optional equality comparer.</param>
        /// <param name="propertyName">The name of the property.</param>
        ILazyProperty<T> GetOrAddLazyProperty<T>(Func<T> getValue, IEqualityComparer<T> comparer = null,
            [CallerMemberName] string propertyName = null);

        /// <summary>
        /// Retrieves the specified asynchronous property if it exists; otherwise, creates the asynchronous property and returns it.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="getValueAsync">The delegate used to calculate the property value.</param>
        /// <param name="comparer">The optional equality comparer.</param>
        /// <param name="propertyName">The name of the property.</param>
        IAsyncProperty<T> GetOrAddAsyncProperty<T>(Func<CancellationToken, Task<T>> getValueAsync,
            IEqualityComparer<T> comparer = null, [CallerMemberName] string propertyName = null);
    }
}
