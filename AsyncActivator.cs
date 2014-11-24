using System;
using System.Threading.Tasks;

namespace DmitryShechtman.Tasks
{
    public static class AsyncActivator
    {
        public static async Task<T> CreateAsync<T>()
            where T : IAsyncInit
        {
            T value = (T)Activator.CreateInstance(typeof(T), true);
            await value.InitAsync();
            return value;
        }

        public static async Task<T> CreateAsync<T, TArg>(TArg arg)
            where T : IAsyncInit<TArg>
        {
            T value = (T)Activator.CreateInstance(typeof(T), true);
            await value.InitAsync(arg);
            return value;
        }
    }
}
