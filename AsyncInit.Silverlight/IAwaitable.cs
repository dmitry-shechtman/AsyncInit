using Microsoft.Runtime.CompilerServices;

namespace Ditto.AsyncInit
{
    /// <summary>
    /// Interface for awaitable types.
    /// </summary>
    public interface IAwaitable
    {
        /// <summary>
        /// Gets an awaiter used to await this object.
        /// </summary>
        /// <returns>An awaiter instance.</returns>
        TaskAwaiter GetAwaiter();
    }

    /// <summary>
    /// Interface for awaitable types.
    /// </summary>
    /// <typeparam name="TResult">The result for the task.</typeparam>
    public interface IAwaitable<TResult>
    {
        /// <summary>
        /// Gets an awaiter used to await this object.
        /// </summary>
        /// <returns>An awaiter instance.</returns>
        TaskAwaiter<TResult> GetAwaiter();
    }
}
