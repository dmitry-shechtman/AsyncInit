using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ditto.AsyncInit.Services.Internal
{
    /// <summary>
    /// Strategy matching typed initialization arguments.
    /// </summary>
    internal class StaticArgumentsStrategy : IArgumentsStrategy
    {
        /// <summary>
        /// Strategy matching empty arguments.
        /// </summary>
        public static readonly StaticArgumentsStrategy Empty = new StaticArgumentsStrategy(AsyncInitArgs.Empty);

        private readonly AsyncInitArgs _args;

        /// <summary>
        /// Creates a new static strategy.
        /// </summary>
        /// <param name="args">Arguments.</param>
        public StaticArgumentsStrategy(AsyncInitArgs args)
        {
            this._args = args;
        }

        /// <summary>
        /// Validates argument types.
        /// </summary>
        /// <param name="types">The types of the arguments.</param>
        public bool IsMatch(Type[] types)
        {
            return TypeArrayEqualityComparer.Instance.Equals(types, _args.Types);
        }

        /// <summary>
        /// Gets an adjusted argument count.
        /// </summary>
        /// <param name="types">The types of the arguments.</param>
        public int GetCount(Type[] types)
        {
            return _args.Count;
        }

        /// <summary>
        /// Asynchronously gets the arguments.
        /// </summary>
        /// <param name="container">Container strategy (ignored).</param>
        /// <param name="types">The types of the arguments.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task<object[]> GetAsync(IContainerStrategy container, Type[] types, CancellationToken cancellationToken)
        {
            return TaskEx.FromResult(_args.Arguments);
        }
    }
}
