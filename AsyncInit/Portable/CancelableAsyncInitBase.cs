using System.Threading;
using System.Threading.Tasks;

namespace Ditto.AsyncInit
{
    /// <summary>
    /// Base class for asynchronously initialized types supporting cancellation.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    public abstract class CancelableAsyncInitBase<T> : AsyncInitBase<T>, ICancelableAsyncInit
        where T : CancelableAsyncInitBase<T>
    {
        /// <summary>
        /// Deriving types should define a private parameterless constructor.
        /// </summary>
        /// <param name="dummy">Dummy parameter (safe to pass <c>null</c>).</param>
        protected CancelableAsyncInitBase(object dummy)
            : base(dummy)
        {
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static Task<T> CreateAsync(CancellationToken cancellationToken)
        {
            return AsyncActivator.CreateAsync<T>(cancellationToken);
        }

        /// <summary>
        /// Asynchronously initializes an instance.
        /// </summary>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected override Task InitAsync()
        {
            return InitAsync(CancellationToken.None);
        }

        /// <summary>
        /// Asynchronously initializes an instance. Overridden by the deriving type.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected abstract Task InitAsync(CancellationToken cancellationToken);

        Task ICancelableAsyncInit.InitAsync(CancellationToken cancellationToken)
        {
            return InitAsync(cancellationToken);
        }
    }

    /// <summary>
    /// Base class for asynchronously initialized types supporting cancellation.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    /// <typeparam name="TArg">The type of the initialization argument.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    public abstract class CancelableAsyncInitBase<T, TArg> : AsyncInitBase<T, TArg>, ICancelableAsyncInit<TArg>
        where T : CancelableAsyncInitBase<T, TArg>
    {
        /// <summary>
        /// Deriving types should define a private parameterless constructor.
        /// </summary>
        /// <param name="dummy">Dummy parameter (safe to pass <c>null</c>).</param>
        protected CancelableAsyncInitBase(object dummy)
            : base(dummy)
        {
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance.
        /// </summary>
        /// <param name="arg">The initialization argument.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static Task<T> CreateAsync(TArg arg, CancellationToken cancellationToken)
        {
            return AsyncActivator.CreateAsync<T, TArg>(arg, cancellationToken);
        }

        /// <summary>
        /// Asynchronously initializes an instance.
        /// </summary>
        /// <param name="arg">The initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected override Task InitAsync(TArg arg)
        {
            return InitAsync(arg, CancellationToken.None);
        }

        /// <summary>
        /// Asynchronously initializes an instance. Overridden by the deriving type.
        /// </summary>
        /// <param name="arg">The initialization argument.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected abstract Task InitAsync(TArg arg, CancellationToken cancellationToken);

        Task ICancelableAsyncInit<TArg>.InitAsync(TArg arg, CancellationToken cancellationToken)
        {
            return InitAsync(arg, cancellationToken);
        }
    }

    /// <summary>
    /// Base class for asynchronously initialized types supporting cancellation.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
    /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    public abstract class CancelableAsyncInitBase<T, TArg1, TArg2> : AsyncInitBase<T, TArg1, TArg2>, ICancelableAsyncInit<TArg1, TArg2>
        where T : CancelableAsyncInitBase<T, TArg1, TArg2>
    {
        /// <summary>
        /// Deriving types should define a private parameterless constructor.
        /// </summary>
        /// <param name="dummy">Dummy parameter (safe to pass <c>null</c>).</param>
        protected CancelableAsyncInitBase(object dummy)
            : base(dummy)
        {
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static Task<T> CreateAsync(TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken)
        {
            return AsyncActivator.CreateAsync<T, TArg1, TArg2>(arg1, arg2, cancellationToken);
        }

        /// <summary>
        /// Asynchronously initializes an instance.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected override Task InitAsync(TArg1 arg1, TArg2 arg2)
        {
            return InitAsync(arg1, arg2, CancellationToken.None);
        }

        /// <summary>
        /// Asynchronously initializes an instance. Overridden by the deriving type.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected abstract Task InitAsync(TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken);

        Task ICancelableAsyncInit<TArg1, TArg2>.InitAsync(TArg1 arg1, TArg2 arg2, CancellationToken cancellationToken)
        {
            return InitAsync(arg1, arg2, cancellationToken);
        }
    }

    /// <summary>
    /// Base class for asynchronously initialized types supporting cancellation.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
    /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
    /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    public abstract class CancelableAsyncInitBase<T, TArg1, TArg2, TArg3> : AsyncInitBase<T, TArg1, TArg2, TArg3>, ICancelableAsyncInit<TArg1, TArg2, TArg3>
        where T : CancelableAsyncInitBase<T, TArg1, TArg2, TArg3>
    {
        /// <summary>
        /// Deriving types should define a private parameterless constructor.
        /// </summary>
        /// <param name="dummy">Dummy parameter (safe to pass <c>null</c>).</param>
        protected CancelableAsyncInitBase(object dummy)
            : base(dummy)
        {
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static Task<T> CreateAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken)
        {
            return AsyncActivator.CreateAsync<T, TArg1, TArg2, TArg3>(arg1, arg2, arg3, cancellationToken);
        }

        /// <summary>
        /// Asynchronously initializes an instance.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected override Task InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            return InitAsync(arg1, arg2, arg3, CancellationToken.None);
        }

        /// <summary>
        /// Asynchronously initializes an instance. Overridden by the deriving type.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected abstract Task InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken);

        Task ICancelableAsyncInit<TArg1, TArg2, TArg3>.InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, CancellationToken cancellationToken)
        {
            return InitAsync(arg1, arg2, arg3, cancellationToken);
        }
    }

    /// <summary>
    /// Base class for asynchronously initialized types supporting cancellation.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
    /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
    /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
    /// <typeparam name="TArg4">The type of the fourth initialization argument.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    public abstract class CancelableAsyncInitBase<T, TArg1, TArg2, TArg3, TArg4> : AsyncInitBase<T, TArg1, TArg2, TArg3, TArg4>, ICancelableAsyncInit<TArg1, TArg2, TArg3, TArg4>
        where T : CancelableAsyncInitBase<T, TArg1, TArg2, TArg3, TArg4>
    {
        /// <summary>
        /// Deriving types should define a private parameterless constructor.
        /// </summary>
        /// <param name="dummy">Dummy parameter (safe to pass <c>null</c>).</param>
        protected CancelableAsyncInitBase(object dummy)
            : base(dummy)
        {
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static Task<T> CreateAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken)
        {
            return AsyncActivator.CreateAsync<T, TArg1, TArg2, TArg3, TArg4>(arg1, arg2, arg3, arg4, cancellationToken);
        }

        /// <summary>
        /// Asynchronously initializes an instance.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected override Task InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            return InitAsync(arg1, arg2, arg3, arg4, CancellationToken.None);
        }

        /// <summary>
        /// Asynchronously initializes an instance. Overridden by the deriving type.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected abstract Task InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken);

        Task ICancelableAsyncInit<TArg1, TArg2, TArg3, TArg4>.InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, CancellationToken cancellationToken)
        {
            return InitAsync(arg1, arg2, arg3, arg4, cancellationToken);
        }
    }

    /// <summary>
    /// Base class for asynchronously initialized types supporting cancellation.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
    /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
    /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
    /// <typeparam name="TArg4">The type of the fourth initialization argument.</typeparam>
    /// <typeparam name="TArg5">The type of the fifth initialization argument.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    public abstract class CancelableAsyncInitBase<T, TArg1, TArg2, TArg3, TArg4, TArg5> : AsyncInitBase<T, TArg1, TArg2, TArg3, TArg4, TArg5>, ICancelableAsyncInit<TArg1, TArg2, TArg3, TArg4, TArg5>
        where T : CancelableAsyncInitBase<T, TArg1, TArg2, TArg3, TArg4, TArg5>
    {
        /// <summary>
        /// Deriving types should define a private parameterless constructor.
        /// </summary>
        /// <param name="dummy">Dummy parameter (safe to pass <c>null</c>).</param>
        protected CancelableAsyncInitBase(object dummy)
            : base(dummy)
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
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static Task<T> CreateAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken)
        {
            return AsyncActivator.CreateAsync<T, TArg1, TArg2, TArg3, TArg4, TArg5>(arg1, arg2, arg3, arg4, arg5, cancellationToken);
        }

        /// <summary>
        /// Asynchronously initializes an instance.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="arg5">The fifth initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected override Task InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            return InitAsync(arg1, arg2, arg3, arg4, arg5, CancellationToken.None);
        }

        /// <summary>
        /// Asynchronously initializes an instance. Overridden by the deriving type.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="arg5">The fifth initialization argument.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected abstract Task InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken);

        Task ICancelableAsyncInit<TArg1, TArg2, TArg3, TArg4, TArg5>.InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, CancellationToken cancellationToken)
        {
            return InitAsync(arg1, arg2, arg3, arg4, arg5, cancellationToken);
        }
    }

    /// <summary>
    /// Base class for asynchronously initialized types supporting cancellation.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
    /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
    /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
    /// <typeparam name="TArg4">The type of the fourth initialization argument.</typeparam>
    /// <typeparam name="TArg5">The type of the fifth initialization argument.</typeparam>
    /// <typeparam name="TArg6">The type of the sixth initialization argument.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    public abstract class CancelableAsyncInitBase<T, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : AsyncInitBase<T, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, ICancelableAsyncInit<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
        where T : CancelableAsyncInitBase<T, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
    {
        /// <summary>
        /// Deriving types should define a private parameterless constructor.
        /// </summary>
        /// <param name="dummy">Dummy parameter (safe to pass <c>null</c>).</param>
        protected CancelableAsyncInitBase(object dummy)
            : base(dummy)
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
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static Task<T> CreateAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken)
        {
            return AsyncActivator.CreateAsync<T, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(arg1, arg2, arg3, arg4, arg5, arg6, cancellationToken);
        }

        /// <summary>
        /// Asynchronously initializes an instance.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="arg5">The fifth initialization argument.</param>
        /// <param name="arg6">The sixth initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected override Task InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
            return InitAsync(arg1, arg2, arg3, arg4, arg5, arg6, CancellationToken.None);
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
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected abstract Task InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken);

        Task ICancelableAsyncInit<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>.InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, CancellationToken cancellationToken)
        {
            return InitAsync(arg1, arg2, arg3, arg4, arg5, arg6, cancellationToken);
        }
    }

    /// <summary>
    /// Base class for asynchronously initialized types supporting cancellation.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    /// <typeparam name="TArg1">The type of the first initialization argument.</typeparam>
    /// <typeparam name="TArg2">The type of the second initialization argument.</typeparam>
    /// <typeparam name="TArg3">The type of the third initialization argument.</typeparam>
    /// <typeparam name="TArg4">The type of the fourth initialization argument.</typeparam>
    /// <typeparam name="TArg5">The type of the fifth initialization argument.</typeparam>
    /// <typeparam name="TArg6">The type of the sixth initialization argument.</typeparam>
    /// <typeparam name="TArg7">The type of the seventh initialization argument.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes")]
    public abstract class CancelableAsyncInitBase<T, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> : AsyncInitBase<T, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, ICancelableAsyncInit<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
        where T : CancelableAsyncInitBase<T, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
    {
        /// <summary>
        /// Deriving types should define a private parameterless constructor.
        /// </summary>
        /// <param name="dummy">Dummy parameter (safe to pass <c>null</c>).</param>
        protected CancelableAsyncInitBase(object dummy)
            : base(dummy)
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
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static Task<T> CreateAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken)
        {
            return AsyncActivator.CreateAsync<T, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(arg1, arg2, arg3, arg4, arg5, arg6, arg7, cancellationToken);
        }

        /// <summary>
        /// Asynchronously initializes an instance.
        /// </summary>
        /// <param name="arg1">The first initialization argument.</param>
        /// <param name="arg2">The second initialization argument.</param>
        /// <param name="arg3">The third initialization argument.</param>
        /// <param name="arg4">The fourth initialization argument.</param>
        /// <param name="arg5">The fifth initialization argument.</param>
        /// <param name="arg6">The sixth initialization argument.</param>
        /// <param name="arg7">The seventh initialization argument.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected override Task InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
        {
            return InitAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, CancellationToken.None);
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
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> capturing the initialization.</returns>
        protected abstract Task InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken);

        Task ICancelableAsyncInit<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>.InitAsync(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, CancellationToken cancellationToken)
        {
            return InitAsync(arg1, arg2, arg3, arg4, arg5, arg6, arg7, cancellationToken);
        }
    }

}
