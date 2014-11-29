using System;
using System.Linq;
using System.Reflection;

namespace DmitryShechtman.Tasks
{
    internal static class Utils
    {
        public static T CreateInstance<T>()
        {
            var typeInfo = typeof(T).GetTypeInfo();
            var ctor = typeInfo.DeclaredConstructors.SingleOrDefault(c => c.GetParameters().Length == 0);
            if (ctor == null)
                throw new MissingMemberException("No parameterless constructor defined for this object.");
            return (T)ctor.Invoke(null);
        }
    }
}
