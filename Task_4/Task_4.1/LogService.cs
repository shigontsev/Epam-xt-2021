using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4._1
{
    public class LogService
    {
        public static void DeleteTxt(string path)
        {
            if (!File.Exists(path))
            {
                var files = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    //Console.WriteLine("Delate: " + file);
                    File.Delete(file);
                }
            }
        }

        public static async void Run()
        {
            //string[] args = System.Environment.GetCommandLineArgs();

            //// If a directory is not specified, exit program.
            //if (args.Length != 2)
            //{
            //    // Display the proper way to call the program.
            //    Console.WriteLine("Usage: Watcher.exe (directory)");
            //    return;
            //}

            // Create a new FileSystemWatcher and set its properties.
            FileSystemWatcher watcher = new FileSystemWatcher();
            //watcher.Path = args[1];
            watcher.Path = Environment.CurrentDirectory;
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            //watcher.NotifyFilter = NotifyFilters.LastAccess 
            //    | NotifyFilters.LastWrite
            //    | NotifyFilters.FileName 
            //    | NotifyFilters.DirectoryName;

            watcher.NotifyFilter = NotifyFilters.LastAccess
                | NotifyFilters.LastWrite | NotifyFilters.Size
                | NotifyFilters.FileName
                | NotifyFilters.DirectoryName;
            // Only watch text files.
            watcher.Filter = "*.txt";

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChangedOrCreated);
            watcher.Created += new FileSystemEventHandler(OnChangedOrCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            //watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.IncludeSubdirectories = true;
            // Begin watching.
            watcher.EnableRaisingEvents = true;

            // Wait for the user to quit the program.
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }

        private static DateTime lastRead = DateTime.MinValue;

        private static async void OnChangedOrCreated(object source, FileSystemEventArgs e)
        {
            //if (e.ChangeType != WatcherChangeTypes.Changed)
            //{
            //    return;
            //}
            DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
            if (lastWriteTime != lastRead)
            {
                //var task1 = Task.Run(() => Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType));
                var task1 = Task.Run(async ()
                    => {
                        Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
                        LogType logType = LogType.None;
                        switch (e.ChangeType)
                        {
                            case WatcherChangeTypes.Changed:
                                logType = LogType.Edit;
                                break;
                            case WatcherChangeTypes.Created:
                                logType = LogType.Create;
                                break;
                            //case WatcherChangeTypes.Deleted:
                            //    logType = LogType.Delete;
                            //    break;
                        }
                        await JsonService.AddLog(new Log
                        {
                            Id = Guid.NewGuid(),
                            Date = File.GetLastWriteTime(e.FullPath),
                            Type = logType,
                            Path = e.FullPath,
                            Content = await new StreamReader(e.FullPath).ReadToEndAsync()
                        });
                    });
                await task1;

                lastRead = lastWriteTime;
            }

        }

        // Define the event handlers.
        private static async void OnDeleted(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            DateTime lastWriteTime = DateTime.Now;
            var task1 = Task.Run(async () 
                => { 
                    Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);

                    LogType logType = LogType.Delete;
                    await JsonService.AddLog(new Log
                    {
                        Id = Guid.NewGuid(),
                        Date = lastWriteTime,
                        Type = logType,
                        Path = e.FullPath
                    });
                });
            await task1;
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
    }
}
