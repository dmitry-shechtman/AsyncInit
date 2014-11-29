using System.Threading;
using System.Threading.Tasks;

namespace DmitryShechtman.Tasks
{
    public static class AsyncActivator
    {
        public static async Task<T> CreateAsync<T>()
            where T : IAsyncInit
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync().ConfigureAwait(false);
            return value;
        }

        public static async Task<T> CreateAsync<T>(CancellationToken cancellationToken)
            where T : ICancelableAsyncInit
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(cancellationToken).ConfigureAwait(false);
            return value;
        }

        public static async Task<T> CreateAsync<T, TArg>(TArg arg)
            where T : IAsyncInit<TArg>
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(arg).ConfigureAwait(false);
            return value;
        }

        public static async Task<T> CreateAsync<T, TArg>(TArg arg, CancellationToken cancellationToken)
            where T : ICancelableAsyncInit<TArg>
        {
            T value = Utils.CreateInstance<T>();
            await value.InitAsync(arg, cancellationToken).ConfigureAwait(false);
            return value;
        }
    }
}
