using Aura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Data.Interfaces
{
    public interface ISessionRepository
    {
        void Save(Session session);
        Session Get();
    }
}
