using Aura.Rules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Models
{
    public class BucketRule
    {
        public string PropertyName { get; set; }
        public string RuleName { get; set; }
        public string Value { get; set; }
        public IRule Rule { get; set; }
    }
}
