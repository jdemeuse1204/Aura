using Aura.Processors.GeneralStep.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Processors.ProcessingStep.Base
{
    public interface IProcessingStep : IGeneralStep
    {
        bool CanProcess { get; }
    }
}
