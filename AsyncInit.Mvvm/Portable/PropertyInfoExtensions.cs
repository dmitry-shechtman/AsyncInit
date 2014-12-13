using System.Reflection;

namespace Ditto.AsyncInit.Mvvm
{
    internal static class PropertyInfoExtensions
    {
        //[Property]
        public static MethodInfo GetGetMethod(this PropertyInfo propertyInfo)
        {
            return propertyInfo.GetMethod;
        }
    }
}
