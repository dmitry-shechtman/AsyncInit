using System.Threading.Tasks;

namespace Ditto.AsyncInit
{
    /// <summary>
    /// Base class for asynchronously initialized types.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
	/// <conceptualLink target="edeb370d-6d7e-4f82-adab-f2326d89c857" />
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    public abstract class AsyncInitBase<T> : IAsyncInit
        where T : AsyncInitBase<T>
    {
        /// <summary>
        /// Deriving types should define a private parameterless constructor.
        /// </summary>
        /// <param name="dummy">Dummy parameter (safe to pass <c>null</c>).</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "dummy")]
        protected AsyncInitBase(object dummy)
        {
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance.
        /// </summary>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static Task<T> CreateAsync()
        {
            return AsyncActivator.CreateAsync<T>();
        }

        /// <summary>
        /// Asynchronously initializes an instance. Overridden by the deriving type.
        /// </summary>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected abstract Task InitAsync();

        Task IAsyncInit.InitAsync()
        {
            return InitAsync();
        }
    }

    /// <summary>
    /// Base class for asynchronously initialized types.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    /// <typeparam name="TArg">The type of the initialization argument.</typeparam>
	/// <conceptualLink target="edeb370d-6d7e-4f82-adab-f2326d89c857" />
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    public abstract class AsyncInitBase<T, TArg> : IAsyncInit<TArg>
        where T : AsyncInitBase<T, TArg>
    {
        /// <summary>
        /// Deriving types should define a private parameterless constructor.
        /// </summary>
        /// <param name="dummy">Dummy parameter (safe to pass <c>null</c>).</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "dummy")]
        protected AsyncInitBase(object dummy)
        {
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance.
        /// </summary>
        /// <param name="arg">The initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static Task<T> CreateAsync(TArg arg)
        {
            return AsyncActivator.CreateAsync<T, TArg>(arg);
        }

        /// <summary>
        /// Asynchronously initializes an instance. Overridden by the deriving type.
        /// </summary>
        /// <param name="arg">The initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected abstract Task InitAsync(TArg arg);

        Task IAsyncInit<TArg>.InitAsync(TArg arg)
        {
            return InitAsync(arg);
        }
    }

    /// <summary>
    /// Base class for asynchronously initialized types.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
    /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
	/// <conceptualLink target="edeb370d-6d7e-4f82-adab-f2326d89c857" />
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    public abstract class AsyncInitBase<T, TArg1, TArg2> : IAsyncInit<TArg1, TArg2>
        where T : AsyncInitBase<T, TArg1, TArg2>
    {
        /// <summary>
        /// Deriving types should define a private parameterless constructor.
        /// </summary>
        /// <param name="dummy">Dummy parameter (safe to pass <c>null</c>).</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "dummy")]
        protected AsyncInitBase(object dummy)
        {
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static Task<T> CreateAsync(TArg1 arg1, TArg2 arg2)
        {
            return AsyncActivator.CreateAsync<T, TArg1, TArg2>(arg1, arg2);
        }

        /// <summary>
        /// Asynchronously initializes an instance. Overridden by the deriving type.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected abstract Task InitAsync(TArg1 arg1, TArg2 arg2);

        Task IAsyncInit<TArg1, TArg2>.InitAsync(TArg1 arg1, TArg2 arg2)
        {
            return InitAsync(arg1, arg2);
        }
    }

    /// <summary>
    /// Base class for asynchronously initialized types.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
    /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
    /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
	/// <conceptualLink target="edeb370d-6d7e-4f82-adab-f2326d89c857" />
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    public abstract class AsyncInitBase<T, TArg1, TArg2, TArg3> : IAsyncInit<TArg1, TArg2, TArg3>
        where T : AsyncInitBase<T, TArg1, TArg2, TArg3>
    {
        /// <summary>
        /// Deriving types should define a private parameterless constructor.
        /// </summary>
        /// <param name="dummy">Dummy parameter (safe to pass <c>null</c>).</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "dummy")]
        protected AsyncInitBase(object dummy)
        {
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static Task<T> CreateAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            return AsyncActivator.CreateAsync<T, TArg1, TArg2, TArg3>(arg1, arg2, arg3);
        }

        /// <summary>
        /// Asynchronously initializes an instance. Overridden by the deriving type.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected abstract Task InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3);

        Task IAsyncInit<TArg1, TArg2, TArg3>.InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            return InitAsync(arg1, arg2, arg3);
        }
    }

    /// <summary>
    /// Base class for asynchronously initialized types.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
    /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
    /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
    /// <typeparam name="TArg4">The type of the fourth initialization argument.</typeparam>
	/// <conceptualLink target="edeb370d-6d7e-4f82-adab-f2326d89c857" />
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    public abstract class AsyncInitBase<T, TArg1, TArg2, TArg3, TArg4> : IAsyncInit<TArg1, TArg2, TArg3, TArg4>
        where T : AsyncInitBase<T, TArg1, TArg2, TArg3, TArg4>
    {
        /// <summary>
        /// Deriving types should define a private parameterless constructor.
        /// </summary>
        /// <param name="dummy">Dummy parameter (safe to pass <c>null</c>).</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "dummy")]
        protected AsyncInitBase(object dummy)
        {
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static Task<T> CreateAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            return AsyncActivator.CreateAsync<T, TArg1, TArg2, TArg3, TArg4>(arg1, arg2, arg3, arg4);
        }

        /// <summary>
        /// Asynchronously initializes an instance. Overridden by the deriving type.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected abstract Task InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);

        Task IAsyncInit<TArg1, TArg2, TArg3, TArg4>.InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            return InitAsync(arg1, arg2, arg3, arg4);
        }
    }

    /// <summary>
    /// Base class for asynchronously initialized types.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
    /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
    /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
    /// <typeparam name="TArg4">The type of the fourth initialization argument.</typeparam>
    /// <typeparam name="TArg5">The type of the fifth initialization argument.</typeparam>
	/// <conceptualLink target="edeb370d-6d7e-4f82-adab-f2326d89c857" />
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    public abstract class AsyncInitBase<T, TArg1, TArg2, TArg3, TArg4, TArg5> : IAsyncInit<TArg1, TArg2, TArg3, TArg4, TArg5>
        where T : AsyncInitBase<T, TArg1, TArg2, TArg3, TArg4, TArg5>
    {
        /// <summary>
        /// Deriving types should define a private parameterless constructor.
        /// </summary>
        /// <param name="dummy">Dummy parameter (safe to pass <c>null</c>).</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "dummy")]
        protected AsyncInitBase(object dummy)
        {
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="arg5">The fifth initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static Task<T> CreateAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            return AsyncActivator.CreateAsync<T, TArg1, TArg2, TArg3, TArg4, TArg5>(arg1, arg2, arg3, arg4, arg5);
        }

        /// <summary>
        /// Asynchronously initializes an instance. Overridden by the deriving type.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="arg5">The fifth initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected abstract Task InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5);

        Task IAsyncInit<TArg1, TArg2, TArg3, TArg4, TArg5>.InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            return InitAsync(arg1, arg2, arg3, arg4, arg5);
        }
    }

    /// <summary>
    /// Base class for asynchronously initialized types.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
    /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
    /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
    /// <typeparam name="TArg4">The type of the fourth initialization argument.</typeparam>
    /// <typeparam name="TArg5">The type of the fifth initialization argument.</typeparam>
    /// <typeparam name="TArg6">The type of the sixth initialization argument.</typeparam>
	/// <conceptualLink target="edeb370d-6d7e-4f82-adab-f2326d89c857" />
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    public abstract class AsyncInitBase<T, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : IAsyncInit<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
        where T : AsyncInitBase<T, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
    {
        /// <summary>
        /// Deriving types should define a private parameterless constructor.
        /// </summary>
        /// <param name="dummy">Dummy parameter (safe to pass <c>null</c>).</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "dummy")]
        protected AsyncInitBase(object dummy)
        {
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="arg5">The fifth initialization argument.</param>
        /// <param name="arg6">The sixth initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static Task<T> CreateAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
            return AsyncActivator.CreateAsync<T, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(arg1, arg2, arg3, arg4, arg5, arg6);
        }

        /// <summary>
        /// Asynchronously initializes an instance. Overridden by the deriving type.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="arg5">The fifth initialization argument.</param>
        /// <param name="arg6">The sixth initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected abstract Task InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6);

        Task IAsyncInit<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>.InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
            return InitAsync(arg1, arg2, arg3, arg4, arg5, arg6);
        }
    }

    /// <summary>
    /// Base class for asynchronously initialized types.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
    /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
    /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
    /// <typeparam name="TArg4">The type of the fourth initialization argument.</typeparam>
    /// <typeparam name="TArg5">The type of the fifth initialization argument.</typeparam>
    /// <typeparam name="TArg6">The type of the sixth initialization argument.</typeparam>
    /// <typeparam name="TArg7">The type of the seventh initialization argument.</typeparam>
	/// <conceptualLink target="edeb370d-6d7e-4f82-adab-f2326d89c857" />
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    public abstract class AsyncInitBase<T, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> : IAsyncInit<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
        where T : AsyncInitBase<T, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
    {
        /// <summary>
        /// Deriving types should define a private parameterless constructor.
        /// </summary>
        /// <param name="dummy">Dummy parameter (safe to pass <c>null</c>).</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "dummy")]
        protected AsyncInitBase(object dummy)
        {
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="arg5">The fifth initialization argument.</param>
        /// <param name="arg6">The sixth initialization argument.</param>
        /// <param name="arg7">The seventh initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static Task<T> CreateAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
        {
            return AsyncActivator.CreateAsync<T, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        /// <summary>
        /// Asynchronously initializes an instance. Overridden by the deriving type.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="arg5">The fifth initialization argument.</param>
        /// <param name="arg6">The sixth initialization argument.</param>
        /// <param name="arg7">The seventh initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected abstract Task InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7);

        Task IAsyncInit<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>.InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
        {
            return InitAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
    }

}
