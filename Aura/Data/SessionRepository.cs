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
    public class SessionRepository : ISessionRepository
    {
        private readonly IApplicationSettings ApplicationSettings;
        private readonly JsonDataWriter JsonDataWriter;
        private readonly JsonDataReader JsonDataReader;

        [Inject]
        public SessionRepository(IApplicationSettings applicationSettings)
        {
            ApplicationSettings = applicationSettings;
            var logFileLocation = Path.Combine(ApplicationSettings.MainFileDirectory, ApplicationSettings.SessionFileDirectory);

            JsonDataWriter = new JsonDataWriter(logFileLocation, ApplicationSettings.SessionFileName);
            JsonDataReader = new JsonDataReader(logFileLocation, ApplicationSettings.SessionFileName);
        }

        public void Save(Session session)
        {
            JsonDataWriter.Write(session);
        }

        public Session Get()
        {
            return JsonDataReader.Get<Session>();
        }
    }
}
