using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Rules.Interfaces
{
    public interface IRule
    {
        string Name { get; }
        string DisplayName { get; }
        Guid Id { get; }
    }
}
