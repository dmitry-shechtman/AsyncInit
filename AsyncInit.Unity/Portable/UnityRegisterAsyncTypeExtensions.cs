using Ditto.AsyncInit.Services;
using Microsoft.Practices.Unity;
using System;

namespace Ditto.AsyncInit.Unity
{
    /// <summary>
    /// Adds a set of asynchronous registration methods to <see cref="IUnityContainer"/>.
    /// </summary>
    /// <conceptualLink target="30e16988-88d9-400d-bf76-21885513e5df" />
    /// <conceptualLink target="773158a0-bea9-482f-b8ac-9670797b0da5" />
    public static class UnityRegisterAsyncTypeExtensions
    {
        /// <summary>
        /// Registers the specified asynchronously initialized type with the container.
        /// </summary>
        /// <typeparam name="T">The type to register.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="injectionMembers">Injection configuration objects.</param>
        /// <returns>The container.</returns>
		/// <seealso cref="UnityContainerExtensions.RegisterType{T}(IUnityContainer,InjectionMember[])" />
		/// <conceptualLink target="30e16988-88d9-400d-bf76-21885513e5df" />
        public static IUnityContainer RegisterAsyncType<T>(this IUnityContainer container, params InjectionMember[] injectionMembers)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            return container.RegisterType<IAsyncInitializer<T>, UnityAsyncInitializer<T, T>>(injectionMembers);
        }

        /// <summary>
        /// Registers the specified asynchronously initialized type with the container.
        /// </summary>
        /// <typeparam name="T">The type to register.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="lifetimeManager">The <see cref="LifetimeManager"/> that controls the lifetime of the returned instance.</param>
        /// <param name="injectionMembers">Injection configuration objects.</param>
        /// <returns>The container.</returns>
		/// <seealso cref="UnityContainerExtensions.RegisterType{T}(IUnityContainer,LifetimeManager,InjectionMember[])" />
		/// <conceptualLink target="30e16988-88d9-400d-bf76-21885513e5df" />
        public static IUnityContainer RegisterAsyncType<T>(this IUnityContainer container, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            return container.RegisterType<IAsyncInitializer<T>, UnityAsyncInitializer<T, T>>(lifetimeManager, injectionMembers);
        }

        /// <summary>
        /// Registers the specified asynchronously initialized type with the container.
        /// </summary>
        /// <typeparam name="T">The type to register.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="name">The name to use for registration.</param>
        /// <param name="injectionMembers">Injection configuration objects.</param>
        /// <returns>The container.</returns>
		/// <seealso cref="UnityContainerExtensions.RegisterType{T}(IUnityContainer,String,InjectionMember[])" />
		/// <conceptualLink target="30e16988-88d9-400d-bf76-21885513e5df" />
        public static IUnityContainer RegisterAsyncType<T>(this IUnityContainer container, string name, params InjectionMember[] injectionMembers)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            return container.RegisterType<IAsyncInitializer<T>, UnityAsyncInitializer<T, T>>(name, injectionMembers);
        }

        /// <summary>
        /// Registers the specified asynchronously initialized type with the container.
        /// </summary>
        /// <typeparam name="T">The type to register.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="name">The name to use for registration.</param>
        /// <param name="lifetimeManager">The <see cref="LifetimeManager"/> that controls the lifetime of the returned instance.</param>
        /// <param name="injectionMembers">Injection configuration objects.</param>
        /// <returns>The container.</returns>
		/// <seealso cref="UnityContainerExtensions.RegisterType{T}(IUnityContainer,String,LifetimeManager,InjectionMember[])" />
		/// <conceptualLink target="30e16988-88d9-400d-bf76-21885513e5df" />
        public static IUnityContainer RegisterAsyncType<T>(this IUnityContainer container, string name, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            return container.RegisterType<IAsyncInitializer<T>, UnityAsyncInitializer<T, T>>(name, lifetimeManager, injectionMembers);
        }

        /// <summary>
        /// Registers the specified asynchronously initialized type with the container.
        /// </summary>
        /// <typeparam name="T">The type to register.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="args">Initialization arguments.</param>
        /// <returns>The container.</returns>
		/// <seealso cref="UnityContainerExtensions.RegisterType{T}(IUnityContainer,InjectionMember[])" />
		/// <conceptualLink target="30e16988-88d9-400d-bf76-21885513e5df" />
        public static IUnityContainer RegisterAsyncType<T>(this IUnityContainer container, AsyncInitArgs args)
        {
            if (container == null)
                throw new ArgumentNullException("container");
			var injectionMembers = CreateInjectionMembers(args);
            return container.RegisterType<IAsyncInitializer<T>, UnityAsyncInitializer<T, T>>(injectionMembers);
        }

        /// <summary>
        /// Registers the specified asynchronously initialized type with the container.
        /// </summary>
        /// <typeparam name="T">The type to register.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="lifetimeManager">The <see cref="LifetimeManager"/> that controls the lifetime of the returned instance.</param>
        /// <param name="args">Initialization arguments.</param>
        /// <returns>The container.</returns>
		/// <seealso cref="UnityContainerExtensions.RegisterType{T}(IUnityContainer,LifetimeManager,InjectionMember[])" />
		/// <conceptualLink target="30e16988-88d9-400d-bf76-21885513e5df" />
        public static IUnityContainer RegisterAsyncType<T>(this IUnityContainer container, LifetimeManager lifetimeManager, AsyncInitArgs args)
        {
            if (container == null)
                throw new ArgumentNullException("container");
			var injectionMembers = CreateInjectionMembers(args);
            return container.RegisterType<IAsyncInitializer<T>, UnityAsyncInitializer<T, T>>(lifetimeManager, injectionMembers);
        }

        /// <summary>
        /// Registers the specified asynchronously initialized type with the container.
        /// </summary>
        /// <typeparam name="T">The type to register.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="name">The name to use for registration.</param>
        /// <param name="args">Initialization arguments.</param>
        /// <returns>The container.</returns>
		/// <seealso cref="UnityContainerExtensions.RegisterType{T}(IUnityContainer,String,InjectionMember[])" />
		/// <conceptualLink target="30e16988-88d9-400d-bf76-21885513e5df" />
        public static IUnityContainer RegisterAsyncType<T>(this IUnityContainer container, string name, AsyncInitArgs args)
        {
            if (container == null)
                throw new ArgumentNullException("container");
			var injectionMembers = CreateInjectionMembers(args);
            return container.RegisterType<IAsyncInitializer<T>, UnityAsyncInitializer<T, T>>(name, injectionMembers);
        }

        /// <summary>
        /// Registers the specified asynchronously initialized type with the container.
        /// </summary>
        /// <typeparam name="T">The type to register.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="name">The name to use for registration.</param>
        /// <param name="lifetimeManager">The <see cref="LifetimeManager"/> that controls the lifetime of the returned instance.</param>
        /// <param name="args">Initialization arguments.</param>
        /// <returns>The container.</returns>
		/// <seealso cref="UnityContainerExtensions.RegisterType{T}(IUnityContainer,String,LifetimeManager,InjectionMember[])" />
		/// <conceptualLink target="30e16988-88d9-400d-bf76-21885513e5df" />
        public static IUnityContainer RegisterAsyncType<T>(this IUnityContainer container, string name, LifetimeManager lifetimeManager, AsyncInitArgs args)
        {
            if (container == null)
                throw new ArgumentNullException("container");
			var injectionMembers = CreateInjectionMembers(args);
            return container.RegisterType<IAsyncInitializer<T>, UnityAsyncInitializer<T, T>>(name, lifetimeManager, injectionMembers);
        }

        /// <summary>
        /// Registers the specified asynchronously initialized type with the container.
        /// </summary>
        /// <typeparam name="TFrom">The requested type.</typeparam>
        /// <typeparam name="TTo">The actual type.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="injectionMembers">Injection configuration objects.</param>
        /// <returns>The container.</returns>
		/// <seealso cref="UnityContainerExtensions.RegisterType{TFrom,TTo}(IUnityContainer,InjectionMember[])" />
		/// <conceptualLink target="773158a0-bea9-482f-b8ac-9670797b0da5" />
        public static IUnityContainer RegisterAsyncType<TFrom, TTo>(this IUnityContainer container, params InjectionMember[] injectionMembers)
			where TTo : TFrom
        {
            if (container == null)
                throw new ArgumentNullException("container");
            return container.RegisterType<IAsyncInitializer<TFrom>, UnityAsyncInitializer<TFrom, TTo>>(injectionMembers);
        }

        /// <summary>
        /// Registers the specified asynchronously initialized type with the container.
        /// </summary>
        /// <typeparam name="TFrom">The requested type.</typeparam>
        /// <typeparam name="TTo">The actual type.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="lifetimeManager">The <see cref="LifetimeManager"/> that controls the lifetime of the returned instance.</param>
        /// <param name="injectionMembers">Injection configuration objects.</param>
        /// <returns>The container.</returns>
		/// <seealso cref="UnityContainerExtensions.RegisterType{TFrom,TTo}(IUnityContainer,LifetimeManager,InjectionMember[])" />
		/// <conceptualLink target="773158a0-bea9-482f-b8ac-9670797b0da5" />
        public static IUnityContainer RegisterAsyncType<TFrom, TTo>(this IUnityContainer container, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers)
			where TTo : TFrom
        {
            if (container == null)
                throw new ArgumentNullException("container");
            return container.RegisterType<IAsyncInitializer<TFrom>, UnityAsyncInitializer<TFrom, TTo>>(lifetimeManager, injectionMembers);
        }

        /// <summary>
        /// Registers the specified asynchronously initialized type with the container.
        /// </summary>
        /// <typeparam name="TFrom">The requested type.</typeparam>
        /// <typeparam name="TTo">The actual type.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="name">The name to use for registration.</param>
        /// <param name="injectionMembers">Injection configuration objects.</param>
        /// <returns>The container.</returns>
		/// <seealso cref="UnityContainerExtensions.RegisterType{TFrom,TTo}(IUnityContainer,String,InjectionMember[])" />
		/// <conceptualLink target="773158a0-bea9-482f-b8ac-9670797b0da5" />
        public static IUnityContainer RegisterAsyncType<TFrom, TTo>(this IUnityContainer container, string name, params InjectionMember[] injectionMembers)
			where TTo : TFrom
        {
            if (container == null)
                throw new ArgumentNullException("container");
            return container.RegisterType<IAsyncInitializer<TFrom>, UnityAsyncInitializer<TFrom, TTo>>(name, injectionMembers);
        }

        /// <summary>
        /// Registers the specified asynchronously initialized type with the container.
        /// </summary>
        /// <typeparam name="TFrom">The requested type.</typeparam>
        /// <typeparam name="TTo">The actual type.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="name">The name to use for registration.</param>
        /// <param name="lifetimeManager">The <see cref="LifetimeManager"/> that controls the lifetime of the returned instance.</param>
        /// <param name="injectionMembers">Injection configuration objects.</param>
        /// <returns>The container.</returns>
		/// <seealso cref="UnityContainerExtensions.RegisterType{TFrom,TTo}(IUnityContainer,String,LifetimeManager,InjectionMember[])" />
		/// <conceptualLink target="773158a0-bea9-482f-b8ac-9670797b0da5" />
        public static IUnityContainer RegisterAsyncType<TFrom, TTo>(this IUnityContainer container, string name, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers)
			where TTo : TFrom
        {
            if (container == null)
                throw new ArgumentNullException("container");
            return container.RegisterType<IAsyncInitializer<TFrom>, UnityAsyncInitializer<TFrom, TTo>>(name, lifetimeManager, injectionMembers);
        }

        /// <summary>
        /// Registers the specified asynchronously initialized type with the container.
        /// </summary>
        /// <typeparam name="TFrom">The requested type.</typeparam>
        /// <typeparam name="TTo">The actual type.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="args">Initialization arguments.</param>
        /// <returns>The container.</returns>
		/// <seealso cref="UnityContainerExtensions.RegisterType{TFrom,TTo}(IUnityContainer,InjectionMember[])" />
		/// <conceptualLink target="773158a0-bea9-482f-b8ac-9670797b0da5" />
        public static IUnityContainer RegisterAsyncType<TFrom, TTo>(this IUnityContainer container, AsyncInitArgs args)
			where TTo : TFrom
        {
            if (container == null)
                throw new ArgumentNullException("container");
			var injectionMembers = CreateInjectionMembers(args);
            return container.RegisterType<IAsyncInitializer<TFrom>, UnityAsyncInitializer<TFrom, TTo>>(injectionMembers);
        }

        /// <summary>
        /// Registers the specified asynchronously initialized type with the container.
        /// </summary>
        /// <typeparam name="TFrom">The requested type.</typeparam>
        /// <typeparam name="TTo">The actual type.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="lifetimeManager">The <see cref="LifetimeManager"/> that controls the lifetime of the returned instance.</param>
        /// <param name="args">Initialization arguments.</param>
        /// <returns>The container.</returns>
		/// <seealso cref="UnityContainerExtensions.RegisterType{TFrom,TTo}(IUnityContainer,LifetimeManager,InjectionMember[])" />
		/// <conceptualLink target="773158a0-bea9-482f-b8ac-9670797b0da5" />
        public static IUnityContainer RegisterAsyncType<TFrom, TTo>(this IUnityContainer container, LifetimeManager lifetimeManager, AsyncInitArgs args)
			where TTo : TFrom
        {
            if (container == null)
                throw new ArgumentNullException("container");
			var injectionMembers = CreateInjectionMembers(args);
            return container.RegisterType<IAsyncInitializer<TFrom>, UnityAsyncInitializer<TFrom, TTo>>(lifetimeManager, injectionMembers);
        }

        /// <summary>
        /// Registers the specified asynchronously initialized type with the container.
        /// </summary>
        /// <typeparam name="TFrom">The requested type.</typeparam>
        /// <typeparam name="TTo">The actual type.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="name">The name to use for registration.</param>
        /// <param name="args">Initialization arguments.</param>
        /// <returns>The container.</returns>
		/// <seealso cref="UnityContainerExtensions.RegisterType{TFrom,TTo}(IUnityContainer,String,InjectionMember[])" />
		/// <conceptualLink target="773158a0-bea9-482f-b8ac-9670797b0da5" />
        public static IUnityContainer RegisterAsyncType<TFrom, TTo>(this IUnityContainer container, string name, AsyncInitArgs args)
			where TTo : TFrom
        {
            if (container == null)
                throw new ArgumentNullException("container");
			var injectionMembers = CreateInjectionMembers(args);
            return container.RegisterType<IAsyncInitializer<TFrom>, UnityAsyncInitializer<TFrom, TTo>>(name, injectionMembers);
        }

        /// <summary>
        /// Registers the specified asynchronously initialized type with the container.
        /// </summary>
        /// <typeparam name="TFrom">The requested type.</typeparam>
        /// <typeparam name="TTo">The actual type.</typeparam>
        /// <param name="container">The container.</param>
        /// <param name="name">The name to use for registration.</param>
        /// <param name="lifetimeManager">The <see cref="LifetimeManager"/> that controls the lifetime of the returned instance.</param>
        /// <param name="args">Initialization arguments.</param>
        /// <returns>The container.</returns>
		/// <seealso cref="UnityContainerExtensions.RegisterType{TFrom,TTo}(IUnityContainer,String,LifetimeManager,InjectionMember[])" />
		/// <conceptualLink target="773158a0-bea9-482f-b8ac-9670797b0da5" />
        public static IUnityContainer RegisterAsyncType<TFrom, TTo>(this IUnityContainer container, string name, LifetimeManager lifetimeManager, AsyncInitArgs args)
			where TTo : TFrom
        {
            if (container == null)
                throw new ArgumentNullException("container");
			var injectionMembers = CreateInjectionMembers(args);
            return container.RegisterType<IAsyncInitializer<TFrom>, UnityAsyncInitializer<TFrom, TTo>>(name, lifetimeManager, injectionMembers);
        }

		private static InjectionConstructor[] CreateInjectionMembers(AsyncInitArgs args)
		{
            if (args == null)
                throw new ArgumentNullException("args");
			return new[] { new InjectionConstructor(args) };
		}
	}
}
