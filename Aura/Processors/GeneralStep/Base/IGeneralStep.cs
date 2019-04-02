using Aura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Processors.GeneralStep.Base
{
    public interface IGeneralStep
    {
        void Run(Session session, List<ProcessRollup> processRollups);
    }
}
