using Aura.Models.Types;
using Aura.Rules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Models
{
    public class RuleItem
    {
        public string Name { get; set; }
        public List<BucketRule> Rules { get; set; }
    }
}
