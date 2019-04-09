using Aura.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Rules.Base
{
    public abstract class RuleBase
    {
        public Guid Id { get; }
        public string Name { get; }
        public string DisplayName { get; }

        public RuleBase(string ruleName)
        {
            Name = ruleName;
            DisplayName = StringHelpers.SeparateStringOnCasing(ruleName);
            Id = Guid.NewGuid();
        }
    }
}
