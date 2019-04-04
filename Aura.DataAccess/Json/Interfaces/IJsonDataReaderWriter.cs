using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.DataAccess.Json.Interfaces
{
    public interface IJsonDataReaderWriter
    {
        T Get<T>() where T : class;
        T Get<T>(Func<T, bool> expression) where T : class;
        IEnumerable<T> All<T>(Func<T, bool> expression) where T : class;
        IEnumerable<T> All<T>() where T : class;

        void Remove<T>(Func<T, bool> expression) where T : class;
        void Write<T>(IEnumerable<T> items) where T : class;
        void Write<T>(T item) where T : class;
    }
}
