using System.Threading.Tasks;

namespace DmitryShechtman.Tasks
{
    public interface IAsyncInit
    {
        Task InitAsync();
    }

    public interface IAsyncInit<TArg>
    {
        Task InitAsync(TArg arg);
    }
}
