using Aura.AddOns.Step;
using Aura.Data.Interfaces;
using Aura.Services.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aura.Services
{
    public class AddOnManager : IAddOnManager
    {
        private readonly IApplicationSettings ApplicationSettings;
        private readonly IDictionary<IAddOnStep, DateTime> ProcessAddOnSteps;

        [Inject]
        public AddOnManager(IApplicationSettings applicationSettings)
        {
            ApplicationSettings = applicationSettings;
            ProcessAddOnSteps = GetAddOnSteps().ToDictionary(w => w, x => DateTime.MinValue);
        }

        private IEnumerable<IAddOnStep> GetAddOnSteps()
        {
            var baseDirectory = Path.Combine(ApplicationSettings.MainFileDirectory, ApplicationSettings.AddOnsFileDirectory);

            if (Directory.Exists(baseDirectory) == false)
            {
                return new List<IAddOnStep>();
            }

            var addOnDirectory = $@"{baseDirectory}\*.dll";

            // create new kernel for each directory otherwise we will have collisions when we bind dependencies
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Settings.ActivationCacheDisabled = true;
                kernel.Load(addOnDirectory);
                return kernel.GetModules().Select(w => w.Kernel.Get<IAddOnStep>()).ToList();
            }
        }

        public IEnumerable<IAddOnStep> GetAddOnStepsToProcess()
        {
            var result = new List<IAddOnStep>();

            var processAddOnStepsArray = ProcessAddOnSteps.ToArray();

            for (var i = 0; i < processAddOnStepsArray.Length; i++)
            {
                var pair = processAddOnStepsArray[i];

                if ((DateTime.Now - pair.Value).TotalSeconds > pair.Key.RunInterval.TotalSeconds)
                {
                    result.Add(pair.Key);

                    // mark the step as processed, because it will be processed
                    ProcessAddOnSteps[pair.Key] = DateTime.Now;
                }
            }

            return result;
        }
    }
}
