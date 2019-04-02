using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Models
{
    public class Session
    {
        public DateTime UpdatedDateTime { get; set; }
        public DateTime LastActivityDateTime { get; set; }
        public bool IsUserInactive { get; set; }
        public bool IsSessionLocked { get; set; }
    }
}
