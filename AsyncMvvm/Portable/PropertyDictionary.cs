using System;
using System.Collections.Generic;

namespace Ditto.AsyncMvvm
{
    internal class PropertyDictionary
    {
        private readonly IDictionary<string, object> _properties;

        public PropertyDictionary()
        {
            this._properties = new Dictionary<string, object>();
        }

        public bool TryGetValue<T>(string propertyName, out T value)
        {
            if (propertyName == null)
                throw new ArgumentNullException("propertyName");
            object result;
            if (_properties.TryGetValue(propertyName, out result))
            {
                value = (T)result;
                return true;
            }
            value = default(T);
            return false;
        }

        public void Add(string propertyName, object value)
        {
            _properties[propertyName] = value;
        }

        public void SetValue(string propertyName, object value)
        {
            _properties[propertyName] = value;
        }

        public void Remove(string propertyName)
        {
            _properties.Remove(propertyName);
        }

        public void Clear()
        {
            _properties.Clear();
        }
    }
}
