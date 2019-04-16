using Aura.Common.Helpers;
using Aura.Data.Interfaces;
using Aura.Services.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aura.Services
{
    public class RuleManager : IRuleManager
    {
        private readonly IRuleRepository RuleRepository;
        private readonly IRulesFactory RulesFactory;

        [Inject]
        public RuleManager(IRuleRepository ruleRepository, IRulesFactory rulesFactory)
        {
            RuleRepository = ruleRepository;
            RulesFactory = rulesFactory;
        }

        public IEnumerable<string> GetWhenProperties()
        {
            return RuleRepository.GetWhenProperties();
        }

        public IEnumerable<string> GetWhenRuleNames()
        {
            return RuleRepository.GetWhenRuleNames().Select(w => StringHelpers.SeparateStringOnCasing(w));
        }
    }
}
