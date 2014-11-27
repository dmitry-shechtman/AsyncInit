using System.Threading;
using System.Threading.Tasks;

namespace DmitryShechtman.Tasks
{
    public abstract class CancelableAsyncInitBase<T> : AsyncInitBase<T>, ICancelableAsyncInit
        where T : CancelableAsyncInitBase<T>
    {
        public static Task<T> CreateAsync(CancellationToken cancellationToken)
        {
            return AsyncActivator.CreateAsync<T>(cancellationToken);
        }

        protected override Task InitAsync()
        {
            return InitAsync(CancellationToken.None);
        }

        protected abstract Task InitAsync(CancellationToken cancellationToken);

        Task ICancelableAsyncInit.InitAsync(CancellationToken cancellationToken)
        {
            return InitAsync(cancellationToken);
        }
    }

    public abstract class CancelableAsyncInitBase<T, TArg> : AsyncInitBase<T, TArg>, ICancelableAsyncInit<TArg>
        where T : CancelableAsyncInitBase<T, TArg>
    {
        public static Task<T> CreateAsync(TArg arg, CancellationToken cancellationToken)
        {
            return AsyncActivator.CreateAsync<T, TArg>(arg, cancellationToken);
        }

        protected override Task InitAsync(TArg arg)
        {
            return InitAsync(arg, CancellationToken.None);
        }

        protected abstract Task InitAsync(TArg arg, CancellationToken cancellationToken);

        Task ICancelableAsyncInit<TArg>.InitAsync(TArg arg, CancellationToken cancellationToken)
        {
            return InitAsync(arg, cancellationToken);
        }
    }
}
