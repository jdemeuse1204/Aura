using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Models
{
    public class RuleItem
    {
        public string Name { get; set; }
        public List<BucketRule> Rules { get; set; }
    }
}
