using Ditto.AsyncInit.Services;
using Microsoft.Practices.Unity;

namespace Ditto.AsyncInit.Unity
{
    /// <summary>
    /// Asynchronous initializer using Unity dependency injection container.
    /// </summary>
    /// <typeparam name="TFrom">The requested type.</typeparam>
    /// <typeparam name="TTo">The actual type.</typeparam>
    public sealed partial class UnityAsyncInitializer<TFrom, TTo> : ContainerAsyncInitializerBase<TFrom, TTo, UnityContainerStrategy>
        where TTo : TFrom
    {
        /// <summary>
        /// Creates a new initializer with resolved initialization arguments.
        /// </summary>
        [InjectionConstructor]
        public UnityAsyncInitializer()
        {
        }

        /// <summary>
        /// Creates a new initializer with typed initialization arguments.
        /// </summary>
        /// <param name="args">Arguments.</param>
        public UnityAsyncInitializer(AsyncInitArgs args)
            : base(args)
        {
        }

        /// <summary>
        /// Dependency injection container strategy.
        /// </summary>
        [Dependency]
        public override UnityContainerStrategy ContainerStrategy
        {
            get;
            set;
        }
    }
}
