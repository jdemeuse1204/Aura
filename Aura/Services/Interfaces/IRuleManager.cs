using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Services.Interfaces
{
    public interface IRuleManager
    {
        IEnumerable<string> GetWhenProperties();
        IEnumerable<string> GetWhenRuleNames();
    }
}
