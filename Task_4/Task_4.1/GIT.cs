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
    public class GIT
    {
        private const string _nameFolderLogger = @"\GIT";

        private const string _nameFolderLogContent = @"\LogContent";

        private const string _nameFolderFixationLog = @"\FixationLog";

        private const string _nameFolderStates = @"\LogState";


        /// <summary>
        /// Current folder for researching
        /// </summary>
        public string CurrentPath { get; private set; }

        /// <summary>
        /// Path folder Logger
        /// </summary>
        public string LoggerPathFolder => CurrentPath + _nameFolderLogger;

        /// <summary>
        /// Path folder for keeping content of files
        /// </summary>
        public string LogContentPathFolder => LoggerPathFolder + _nameFolderLogContent;

        /// <summary>
        /// Path folder for keeping commite of fixation
        /// </summary>
        public string FixationLogPathFolder => LoggerPathFolder + _nameFolderFixationLog;

        /// <summary>
        /// Path folder for keeping commite of fixation
        /// </summary>
        public string StateLogPathFolder => LoggerPathFolder + _nameFolderStates;

        public GIT(string currentFolderPath)
        {
            CurrentPath = currentFolderPath;

            if (!Directory.Exists(LoggerPathFolder))
            {
                DirectoryInfo di = Directory.CreateDirectory(LoggerPathFolder);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
            if (!Directory.Exists(LogContentPathFolder))
            {
                Directory.CreateDirectory(LogContentPathFolder);
            }
            if (!Directory.Exists(FixationLogPathFolder))
            {
                Directory.CreateDirectory(FixationLogPathFolder);
            }
            if (!Directory.Exists(StateLogPathFolder))
            {
                Directory.CreateDirectory(StateLogPathFolder);
            }
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
                JsonService.Serialize(list, pathLog);

                if (!Directory.Exists(LogContentPathFolder))
                {
                    Directory.CreateDirectory(LogContentPathFolder);
                }

                //save content files
                foreach (var log in list)
                {                    
                    if (log.Type != LogType.Delete || log.Type != LogType.Rename)
                    {
                        string pathLogContent = Path.Combine(LogContentPathFolder, $"{log.Id}.json");

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
                    var filesByDate = files
                        .Select(path => new { path, WriteTime = File.GetLastWriteTime(path) })
                        .OrderBy(x => x.WriteTime)
                        .ToList();

                    return filesByDate.SelectMany(x => JsonService.Deserialize(x.path)).ToList();
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
            if (!Directory.Exists(StateLogPathFolder))
            {
                Directory.CreateDirectory(StateLogPathFolder);
            }
            string pathDirectoryCurrentState = Path.Combine(StateLogPathFolder, guid.ToString());
            Directory.CreateDirectory(pathDirectoryCurrentState);
            
            CopyFiles(CurrentPath, pathDirectoryCurrentState);
        }
        
        /// <summary>
        /// Copy file *.txt from Source to Dest directory, in folder and down
        /// </summary>
        public void CopyFiles(string sourceDirectoryPath, string destDirectoryPath)
        {
            bool isSourcePathOfLogger = sourceDirectoryPath.Contains(LoggerPathFolder);

            var listPathFiles = Directory.GetFiles(sourceDirectoryPath, "*.txt", SearchOption.AllDirectories)
                .Where(f => isSourcePathOfLogger ? true : !f.Contains(LoggerPathFolder));
            var listPathFolders = Directory.GetDirectories(sourceDirectoryPath, "", SearchOption.AllDirectories)
                .Where(f => isSourcePathOfLogger ? true : !f.Contains(LoggerPathFolder)); ;


            Regex reg = new Regex(@".+\.txt$");
            foreach (var item in listPathFolders.Union(listPathFiles))
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
            var folders = Directory.EnumerateDirectories(StateLogPathFolder);
            if (folders.Count() == 0)
            {
                return new Dictionary<string, InfoState>();
            }

            return folders
                .Select(f => new InfoState(Directory.GetLastWriteTime(f), f))
                .OrderBy(Is => Is.Date)
                .ToDictionary(Is => Is.Path.Replace(StateLogPathFolder + "\\", ""), Is => Is);
        }

    }
}
