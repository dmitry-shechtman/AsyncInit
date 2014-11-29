using System.Threading;
using System.Threading.Tasks;

namespace DmitryShechtman.Tasks
{
    /// <summary>
    /// Base class for asynchronously initialized types supporting cancellation.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    public abstract class CancelableAsyncInitBase<T> : AsyncInitBase<T>, ICancelableAsyncInit
        where T : CancelableAsyncInitBase<T>
    {
        /// <summary>
        /// Asynchronously creates and initializes an instance.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A Task capturing the initialization.</returns>
        public static Task<T> CreateAsync(CancellationToken cancellationToken)
        {
            return AsyncActivator.CreateAsync<T>(cancellationToken);
        }

        /// <summary>
        /// Asynchronously initializes an instance.
        /// </summary>
        /// <returns>A Task capturing the initialization.</returns>
        protected override Task InitAsync()
        {
            return InitAsync(CancellationToken.None);
        }

        /// <summary>
        /// Asynchronously initializes an instance. Overridden by the deriving type.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A Task capturing the initialization.</returns>
        protected abstract Task InitAsync(CancellationToken cancellationToken);

        Task ICancelableAsyncInit.InitAsync(CancellationToken cancellationToken)
        {
            return InitAsync(cancellationToken);
        }
    }

    /// <summary>
    /// Base class for asynchronously initialized types supporting cancellation.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    /// <typeparam name="TArg">The argument type.</typeparam>
    public abstract class CancelableAsyncInitBase<T, TArg> : AsyncInitBase<T, TArg>, ICancelableAsyncInit<TArg>
        where T : CancelableAsyncInitBase<T, TArg>
    {
        /// <summary>
        /// Asynchronously creates and initializes an instance.
        /// </summary>
        /// <param name="arg">The argument to pass to the object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A Task capturing the initialization.</returns>
        public static Task<T> CreateAsync(TArg arg, CancellationToken cancellationToken)
        {
            return AsyncActivator.CreateAsync<T, TArg>(arg, cancellationToken);
        }

        /// <summary>
        /// Asynchronously initializes an instance.
        /// </summary>
        /// <param name="arg">The initialization argument.</param>
        /// <returns>A Task capturing the initialization.</returns>
        protected override Task InitAsync(TArg arg)
        {
            return InitAsync(arg, CancellationToken.None);
        }

        /// <summary>
        /// Asynchronously initializes an instance. Overridden by the deriving type.
        /// </summary>
        /// <param name="arg">The initialization argument.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A Task capturing the initialization.</returns>
        protected abstract Task InitAsync(TArg arg, CancellationToken cancellationToken);

        Task ICancelableAsyncInit<TArg>.InitAsync(TArg arg, CancellationToken cancellationToken)
        {
            return InitAsync(arg, cancellationToken);
        }
    }
}
