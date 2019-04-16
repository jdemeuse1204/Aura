using Aura.Data.Interfaces;
using Aura.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

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
