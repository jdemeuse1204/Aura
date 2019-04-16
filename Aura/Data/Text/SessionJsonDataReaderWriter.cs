using Aura.Data.Interfaces;
using Aura.DataAccess.Json;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Data.Text
{
    public class SessionJsonDataReaderWriter : JsonDataReaderWriter, ISessionJsonDataReaderWriter
    {
        [Inject]
        public SessionJsonDataReaderWriter(IApplicationSettings applicationSettings)
            : base(applicationSettings.MainFileDirectory, applicationSettings.SessionFileName)
        {
        }
    }
}
