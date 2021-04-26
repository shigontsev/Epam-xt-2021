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
            return Deserialize(pathLog);
        }

        public static string GetContentLogById(Guid id, string pathFolderLogContent)
        {
            string pathContent = $"{pathFolderLogContent}\\{id}.json";

            return !File.Exists(pathContent) ? File.ReadAllText(pathContent) : null;
        }

        public static void SetListLog(List<Log> list, string pathLog)
        {
            if (list.Count > 0)
            {
                Serialize(list, pathLog);
            }
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

        public static List<Log> GetAllFixation(string pathFixationLog)
        {
            if (Directory.Exists(pathFixationLog))
            {
                var files = Directory.GetFiles(pathFixationLog, "*.json");
                if (files.Count() > 0)
                {
                    var filesBefore = new Dictionary<string, DateTime>();
                    foreach (var item in files)
                    {
                        filesBefore.Add(item, File.GetLastWriteTime(item));
                    }
                    var filesAfter = filesBefore.OrderBy(x => x.Value).ToList();
                    var list = new List<Log>();
                    foreach (var file in filesAfter)
                    {
                        list.AddRange(Deserialize(file.Key));
                    }
                    return list;
                }
            }
            Directory.CreateDirectory(pathFixationLog);
            return new List<Log>();
        }

        /// <summary>
        /// Reader
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
        /// Setter
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
