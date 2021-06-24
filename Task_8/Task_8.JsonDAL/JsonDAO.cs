using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.Entities;

namespace Task_8.JsonDAL
{
    internal static class JsonDAO<T> where T : class
    {
        
        /// <summary>
        /// Получения коллекции из файла
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        internal static List<T> Deserialize(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException(
                    string.Format("File at path {0} isn't exist!",
                        filePath));

            List<T> users = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(filePath));

            return users;
        }

        /// <summary>
        /// Запись коллекции в файл
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        internal static void Serialize(string filePath, List<T> list)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException(
                    string.Format("File at path {0} isn't exist!",
                        filePath));
            File.WriteAllText(filePath, JsonConvert.SerializeObject(list));
        }
    }
}
