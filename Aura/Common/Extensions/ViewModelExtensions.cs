using Aura.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        private static void RaisePropertyChangedEvent<T>(T instance, string propertyName)
        {
            typeof(ViewModel).GetMethod("RaisePropertyChangedEvent", BindingFlags.NonPublic | BindingFlags.Instance)?.Invoke(instance, new object[] { propertyName });
        }
    }
}
