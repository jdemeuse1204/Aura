using Aura.AddOns.Step;
using Aura.Models;
using Aura.Processors.ProcessingStep.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Processors.ProcessingStep
{
    public class IsSessionLockedStep : IProcessingStep
    {
        public bool CanProcess => true;

        public void Run(Session session, List<IProcessRollup> processRollups)
        {
            if (session.IsSessionLocked == true)
            {
                var runningProcesses = processRollups.SelectMany(w => w.Processes).Where(w => w.IsRunning);

                // end all processes that are running
                foreach (var process in runningProcesses)
                {
                    process.SetNotActive();
                }
            }
        }
    }
}
