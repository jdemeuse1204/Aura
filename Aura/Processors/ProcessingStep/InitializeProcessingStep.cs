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
    public class InitializeProcessingStep : IProcessingStep
    {
        public bool CanProcess { get; private set; }

        public InitializeProcessingStep()
        {
            CanProcess = true;
        }

        public void Run(Session session, List<IProcessRollup> processRollups)
        {
            session.LastActivityDateTime = DateTime.Now;

            // only process once
            CanProcess = false;
        }
    }
}
