﻿using System;
using System.Linq;
using System.Reflection;

namespace Ditto.AsyncInit.Internal
{
    /// <summary>
    /// Provides utility methods for AsyncActivator.
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Creates an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type to create.</typeparam>
        /// <returns>A reference to the newly created object.</returns>
        public static T CreateInstance<T>()
        {
            var typeInfo = typeof(T).GetTypeInfo();
            var ctor = typeInfo.DeclaredConstructors.SingleOrDefault(c => !c.IsStatic && c.GetParameters().Length == 0);
            if (ctor == null)
                throw new MissingMemberException("No parameterless constructor is defined for this type.");
            return (T)ctor.Invoke(null);
        }
    }
}
