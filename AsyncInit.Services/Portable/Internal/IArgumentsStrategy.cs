using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ditto.AsyncInit.Services.Internal
{
    /// <summary>
    /// Interface for initialization arguments strategies.
    /// </summary>
    internal interface IArgumentsStrategy
    {
        /// <summary>
        /// Validates argument types.
        /// </summary>
        /// <param name="types">The types of the arguments.</param>
        bool IsMatch(Type[] types);

        /// <summary>
        /// Gets an adjusted argument count.
        /// </summary>
        /// <param name="types">The types of the arguments.</param>
        int GetCount(Type[] types);

        /// <summary>
        /// Asynchronously gets the arguments.
        /// </summary>
        /// <param name="container">Container strategy (or <value>null</value> if none is available).</param>
        /// <param name="types">The types of the arguments.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task<object[]> GetAsync(IContainerStrategy container, Type[] types, CancellationToken cancellationToken);
    }
}
