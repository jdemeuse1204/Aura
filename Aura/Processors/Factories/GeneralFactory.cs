using Aura.Processors.GeneralStep;
using Aura.Processors.GeneralStep.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Processors.Factories
{
    public class GeneralFactory
    {
        private readonly List<IGeneralStep> Steps;

        public GeneralFactory()
        {
            // Register steps
            Steps = new List<IGeneralStep>
            {
                new SetSessionLockedStep(),
                new SetSessionUnlockedStep(),
                new SetUserActiveStep(),
                new SetUserInactiveStep(),
                new DisposeUser()
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
