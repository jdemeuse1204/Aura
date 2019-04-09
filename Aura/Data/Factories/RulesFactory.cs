using Aura.AddOns.Step;
using Aura.Data.Interfaces;
using Aura.Rules.Interfaces;
using Aura.Rules.Then;
using Aura.Rules.When;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
