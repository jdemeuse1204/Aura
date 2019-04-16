using Aura.ViewModels.Base;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Aura.Common.Extensions
{
    public static class ViewModelExtensions
    {
        public static void SetProperty<T, K>(this T instance, Expression<Func<T, K>> propertyFunction, K value) where T : ViewModel
        {
            if (propertyFunction.Body is MemberExpression memberExpression)
            {
                ((PropertyInfo)memberExpression.Member).SetValue(instance, value, null);
                RaisePropertyChangedEvent(instance, memberExpression.Member.Name);
            }
        }

        public static void RaisePropertyChanged<T>(this T instance, Expression<Func<T, object>> propertyFunction) where T : ViewModel
        {
            if (propertyFunction.Body is MemberExpression memberExpression)
            {
                RaisePropertyChangedEvent(instance, GetPropertyName(memberExpression));
            }
        }

        private static string GetPropertyName(MemberExpression expression)
        {
            return expression.Member.Name;
        }

        private static void RaisePropertyChangedEvent<T>(T instance, string propertyName)
        {
            typeof(ViewModel).GetMethod("RaisePropertyChangedEvent", BindingFlags.NonPublic | BindingFlags.Instance)?.Invoke(instance, new object[] { propertyName });
        }
    }
}
