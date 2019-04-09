using Aura.Rules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Data.Interfaces
{
    public interface IRuleRepository
    {
        void Save(IRule rule);
        IEnumerable<T> GetAllRules<T>() where T : class, IRule, new();
        bool RulesExist();
    }
}
