using Aura.Data.Interfaces;
using Aura.Rules.Interfaces;
using Aura.Rules.When;
using Aura.Services.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
