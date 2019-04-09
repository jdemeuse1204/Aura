using Aura.Rules.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Rules.Then.Base
{
    public abstract class ThenBase : RuleBase
    {
        public ThenBase(string ruleName) 
            : base(ruleName)
        {
        }

        public void Then<T, K>(T instance, K value, Action<T, K> action) where T : class
        {
            action(instance, value);
        }
    }
}
