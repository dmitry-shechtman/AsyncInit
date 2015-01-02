using Ditto.AsyncInit.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ditto.AsyncInit.Unity
{
    /// <summary>
    /// Adds a set of asynchronous resolution methods to <see cref="IUnityContainer"/>.
    /// </summary>
    public static class UnityResolveAsyncTypeExtensions
    {
        /// <summary>
        /// Resolves and asynchronously initializes an instance.
        /// </summary>
        /// <typeparam name="T">The type of object to resolve.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="overrides">Resolver overrides.</param>
        public static Task<T> ResolveAsync<T>(this IUnityContainer container, params ResolverOverride[] overrides)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            return container.Resolve<IAsyncInitializer<T>>(overrides).AsTask();
        }

        /// <summary>
        /// Resolves and asynchronously initializes an instance.
        /// </summary>
        /// <typeparam name="T">The type of object to resolve.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="overrides">Resolver overrides.</param>
        public static Task<T> ResolveAsync<T>(this IUnityContainer container, CancellationToken cancellationToken, params ResolverOverride[] overrides)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            return container.Resolve<IAsyncInitializer<T>>(overrides).AsTask(cancellationToken);
        }

        /// <summary>
        /// Resolves and asynchronously initializes an instance.
        /// </summary>
        /// <typeparam name="T">The type of object to resolve.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="name">The name used for registration.</param>
        /// <param name="overrides">Resolver overrides.</param>
        public static Task<T> ResolveAsync<T>(this IUnityContainer container, string name, params ResolverOverride[] overrides)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            return container.Resolve<IAsyncInitializer<T>>(name, overrides).AsTask();
        }

        /// <summary>
        /// Resolves and asynchronously initializes an instance.
        /// </summary>
        /// <typeparam name="T">The type of object to resolve.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="name">The name used for registration.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="overrides">Resolver overrides.</param>
        public static Task<T> ResolveAsync<T>(this IUnityContainer container, string name, CancellationToken cancellationToken, params ResolverOverride[] overrides)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            return container.Resolve<IAsyncInitializer<T>>(name, overrides).AsTask(cancellationToken);
        }

        /// <summary>
        /// Resolves and asynchronously initializes an instance.
        /// </summary>
        /// <typeparam name="T">The type of object to resolve.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="args">Initialization arguments.</param>
        /// <param name="overrides">Resolver overrides.</param>
        public static Task<T> ResolveAsync<T>(this IUnityContainer container, AsyncInitArgs args, params ResolverOverride[] overrides)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            overrides = overrides.Concat(CreateDependencyOverrides(args)).ToArray();
            return container.Resolve<IAsyncInitializer<T>>(overrides).AsTask();
        }

        /// <summary>
        /// Resolves and asynchronously initializes an instance.
        /// </summary>
        /// <typeparam name="T">The type of object to resolve.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="args">Initialization arguments.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="overrides">Resolver overrides.</param>
        public static Task<T> ResolveAsync<T>(this IUnityContainer container, AsyncInitArgs args, CancellationToken cancellationToken, params ResolverOverride[] overrides)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            overrides = overrides.Concat(CreateDependencyOverrides(args)).ToArray();
            return container.Resolve<IAsyncInitializer<T>>(overrides).AsTask(cancellationToken);
        }

        /// <summary>
        /// Resolves and asynchronously initializes an instance.
        /// </summary>
        /// <typeparam name="T">The type of object to resolve.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="name">The name used for registration.</param>
        /// <param name="args">Initialization arguments.</param>
        /// <param name="overrides">Resolver overrides.</param>
        public static Task<T> ResolveAsync<T>(this IUnityContainer container, string name, AsyncInitArgs args, params ResolverOverride[] overrides)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            overrides = overrides.Concat(CreateDependencyOverrides(args)).ToArray();
            return container.Resolve<IAsyncInitializer<T>>(name, overrides).AsTask();
        }

        /// <summary>
        /// Resolves and asynchronously initializes an instance.
        /// </summary>
        /// <typeparam name="T">The type of object to resolve.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="name">The name used for registration.</param>
        /// <param name="args">Initialization arguments.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="overrides">Resolver overrides.</param>
        public static Task<T> ResolveAsync<T>(this IUnityContainer container, string name, AsyncInitArgs args, CancellationToken cancellationToken, params ResolverOverride[] overrides)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            overrides = overrides.Concat(CreateDependencyOverrides(args)).ToArray();
            return container.Resolve<IAsyncInitializer<T>>(name, overrides).AsTask(cancellationToken);
        }

		private static IEnumerable<DependencyOverride> CreateDependencyOverrides(AsyncInitArgs args)
		{
            if (args == null)
                throw new ArgumentNullException("args");
			for (int i = 0; i < args.Count; i++)
				yield return new DependencyOverride(args.Types[i], args.Arguments[i]);
		}
	}
}
