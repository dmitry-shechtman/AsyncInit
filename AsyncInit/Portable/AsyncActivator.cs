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
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
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
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
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
        /// <typeparam name="TArg">The type of the initialization argument.</typeparam>
        /// <param name="arg">The initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
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
        /// <typeparam name="TArg">The type of the initialization argument.</typeparam>
        /// <param name="arg">The initialization argument.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        public static async Task<T> CreateAsync<T, TArg>(TArg arg, CancellationToken cancellationToken)
            where T : ICancelableAsyncInit<TArg>
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(arg, cancellationToken).ConfigureAwait(false);
            return value;
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create (must implement <see cref="IAsyncInit{TArg1, TArg2}"/>).</typeparam>
        /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        public static async Task<T> CreateAsync<T, TArg1, TArg2>(TArg1 arg1, TArg2 arg2)
            where T : IAsyncInit<TArg1, TArg2>
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(arg1, arg2).ConfigureAwait(false);
            return value;
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create (must implement <see cref="ICancelableAsyncInit{TArg1, TArg2}"/>).</typeparam>
        /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        public static async Task<T> CreateAsync<T, TArg1, TArg2>(TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken)
            where T : ICancelableAsyncInit<TArg1, TArg2>
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(arg1, arg2, cancellationToken).ConfigureAwait(false);
            return value;
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create (must implement <see cref="IAsyncInit{TArg1, TArg2, TArg3}"/>).</typeparam>
        /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
        /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        public static async Task<T> CreateAsync<T, TArg1, TArg2, TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3)
            where T : IAsyncInit<TArg1, TArg2, TArg3>
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(arg1, arg2, arg3).ConfigureAwait(false);
            return value;
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create (must implement <see cref="ICancelableAsyncInit{TArg1, TArg2, TArg3}"/>).</typeparam>
        /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
        /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        public static async Task<T> CreateAsync<T, TArg1, TArg2, TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken)
            where T : ICancelableAsyncInit<TArg1, TArg2, TArg3>
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(arg1, arg2, arg3, cancellationToken).ConfigureAwait(false);
            return value;
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create (must implement <see cref="IAsyncInit{TArg1, TArg2, TArg3, TArg4}"/>).</typeparam>
        /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
        /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
        /// <typeparam name="TArg4">The type of the fourth initialization argument.</typeparam>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        public static async Task<T> CreateAsync<T, TArg1, TArg2, TArg3, TArg4>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
            where T : IAsyncInit<TArg1, TArg2, TArg3, TArg4>
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(arg1, arg2, arg3, arg4).ConfigureAwait(false);
            return value;
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create (must implement <see cref="ICancelableAsyncInit{TArg1, TArg2, TArg3, TArg4}"/>).</typeparam>
        /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
        /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
        /// <typeparam name="TArg4">The type of the fourth initialization argument.</typeparam>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        public static async Task<T> CreateAsync<T, TArg1, TArg2, TArg3, TArg4>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken)
            where T : ICancelableAsyncInit<TArg1, TArg2, TArg3, TArg4>
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(arg1, arg2, arg3, arg4, cancellationToken).ConfigureAwait(false);
            return value;
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create (must implement <see cref="IAsyncInit{TArg1, TArg2, TArg3, TArg4, TArg5}"/>).</typeparam>
        /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
        /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
        /// <typeparam name="TArg4">The type of the fourth initialization argument.</typeparam>
        /// <typeparam name="TArg5">The type of the fifth initialization argument.</typeparam>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="arg5">The fifth initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        public static async Task<T> CreateAsync<T, TArg1, TArg2, TArg3, TArg4, TArg5>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
            where T : IAsyncInit<TArg1, TArg2, TArg3, TArg4, TArg5>
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(arg1, arg2, arg3, arg4, arg5).ConfigureAwait(false);
            return value;
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create (must implement <see cref="ICancelableAsyncInit{TArg1, TArg2, TArg3, TArg4, TArg5}"/>).</typeparam>
        /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
        /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
        /// <typeparam name="TArg4">The type of the fourth initialization argument.</typeparam>
        /// <typeparam name="TArg5">The type of the fifth initialization argument.</typeparam>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="arg5">The fifth initialization argument.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        public static async Task<T> CreateAsync<T, TArg1, TArg2, TArg3, TArg4, TArg5>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken)
            where T : ICancelableAsyncInit<TArg1, TArg2, TArg3, TArg4, TArg5>
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(arg1, arg2, arg3, arg4, arg5, cancellationToken).ConfigureAwait(false);
            return value;
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create (must implement <see cref="IAsyncInit{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6}"/>).</typeparam>
        /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
        /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
        /// <typeparam name="TArg4">The type of the fourth initialization argument.</typeparam>
        /// <typeparam name="TArg5">The type of the fifth initialization argument.</typeparam>
        /// <typeparam name="TArg6">The type of the sixth initialization argument.</typeparam>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="arg5">The fifth initialization argument.</param>
        /// <param name="arg6">The sixth initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        public static async Task<T> CreateAsync<T, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
            where T : IAsyncInit<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(arg1, arg2, arg3, arg4, arg5, arg6).ConfigureAwait(false);
            return value;
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create (must implement <see cref="ICancelableAsyncInit{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6}"/>).</typeparam>
        /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
        /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
        /// <typeparam name="TArg4">The type of the fourth initialization argument.</typeparam>
        /// <typeparam name="TArg5">The type of the fifth initialization argument.</typeparam>
        /// <typeparam name="TArg6">The type of the sixth initialization argument.</typeparam>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="arg5">The fifth initialization argument.</param>
        /// <param name="arg6">The sixth initialization argument.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        public static async Task<T> CreateAsync<T, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken)
            where T : ICancelableAsyncInit<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(arg1, arg2, arg3, arg4, arg5, arg6, cancellationToken).ConfigureAwait(false);
            return value;
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create (must implement <see cref="IAsyncInit{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7}"/>).</typeparam>
        /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
        /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
        /// <typeparam name="TArg4">The type of the fourth initialization argument.</typeparam>
        /// <typeparam name="TArg5">The type of the fifth initialization argument.</typeparam>
        /// <typeparam name="TArg6">The type of the sixth initialization argument.</typeparam>
        /// <typeparam name="TArg7">The type of the seventh initialization argument.</typeparam>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="arg5">The fifth initialization argument.</param>
        /// <param name="arg6">The sixth initialization argument.</param>
        /// <param name="arg7">The seventh initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        public static async Task<T> CreateAsync<T, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
            where T : IAsyncInit<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7).ConfigureAwait(false);
            return value;
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create (must implement <see cref="ICancelableAsyncInit{TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7}"/>).</typeparam>
        /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
        /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
        /// <typeparam name="TArg4">The type of the fourth initialization argument.</typeparam>
        /// <typeparam name="TArg5">The type of the fifth initialization argument.</typeparam>
        /// <typeparam name="TArg6">The type of the sixth initialization argument.</typeparam>
        /// <typeparam name="TArg7">The type of the seventh initialization argument.</typeparam>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="arg5">The fifth initialization argument.</param>
        /// <param name="arg6">The sixth initialization argument.</param>
        /// <param name="arg7">The seventh initialization argument.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        public static async Task<T> CreateAsync<T, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken)
            where T : ICancelableAsyncInit<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, cancellationToken).ConfigureAwait(false);
            return value;
        }

    }
}
