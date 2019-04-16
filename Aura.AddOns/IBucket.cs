using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.AddOns
{
    public interface IBucket
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
