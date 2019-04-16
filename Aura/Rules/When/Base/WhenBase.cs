using Aura.Rules.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Rules.When.Base
{
    public abstract class WhenBase : RuleBase
    {
        public string PropertyName { get; }

        public WhenBase(string ruleName, string propertyName)
            : base(ruleName)
        {
            PropertyName = propertyName;
        }

        public bool When<T, K>(T instance, string propertyName, Func<K, bool> comparison) where T : class
        {
            K propertyValue = (K)typeof(T).GetProperty(propertyName).GetValue(instance);

            return comparison(propertyValue);
        }
    }
}
