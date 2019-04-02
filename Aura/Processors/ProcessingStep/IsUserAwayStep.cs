using Aura.Models;
using Aura.Processors.ProcessingStep.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Processors.ProcessingStep
{
    public class IsUserAwayStep : IProcessingStep
    {
        public bool CanProcess => true;

        public void Run(Session session, List<ProcessRollup> processRollups)
        {
            if ((DateTime.Now - session.LastActivityDateTime).TotalMinutes >= 1)
            {
                // user is away
                session.IsUserInactive = true;
            }
            else
            {
                session.IsUserInactive = false;
            }
        }
    }
}
