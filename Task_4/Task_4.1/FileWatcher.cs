using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4._1
{
    public class FileWatcher
    {
        private delegate void EventHandler(string message);

        private event Action<string> Notify;
                
        /// <summary>
        /// Full list commits
        /// </summary>
        private List<Log> ListCommits;

        /// <summary>
        /// List commits of current active state
        /// </summary>
        private List<Log> ListCommitsCurrentState;

        private GIT _Logger;

        /// <summary>
        /// For async events of File Watcher
        /// </summary>
        private object _locker = new object();

        /// <summary>
        /// For eliminate duplicate events (change and create)
        /// </summary>
        private DateTime _lastRead = DateTime.MinValue;

        /// <summary>
        /// FileWatcher with selected path
        /// </summary>
        /// <param name="watchFolderPath">Path current folder</param>
        public FileWatcher(GIT logger, Action<string> modeNotify)
        {
            _Logger = logger;

            if (!Directory.Exists(_Logger.CurrentPath))
            {
                throw new FileNotFoundException(nameof(_Logger.CurrentPath), "По данной директории папка не существует");
            }            

            Notify = modeNotify;
        }

        /// <summary>
        /// Action FileWatcher by current path
        /// </summary>
        public void Run()
        {
            ListCommits = _Logger.GetAllFixation();
            ListCommitsCurrentState = new List<Log>();

            Guid guid = Guid.NewGuid();
            string pathAnFixation = Path.Combine(_Logger.FixationLogPathFolder, $"{guid}.json");

            ScanFiles();

            //Save Fixation in file *.json, and save State
            if (ListCommitsCurrentState.Count > 0)
            {
                _Logger.SetListLog(ListCommitsCurrentState, pathAnFixation);
                _Logger.SaveState(guid);//PathWatchtFolder
            }
            
            Notify?.Invoke(ListCommitsCurrentState.Count > 0?
                "Фиксация завершена...": "Изменений не наблюдалось. Конец операции...");

            ListCommits.Clear();
            ListCommitsCurrentState.Clear();

            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        /// <summary>
        /// Action scan *.txt files by FileSystemWatcher
        /// </summary>
        private void ScanFiles()
        {
            FileSystemWatcher watcher = new FileSystemWatcher(_Logger.CurrentPath, "*.txt");
            watcher.NotifyFilter = NotifyFilters.LastAccess
                    | NotifyFilters.LastWrite
                    | NotifyFilters.CreationTime
                    | NotifyFilters.FileName;

            watcher.Changed += new FileSystemEventHandler(OnChangedOrCreated);
            watcher.Created += new FileSystemEventHandler(OnChangedOrCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);


            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Notify?.Invoke("Началось наблюдение...");
            Notify?.Invoke("Введите \'q\' для завершения наблюдения.");
            while (Console.Read() != 'q') ;

            watcher.EnableRaisingEvents = false;
        }

        /// <summary>
        /// Event Chaged or Created
        /// </summary>
        private void OnChangedOrCreated(object sender, FileSystemEventArgs e)
        {
            lock (_locker)
            {
                if (e.FullPath.Contains(_Logger.LoggerPathFolder)
                    || (e.ChangeType != WatcherChangeTypes.Changed &&
                    e.ChangeType != WatcherChangeTypes.Created))
                {
                    return;
                }

                while (!File.Exists(e.FullPath)) ;
                while (IOService.IsFileLocked(new FileInfo(e.FullPath))) ;

                DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
                if (lastWriteTime != _lastRead)
                {
                    string content = File.ReadAllText(e.FullPath);
                    LogType logType = e.ChangeType == WatcherChangeTypes.Changed ? 
                        LogType.Edit : LogType.Create;

                    AddCommit(new Log
                    {
                        Id = Guid.NewGuid(),
                        Date = lastWriteTime,
                        Type = logType,
                        Path = e.FullPath,
                        Content = content
                    });

                    Notify?.Invoke(e.ChangeType + " -> File: " + e.FullPath);
                    _lastRead = lastWriteTime;
                }
            }
        }

        /// <summary>
        /// Event Deleted
        /// </summary>
        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            lock (_locker)
            {
                if (e.FullPath.Contains(_Logger.LoggerPathFolder)
                    || e.ChangeType != WatcherChangeTypes.Deleted
                    || File.Exists(e.FullPath))
                {
                    return;
                }

                DateTime lastWriteTime = DateTime.Now;
                LogType logType = LogType.Delete;

                AddCommit(new Log
                {
                    Id = Guid.NewGuid(),
                    Date = lastWriteTime,
                    Type = logType,
                    Path = e.FullPath
                });

                Notify?.Invoke(e.ChangeType + " -> File: " + e.FullPath);
            }
        }

        /// <summary>
        /// Event Renamed
        /// </summary>
        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            lock (_locker)
            {
                if (e.FullPath.Contains(_Logger.LoggerPathFolder)
                    || e.ChangeType != WatcherChangeTypes.Renamed)
                {
                    return;
                }

                DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
                LogType logType = LogType.Rename;

                Guid id = ListCommits.LastOrDefault(x => x.Path == e.OldFullPath).Id;

                AddCommit(new Log
                {
                    Id = id == default(Guid) ? Guid.NewGuid() : id,
                    Date = lastWriteTime,
                    Type = logType,
                    OldPath = e.OldFullPath,
                    Path = e.FullPath
                });

                Notify?.Invoke($"{e.ChangeType} -> File: {e.OldFullPath} renamed to {e.FullPath}");
            }
        }

        private void AddCommit(Log source)
        {
            ListCommits.Add(source);
            ListCommitsCurrentState.Add(source);
        }
    }
}
