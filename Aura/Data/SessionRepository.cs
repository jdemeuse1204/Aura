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
    public class SessionRepository
    {
        private readonly JsonDataWriter JsonDataWriter;
        private readonly JsonDataReader JsonDataReader;

        public SessionRepository()
        {
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
