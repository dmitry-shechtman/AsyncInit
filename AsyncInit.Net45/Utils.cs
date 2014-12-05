using System;

namespace Ditto.AsyncInit
{
    /// <summary>
    /// Provides utility methods for AsyncActivator.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Creates an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type to create.</typeparam>
        /// <returns>A reference to the newly created object.</returns>
        public static T CreateInstance<T>()
        {
            return (T)Activator.CreateInstance(typeof(T), true);
        }
    }
}
