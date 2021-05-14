using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Task_4._1
{
    public class JsonService
    {
        /// <summary>
        /// Reader Json
        /// </summary>
        public static List<Log> Deserialize(string path)
        {
            if (!File.Exists(path))
            {
                return new List<Log>();
            }

            string jsonString = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Log>>(jsonString);
        }

        /// <summary>
        /// Setter Json
        /// </summary>
        public static void Serialize(List<Log> list, string path)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(list, options);
            File.WriteAllText(path, jsonString);
        }
    }
}
