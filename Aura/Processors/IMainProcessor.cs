using Aura.Models;
using System.Collections.Generic;
using static Aura.Processors.MainProcessor;

namespace Aura.Processors
{
    public interface IMainProcessor
    {
        void Run();
        IEnumerable<ProcessRollup> Rollups { get; }
        event OnAfterRunHandler OnAfterRun;
    }
}
