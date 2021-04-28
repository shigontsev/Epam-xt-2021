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
        private const string _nameFolderLogContent = "\\LogContent";

        private const string _nameFolderFixationLog = "\\FixationLog";

        private const string _pathDirectoryStates = "C:\\LogState";

        /// <summary>
        /// Current folder for researching
        /// </summary>
        public string CurrentPath { get; private set; }

        /// <summary>
        /// Path folder for keeping content of files
        /// </summary>
        public string LogContentPathFolder => CurrentPath + _nameFolderLogContent;

        /// <summary>
        /// Path folder for keeping commite of fixation
        /// </summary>
        public string FixationLogPathFolder => CurrentPath + _nameFolderFixationLog;

        public LogService(string currentFolderPath)
        {
            CurrentPath = currentFolderPath;
        }

        public static List<Log> GetListLog(string pathLog)
        {
            return Deserialize(pathLog);
        }

        /// <summary>
        /// Return content selected file by commite
        /// </summary>
        /// <param name="id">Id commite</param>
        /// <returns></returns>
        public string GetContentLogById(Guid id)
        {
            string pathContent = $"{LogContentPathFolder}\\{id}.json";

            return !File.Exists(pathContent) ? File.ReadAllText(pathContent) : null;
        }

        /// <summary>
        /// Save list commites by current status
        /// </summary>
        /// <param name="list">list commites</param>
        /// <param name="pathLog">path current fixation</param>
        public void SetListLog(List<Log> list, string pathLog)
        {
            if (list.Count > 0)
            {
                Serialize(list, pathLog);

                if (!Directory.Exists(LogContentPathFolder))
                {
                    Directory.CreateDirectory(LogContentPathFolder);
                }

                //save content files
                foreach (var log in list)
                {                    
                    if (log.Type != LogType.Delete || log.Type != LogType.Rename)
                    {
                        string pathLogContent = $"{LogContentPathFolder}\\{log.Id}.json";

                        File.WriteAllText(pathLogContent, log.Content);
                    }
                }
            }
        }

        /// <summary>
        /// Return all have fixations
        /// </summary>
        /// <returns></returns>
        public List<Log> GetAllFixation()
        {
            if (Directory.Exists(FixationLogPathFolder))
            {
                var files = Directory.GetFiles(FixationLogPathFolder, "*.json");
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
            Directory.CreateDirectory(FixationLogPathFolder);
            return new List<Log>();
        }

        /// <summary>
        /// Save current status
        /// </summary>
        /// <param name="guid">Id fixation</param>
        public void SaveState(Guid guid)
        {
            if (!Directory.Exists(_pathDirectoryStates))
            {
                Directory.CreateDirectory(_pathDirectoryStates);
            }
            string pathDirectoryCurrentState = _pathDirectoryStates + "\\" + guid;
            Directory.CreateDirectory(pathDirectoryCurrentState);
            
            CopyFiles(CurrentPath, pathDirectoryCurrentState);
        }

        /// <summary>
        /// Get list path *.txt files by selected folder path
        /// </summary>
        /// <param name="start_path">select folder path</param>
        /// <returns></returns>
        private static List<string> GetRecursFiles(string start_path)
        {
            List<string> ls = new List<string>();
            string[] folders = Directory.GetDirectories(start_path);
            foreach (string folder in folders)
            {
                ls.Add(folder);
                ls.AddRange(GetRecursFiles(folder));
            }
            string[] files = Directory.GetFiles(start_path, "*.txt");
            foreach (string filename in files)
            {
                ls.Add(filename);
            }
            return ls;
        }

        /// <summary>
        /// Copy file *.txt from Source to Dest directory, in folder and down
        /// </summary>
        public static void CopyFiles(string sourceDirectoryPath, string destDirectoryPath)
        {
            var direcoryAndFiles = GetRecursFiles(sourceDirectoryPath);

            Regex reg = new Regex(@".+\.txt$");
            foreach (var item in direcoryAndFiles)
            {
                if (reg.Match(item).Success)
                {
                    File.Copy(item, item.Replace(sourceDirectoryPath, destDirectoryPath));
                }
                else
                {
                    //Replace path by parent path
                    string new_directory = item.Replace(sourceDirectoryPath, destDirectoryPath);
                    if (!Directory.Exists(new_directory))
                    {
                        Directory.CreateDirectory(new_directory);
                    }
                }
            }
        }

        /// <summary>
        /// Return list status
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, InfoState> GetStates()
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
