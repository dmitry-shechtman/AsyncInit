using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Ditto.AsyncInit.Mvvm
{
    internal static class Utils
    {
        public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException("propertyExpression");
            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("The expression must be a member expression", "propertyExpression");
            var property = memberExpression.Member as PropertyInfo;
            if (property == null)
                throw new ArgumentException("The expression must be a property expression", "propertyExpression");
            var getMethod = property.GetGetMethod();
            if (getMethod == null)
                throw new ArgumentException("The property must have a public getter", "propertyExpression");
            return property.Name;
        }
    }
}
