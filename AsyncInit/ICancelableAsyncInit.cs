using System.Threading;
using System.Threading.Tasks;

namespace Ditto.AsyncInit
{
    /// <summary>
    /// Interface for asynchronously initialized types supporting cancellation.
    /// </summary>
    public interface ICancelableAsyncInit
    {
        /// <summary>
        /// Asynchronously initializes an instance.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A Task capturing the initialization.</returns>
        Task InitAsync(CancellationToken cancellationToken);
    }

    /// <summary>
    /// Interface for asynchronously initialized types supporting cancellation.
    /// </summary>
    /// <typeparam name="TArg"></typeparam>
    public interface ICancelableAsyncInit<TArg>
    {
        /// <summary>
        /// Asynchronously initializes an instance.
        /// </summary>
        /// <param name="arg">The initialization argument.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A Task capturing the initialization.</returns>
        Task InitAsync(TArg arg, CancellationToken cancellationToken);
    }
}
