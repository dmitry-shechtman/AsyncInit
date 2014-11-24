using System.Threading.Tasks;

namespace DmitryShechtman.Tasks
{
    public abstract class AsyncInitBase<T> : IAsyncInit
        where T : AsyncInitBase<T>
    {
        public static Task<T> CreateAsync()
        {
            return AsyncActivator.CreateAsync<T>();
        }

        protected abstract Task InitAsync();

        Task IAsyncInit.InitAsync()
        {
            return InitAsync();
        }
    }

    public abstract class AsyncInitBase<T, TArg> : IAsyncInit<TArg>
        where T : AsyncInitBase<T, TArg>
    {
        public static Task<T> CreateAsync(TArg arg)
        {
            return AsyncActivator.CreateAsync<T, TArg>(arg);
        }

        protected abstract Task InitAsync(TArg arg);

        Task IAsyncInit<TArg>.InitAsync(TArg arg)
        {
            return InitAsync(arg);
        }
    }
}
