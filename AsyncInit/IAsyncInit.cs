using System.Threading.Tasks;

namespace Ditto.AsyncInit
{
    /// <summary>
    /// Interface for asynchronously initialized types.
    /// </summary>
    public interface IAsyncInit
    {
        /// <summary>
        /// Asynchronously initializes an instance.
        /// </summary>
        /// <returns>A Task capturing the initialization.</returns>
        Task InitAsync();
    }

    /// <summary>
    /// Interface for asynchronously initialized types.
    /// </summary>
    /// <typeparam name="TArg"></typeparam>
    public interface IAsyncInit<TArg>
    {
        /// <summary>
        /// Asynchronously initializes an instance.
        /// </summary>
        /// <param name="arg">The initialization argument.</param>
        /// <returns>A Task capturing the initialization.</returns>
        Task InitAsync(TArg arg);
    }
}
