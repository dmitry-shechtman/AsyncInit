using System;

namespace Ditto.AsyncInit.Services
{
    /// <summary>
    /// Interface for dependency injection container strategies.
    /// </summary>
    public interface IContainerStrategy
    {
        /// <summary>
        /// Builds up an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to build up.</typeparam>
        /// <param name="value">The object to build up.</param>
        void BuildUp<T>(T value);

        /// <summary>
        /// Attempts to resolve an instance of the specified type.
        /// </summary>
        /// <param name="type">The type of object to resolve.</param>
        /// <param name="value">Resolved value (or <value>null</value> if unsuccessful).</param>
        /// <returns><value>true</value> if successful or <value>false</value> otherwise.</returns>
        bool TryResolve(Type type, out object value);
    }
}
