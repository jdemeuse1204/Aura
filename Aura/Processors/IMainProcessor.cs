using Aura.AddOns.Step;
using Aura.Models;
using System.Collections.Generic;
using static Aura.Processors.MainProcessor;

namespace Aura.Processors
{
    public interface IMainProcessor
    {
        void Run();
        IEnumerable<IProcessRollup> Rollups { get; }
        event OnAfterRunHandler OnAfterRun;
    }
}
