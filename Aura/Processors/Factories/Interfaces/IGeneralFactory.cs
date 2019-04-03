using Aura.Processors.GeneralStep.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Processors.Factories.Interfaces
{
    public interface IGeneralFactory
    {
        IEnumerable<IGeneralStep> All();
        IGeneralStep Get<T>() where T : IGeneralStep;
    }
}
