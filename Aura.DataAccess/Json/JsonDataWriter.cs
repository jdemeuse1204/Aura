using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.DataAccess.Json
{
    public class JsonDataWriter
    {
        private readonly string FileNameAndPath;
        public JsonDataWriter(string filePath, string fileName)
        {
            FileNameAndPath = Path.Combine(filePath, fileName);

            if (Directory.Exists(filePath) == false)
            {
                Directory.CreateDirectory(filePath);
            }
        }

        public void Remove<T>(Func<T, bool> expression) where T : class
        {
            using (var iterator = new JsonDataIterator<T>(FileNameAndPath))
            {
                var itemsToSave = iterator.Where(w => expression(w) == false);

                Write(itemsToSave);
            }
        }

        public void Write<T>(IEnumerable<T> items) where T : class
        {
            lock (items)
            {
                File.WriteAllLines(FileNameAndPath, items.Select(JsonConvert.SerializeObject));
            }
        }

        public void Write<T>(T item) where T : class
        {
            lock (item)
            {
                File.WriteAllText(FileNameAndPath, JsonConvert.SerializeObject(item));
            }
        }
    }
}
