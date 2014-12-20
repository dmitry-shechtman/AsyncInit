namespace Ditto.AsyncMvvm
{
    /// <summary>
    /// Interface for properties.
    /// </summary>
    public interface IProperty
    {
        /// <summary>
        /// Invalidates the property.
        /// </summary>
        /// <param name="isNotify">Indicates whether the notification delegate will be invoked.</param>
        /// <param name="propertyName">The name of the property.</param>
        void Invalidate(bool isNotify, string propertyName);
    }
}
