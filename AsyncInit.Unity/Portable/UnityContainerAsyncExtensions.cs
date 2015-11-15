using Ditto.AsyncInit.Services;
using Microsoft.Practices.Unity;
using System;

namespace Ditto.AsyncInit.Unity
{
    /// <summary>
    /// Adds asynchronous capabilities to <see cref="IUnityContainer"/>.
    /// </summary>
    /// <conceptualLink target="30e16988-88d9-400d-bf76-21885513e5df" />
    /// <conceptualLink target="773158a0-bea9-482f-b8ac-9670797b0da5" />
    /// <conceptualLink target="0432922d-9355-47b5-87f0-28feede0474d" />
    /// <conceptualLink target="6f316ae1-44bb-4773-975b-aac2f5a50c49" />
    /// <conceptualLink target="d38428af-c141-4f56-9a1d-8732f6f9a621" />
    public static partial class UnityContainerAsyncExtensions
    {
        /// <summary>
        /// Checks if a particular asynchronously initialized type has been registered with the container.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <param name="container">The container.</param>
        /// <returns><c>true</c> if this type has been registered.</returns>
        /// <seealso cref="UnityContainerExtensions.IsRegistered{T}(IUnityContainer)" />
        /// <conceptualLink target="6f316ae1-44bb-4773-975b-aac2f5a50c49" />
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
        /// <conceptualLink target="d38428af-c141-4f56-9a1d-8732f6f9a621" />
        public static bool IsAsyncTypeRegistered<T>(this IUnityContainer container, string name)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            return container.IsRegistered<IAsyncInitializer<T>>(name);
        }
    }
}
