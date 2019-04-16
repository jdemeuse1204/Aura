using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Rules.Interfaces
{
    public interface IThen<T, K> where T : class where K : class
    {
        void Do(T instance, K value);
    }
}
