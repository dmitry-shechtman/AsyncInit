using Ditto.AsyncInit.Services.Internal;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ditto.AsyncInit.Services
{
    /// <summary>
    /// Base class for asynchronous initializers using a dependency injection container.
    /// </summary>
    /// <typeparam name="TFrom">The requested type.</typeparam>
    /// <typeparam name="TTo">The actual type.</typeparam>
    /// <typeparam name="TContainer">The type of the container strategy.</typeparam>
    public abstract partial class ContainerAsyncInitializerBase<TFrom, TTo, TContainer> : AsyncInitializer<TFrom, TTo>
        where TTo : TFrom
        where TContainer : IContainerStrategy
    {
        private Task<TFrom> _task;

        /// <summary>
        /// Creates a new initializer with resolved initialization arguments.
        /// </summary>
        protected ContainerAsyncInitializerBase()
            : base(ResolveArgumentsStrategy.Instance)
        {
        }

        /// <summary>
        /// Creates a new initializer with typed initialization arguments.
        /// </summary>
        /// <param name="args">Arguments.</param>
        protected ContainerAsyncInitializerBase(AsyncInitArgs args)
            : base(args)
        {
        }

        /// <summary>
        /// Dependency injection container strategy.
        /// </summary>
        public abstract TContainer ContainerStrategy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a cancelable task capturing the initialization.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        public override Task<TFrom> AsTask(CancellationToken cancellationToken)
        {
            if (_task == null)
            {
                lock (this)
                {
                    _task = _task ?? base.AsTask(cancellationToken);
                }
            }
            return _task;
        }

        /// <summary>
        /// Asynchronously creates, initializes and builds up an instance of <typeparamref name="TTo"/>.
        /// using one of the specified initialization interface types.
        /// </summary>
        /// <param name="initTypes">Initialization types.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        protected override async Task<TFrom> CreateAsync(IEnumerable<Type> initTypes, CancellationToken cancellationToken)
        {
            List<Exception> exceptions = new List<Exception>();
            foreach (var initType in initTypes)
            {
                try
                {
                    return await CreateAsync(initType, cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                }
            }
            throw new AsyncInitializerException(typeof(TTo), exceptions);
        }

        /// <summary>
        /// Creates and builds up an instance of <typeparamref name="TTo"/>.
        /// </summary>
        protected override TTo CreateInstance()
        {
            var value = base.CreateInstance();
            ContainerStrategy.BuildUp(value);
            return value;
        }

        /// <summary>
        /// Gets the container strategy.
        /// </summary>
        protected override IContainerStrategy GetContainerStrategy()
        {
            return ContainerStrategy;
        }
    }
}
