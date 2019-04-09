using Aura.Rules.Interfaces;
using Aura.Rules.When.Base;
using System;
using System.Linq.Expressions;

namespace Aura.Rules.When
{
    public class PropertyContains<T> : WhenBase, IRule, IWhen<T> where T : class
    {
        public PropertyContains(string propertyName) : base(nameof(PropertyContains<T>), propertyName)
        {
        }

        public bool IsTrue<K>(T instance, string propertyName, K compareValue)
        {
            return When(instance, propertyName, (K propertyValue) => 
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
