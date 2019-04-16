using Aura.Processors.GeneralStep.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Processors.Factories.Interfaces
{
    public interface IGeneralFactory
    {
        IEnumerable<IGeneralStep> All();
        IGeneralStep Get<T>() where T : IGeneralStep;
    }
}
