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
        private readonly ISessionJsonDataReaderWriter SessionJsonDataWriter;

        [Inject]
        public SessionRepository(IApplicationSettings applicationSettings, ISessionJsonDataReaderWriter sessionJsonDataWriter)
        {
            ApplicationSettings = applicationSettings;
            SessionJsonDataWriter = sessionJsonDataWriter;
        }

        public void Save(Session session)
        {
            SessionJsonDataWriter.Write(session);
        }

        public Session Get()
        {
            return SessionJsonDataWriter.Get<Session>();
        }
    }
}
