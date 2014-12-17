namespace Ditto.AsyncInit.Mvvm
{
    /// <summary>
    /// Base class for entities with asynchronous initialization support.
    /// </summary>
    public abstract class AsyncBindableBase : BindableBase
    {
        private readonly AsyncPropertyHelper _propertyHelper;

        /// <summary>
        /// Creates a new instance of the entity.
        /// </summary>
        public AsyncBindableBase()
        {
            _propertyHelper = new AsyncPropertyHelper(OnPropertyChanged);
        }

        /// <summary>
        /// Asynchronous property helper.
        /// </summary>
        protected AsyncPropertyHelper Property
        {
            get { return _propertyHelper; }
        }
    }
}
