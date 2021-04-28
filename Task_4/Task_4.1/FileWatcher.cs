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

        private event EventHandler Notify;

        public string PathWatchtFolder { get; private set; }

        //public string PathLog => PathWatchtFolder + LogService._nameFileLog;

        //public string PathFolderLogContent => PathWatchtFolder + LogService._nameFolderLogContent;

        private string _pathAnFixation;

        private List<Log> ListCommites;

        private List<Log> CommitesCurrentFixation;

        private LogService _Logger;

        /// <summary>
        /// FileWatcher with selected path
        /// </summary>
        /// <param name="watchFolderPath">Path current folder</param>
        public FileWatcher(string watchFolderPath, LogService logger)
        {
            if (!Directory.Exists(watchFolderPath))
            {
                throw new FileNotFoundException(nameof(watchFolderPath), "По данной директории папка не существует");
            }

            PathWatchtFolder = watchFolderPath;

            _Logger = logger;

            Notify += Message.ShowLine;
        }

        public void Run()
        {
            ListCommites = _Logger.GetAllFixation();//_Logger.FixationLogPath
            CommitesCurrentFixation = new List<Log>();

            Guid guid = Guid.NewGuid();
            _pathAnFixation = $"{_Logger.FixationLogPathFolder}\\{guid}.json";

            FileSystemWatcher watcher = new FileSystemWatcher(PathWatchtFolder, "*.txt");
            watcher.NotifyFilter = NotifyFilters.LastAccess
                    | NotifyFilters.LastWrite
                    | NotifyFilters.CreationTime
                    | NotifyFilters.FileName;

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);


            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Notify?.Invoke("Началось наблюдение...");
            Notify?.Invoke("Введите \'q\' для завершения наблюдения.");
            while (Console.Read() != 'q') ;

            watcher.EnableRaisingEvents = false;
            //Save Fixation in file *.json, and save State
            if (CommitesCurrentFixation.Count > 0)
            {
                _Logger.SetListLog(CommitesCurrentFixation, _pathAnFixation);
                _Logger.SaveState(guid);//PathWatchtFolder
            }
            ListCommites.Clear();
            CommitesCurrentFixation.Clear();
            Notify?.Invoke("Фиксация завершена...");

        }

        private static object _locker = new object();

        private DateTime lastRead = DateTime.MinValue;

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            lock (_locker)
            {
                if (e.ChangeType != WatcherChangeTypes.Changed)
                {
                    return;
                }
                while (!File.Exists(e.FullPath)) ;
                while (IOService.IsFileLocked(new FileInfo(e.FullPath))) ;

                DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
                if (lastWriteTime != lastRead)
                {
                    string content = File.ReadAllText(e.FullPath);
                    LogType logType = LogType.Edit;

                    //RequestOnAddLog(new Log
                    //{
                    //    Id = Guid.NewGuid(),
                    //    Date = lastWriteTime,
                    //    Type = logType,
                    //    Path = e.FullPath,
                    //    Content = content
                    //});
                    AddCommit(new Log
                    {
                        Id = Guid.NewGuid(),
                        Date = lastWriteTime,
                        Type = logType,
                        Path = e.FullPath,
                        Content = content
                    });

                    Notify?.Invoke(e.ChangeType + " -> File: " + e.FullPath);
                    lastRead = lastWriteTime;
                }
            }
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            lock (_locker)
            {
                if (e.ChangeType != WatcherChangeTypes.Created)
                {
                    return;
                }
                while (!File.Exists(e.FullPath)) ;
                while (IOService.IsFileLocked(new FileInfo(e.FullPath))) ;

                DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
                if (lastWriteTime != lastRead)
                {
                    string content = File.ReadAllText(e.FullPath);
                    LogType logType = LogType.Create;

                    //RequestOnAddLog(new Log
                    //{
                    //    Id = Guid.NewGuid(),
                    //    Date = lastWriteTime,
                    //    Type = logType,
                    //    Path = e.FullPath,
                    //    Content = content
                    //});
                    AddCommit(new Log
                    {
                        Id = Guid.NewGuid(),
                        Date = lastWriteTime,
                        Type = logType,
                        Path = e.FullPath,
                        Content = content
                    });

                    Notify?.Invoke(e.ChangeType + " -> File: " + e.FullPath);
                    lastRead = lastWriteTime;
                }
            }
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            lock (_locker)
            {
                DateTime lastWriteTime = DateTime.Now;
                if (lastRead >= lastWriteTime - TimeSpan.FromSeconds(1))
                {
                    return;
                }
                if (e.ChangeType != WatcherChangeTypes.Deleted)
                {
                    return;
                }

                LogType logType = LogType.Delete;
                //RequestOnAddLog(new Log
                //{
                //    Id = Guid.NewGuid(),
                //    Date = lastWriteTime,
                //    Type = logType,
                //    Path = e.FullPath
                //});

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

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            lock (_locker)
            {
                if (e.ChangeType != WatcherChangeTypes.Renamed)
                {
                    return;
                }

                DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
                LogType logType = LogType.Rename;

                Guid id = ListCommites.LastOrDefault(x => x.Path == e.OldFullPath).Id;
                //RequestOnAddLog(new Log
                //{
                //    Id = id == default(Guid)? Guid.NewGuid(): id,
                //    Date = lastWriteTime,
                //    Type = logType,
                //    OldPath = e.OldFullPath,
                //    Path = e.FullPath
                //});

                AddCommit(new Log
                {
                    Id = id == null ? Guid.NewGuid() : id,
                    Date = lastWriteTime,
                    Type = logType,
                    OldPath = e.OldFullPath,
                    Path = e.FullPath
                });

                Notify?.Invoke($"{e.ChangeType} -> File: {e.OldFullPath} renamed to {e.FullPath}");
            }
        }

        //private void RequestOnAddLog(Log source)
        //{
        //    LogService.AddLog(source, PathLog, PathFolderLogContent);
        //}

        private void AddCommit(Log source)
        {
            ListCommites.Add(source);
            CommitesCurrentFixation.Add(source);
        }
    }
}
