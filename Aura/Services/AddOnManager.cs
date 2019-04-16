using Aura.AddOns.Events;
using Aura.Data.Interfaces;
using Aura.Services.Interfaces;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aura.Services
{
    public class AddOnManager : IAddOnManager
    {
        private readonly IApplicationSettings ApplicationSettings;
        private readonly IDictionary<IApplicationProcessEvent, DateTime> ProcessAddOnSteps;
        private readonly IEnumerable<IApplicationExitEvent> ApplicationExitEvents;
        private readonly IEnumerable<IApplicationStartEvent> ApplicationStartEvents;

        private List<INinjectModule> AddOns { get; set; }

        [Inject]
        public AddOnManager(IApplicationSettings applicationSettings)
        {
            ApplicationSettings = applicationSettings;

            using (IKernel kernel = new StandardKernel())
            {
                AddOns = GetAddOns(kernel);
                ProcessAddOnSteps = GetAddOns<IApplicationProcessEvent>().ToDictionary(w => w, x => DateTime.MinValue);
                ApplicationExitEvents = GetAddOns<IApplicationExitEvent>();
                ApplicationStartEvents = GetAddOns<IApplicationStartEvent>();
            }
        }

        private List<INinjectModule> GetAddOns(IKernel kernel)
        {
            var baseDirectory = Path.Combine(ApplicationSettings.MainFileDirectory, ApplicationSettings.AddOnsFileDirectory);
            var result = new List<INinjectModule>();

            if (Directory.Exists(baseDirectory) == false)
            {
                return result;
            }

            foreach (var directory in Directory.GetDirectories(baseDirectory).Select(w => $@"{w}\*.dll"))
            {
                kernel.Settings.ActivationCacheDisabled = true;
                kernel.Load(directory);

                result.AddRange(kernel.GetModules());
            }

            return result;
        }

        private IEnumerable<T> GetAddOns<T>() where T : class
        {
            return AddOns.Where(w => ((NinjectModule)w).Bindings.Any(x => x.Service.UnderlyingSystemType == typeof(T))).Select(w => w.Kernel.Get<T>()).ToList();
        }

        public IEnumerable<IApplicationProcessEvent> GetAddOnApplicationProcessEvents()
        {
            var result = new List<IApplicationProcessEvent>();

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

        public IEnumerable<IApplicationStartEvent> GetAddOnApplicationStartEvents()
        {
            return ApplicationStartEvents;
        }

        public IEnumerable<IApplicationExitEvent> GetAddOnApplicationExitEvents()
        {
            return ApplicationExitEvents;
        }
    }
}
