using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Rules.Interfaces
{
    public interface IRule
    {
        string Name { get; }
        string DisplayName { get; }
        Guid Id { get; }
    }
}
