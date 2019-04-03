using Aura.AddOns.Step;
using Aura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
