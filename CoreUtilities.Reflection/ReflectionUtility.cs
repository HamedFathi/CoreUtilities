using System;
using System.Reflection;

namespace CoreUtilities
{
    public static class ReflectionUtility
    {
        public static TProperty GetProperty<TClass, TProperty>(TClass instance, string propertyName)
                      where TClass : class
        {
            if (propertyName == null || string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException(nameof(propertyName), "Value can not be null or empty.");

            object obj = null;
            var type = instance.GetType();
            var info = type.GetTypeInfo().GetProperty(propertyName);
            if (info != null)
                obj = info.GetValue(instance, null);
            return (TProperty)obj;
        }

        public static void SetProperty<TClass>(TClass classInstance, string propertyName, object propertyValue)
                    where TClass : class
        {
            if (propertyName == null || string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException(nameof(propertyName), "Value can not be null or empty.");

            var type = classInstance.GetType();
            var info = type.GetTypeInfo().GetProperty(propertyName);

            if (info != null)
                info.SetValue(classInstance, Convert.ChangeType(propertyValue, info.PropertyType), null);
        }
    }
}
