using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task_4._1
{
    public class JsonService
    {
        public static List<Log> GetListLog()
        {
            string pathLog = "log.json";
            if (!File.Exists(pathLog))
            {
                return new List<Log>();
            }

            // чтение данных
            string jsonString = File.ReadAllText(pathLog);
            return JsonSerializer.Deserialize<List<Log>>(jsonString);
        }

        public static string GetContentLog(Log source)
        {            
            return GetContentLogById(source.Id);
        }

        public static string GetContentLogById(Guid id)
        {
            string pathContent = $"LogContent\\{id}.json";

            return !File.Exists(pathContent) ? File.ReadAllText(pathContent) : null;
        }

        public static void SetListLog(List<Log> list)
        {
            string pathLog = "log.json";

            //if (!File.Exists(pathLog))
            //{
            //    File.Create(pathLog);
            //}

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(list, options);
            File.WriteAllText(pathLog, jsonString);
        }

        public static void AddLog(Log source)
        {
            //string pathLog = "log.json";

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            List<Log> list = GetListLog();
            list.Add(source);

            SetListLog(list);

            if (!Directory.Exists("LogContent"))
            {
                Directory.CreateDirectory("LogContent");
            }

            if (source.Type != LogType.Delete)
            {
                string pathLogContent = $"LogContent\\{source.Id}.json";

                File.WriteAllText(pathLogContent, source.Content);
            }
        }
    }
}
