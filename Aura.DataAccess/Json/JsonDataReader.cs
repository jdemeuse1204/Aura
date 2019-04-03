using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.DataAccess.Json
{
    public class JsonDataReader
    {
        private readonly string FileNameAndPath;
        public JsonDataReader(string filePath, string fileName)
        {
            FileNameAndPath = Path.Combine(filePath, fileName);

            if (Directory.Exists(filePath) == false)
            {
                Directory.CreateDirectory(filePath);
            }
        }

        public T Get<T>() where T : class
        {
            if (File.Exists(FileNameAndPath) == false)
            {
                return default(T);
            }

            var text = File.ReadAllText(FileNameAndPath);

            if (string.IsNullOrEmpty(text))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(text);
        }

        public T Get<T>(Func<T, bool> expression) where T : class
        {
            if (File.Exists(FileNameAndPath) == false)
            {
                return default(T);
            }

            using (var iterator = new JsonDataIterator<T>(FileNameAndPath))
            {
                return iterator.FirstOrDefault(expression);
            }
        }

        public IEnumerable<T> All<T>(Func<T, bool> expression) where T : class
        {
            if (File.Exists(FileNameAndPath) == false)
            {
                return new List<T>();
            }

            using (var iterator = new JsonDataIterator<T>(FileNameAndPath))
            {
                return iterator.Where(expression);
            }
        }

        public IEnumerable<T> All<T>() where T : class
        {
            if (File.Exists(FileNameAndPath) == false)
            {
                return new List<T>();
            }

            using (var iterator = new JsonDataIterator<T>(FileNameAndPath))
            {
                return iterator.ToList();
            }
        }
    }
}
