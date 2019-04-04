using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.DataAccess.Http.Interfaces
{
    public interface IFetch
    {
        string Post(Dictionary<string, string> headers, string body);
        string Put(Dictionary<string, string> headers, string body);
        void AddHeader(string key, string value);
        string Get();
    }
}
