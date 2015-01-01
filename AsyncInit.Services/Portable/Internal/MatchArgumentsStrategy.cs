using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ditto.AsyncInit.Services.Internal
{
    /// <summary>
    /// Strategy matching untyped initialization arguments.
    /// </summary>
    internal class MatchArgumentsStrategy : IArgumentsStrategy
    {
        private readonly object[] _args;

        /// <summary>
        /// Creates a new matching strategy.
        /// </summary>
        /// <param name="args">Arguments.</param>
        public MatchArgumentsStrategy(object[] args)
        {
            this._args = args;
        }

        /// <summary>
        /// Validates argument types.
        /// </summary>
        /// <param name="types">The types of the arguments.</param>
        public bool IsMatch(Type[] types)
        {
            return types.Length == _args.Length
                && Enumerable.Range(0, types.Length).All(i => IsMatch(types[i], i));
        }

        /// <summary>
        /// Gets an adjusted argument count.
        /// </summary>
        /// <param name="types">The types of the arguments.</param>
        public int GetCount(Type[] types)
        {
            return types.Length;
        }

        /// <summary>
        /// Asynchronously gets the arguments.
        /// </summary>
        /// <param name="container">Container strategy (ignored).</param>
        /// <param name="types">The types of the arguments.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task<object[]> GetAsync(IContainerStrategy container, Type[] types, CancellationToken cancellationToken)
        {
            return TaskEx.FromResult(_args);
        }

        /// <summary>
        /// Matches a type to an argument.
        /// </summary>
        /// <param name="type">Argument type.</param>
        /// <param name="index">Argument index.</param>
        private bool IsMatch(Type type, int index)
        {
            var arg = _args[index];
            if (arg == null)
                return type.IsValueType || TypeUtilities.IsNullable(type);
            return type.IsAssignableFrom(arg.GetType());
        }
    }
}
