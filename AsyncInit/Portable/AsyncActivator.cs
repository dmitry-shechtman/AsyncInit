using System.Threading;
using System.Threading.Tasks;

namespace Ditto.AsyncInit
{
    /// <summary>
    /// Provides factory methods for asynchronously initialized types.
    /// </summary>
    public static class AsyncActivator
    {
        /// <summary>
        /// Asynchronously creates and initializes an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create (must implement <see cref="IAsyncInit"/>).</typeparam>
        /// <returns>A Task capturing the initialization.</returns>
        public static async Task<T> CreateAsync<T>()
            where T : IAsyncInit
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync().ConfigureAwait(false);
            return value;
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create (must implement <see cref="ICancelableAsyncInit"/>).</typeparam>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A Task capturing the initialization.</returns>
        public static async Task<T> CreateAsync<T>(CancellationToken cancellationToken)
            where T : ICancelableAsyncInit
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(cancellationToken).ConfigureAwait(false);
            return value;
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create (must implement <see cref="IAsyncInit{TArg}"/>).</typeparam>
        /// <typeparam name="TArg">The type of the argument to pass.</typeparam>
        /// <param name="arg">The argument to pass to the object.</param>
        /// <returns>A Task capturing the initialization.</returns>
        public static async Task<T> CreateAsync<T, TArg>(TArg arg)
            where T : IAsyncInit<TArg>
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(arg).ConfigureAwait(false);
            return value;
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create (must implement <see cref="ICancelableAsyncInit{TArg}"/>).</typeparam>
        /// <typeparam name="TArg">The type of the argument to pass.</typeparam>
        /// <param name="arg">The argument to pass to the object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A Task capturing the initialization.</returns>
        public static async Task<T> CreateAsync<T, TArg>(TArg arg, CancellationToken cancellationToken)
            where T : ICancelableAsyncInit<TArg>
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(arg, cancellationToken).ConfigureAwait(false);
            return value;
        }
    }
}
