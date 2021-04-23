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
        public static FileSystemWatcher watcherA;

        public static void Run()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher(Environment.CurrentDirectory, "*.txt"))
            {
                //watcher.Path = Environment.CurrentDirectory;

                watcher.NotifyFilter = NotifyFilters.LastAccess
                    | NotifyFilters.LastWrite
                    | NotifyFilters.CreationTime
                    | NotifyFilters.FileName;
                // Only watch text files.
                //watcher.Filter = "*.txt";

                // Add event handlers.
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnCreated);
                watcher.Deleted += new FileSystemEventHandler(OnDeleted);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);

                watcherA = watcher;

                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;

                // Wait for the user to quit the program.
                Message.ShowLine("Введите \'q\' для завершения наблюдения.");
                //while (Console.Read() != 'q') ;
                Console.ReadLine();
            }
        }

        private static DateTime lastRead = DateTime.MinValue;

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            while (!File.Exists(e.FullPath)) ;
            //if (!File.Exists(e.FullPath))
            //return;
            //DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
            //DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
            //async спас от другого процесса
            //string content = Task<string>.Run(async () => await File.ReadAllTextAsync(e.FullPath)).Result;
            //string content = File.ReadAllText(e.FullPath);

            //string content;
            //using (StreamReader sr = new StreamReader(e.FullPath))
            //{
            //    content = sr.ReadToEnd();
            //    sr.Dispose();
            //    sr.Close();
            //}
            // асинхронное чтение
            //using (StreamReader sr = new StreamReader(e.FullPath))
            //{
            //    var task = new Task<string>(() => sr.ReadToEnd());
            //    //task.Wait(TimeSpan.FromMilliseconds(1));
            //    task.Start();
            //    content = task.Result;
            //    await task;
            //    //while (!task.IsCompletedSuccessfully) ;
            //    sr.Dispose();
            //    sr.Close();

            //}

            //content = IOService.ReadFile(e.FullPath);

            bool bb;
            while (bb = IOService.IsFileLocked(new FileInfo(e.FullPath)))
            {

            }
            DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
            if (lastWriteTime != lastRead)
            {
                //Thread.Sleep(TimeSpan.FromSeconds(1));
                string content = File.ReadAllText(e.FullPath);
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

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Created)
            {
                return;
            }
            while (!File.Exists(e.FullPath)) ;
            //if (!File.Exists(e.FullPath))
            //return;

            bool bb;
            while (bb = IOService.IsFileLocked(new FileInfo(e.FullPath)))
            {

            }
            DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
            if (lastWriteTime != lastRead)
            {
                //Thread.Sleep(TimeSpan.FromSeconds(1));
                string content = File.ReadAllText(e.FullPath);
                Message.ShowLine("File: " + e.FullPath + " " + e.ChangeType);
                LogType logType = LogType.Create;
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
            //Thread.Sleep(TimeSpan.FromMilliseconds(200));
        }

        // Define the event handlers.
        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
            DateTime lastWriteTime = DateTime.Now;
            if (lastRead >= lastWriteTime || lastRead <= lastWriteTime + TimeSpan.FromMilliseconds(10))
            {
                return;
            }
            if (e.ChangeType != WatcherChangeTypes.Deleted)
            {
                return;
            }
            // Specify what is done when a file is changed, created, or deleted.
            //DateTime lastWriteTime = DateTime.Now;
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
