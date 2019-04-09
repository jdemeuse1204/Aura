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
        private readonly FileStream FileStream;

        public JsonDataIterator(string fileNameAndPath)
        {
            FileNameAndPath = fileNameAndPath;
            FileStream = new FileStream(FileNameAndPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader = new StreamReader(FileStream);
        }

        public void Dispose()
        {
            StreamReader.Dispose();
            FileStream.Dispose();
        }

        public IEnumerable<string> GetAllLines()
        {
            var lines = new List<string>();
            string line;

            while ((line = StreamReader.ReadLine()) != null)
            {
                yield return line;
            }
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
