using Aura.Rules.Interfaces;
using Aura.Rules.When.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Rules.When
{
    public class PropertyEqualsIgnoreCase<T> : WhenBase, IRule, IWhen<T> where T : class
    {
        public PropertyEqualsIgnoreCase(string propertyName) : base(nameof(PropertyEqualsIgnoreCase<T>), propertyName)
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
                    compareValueString.Equals(propertyValueString, StringComparison.OrdinalIgnoreCase);
            });
        }
    }
}
