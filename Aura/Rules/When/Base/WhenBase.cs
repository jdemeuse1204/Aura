using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Rules.When.Base
{
    public abstract class WhenBase
    {
        public bool When<T, K>(T instance, Expression<Func<T, K>> property, Func<K, bool> comparison) where T : class
        {
            if (property.Body is MemberExpression memberExpression)
            {
                K propertyValue = (K)((PropertyInfo)memberExpression.Member).GetValue(instance);

                return comparison(propertyValue);
            }

            return false;
        }
    }
}
