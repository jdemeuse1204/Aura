using Aura.Processors.ProcessingStep.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Processors.Factories.Interfaces
{
    public interface IProcessingFactory
    {
        IEnumerable<IProcessingStep> All();
        IProcessingStep Get<T>() where T : IProcessingStep;
    }
}
