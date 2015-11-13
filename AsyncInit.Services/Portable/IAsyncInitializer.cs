using System.Threading;
using System.Threading.Tasks;

namespace Ditto.AsyncInit.Services
{
    /// <summary>
    /// Interface for asynchronous initializers.
    /// </summary>
    /// <typeparam name="T">The type of object to initialize (must implement any of the
    /// <see cref="IAsyncInit"/>/<see cref="ICancelableAsyncInit"/> interfaces).</typeparam>
    public interface IAsyncInitializer<T>
    {
        /// <summary>
        /// Gets a task capturing the initialization.
        /// </summary>
        /// <returns>Task capturing the initialization.</returns>
        Task<T> AsTask();

        /// <summary>
        /// Gets a cancelable task capturing the initialization.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Cancelable task capturing the initialization.</returns>
        Task<T> AsTask(CancellationToken cancellationToken);
    }
}
