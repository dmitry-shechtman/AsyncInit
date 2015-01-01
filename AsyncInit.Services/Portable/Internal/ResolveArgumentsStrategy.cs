using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Ditto.AsyncInit.Services.Internal
{
    /// <summary>
    /// Strategy for resolving initialization arguments using a dependency injection container.
    /// </summary>
    internal class ResolveArgumentsStrategy : IArgumentsStrategy
    {
        private static readonly ResolveArgumentsStrategy _instance = new ResolveArgumentsStrategy();

        public static ResolveArgumentsStrategy Instance
        {
            get { return _instance; }
        }

        private ResolveArgumentsStrategy()
        {
        }

        /// <summary>
        /// Validates argument types.
        /// </summary>
        /// <param name="types">The types of the arguments.</param>
        public bool IsMatch(Type[] types)
        {
            return true;
        }

        /// <summary>
        /// Gets an adjusted argument count.
        /// </summary>
        /// <param name="types">The types of the arguments.</param>
        public int GetCount(Type[] types)
        {
            return types.Sum(t => DoGetCount(t));
        }

        /// <summary>
        /// Asynchronously resolves the arguments.
        /// </summary>
        /// <param name="container">Container strategy.</param>
        /// <param name="types">The types of the arguments.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task<object[]> GetAsync(IContainerStrategy container, Type[] types, CancellationToken cancellationToken)
        {
            return TaskEx.WhenAll(types.Select(type =>
                ResolveAsync(container, type, cancellationToken)));
        }

        /// <summary>
        /// Gets an adjusted type argument count for the specified type.
        /// </summary>
        /// <param name="type">Argument type.</param>
        private int DoGetCount(Type type)
        {
            var tupleType = GetTupleType(type);
            if (tupleType == null)
                return 1;
            var argTypes = tupleType.GetGenericArguments();
            return GetCount(argTypes);
        }

        /// <summary>
        /// Gets a base tuple type for the specified type.
        /// </summary>
        /// <param name="type">Argument type.</param>
        /// <returns>The constructed <see cref="Tuple"/> type from which the specified type inherits, or <value>null</value>.</returns>
        private static Type GetTupleType(Type type)
        {
            if (type == null || TypeUtilities.IsTuple(type))
                return type;
            var baseType = type.BaseType;
            return GetTupleType(baseType);
        }

        /// <summary>
        /// Resolves an object from the container.
        /// </summary>
        /// <param name="container">Container strategy.</param>
        /// <param name="type">The type of object to resolve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        private async Task<object> ResolveAsync(IContainerStrategy container, Type type, CancellationToken cancellationToken)
        {
            object value;
            if (container.TryResolve(type, out value))
                return value;
            return await ResolveInitializerAsync(container, type, cancellationToken);
        }

        /// <summary>
        /// Resolves an instance of an asynchronously initialized type from the container.
        /// </summary>
        /// <param name="container">Container strategy.</param>
        /// <param name="type">The type of object to resolve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        private static Task<object> ResolveInitializerAsync(IContainerStrategy container, Type type, CancellationToken cancellationToken)
        {
            var initializerType = typeof(IAsyncInitializer<>).MakeGenericType(type);
            object initializer;
            if (!container.TryResolve(initializerType, out initializer))
                throw new AsyncInitializerException(type, "Resolution failed.");
            var getTask = initializerType.GetMethod("AsTask",
                new[] { typeof(CancellationToken) });
            var task = getTask.Invoke(initializer, new object[] { cancellationToken });
            return GetResultAsync(task);
        }

        /// <summary>
        /// Gets the result of an asynchronous task whith cancellation exception unwrapped.
        /// </summary>
        /// <param name="task">The task.</param>
        private static Task<object> GetResultAsync(object task)
        {
            var getAwaiter = task.GetType().GetMethod("GetAwaiter");
            var awaiter = getAwaiter.Invoke(task, null);
            var getResult = awaiter.GetType().GetMethod("GetResult");
            try
            {
                var result = getResult.Invoke(awaiter, null);
                return TaskEx.FromResult(result);
            }
            catch (TargetInvocationException ex)
            {
                var ex2 = ex.InnerException as TaskCanceledException;
                if (ex2 != null)
                    throw ex2;
                throw;
            }
        }
    }
}
