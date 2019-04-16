using Aura.AddOns;
using System.Collections.Generic;

namespace Aura.Processors
{
    public class MainProcessorEventArgs : IMainProcessorEventArgs
    {
        public MainProcessorEventArgs(IEnumerable<IProcessRollup> rollups)
        {
            Rollups = rollups;
        }

        public IEnumerable<IProcessRollup> Rollups { get; }
    }
}
