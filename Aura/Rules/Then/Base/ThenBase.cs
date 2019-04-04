using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Rules.Then.Base
{
    public abstract class ThenBase
    {
        public void Then<T, K>(T instance, K value, Action<T, K> action) where T : class
        {
            action(instance, value);
        }
    }
}
