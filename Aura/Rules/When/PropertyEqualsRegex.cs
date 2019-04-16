using Aura.Rules.Interfaces;
using Aura.Rules.When.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Aura.Rules.When
{
    public class PropertyEqualsRegex<T> : WhenBase, IRule, IWhen<T> where T : class
    {
        public PropertyEqualsRegex(string propertyName) : base(nameof(PropertyEqualsRegex<T>), propertyName)
        {
        }

        public bool IsTrue<K>(T instance, string propertyName, K compareValue)
        {
            return When(instance, propertyName, (K propertyValue) =>
            {
                return propertyValue != null &&
                    propertyValue is string propertyValueString &&
                    compareValue != null &&
                    compareValue is Regex compareValueRegex &&
                    compareValueRegex.IsMatch(propertyValueString);
            });
        }
    }
}
