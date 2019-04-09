using Aura.Common.Behavior;
using Aura.Models;
using Aura.Rules.Interfaces;
using Aura.Rules.When;
using Aura.ViewModels.Base;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aura.ViewModels.Modal
{
    public class AddBucketControlViewModel : ViewModel
    {
        public ActionCommand<object> DeleteRuleItemClick => new ActionCommand<object>(DeleteRuleItemHandler);

        public IEnumerable<IRule> WhenRules { get; set; }
        public IEnumerable<IRule> ThenRules { get; set; }
        public RuleItem Item { get; set; }

        [Inject]
        public AddBucketControlViewModel()
        {
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
    }
}
