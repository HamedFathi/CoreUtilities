using System;
using System.Linq.Expressions;
using System.Reflection;

namespace CoreUtilities
{
    public static class ExpressionUtility<T>
    {
        public static TAttribute GetCustomAttribute<TAttribute>(
                    Expression<Func<T, TAttribute>> selector) where TAttribute : Attribute
        {
            System.Linq.Expressions.Expression body = selector;
            if (body is LambdaExpression)
            {
                body = ((LambdaExpression)body).Body;
            }
            switch (body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    var str =
                        ((PropertyInfo)((MemberExpression)body).Member).GetCustomAttribute<TAttribute>();
                    return str;

                default:
                    throw new InvalidOperationException();
            }
        }

        public static Func<TObject, TProperty> GetProperty<TObject, TProperty>(string propertyName)
        {
            ParameterExpression paramExpression = Expression.Parameter(typeof(TObject), "value");

            Expression propertyGetterExpression = Expression.Property(paramExpression, propertyName);

            Func<TObject, TProperty> result = Expression.Lambda<Func<TObject, TProperty>>(propertyGetterExpression, paramExpression).Compile();

            return result;
        }

        public static Action<TObject, TProperty> SetProperty<TObject, TProperty>(string propertyName)
        {
            ParameterExpression paramExpression = Expression.Parameter(typeof(TObject));

            ParameterExpression paramExpression2 = Expression.Parameter(typeof(TProperty), propertyName);

            MemberExpression propertyGetterExpression = Expression.Property(paramExpression, propertyName);

            Action<TObject, TProperty> result = Expression.Lambda<Action<TObject, TProperty>>
                (Expression.Assign(propertyGetterExpression, paramExpression2), paramExpression, paramExpression2).Compile();

            return result;
        }
    }
}
