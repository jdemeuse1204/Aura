using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Rules.Interfaces
{
    public interface IWhen<T> where T : class
    {
        bool IsTrue<K>(T instance, string propertyName, K compareValue);
    }
}
