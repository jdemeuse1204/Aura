using Aura.AddOns;
using Aura.Data.Interfaces;
using Aura.Models;
using Ninject;
using System.Collections.Generic;

namespace Aura.Data
{
    public class ProcessRepository : IProcessRepository
    {
        private readonly IApplicationSettings ApplicationSettings;
        private readonly IProcessJsonDataReaderWriter ProcessJsonDataWriter;

        [Inject]
        public ProcessRepository(IApplicationSettings applicationSettings, IProcessJsonDataReaderWriter processJsonDataWriter)
        {
            ApplicationSettings = applicationSettings;
            ProcessJsonDataWriter = processJsonDataWriter;
        }

        public void Save(IEnumerable<IWindowsProcess> processes)
        {
            ProcessJsonDataWriter.Write(processes);
        }

        public IEnumerable<IWindowsProcess> LoadSavedProcesses()
        {
            return ProcessJsonDataWriter.All<WindowsProcess>();
        }
    }
}
