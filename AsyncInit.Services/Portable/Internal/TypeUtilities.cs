using System;

namespace Ditto.AsyncInit.Services.Internal
{
    internal static class TypeUtilities
    {
        private static readonly string Nullable = typeof(Nullable).FullName;
        private static readonly string Tuple = typeof(Tuple).FullName;
        private static readonly string IAsyncInit = typeof(IAsyncInit).FullName;
        private static readonly string ICancelableAsyncInit = typeof(ICancelableAsyncInit).FullName;

        /// <summary>
        /// Checks whether the specified type is a <see cref="Nullable"/>.
        /// </summary>
        /// <param name="type">Type to check.</param>
        /// <returns><value>true</value> if the type is a constructed <see cref="System.Nullable{T}"/> type.</returns>
        public static bool IsNullable(Type type)
        {
            var name = GetPartialName(type);
            return name == Nullable;
        }

        /// <summary>
        /// Checks whether the specified type is a <see cref="Tuple"/>.
        /// </summary>
        /// <param name="type">Type to check.</param>
        /// <returns><value>true</value> if the type is a constructed <see cref="Tuple"/> type.</returns>
        public static bool IsTuple(Type type)
        {
            var name = GetPartialName(type);
            return name == Tuple;
        }

        /// <summary>
        /// Checks whether the specified type is a <see cref="IAsyncInit"/> or a <see cref="ICancelableAsyncInit"/>.
        /// </summary>
        /// <param name="type">Type to check.</param>
        /// <returns>
        /// <value>true</value> if the type is <see cref="IAsyncInit"/>, <see cref="ICancelableAsyncInit"/>,
        /// or a constructed <see cref="IAsyncInit"/> or <see cref="ICancelableAsyncInit"/> type.
        /// </returns>
        public static bool IsAsyncInit(Type type)
        {
            var name = GetPartialName(type);
            return name == IAsyncInit || name == ICancelableAsyncInit;
        }

        /// <summary>
        /// Checks whether the specified type is a <see cref="ICancelableAsyncInit"/>.
        /// </summary>
        /// <param name="type">Type to check.</param>
        /// <returns>
        /// <value>true</value> if the type is <see cref="ICancelableAsyncInit"/> or a constructed
        /// <see cref="ICancelableAsyncInit"/> type.
        /// </returns>
        public static bool IsCancelable(Type type)
        {
            var name = GetPartialName(type);
            return name == ICancelableAsyncInit;
        }

        /// <summary>
        /// Gets the partial name of the specified type.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <returns>The fully qualified type name without the generic argument suffix.</returns>
        private static string GetPartialName(Type type)
        {
            return type.FullName.Split('`')[0];
        }
    }
}
