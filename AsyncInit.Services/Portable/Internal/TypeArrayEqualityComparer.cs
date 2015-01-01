using System;
using System.Collections.Generic;
using System.Linq;

namespace Ditto.AsyncInit.Services.Internal
{
    internal class TypeArrayEqualityComparer : IEqualityComparer<Type[]>
    {
        private static readonly TypeArrayEqualityComparer _instance = new TypeArrayEqualityComparer();

        public static TypeArrayEqualityComparer Instance
        {
            get { return _instance; }
        }

        private TypeArrayEqualityComparer()
        {
        }

        public bool Equals(Type[] t1, Type[] t2)
        {
            return t1 != null && t2 != null
                && t1.Length == t2.Length
                && Enumerable.Range(0, t1.Length).All(i => t1[i] == t2[i]);
        }

        public int GetHashCode(Type[] types)
        {
            return types.Aggregate(0, (hc, t) => hc ^ t.GetHashCode());
        }
    }
}
