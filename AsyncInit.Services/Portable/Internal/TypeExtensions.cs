using System;

namespace Ditto.AsyncInit.Services.Internal
{
    static class TypeExtensions
    {
        public static bool GetIsAbstract(this Type type)
        {
            return type.IsAbstract;
        }

        public static bool GetIsClass(this Type type)
        {
            return type.IsClass;
        }

        public static bool GetIsValueType(this Type type)
        {
            return type.IsValueType;
        }

        public static Type GetBaseType(this Type type)
        {
            return type.BaseType;
        }
    }
}
