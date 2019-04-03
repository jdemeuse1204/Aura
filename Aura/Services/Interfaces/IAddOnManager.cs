using Aura.AddOns.Step;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Services.Interfaces
{
    public interface IAddOnManager
    {
        IEnumerable<IAddOnStep> GetAddOnStepsToProcess();
    }
}
