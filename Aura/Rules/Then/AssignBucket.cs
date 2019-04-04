using Aura.AddOns.Step;
using Aura.Rules.Interfaces;
using Aura.Rules.Then.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Rules.Then
{
    public class AssignBucket<T, K> : ThenBase, IThen<T, K> where T : class, IWindowsProcess where K : class, IBucket
    {
        public void Do(T instance, K value)
        {
            Then(instance, value, (T t, K k) => 
            {
                t.Bucket = k;
            });
        }
    }
}
