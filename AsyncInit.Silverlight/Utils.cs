using System;
using System.Reflection;

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
            var ctor = typeof(T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], null);
            if (ctor == null)
                throw new MissingMemberException("No parameterless constructor defined for this object.");
            return (T)ctor.Invoke(null);
        }
    }
}
