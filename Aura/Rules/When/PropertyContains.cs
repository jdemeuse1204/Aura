using Aura.Rules.Interfaces;
using Aura.Rules.When.Base;
using System;
using System.Linq.Expressions;

namespace Aura.Rules.When
{
    public class PropertyContains<T> : WhenBase, IWhen<T> where T : class
    {
        public bool IsTrue<K>(T instance, Expression<Func<T, K>> property, K compareValue)
        {
            return When(instance, property, (K propertyValue) => 
            {
                return propertyValue != null && 
                    propertyValue is string propertyValueString && 
                    compareValue != null && 
                    compareValue is string compareValueString && 
                    propertyValueString.Contains(compareValueString);
            });
        }
    }
}
