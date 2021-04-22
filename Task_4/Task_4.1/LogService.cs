using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4._1
{
    public class LogService
    {
        

        public static void Run()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = Environment.CurrentDirectory;

            watcher.NotifyFilter = NotifyFilters.LastAccess
                | NotifyFilters.LastWrite
                | NotifyFilters.CreationTime
                | NotifyFilters.FileName
                | NotifyFilters.DirectoryName;
            // Only watch text files.
            watcher.Filter = "*.txt";

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChangedOrCreated);
            watcher.Created += new FileSystemEventHandler(OnChangedOrCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            // Wait for the user to quit the program.
            Message.ShowLine("Введите \'q\' для завершения наблюдения.");
            while (Console.Read() != 'q') ;
        }

        private static DateTime lastRead = DateTime.MinValue;

        private static void OnChangedOrCreated(object source, FileSystemEventArgs e)
        {
            DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
            //async спас от другого процесса
            string content = Task<string>.Run(async () => await File.ReadAllTextAsync(e.FullPath)).Result;
            if (lastWriteTime != lastRead)
            {
                Message.ShowLine("File: " + e.FullPath + " " + e.ChangeType);
                LogType logType = LogType.None;
                switch (e.ChangeType)
                {
                    case WatcherChangeTypes.Changed:
                        logType = LogType.Edit;
                        break;
                    case WatcherChangeTypes.Created:
                        logType = LogType.Create;
                        break;
                }
                JsonService.AddLog(new Log
                {
                    Id = Guid.NewGuid(),
                    Date = lastWriteTime,
                    Type = logType,
                    Path = e.FullPath,
                    Content = content
                });

                lastRead = lastWriteTime;
            }

        }

        // Define the event handlers.
        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            DateTime lastWriteTime = DateTime.Now;

            Message.ShowLine("File: " + e.FullPath + " " + e.ChangeType);

                    LogType logType = LogType.Delete;
                    JsonService.AddLog(new Log
                    {
                        Id = Guid.NewGuid(),
                        Date = lastWriteTime,
                        Type = logType,
                        Path = e.FullPath
                    });
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Message.ShowLine($"File: {e.OldFullPath} renamed to {e.FullPath}, Type: {e.ChangeType}");

            DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);            

            LogType logType = LogType.Rename;

            Guid id = JsonService.GetListLog().LastOrDefault(x => x.Path == e.OldFullPath).Id;
            JsonService.AddLog(new Log
            {
                Id = id == default(Guid)? Guid.NewGuid(): id,
                Date = lastWriteTime,
                Type = logType,
                OldPath = e.OldFullPath,
                Path = e.FullPath
            });
        }
    }
}
