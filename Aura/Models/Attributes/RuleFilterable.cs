using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class RuleFilterable : Attribute
    {
    }
}
