using Aura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Processors
{
    public class MainProcessorEventArgs
    {
        public MainProcessorEventArgs(IEnumerable<ProcessRollup> rollups)
        {
            Rollups = rollups;
        }

        public IEnumerable<ProcessRollup> Rollups { get; }
    }
}
