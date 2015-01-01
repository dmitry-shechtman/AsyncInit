using Ditto.AsyncInit.Internal;
using Ditto.AsyncInit.Services.Internal;
using Microsoft.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ditto.AsyncInit.Services
{
    /// <summary>
    /// Asynchronous initializer.
    /// </summary>
    /// <typeparam name="TFrom">The requested type.</typeparam>
    /// <typeparam name="TTo">The actual type.</typeparam>
    public class AsyncInitializer<TFrom, TTo> : IAsyncInitializer<TFrom>
        where TTo : TFrom
    {
        /// <summary>
        /// An initializer with no initialization arguments.
        /// </summary>
        public static readonly AsyncInitializer<TFrom, TTo> Empty = new AsyncInitializer<TFrom, TTo>(AsyncInitArgs.Empty);

        private readonly IArgumentsStrategy _arguments;

        /// <summary>
        /// Creates a new initializer with typed initialization arguments.
        /// </summary>
        /// <param name="args">Arguments.</param>
        public AsyncInitializer(AsyncInitArgs args)
            : this(new StaticArgumentsStrategy(args))
        {
        }

        /// <summary>
        /// Creates a new initializer with the specified arguments strategy.
        /// </summary>
        /// <param name="arguments">Arguments strategy.</param>
        internal AsyncInitializer(IArgumentsStrategy arguments)
        {
            this._arguments = arguments;
        }

        /// <summary>
        /// Gets an awaiter used to await the initialization.
        /// </summary>
        TaskAwaiter<TFrom> IAsyncInitializer<TFrom>.GetAwaiter()
        {
            return AsTask().GetAwaiter();
        }

        /// <summary>
        /// Gets a task capturing the initialization.
        /// </summary>
        public Task<TFrom> AsTask()
        {
            return AsTask(CancellationToken.None);
        }

        /// <summary>
        /// Gets a cancelable task capturing the initialization.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        public virtual Task<TFrom> AsTask(CancellationToken cancellationToken)
        {
            return CreateAsync(cancellationToken);
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of <typeparamref name="TTo"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        private async Task<TFrom> CreateAsync(CancellationToken cancellationToken)
        {
            var initTypes = GetInitTypes();
            try
            {
                return await CreateAsync(initTypes, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (AsyncInitializerException aiException)
            {
                if (aiException.Type == typeof(TTo))
                    throw;
                throw new AsyncInitializerException(typeof(TTo), aiException);
            }
            catch (Exception exception)
            {
                throw new AsyncInitializerException(typeof(TTo), exception);
            }
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of <typeparamref name="TTo"/>
        /// using the first specified initialization interface type.
        /// </summary>
        /// <param name="initTypes">Initialization interface types.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        protected virtual Task<TFrom> CreateAsync(IEnumerable<Type> initTypes, CancellationToken cancellationToken)
        {
            var initType = initTypes.First();
            return CreateAsync(initType, cancellationToken);
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of <typeparamref name="TTo"/>
        /// using the specified initialization interface type.
        /// </summary>
        /// <param name="initType">Initialization interface type.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        protected async Task<TFrom> CreateAsync(Type initType, CancellationToken cancellationToken)
        {
            var argTypes = initType.GetGenericArguments();
            var args = await GetArgumentsAsync(argTypes, cancellationToken);
            return await CreateAsync(initType, args, cancellationToken);
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance of <typeparamref name="TTo"/>
        /// using the specified initialization interface type and initialization arguments.
        /// </summary>
        /// <param name="initType">Initialization interface type.</param>
        /// <param name="args">Initialization arguments</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        private async Task<TFrom> CreateAsync(Type initType, IEnumerable<object> args, CancellationToken cancellationToken)
        {
            var value = CreateInstance();
            var initAsync = initType.GetMethod("InitAsync");
            if (TypeUtilities.IsCancelable(initType))
                args = args.Concat(new object[] { cancellationToken });
            var task = (Task)initAsync.Invoke(value, args.ToArray());
            await task.ConfigureAwait(false);
            return value;
        }

        /// <summary>
        /// Gets the initialization interface types.
        /// </summary>
        private IEnumerable<Type> GetInitTypes()
        {
            if (!typeof(TTo).IsClass || typeof(TTo).IsAbstract)
                throw new AsyncInitializerException(typeof(TTo), "Must be a non-abstract class.");

            var initTypes = typeof(TTo).GetInterfaces()
                .Where(TypeUtilities.IsAsyncInit);
            if (initTypes.Count() == 0)
                throw new AsyncInitializerException(typeof(TTo), "Must implement at least one of the IAsyncAwait/ICancelableAsyncAwait interfaces.");

            initTypes = initTypes
                .Where(IsArgumentsMatch);
            if (initTypes.Count() == 0)
                throw new AsyncInitializerException(typeof(TTo), "Must have matching argument types.");

            return initTypes
                .OrderByDescending(GetInitTypeRank)
                .GroupBy(GetGenericArguments, TypeArrayEqualityComparer.Instance)
                .Select(Enumerable.First);
        }

        /// <summary>
        /// Creates an instance of <typeparamref name="TTo"/>.
        /// </summary>
        protected virtual TTo CreateInstance()
        {
            return Utilities.CreateInstance<TTo>();
        }

        /// <summary>
        /// Asynchronously gets the arguments.
        /// </summary>
        /// <param name="argTypes">The types of the arguments.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        private async Task<object[]> GetArgumentsAsync(Type[] argTypes, CancellationToken cancellationToken)
        {
            IContainerStrategy container = GetContainerStrategy();
            return await _arguments.GetAsync(container, argTypes, cancellationToken);
        }

        /// <summary>
        /// Gets the container strategy.
        /// </summary>
        /// <returns>Container strategy (or <value>null</value> if none is available).</returns>
        protected virtual IContainerStrategy GetContainerStrategy()
        {
            return null;
        }

        /// <summary>
        /// Validates the argument types.
        /// </summary>
        /// <param name="type">The types of the arguments.</param>
        /// <returns><value>true</value> if the argument types match.</returns>
        private bool IsArgumentsMatch(Type type)
        {
            var argTypes = type.GetGenericArguments();
            return _arguments.IsMatch(argTypes);
        }

        /// <summary>
        /// Gets the rank for the specified initialization interface type.
        /// </summary>
        /// <param name="type">Initialization type.</param>
        private int GetInitTypeRank(Type type)
        {
            var argTypes = type.GetGenericArguments();
            var initRank = _arguments.GetCount(argTypes);
            return TypeUtilities.IsCancelable(type)
                ? initRank * 2 + 1
                : initRank * 2;
        }

        /// <summary>
        /// Gets the argument types for the specified initialization interface type.
        /// </summary>
        /// <param name="type">Initialization type.</param>
        private static Type[] GetGenericArguments(Type type)
        {
            return type.GetGenericArguments();
        }
    }
}
