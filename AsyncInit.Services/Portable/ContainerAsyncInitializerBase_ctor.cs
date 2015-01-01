using Ditto.AsyncInit.Services.Internal;

namespace Ditto.AsyncInit.Services
{
    partial class ContainerAsyncInitializerBase<TFrom, TTo, TContainer>
    {
        /// <summary>
        /// Creates a new initializer with untyped initialization arguments.
        /// </summary>
        /// <param name="arg">The argument.</param>
        protected ContainerAsyncInitializerBase(object arg)
            : base(new MatchArgumentsStrategy(new[] { arg }))
        {
        }

        /// <summary>
        /// Creates a new initializer with untyped initialization arguments.
        /// </summary>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        protected ContainerAsyncInitializerBase(object arg1, object arg2)
            : base(new MatchArgumentsStrategy(new[] { arg1, arg2 }))
        {
        }

        /// <summary>
        /// Creates a new initializer with untyped initialization arguments.
        /// </summary>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        protected ContainerAsyncInitializerBase(object arg1, object arg2, object arg3)
            : base(new MatchArgumentsStrategy(new[] { arg1, arg2, arg3 }))
        {
        }

        /// <summary>
        /// Creates a new initializer with untyped initialization arguments.
        /// </summary>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        protected ContainerAsyncInitializerBase(object arg1, object arg2, object arg3, object arg4)
            : base(new MatchArgumentsStrategy(new[] { arg1, arg2, arg3, arg4 }))
        {
        }

        /// <summary>
        /// Creates a new initializer with untyped initialization arguments.
        /// </summary>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <param name="arg5">The fifth argument.</param>
        protected ContainerAsyncInitializerBase(object arg1, object arg2, object arg3, object arg4, object arg5)
            : base(new MatchArgumentsStrategy(new[] { arg1, arg2, arg3, arg4, arg5 }))
        {
        }

        /// <summary>
        /// Creates a new initializer with untyped initialization arguments.
        /// </summary>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <param name="arg5">The fifth argument.</param>
        /// <param name="arg6">The sixth argument.</param>
        protected ContainerAsyncInitializerBase(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6)
            : base(new MatchArgumentsStrategy(new[] { arg1, arg2, arg3, arg4, arg5, arg6 }))
        {
        }

        /// <summary>
        /// Creates a new initializer with untyped initialization arguments.
        /// </summary>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <param name="arg5">The fifth argument.</param>
        /// <param name="arg6">The sixth argument.</param>
        /// <param name="arg7">The seventh argument.</param>
        protected ContainerAsyncInitializerBase(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7)
            : base(new MatchArgumentsStrategy(new[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }))
        {
        }

    }
}
