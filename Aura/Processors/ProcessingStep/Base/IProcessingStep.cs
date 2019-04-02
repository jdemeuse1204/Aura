using Aura.Processors.GeneralStep.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Processors.ProcessingStep.Base
{
    public interface IProcessingStep : IGeneralStep
    {
        bool CanProcess { get; }
    }
}
