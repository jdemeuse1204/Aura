using Aura.Rules.Interfaces;
using Aura.Rules.When.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aura.Rules.When
{
    public class PropertyEqualsRegex<T> : WhenBase, IWhen<T> where T : class
    {
        public bool IsTrue<K>(T instance, Expression<Func<T, K>> property, K compareValue) 
        {
            return When(instance, property, (K propertyValue) =>
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
