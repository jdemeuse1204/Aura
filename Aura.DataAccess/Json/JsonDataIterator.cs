using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.DataAccess.Json
{
    public class JsonDataIterator<T> : IEnumerable<T>, IDisposable where T : class
    {
        private readonly string FileNameAndPath;
        private readonly StreamReader StreamReader;

        public JsonDataIterator(string fileNameAndPath)
        {
            FileNameAndPath = fileNameAndPath;
            StreamReader = new StreamReader(FileNameAndPath);
        }

        public void Dispose()
        {
            StreamReader.Dispose();
        }

        public IEnumerator<T> GetEnumerator()
        {
            string line;

            while ((line = StreamReader.ReadLine()) != null)
            {
                yield return JsonConvert.DeserializeObject<T>(line);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
