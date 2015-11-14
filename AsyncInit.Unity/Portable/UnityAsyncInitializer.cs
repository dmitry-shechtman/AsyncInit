using Ditto.AsyncInit.Services;
using Microsoft.Practices.Unity;

namespace Ditto.AsyncInit.Unity
{
    /// <summary>
    /// Asynchronous initializer using Unity dependency injection container.
    /// </summary>
    /// <typeparam name="TFrom">The requested type.</typeparam>
    /// <typeparam name="TTo">The actual type.</typeparam>
    internal sealed partial class UnityAsyncInitializer<TFrom, TTo> : ContainerAsyncInitializerBase<TFrom, TTo, UnityContainerStrategy>
        where TTo : TFrom
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnityAsyncInitializer{TFrom,TTo}"/> class with resolved initialization arguments.
        /// </summary>
        [InjectionConstructor]
        public UnityAsyncInitializer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityAsyncInitializer{TFrom,TTo}"/> class with typed initialization arguments.
        /// </summary>
        /// <param name="args">Arguments.</param>
        public UnityAsyncInitializer(AsyncInitArgs args)
            : base(args)
        {
        }

        /// <summary>
        /// Gets or sets the dependency injection container strategy.
        /// </summary>
        /// <value>Container strategy.</value>
        [Dependency]
        public override UnityContainerStrategy ContainerStrategy
        {
            get;
            set;
        }
    }
}
