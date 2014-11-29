using System;

namespace DmitryShechtman.Tasks
{
    internal static class Utils
    {
        public static T CreateInstance<T>()
        {
            return (T)Activator.CreateInstance(typeof(T), true);
        }
    }
}
