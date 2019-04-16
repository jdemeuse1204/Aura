using Aura.Data.Interfaces;
using Aura.DataAccess.Json;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Aura.Data.Text
{
    public class ProcessJsonDataReaderWriter : JsonDataReaderWriter, IProcessJsonDataReaderWriter
    {
        [Inject]
        public ProcessJsonDataReaderWriter(IApplicationSettings applicationSettings)
            : base(Path.Combine(applicationSettings.MainFileDirectory, applicationSettings.DataFileDirectory), applicationSettings.DataFileName)
        {
        }
    }
}
