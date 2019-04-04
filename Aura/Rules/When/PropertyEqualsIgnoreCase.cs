using Aura.Rules.Interfaces;
using Aura.Rules.When.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Rules.When
{
    public class PropertyEqualsIgnoreCase<T>: WhenBase, IWhen<T> where T : class
    {
        public bool IsTrue<K>(T instance, Expression<Func<T, K>> property, K compareValue)
        {
            return When(instance, property, (K propertyValue) =>
            {
                return propertyValue != null &&
                    propertyValue is string propertyValueString &&
                    compareValue != null &&
                    compareValue is string compareValueString &&
                    compareValueString.Equals(propertyValueString, StringComparison.OrdinalIgnoreCase);
            });
        }
    }
}
