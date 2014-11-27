using System.Threading;
using System.Threading.Tasks;

namespace DmitryShechtman.Tasks
{
    public interface ICancelableAsyncInit
    {
        Task InitAsync(CancellationToken cancellationToken);
    }

    public interface ICancelableAsyncInit<TArg>
    {
        Task InitAsync(TArg arg, CancellationToken cancellationToken);
    }
}
