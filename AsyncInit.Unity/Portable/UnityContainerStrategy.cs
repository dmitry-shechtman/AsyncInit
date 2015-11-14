using Ditto.AsyncInit.Services;
using Microsoft.Practices.Unity;
using System;

namespace Ditto.AsyncInit.Unity
{
    /// <summary>
    /// Unity dependency injection container strategy.
    /// </summary>
    public class UnityContainerStrategy : IContainerStrategy
    {
        private readonly IUnityContainer _container;
        private readonly DependencyOverride _override;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityContainerStrategy"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public UnityContainerStrategy(IUnityContainer container)
        {
            this._container = container;
            this._override = new DependencyOverride<UnityContainerStrategy>(this);
        }

        /// <summary>
        /// Builds up an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to build up.</typeparam>
        /// <param name="value">The object to build up.</param>
        public void BuildUp<T>(T value)
        {
            _container.BuildUp(value, _override);
        }

        /// <summary>
        /// Attempts to resolve an instance of the specified type.
        /// </summary>
        /// <param name="type">The type of object to resolve.</param>
        /// <param name="value">Resolved value (or <c>null</c> if unsuccessful).</param>
        /// <returns><c>true</c> if successful or <c>false</c> otherwise.</returns>
        public bool TryResolve(Type type, out object value)
        {
            try
            {
                value = _container.Resolve(type, _override);
                return true;
            }
            catch (ResolutionFailedException)
            {
                value = null;
                return false;
            }
        }
    }
}
