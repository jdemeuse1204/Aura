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
    public class PropertyEquals<T> : WhenBase, IRule, IWhen<T> where T : class
    {
        public PropertyEquals(string propertyName) : base(nameof(PropertyEquals<T>), propertyName)
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
                    compareValueString == propertyValueString;
            });
        }
    }
}
