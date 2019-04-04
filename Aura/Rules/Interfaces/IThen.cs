using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Rules.Interfaces
{
    public interface IThen<T, K> where T : class where K : class
    {
        void Do(T instance, K value);
    }
}
