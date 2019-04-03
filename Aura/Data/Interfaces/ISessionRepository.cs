using Aura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Data.Interfaces
{
    public interface ISessionRepository
    {
        void Save(Session session);
        Session Get();
    }
}
