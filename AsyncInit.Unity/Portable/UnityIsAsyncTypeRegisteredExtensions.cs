using Ditto.AsyncInit.Services;
using Microsoft.Practices.Unity;
using System;

namespace Ditto.AsyncInit.Unity
{
    /// <summary>
    /// Adds a set of asynchronous registration check methods to <see cref="IUnityContainer"/>.
    /// </summary>
    public static class UnityIsAsyncTypeRegisteredExtensions
    {
        /// <summary>
        /// Checks if a particular asynchronously initialized type has been registered with the container.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <param name="container">The container.</param>
        /// <returns><c>true</c> if this type has been registered.</returns>
        /// <seealso cref="UnityContainerExtensions.IsRegistered{T}(IUnityContainer)" />
        public static bool IsAsyncTypeRegistered<T>(this IUnityContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            return container.IsRegistered<IAsyncInitializer<T>>();
        }

        /// <summary>
        /// Checks if a particular asynchronously initialized type/name pair has been registered with the container.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="name">The name to check.</param>
        /// <returns><c>true</c> if this type/name pair has been registered.</returns>
        /// <seealso cref="UnityContainerExtensions.IsRegistered{T}(IUnityContainer,String)" />
        public static bool IsAsyncTypeRegistered<T>(this IUnityContainer container, string name)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            return container.IsRegistered<IAsyncInitializer<T>>(name);
        }
    }
}
