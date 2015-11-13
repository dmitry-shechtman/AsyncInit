using System;
using System.Collections.Generic;
using System.Globalization;

namespace Ditto.AsyncInit.Services
{
    /// <summary>
    /// Represents errors that occur during asynchronous initialization.
    /// </summary>
    public class AsyncInitializerException : AggregateException
    {
        private readonly Type _type;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncInitializerException"/> class.
        /// </summary>
        /// <param name="type">The type of object to initialize.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        internal AsyncInitializerException(Type type, Exception innerException)
            : base(GetMessage(type), innerException)
        {
            this._type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncInitializerException"/> class.
        /// </summary>
        /// <param name="type">The type of object to initialize.</param>
        /// <param name="innerExceptions">The exceptions that are the cause of the current exception.</param>
        internal AsyncInitializerException(Type type, IEnumerable<Exception> innerExceptions)
            : base(GetMessage(type), innerExceptions)
        {
            this._type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncInitializerException"/> class.
        /// </summary>
        /// <param name="type">The type of object to initialize.</param>
        /// <param name="innerMessage">The error message that explains the reason for the exception.</param>
        internal AsyncInitializerException(Type type, string innerMessage)
            : base(GetMessage(type, innerMessage))
        {
            this._type = type;
        }

        internal Type Type
        {
            get { return _type; }
        }

        private static string GetMessage(Type type)
        {
            return string.Format(CultureInfo.CurrentCulture, "Cannot initialize {0}.", type);
        }

        private static string GetMessage(Type type, string innerMessage)
        {
            return string.Format(CultureInfo.CurrentCulture, "Cannot initialize {0}: {1}", type, innerMessage);
        }
    }
}
