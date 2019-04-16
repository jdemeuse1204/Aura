using Aura.Common;
using Aura.Common.Behavior;
using Aura.Models;
using Aura.Rules.Interfaces;
using Aura.Services.Interfaces;
using Aura.ViewModels.Base;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Aura.ViewModels.Modal
{
    public class AddBucketControlViewModel : ViewModel
    {
        private readonly IRuleManager RuleManager;


        #region Commands
        public ICommand SaveClick => new CommandHandler(() => SaveHandler(), true);
        public ActionCommand<object> DeleteRuleItemClick => new ActionCommand<object>(DeleteRuleItemHandler);
        #endregion

        public IEnumerable<IRule> WhenRules { get; set; }
        public IEnumerable<IRule> ThenRules { get; set; }
        public RuleItem Item { get; set; }
        public List<string> WhenRuleNames { get; set; }
        public List<string> WhenPropertyNames { get; set; }
        public List<string> ThenRuleNames { get; set; }

        [Inject]
        public AddBucketControlViewModel(IRuleManager ruleManager)
        {
            RuleManager = ruleManager;
            WhenRuleNames = RuleManager.GetWhenRuleNames().ToList();
            WhenPropertyNames = RuleManager.GetWhenProperties().ToList();
            Item = new RuleItem
            {
                Rules = new List<BucketRule>
                {
                    new BucketRule()
                }
            };
        }

        private void DeleteRuleItemHandler(object e)
        {

        }

        private void SaveHandler()
        {

        }
    }
}
