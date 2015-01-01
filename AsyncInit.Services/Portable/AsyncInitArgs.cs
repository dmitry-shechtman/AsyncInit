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
        /// The types of the arguments.
        /// </summary>
        public Type[] Types
        {
            get { return _types; }
        }

        /// <summary>
        /// The arguments.
        /// </summary>
        public object[] Arguments
        {
            get { return _args; }
        }

        /// <summary>
        /// Argument count.
        /// </summary>
        public int Count
        {
            get { return _args.Length; }
        }
    }
}
