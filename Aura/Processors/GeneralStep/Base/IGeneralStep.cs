using Aura.AddOns;
using Aura.Models;
using System.Collections.Generic;

namespace Aura.Processors.GeneralStep.Base
{
    public interface IGeneralStep
    {
        void Run(Session session, List<IProcessRollup> processRollups);
    }
}
