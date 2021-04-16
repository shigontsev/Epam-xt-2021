using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4._1
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //var prog = new Program();
            //List<Log> list = await GetListLog();
            //list.Add(new Log() { Id = Guid.NewGuid(), Type = LogType.Create, Path = Environment.CurrentDirectory, Content = "Hello Android!!!" });
            //SetListLog(list);

            //TestJsonLog();

            //using (FileStream fs = new FileStream(Environment.CurrentDirectory+"\\TukTuk\\kekman.txt", FileMode.OpenOrCreate))
            //{
            //    // преобразуем строку в байты
            //    byte[] array = System.Text.Encoding.Default.GetBytes("tuktuk");
            //    // запись массива байтов в файл
            //    fs.Write(array, 0, array.Length);
            //}

            DelateTXT(Environment.CurrentDirectory);

            //Run();

            Console.ReadLine();
        }

        static void DelateTXT(string path)
        {
            Regex reg = new Regex(@"\.txt$");
            if (!File.Exists(path))
            {
                var files = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
                //var files = Directory.GetFiles(path);
                //var folders = Directory.GetDirectories(path);
                foreach (var file in files)
                    //if (reg.Match(file).Success)
                    {
                        Console.WriteLine("Delate: " + file);
                    File.Delete(file);
                }
                //if (folders?.Length > 0)
                //{
                //    foreach (var folder in folders)
                //    {
                //        DelateTXT(folder);
                //    }
                //}
            }
                
                        
            //Console.WriteLine("Delate: " + file);
        }

        static async Task TestJsonLog()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };


            using (FileStream fs = new FileStream("log.json", FileMode.OpenOrCreate))
            //using (FileStream fs = new FileStream("log.json", FileMode.Append))
            {
                var a = new List<Log>();
                Log log = new Log() { Id = Guid.NewGuid(), Type = LogType.Create, Path = Environment.CurrentDirectory, Content = "Hello World!!!" };
                Log log1 = new Log() { Id = Guid.NewGuid(), Type = LogType.Edit, Path = Environment.CurrentDirectory, Content = "Hello Human!!!" };
                a.Add(log);
                a.Add(log1);
                await JsonSerializer.SerializeAsync<List<Log>>(fs, a, options);
                //Log log1 = new Log() { Id = Guid.NewGuid(), Type = LogType.Create, Path = Environment.CurrentDirectory, Content = "Hello Human!!!" };
                //await JsonSerializer.SerializeAsync<Log>(fs, log1);
                Console.WriteLine("Data has been saved to file");
            }

            // чтение данных
            using (FileStream fs = new FileStream("log.json", FileMode.OpenOrCreate))
            //using (FileStream fs = new FileStream("log.json", FileMode.Open))
            {
                List<Log> restoredLog = await JsonSerializer.DeserializeAsync<List<Log>>(fs);
                foreach (var item in restoredLog)
                {

                    Console.WriteLine($"Id: {item.Id}  Type: {item.Type} Path: {item.Path} Content: {item.Content}");
                }
                //Log restoredLog = await JsonSerializer.DeserializeAsync<Log>(fs);
                //Console.WriteLine($"Id: {restoredLog.Id}  Type: {restoredLog.Type} Path: {restoredLog.Path} Content: {restoredLog.Content}");
            }
        }

        static async Task<List<Log>> GetListLog()
        {
            // чтение данных
            using (FileStream fs = new FileStream("log.json", FileMode.Open))
            //using (FileStream fs = new FileStream("log.json", FileMode.Open))
            {
                List<Log> restoredLog = await JsonSerializer.DeserializeAsync<List<Log>>(fs);
                //foreach (var item in restoredLog)
                //{
                //    Console.WriteLine($"Id: {item.Id}  Type: {item.Type} Path: {item.Path} Content: {item.Content}");
                //}
                return restoredLog.ToList();
                //Log restoredLog = await JsonSerializer.DeserializeAsync<Log>(fs);
                //Console.WriteLine($"Id: {restoredLog.Id}  Type: {restoredLog.Type} Path: {restoredLog.Path} Content: {restoredLog.Content}");
            }
        }

        static async Task SetListLog(List<Log> list)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            List<Log> list1 = await GetListLog();

            if (list1.SequenceEqual(list))
            {
                Console.WriteLine("Файл не изменен");
                return;
            }
            using (FileStream fs = new FileStream("log.json", FileMode.OpenOrCreate))
            //using (FileStream fs = new FileStream("log.json", FileMode.Append))
            {
                //var a = new List<Log>();
                //Log log = new Log() { Id = Guid.NewGuid(), Type = LogType.Create, Path = Environment.CurrentDirectory, Content = "Hello World!!!" };
                //Log log1 = new Log() { Id = Guid.NewGuid(), Type = LogType.Edit, Path = Environment.CurrentDirectory, Content = "Hello Human!!!" };
                //a.Add(log);
                //a.Add(log1);
                await JsonSerializer.SerializeAsync<List<Log>>(fs, list, options);
                //Log log1 = new Log() { Id = Guid.NewGuid(), Type = LogType.Create, Path = Environment.CurrentDirectory, Content = "Hello Human!!!" };
                //await JsonSerializer.SerializeAsync<Log>(fs, log1);
                Console.WriteLine("Data has been saved to file");
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
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreatedOrDeleted);
            watcher.Deleted += new FileSystemEventHandler(OnCreatedOrDeleted);
            //watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.IncludeSubdirectories = true;
            // Begin watching.
            watcher.EnableRaisingEvents = true;

            // Wait for the user to quit the program.
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }

        static DateTime lastRead = DateTime.MinValue;

        private static async void OnChanged(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
            if (lastWriteTime != lastRead)
            {
                var task1 = Task.Run(() => Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType));
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
                await task1;
                lastRead = lastWriteTime;
            }
            
        }

        // Define the event handlers.
        private static async void OnCreatedOrDeleted(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            //Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            var task1 = Task.Run(() => Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType));
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
            await task1;
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }

        //Мониторинг файлов
        //https://ru.stackoverflow.com/questions/428820/%D0%9F%D0%BE%D1%81%D1%82%D0%BE%D1%8F%D0%BD%D0%BD%D1%8B%D0%B9-%D0%BC%D0%BE%D0%BD%D0%B8%D1%82%D0%BE%D1%80%D0%B8%D0%BD%D0%B3-%D0%BF%D0%B0%D0%BF%D0%BA%D0%B8-%D1%80%D0%B5%D0%B0%D0%BB%D0%B8%D0%B7%D0%BE%D0%B2%D0%B0%D0%BD%D0%BD%D1%8B%D0%B9-%D0%BD%D0%B0-c

        //убирает дублирование в Changed
        //https://coderoad.ru/1764809/%D0%A1%D0%BE%D0%B1%D1%8B%D1%82%D0%B8%D0%B5-FileSystemWatcher-Changed-%D0%B2%D1%8B%D0%B7%D1%8B%D0%B2%D0%B0%D0%B5%D1%82%D1%81%D1%8F-%D0%B4%D0%B2%D0%B0%D0%B6%D0%B4%D1%8B
    }

}
