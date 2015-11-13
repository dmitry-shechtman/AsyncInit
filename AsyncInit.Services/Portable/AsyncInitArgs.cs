using System;
using System.Linq;

namespace Ditto.AsyncInit.Services
{
    /// <summary>
    /// Asynchronous initialization arguments.
    /// </summary>
    public sealed partial class AsyncInitArgs
    {
        /// <summary>
        /// Empty asynchronous initialization arguments.
        /// </summary>
        public static readonly AsyncInitArgs Empty = new AsyncInitArgs(new Type[0], new object[0]);

        private readonly Type[] _types;
        private readonly object[] _args;

        private AsyncInitArgs(Type[] types, object[] args)
        {
            this._types = types;
            this._args = args;
        }

        /// <summary>
        /// Gets the types of the arguments.
        /// </summary>
        /// <value>Types of the arguments.</value>
        public Type[] Types
        {
            get { return _types; }
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>Arguments.</value>
        public object[] Arguments
        {
            get { return _args; }
        }

        /// <summary>
        /// Gets the argument count.
        /// </summary>
        /// <value>Argument count.</value>
        public int Count
        {
            get { return _args.Length; }
        }
    }
}
