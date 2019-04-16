using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Rules.Interfaces
{
    public interface IWhen<T> where T : class
    {
        bool IsTrue<K>(T instance, string propertyName, K compareValue);
    }
}
