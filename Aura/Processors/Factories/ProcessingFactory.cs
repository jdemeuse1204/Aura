using Aura.Processors.ProcessingStep;
using Aura.Processors.ProcessingStep.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Processors.Factories
{
    public class ProcessingFactory
    {
        private readonly List<IProcessingStep> Steps;

        public ProcessingFactory()
        {
            // register steps
            Steps = new List<IProcessingStep>
            {
                new LoadProcessesRollupsStep(),
                new LoadSessionStep(),
                new InitializeProcessingStep(),   
                new IsUserAwayStep(),
                new IsSessionLockedStep(),
                new WindowsCurrentRunningProcessesStep(),
                new SaveProcessesStep(),
                new SaveSessionStep()
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
