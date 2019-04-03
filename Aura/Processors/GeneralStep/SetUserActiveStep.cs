using Aura.AddOns.Step;
using Aura.Models;
using Aura.Processors.GeneralStep.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Processors.GeneralStep
{
    public class SetUserActiveStep : IGeneralStep
    {
        public void Run(Session session, List<IProcessRollup> processRollups)
        {
            session.LastActivityDateTime = DateTime.Now;
        }
    }
}
