using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_4._1
{
    public class LogService
    {
        public const string _nameFileLog = "\\log.json";

        public const string _nameFolderLogContent = "\\LogContent";

        public const string _pathDirectoryStates = "C:\\LogState";

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

        public static void SaveState(string pathCurrent)
        {
            if (!Directory.Exists(_pathDirectoryStates))
            {
                Directory.CreateDirectory(_pathDirectoryStates);
            }
            string pathDirectoryCurrentState = _pathDirectoryStates + "\\" + Guid.NewGuid();
            Directory.CreateDirectory(pathDirectoryCurrentState);
            //var currentInfo = new DirectoryInfo(pathCurrent);
            //var directorys = Directory.EnumerateDirectories(pathCurrent)
            //    .Select(x => x.Replace(pathCurrent, "")).ToList();
            //var files = Directory.GetFiles(pathCurrent, "*.txt", SearchOption.AllDirectories)
            //    .Select(x => x.Replace(pathCurrent, "")).ToList();
            //foreach (var item in directorys)
            //{
            //    //Directory.CreateDirectory(_pathDirectoryStates + item);
            //    Console.WriteLine(item);
            //}
            //foreach (var item in files)
            //{
            //    //Directory.CreateDirectory(_pathDirectoryStates + item);
            //    Console.WriteLine(item);
            //}

            //var direcoryAndFiles = GetRecursFiles(pathCurrent).Select(x => x.Replace(pathCurrent, "")).ToList();
            var direcoryAndFiles = GetRecursFiles(pathCurrent);

            Regex reg = new Regex(@".+\.txt$");
            foreach (var item in direcoryAndFiles)
            {
                //Directory.CreateDirectory(_pathDirectoryStates + item);

                //Console.WriteLine(item+"  "+reg.Match(item).Success);
                if (reg.Match(item).Success)
                {
                    File.Copy(item, item.Replace(pathCurrent, pathDirectoryCurrentState));
                }
                else
                {
                    Directory.CreateDirectory(item.Replace(pathCurrent, pathDirectoryCurrentState));
                }
            }

        }

        private static List<string> GetRecursFiles(string start_path)
        {
            List<string> ls = new List<string>();
                string[] folders = Directory.GetDirectories(start_path);
                foreach (string folder in folders)
                {
                    ls.Add(folder);
                    ls.AddRange(GetRecursFiles(folder));
                }
                string[] files = Directory.GetFiles(start_path,"*.txt");
                foreach (string filename in files)
                {
                    ls.Add(filename);
                }
            return ls;
        }

        /// <summary>
        /// Возвращает список состояний
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, InfoState> GetStates()
        {
            var folders = Directory.EnumerateDirectories(_pathDirectoryStates);
            if (folders.Count() == 0)
            {
                return new Dictionary<string, InfoState>();
            }

            var states = new List<InfoState>();
            foreach (var item in folders)
            {
                states.Add(new InfoState(Directory.GetLastWriteTime(item), item));
            }
            var states_Sorted = states.OrderBy(x => x.Date).ToList();
            var result = new Dictionary<string, InfoState>();
            foreach (var item in states_Sorted)
            {
                result.Add(item.Path.Replace(_pathDirectoryStates + "\\", ""), item);
            }

            return result;
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
