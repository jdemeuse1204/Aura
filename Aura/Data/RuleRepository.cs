using Aura.Data.Interfaces;
using Aura.Rules.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Data
{
    public class RuleRepository : IRuleRepository
    {
        private readonly IRuleJsonDataReaderWriter RuleJsonDataReaderWriter;

        [Inject]
        public RuleRepository(IRuleJsonDataReaderWriter ruleJsonDataReaderWriter)
        {
            RuleJsonDataReaderWriter = ruleJsonDataReaderWriter;
        }

        public void Save(IRule rule)
        {
            RuleJsonDataReaderWriter.Write(rule);
        }

        public IEnumerable<T> GetAllRules<T>() where T : class, IRule, new()
        {
            return RuleJsonDataReaderWriter.All<T>();
        }

        public bool RulesExist()
        {
            return RuleJsonDataReaderWriter.HasData();
        }
    }
}
