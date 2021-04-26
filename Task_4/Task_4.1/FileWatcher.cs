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
        private FileSystemWatcher _watcher;

        public delegate void EventHandler(string message);

        private event EventHandler Notify;

        public string PathWatchtFolder { get; private set; }

        public string PathLog => PathWatchtFolder + LogService._nameFileLog;

        public string PathFolderLogContent => PathWatchtFolder + LogService._nameFolderLogContent;

        private string _pathFixation;

        public List<Log> ListCommites { get; private set; }

        private List<Log> CommitesCurrentFixation;

        /// <summary>
        /// FileWatcher with selected path
        /// </summary>
        /// <param name="watchFolderPath">Path current folder</param>
        public FileWatcher(string watchFolderPath)
        {
            if (!Directory.Exists(watchFolderPath))
            {
                throw new FileNotFoundException(nameof(watchFolderPath), "По данной директории папка не существует");
            }

            PathWatchtFolder = watchFolderPath;
            _watcher = new FileSystemWatcher(PathWatchtFolder, "*.txt");
            Notify += Message.ShowLine;

            ListCommites = LogService.GetAllFixation(PathWatchtFolder + "\\FixationLog");
        }

        public void Run()
        {
            //using (FileSystemWatcher watcher = _watcher)
            //{
                _pathFixation = PathWatchtFolder + $"\\FixationLog\\{Guid.NewGuid()}.json";
                CommitesCurrentFixation = new List<Log>();
            _watcher.NotifyFilter = NotifyFilters.LastAccess
                    | NotifyFilters.LastWrite
                    | NotifyFilters.CreationTime
                    | NotifyFilters.FileName;

            _watcher.Changed += new FileSystemEventHandler(OnChanged);
            _watcher.Created += new FileSystemEventHandler(OnCreated);
            _watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            _watcher.Renamed += new RenamedEventHandler(OnRenamed);


            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;

                Message.ShowLine("Введите \'q\' для завершения наблюдения.");
                while (Console.Read() != 'q') ;
                //Save Fixation in file *.json
                LogService.SetListLog(CommitesCurrentFixation, _pathFixation);

            //}
        }

        private DateTime lastRead = DateTime.MinValue;

        private void OnChanged(object source, FileSystemEventArgs e)
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

        private void OnCreated(object source, FileSystemEventArgs e)
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

        private void OnDeleted(object source, FileSystemEventArgs e)
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

        private void OnRenamed(object source, RenamedEventArgs e)
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

        private void RequestOnAddLog(Log source)
        {
            LogService.AddLog(source, PathLog, PathFolderLogContent);
        }

        private void AddCommit(Log source)
        {
            ListCommites.Add(source);
            CommitesCurrentFixation.Add(source);
        }
    }
}
