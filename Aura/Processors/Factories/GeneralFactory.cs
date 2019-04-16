using Aura.Processors.Factories.Interfaces;
using Aura.Processors.GeneralStep;
using Aura.Processors.GeneralStep.Base;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aura.Processors.Factories
{
    public class GeneralFactory : IGeneralFactory
    {
        private readonly List<IGeneralStep> Steps;

        public GeneralFactory(IKernel kernel)
        {
            // Register steps
            Steps = new List<IGeneralStep>
            {
                kernel.Get<SetSessionLockedStep>(),
                kernel.Get<SetSessionUnlockedStep>(),
                kernel.Get<SetUserActiveStep>(),
                kernel.Get<SetUserInactiveStep>(),
                kernel.Get<DisposeUser>()
            };
        }

        public IEnumerable<IGeneralStep> All()
        {
            return Steps;
        }

        public IGeneralStep Get<T>() where T : IGeneralStep
        {
            return Steps.FirstOrDefault(w => w.GetType() == typeof(T));
        }
    }
}
