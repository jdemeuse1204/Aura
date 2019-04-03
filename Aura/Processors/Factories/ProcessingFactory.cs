using Aura.Processors.Factories.Interfaces;
using Aura.Processors.ProcessingStep;
using Aura.Processors.ProcessingStep.Base;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Processors.Factories
{
    public class ProcessingFactory : IProcessingFactory
    {
        private readonly List<IProcessingStep> Steps;

        public ProcessingFactory(IKernel kernel)
        {
            // register steps
            Steps = new List<IProcessingStep>
            {
                kernel.Get<LoadProcessesRollupsStep>(),
                kernel.Get<LoadSessionStep>(),
                kernel.Get<InitializeProcessingStep>(),
                kernel.Get<IsUserAwayStep>(),
                kernel.Get<IsSessionLockedStep>(),
                kernel.Get<WindowsCurrentRunningProcessesStep>(),
                kernel.Get<SaveProcessesStep>(),
                kernel.Get<SaveSessionStep>()
            };
        }

        public IEnumerable<IProcessingStep> All()
        {
            return Steps.Where(w => w.CanProcess);
        }

        public IProcessingStep Get<T>() where T : IProcessingStep
        {
            return Steps.FirstOrDefault(w => w.GetType() == typeof(T));
        }
    }
}
