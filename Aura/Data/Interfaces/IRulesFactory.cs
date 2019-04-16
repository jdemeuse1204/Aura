using Aura.AddOns;
using Aura.Rules.Interfaces;
using System.Collections.Generic;

namespace Aura.Data.Interfaces
{
    public interface IRulesFactory
    {
        IEnumerable<IWhen<T>> GetWhens<T>() where T : class;

        IEnumerable<IThen<T, K>> GetThens<T, K>() where T : class, IWindowsProcess where K : class, IBucket;
    }
}
