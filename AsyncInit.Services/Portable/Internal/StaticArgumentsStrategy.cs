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
        /// Initializes a new instance of the <see cref="StaticArgumentsStrategy"/> class.
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
        /// <returns><c>true</c> if the argument types match.</returns>
        public bool IsMatch(Type[] types)
        {
            return TypeArrayEqualityComparer.Instance.Equals(types, _args.Types);
        }

        /// <summary>
        /// Gets an adjusted argument count.
        /// </summary>
        /// <param name="types">The types of the arguments.</param>
        /// <returns>Adjusted argument count.</returns>
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
        /// <returns>Task with the arguments as its result.</returns>
        public Task<object[]> GetAsync(IContainerStrategy container, Type[] types, CancellationToken cancellationToken)
        {
            return TaskEx.FromResult(_args.Arguments);
        }
    }
}
