using Aura.Rules.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Data.Interfaces
{
    public interface IRuleRepository
    {
        void Save(IRule rule);
        IEnumerable<T> GetAllRules<T>() where T : class, IRule, new();
        bool RulesExist();
        IEnumerable<string> GetWhenProperties();
        IEnumerable<string> GetWhenRuleNames();
    }
}
