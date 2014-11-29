using System.Threading.Tasks;

namespace DmitryShechtman.Tasks
{
    /// <summary>
    /// Base class for asynchronously initialized types.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    public abstract class AsyncInitBase<T> : IAsyncInit
        where T : AsyncInitBase<T>
    {
        /// <summary>
        /// Deriving types should implement a private parameterless constructor.
        /// </summary>
        /// <param name="dummy">Dummy parameter (safe to pass <value>null</value>).</param>
        protected AsyncInitBase(object dummy)
        {
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance.
        /// </summary>
        /// <returns>A Task capturing the initialization.</returns>
        public static Task<T> CreateAsync()
        {
            return AsyncActivator.CreateAsync<T>();
        }

        /// <summary>
        /// Asynchronously initializes an instance. Overridden by the deriving type.
        /// </summary>
        /// <returns>A Task capturing the initialization.</returns>
        protected abstract Task InitAsync();

        Task IAsyncInit.InitAsync()
        {
            return InitAsync();
        }
    }

    /// <summary>
    /// Base class for asynchronously initialized types.
    /// </summary>
    /// <typeparam name="T">The deriving type.</typeparam>
    /// <typeparam name="TArg">The argument type.</typeparam>
    public abstract class AsyncInitBase<T, TArg> : IAsyncInit<TArg>
        where T : AsyncInitBase<T, TArg>
    {
        /// <summary>
        /// Deriving types should implement a private parameterless constructor.
        /// </summary>
        /// <param name="dummy">Dummy parameter (safe to pass <value>null</value>).</param>
        protected AsyncInitBase(object dummy)
        {
        }

        /// <summary>
        /// Asynchronously creates and initializes an instance.
        /// </summary>
        /// <param name="arg">The argument to pass to the object.</param>
        /// <returns>A Task capturing the initialization.</returns>
        public static Task<T> CreateAsync(TArg arg)
        {
            return AsyncActivator.CreateAsync<T, TArg>(arg);
        }

        /// <summary>
        /// Asynchronously initializes an instance. Overridden by the deriving type.
        /// </summary>
        /// <param name="arg">The initialization argument.</param>
        /// <returns>A Task capturing the initialization.</returns>
        protected abstract Task InitAsync(TArg arg);

        Task IAsyncInit<TArg>.InitAsync(TArg arg)
        {
            return InitAsync(arg);
        }
    }
}
