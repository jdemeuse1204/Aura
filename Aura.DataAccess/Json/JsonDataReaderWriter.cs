using Aura.DataAccess.Json.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aura.DataAccess.Json
{
    public class JsonDataReaderWriter : IJsonDataReaderWriter
    {
        private readonly string FileNameAndPath;
        public JsonDataReaderWriter(string filePath, string fileName)
        {
            FileNameAndPath = Path.Combine(filePath, fileName);

            if (Directory.Exists(filePath) == false)
            {
                Directory.CreateDirectory(filePath);
            }
        }

        #region Reading
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
        #endregion

        #region Writing
        public void Remove<T>(Func<T, bool> expression) where T : class
        {
            lock (FileNameAndPath)
            {
                using (var iterator = new JsonDataIterator<T>(FileNameAndPath))
                {
                    var itemsToSave = iterator.Where(w => expression(w) == false);

                    Write(itemsToSave);
                }
            }
        }

        public void Write<T>(IEnumerable<T> items) where T : class
        {
            lock (FileNameAndPath)
            {
                File.WriteAllLines(FileNameAndPath, items.Select(JsonConvert.SerializeObject));
            }
        }

        public void Write<T>(T item) where T : class
        {
            lock (FileNameAndPath)
            {
                File.WriteAllText(FileNameAndPath, JsonConvert.SerializeObject(item));
            }
        }
        #endregion
    }
}
