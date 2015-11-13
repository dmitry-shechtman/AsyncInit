using System;

namespace Ditto.AsyncInit.Services
{
    partial class AsyncInitArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncInitArgs"/> class.
        /// </summary>
        /// <typeparam name="TArg">The type of the argument.</typeparam>
        /// <param name="arg">The argument.</param>
        /// <returns>An instance of <see cref="AsyncInitArgs"/>.</returns>
        public static AsyncInitArgs Create<TArg>(TArg arg)
        {
            return new AsyncInitArgs(
				new[] { typeof(TArg) },
				new object[] { arg });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncInitArgs"/> class.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument.</typeparam>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <returns>An instance of <see cref="AsyncInitArgs"/>.</returns>
        public static AsyncInitArgs Create<TArg1, TArg2>(TArg1 arg1, TArg2 arg2)
        {
            return new AsyncInitArgs(
				new[] { typeof(TArg1), typeof(TArg2) },
				new object[] { arg1, arg2 });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncInitArgs"/> class.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument.</typeparam>
        /// <typeparam name="TArg3">The type of the third argument.</typeparam>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <returns>An instance of <see cref="AsyncInitArgs"/>.</returns>
        public static AsyncInitArgs Create<TArg1, TArg2, TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            return new AsyncInitArgs(
				new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3) },
				new object[] { arg1, arg2, arg3 });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncInitArgs"/> class.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument.</typeparam>
        /// <typeparam name="TArg3">The type of the third argument.</typeparam>
        /// <typeparam name="TArg4">The type of the fourth argument.</typeparam>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <returns>An instance of <see cref="AsyncInitArgs"/>.</returns>
        public static AsyncInitArgs Create<TArg1, TArg2, TArg3, TArg4>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            return new AsyncInitArgs(
				new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4) },
				new object[] { arg1, arg2, arg3, arg4 });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncInitArgs"/> class.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument.</typeparam>
        /// <typeparam name="TArg3">The type of the third argument.</typeparam>
        /// <typeparam name="TArg4">The type of the fourth argument.</typeparam>
        /// <typeparam name="TArg5">The type of the fifth argument.</typeparam>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <param name="arg5">The fifth argument.</param>
        /// <returns>An instance of <see cref="AsyncInitArgs"/>.</returns>
        public static AsyncInitArgs Create<TArg1, TArg2, TArg3, TArg4, TArg5>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            return new AsyncInitArgs(
				new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5) },
				new object[] { arg1, arg2, arg3, arg4, arg5 });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncInitArgs"/> class.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument.</typeparam>
        /// <typeparam name="TArg3">The type of the third argument.</typeparam>
        /// <typeparam name="TArg4">The type of the fourth argument.</typeparam>
        /// <typeparam name="TArg5">The type of the fifth argument.</typeparam>
        /// <typeparam name="TArg6">The type of the sixth argument.</typeparam>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <param name="arg5">The fifth argument.</param>
        /// <param name="arg6">The sixth argument.</param>
        /// <returns>An instance of <see cref="AsyncInitArgs"/>.</returns>
        public static AsyncInitArgs Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
            return new AsyncInitArgs(
				new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6) },
				new object[] { arg1, arg2, arg3, arg4, arg5, arg6 });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncInitArgs"/> class.
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument.</typeparam>
        /// <typeparam name="TArg3">The type of the third argument.</typeparam>
        /// <typeparam name="TArg4">The type of the fourth argument.</typeparam>
        /// <typeparam name="TArg5">The type of the fifth argument.</typeparam>
        /// <typeparam name="TArg6">The type of the sixth argument.</typeparam>
        /// <typeparam name="TArg7">The type of the seventh argument.</typeparam>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <param name="arg5">The fifth argument.</param>
        /// <param name="arg6">The sixth argument.</param>
        /// <param name="arg7">The seventh argument.</param>
        /// <returns>An instance of <see cref="AsyncInitArgs"/>.</returns>
        public static AsyncInitArgs Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
        {
            return new AsyncInitArgs(
				new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7) },
				new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 });
        }

    }
}
