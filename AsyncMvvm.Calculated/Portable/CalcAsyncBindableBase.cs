namespace Ditto.AsyncMvvm.Calculated
{
    /// <summary>
    /// Base class for entities with asynchronous and calculated properties.
    /// </summary>
    public abstract class CalcAsyncBindableBase : AsyncBindableBase<ICalcAsyncPropertyHelper>
    {
        private readonly CalcAsyncPropertyHelper _propertyHelper;

        /// <summary>
        /// Creates a new instance of the entity.
        /// </summary>
        protected CalcAsyncBindableBase()
        {
            this._propertyHelper = new CalcAsyncPropertyHelper(OnPropertyChanged);
        }

        /// <summary>
        /// Asynchronous property helper.
        /// </summary>
        protected override ICalcAsyncPropertyHelper Property
        {
            get { return _propertyHelper; }
        }
    }
}
