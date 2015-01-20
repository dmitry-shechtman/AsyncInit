using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ditto.AsyncInit.Services.Internal
{
    static class TaskEx
    {
        public static Task<TResult> FromResult<TResult>(TResult result)
        {
            return Task.FromResult(result);
        }

        public static Task<TResult[]> WhenAll<TResult>(IEnumerable<Task<TResult>> tasks)
        {
            return Task.WhenAll(tasks);
        }
    }
}
