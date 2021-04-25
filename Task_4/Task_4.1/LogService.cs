using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task_4._1
{
    public class LogService
    {
        public const string _nameFileLog = "\\log.json";

        public const string _nameFolderLogContent = "\\LogContent";

        public static List<Log> GetListLog(string pathLog)
        {
            if (!File.Exists(pathLog))
            {
                return new List<Log>();
            }

            string jsonString = File.ReadAllText(pathLog);
            return JsonSerializer.Deserialize<List<Log>>(jsonString);
        }

        public static string GetContentLogById(Guid id, string pathFolderLogContent)
        {
            string pathContent = $"{pathFolderLogContent}\\{id}.json";

            return !File.Exists(pathContent) ? File.ReadAllText(pathContent) : null;
        }

        public static void SetListLog(List<Log> list, string pathLog)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(list, options);
            File.WriteAllText(pathLog, jsonString);
        }

        public static void AddLog(Log source, string pathLog, string pathFolderLogContent)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            List<Log> list = GetListLog(pathLog);
            list.Add(source);

            SetListLog(list, pathLog);

            if (!Directory.Exists(pathFolderLogContent))
            {
                Directory.CreateDirectory(pathFolderLogContent);
            }

            if (source.Type != LogType.Delete)
            {
                string pathLogContent = $"{pathFolderLogContent}\\{source.Id}.json";

                File.WriteAllText(pathLogContent, source.Content);
            }
        }
    }
}
