using Aura.AddOns.Step;
using Aura.Data.Interfaces;
using Aura.Data.Registry;
using Aura.DataAccess;
using Aura.DataAccess.Json;
using Aura.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
