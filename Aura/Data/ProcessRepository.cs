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
        private readonly JsonDataWriter JsonDataWriter;
        private readonly JsonDataReader JsonDataReader;

        [Inject]
        public ProcessRepository(IApplicationSettings applicationSettings)
        {
            ApplicationSettings = applicationSettings;
            var logFileLocation = Path.Combine(ApplicationSettings.MainFileDirectory, ApplicationSettings.DataFileDirectory);

            JsonDataWriter = new JsonDataWriter(logFileLocation, ApplicationSettings.DataFileName);
            JsonDataReader = new JsonDataReader(logFileLocation, ApplicationSettings.DataFileName);
        }

        public void Save(IEnumerable<IWindowsProcess> processes)
        {
            JsonDataWriter.Write(processes);
        }

        public IEnumerable<IWindowsProcess> LoadSavedProcesses()
        {
            return JsonDataReader.All<WindowsProcess>();
        }
    }
}
