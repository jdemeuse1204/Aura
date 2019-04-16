using Aura.AddOns;
using Aura.Data.Interfaces;
using Aura.Rules.Interfaces;
using System.Collections.Generic;

namespace Aura.Data.Factories
{
    public class RulesFactory : IRulesFactory
    {
        public IEnumerable<IWhen<T>> GetWhens<T>() where T : class
        {
            return new List<IWhen<T>>
            {

            };
        }

        public IEnumerable<IThen<T, K>> GetThens<T, K>() where T : class, IWindowsProcess where K : class, IBucket
        {
            return new List<IThen<T, K>>
            {

            };
        }
    }
}
