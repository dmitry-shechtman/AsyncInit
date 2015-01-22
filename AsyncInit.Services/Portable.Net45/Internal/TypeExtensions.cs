using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ditto.AsyncInit.Services.Internal
{
    static class TypeExtensions
    {
        public static MethodInfo GetMethod(this Type type, string name)
        {
            return type.GetRuntimeMethod(name, new Type[0]);
        }

        public static MethodInfo GetMethod(this Type type, string name, Type[] parameters)
        {
            return type.GetRuntimeMethod(name, parameters);
        }

        public static Type[] GetGenericArguments(this Type type)
        {
            return type.GetTypeInfo().GenericTypeArguments;
        }

        public static IEnumerable<Type> GetInterfaces(this Type type)
        {
            return type.GetTypeInfo().ImplementedInterfaces;
        }

        public static bool IsAssignableFrom(this Type type, Type other)
        {
            return type.GetTypeInfo().IsAssignableFrom(other.GetTypeInfo());
        }

        public static bool GetIsAbstract(this Type type)
        {
            return type.GetTypeInfo().IsAbstract;
        }

        public static bool GetIsClass(this Type type)
        {
            return type.GetTypeInfo().IsClass;
        }

        public static bool GetIsValueType(this Type type)
        {
            return type.GetTypeInfo().IsValueType;
        }

        public static Type GetBaseType(this Type type)
        {
            return type.GetTypeInfo().BaseType;
        }
    }
}
