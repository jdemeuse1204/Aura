using Aura.AddOns.Step;
using Aura.Rules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Data.Interfaces
{
    public interface IRulesFactory
    {
        IEnumerable<IWhen<T>> GetWhens<T>() where T : class;

        IEnumerable<IThen<T, K>> GetThens<T, K>() where T : class, IWindowsProcess where K : class, IBucket;
    }
}
