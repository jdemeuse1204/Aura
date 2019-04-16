using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.AddOns
{
    public interface IMainProcessorEventArgs
    {
        IEnumerable<IProcessRollup> Rollups { get; }
    }
}
