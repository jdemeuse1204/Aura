using Aura.Data.Registry;
using Aura.DataAccess;
using Aura.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Data
{
    public class ProcessRepository
    {
        private readonly JsonDataWriter JsonDataWriter;
        private readonly JsonDataReader JsonDataReader;

        public ProcessRepository()
        {
            var logFileLocation = Path.Combine(ApplicationSettings.MainFileDirectory, ApplicationSettings.DataFileDirectory);

            JsonDataWriter = new JsonDataWriter(logFileLocation, ApplicationSettings.DataFileName);
            JsonDataReader = new JsonDataReader(logFileLocation, ApplicationSettings.DataFileName);
        }

        public void Save(IEnumerable<WindowsProcess> processes)
        {
            JsonDataWriter.Write(processes);
        }

        public IEnumerable<WindowsProcess> LoadSavedProcesses()
        {
            return JsonDataReader.All<WindowsProcess>();
        }
    }
}
