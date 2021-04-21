using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task_4._1
{
    public class JsonService
    {
        public static List<Log> GetListLog()
        {
            string pathLog = "log.json";
            if (!File.Exists(pathLog))
            {
                return new List<Log>();
            }
            // чтение данных

            //using (FileStream fs = new FileStream(pathLog, FileMode.Open))
            ////using (FileStream fs = new FileStream("log.json", FileMode.Open))
            //{
            //    List<Log> restoredLog = Task.Run(async () => await JsonSerializer.DeserializeAsync<List<Log>>(fs)).Result;
            //    //foreach (var item in restoredLog)
            //    //{
            //    //    Console.WriteLine($"Id: {item.Id}  Type: {item.Type} Path: {item.Path} Content: {item.Content}");
            //    //}
            //    return restoredLog.ToList();
            //    //var temp = restoredLog.ToList();
            //    //foreach (var item in collection)
            //    //{

            //    //}
            //    //return restoredLog.All(x=>x).ToList();
            //    //Log restoredLog = await JsonSerializer.DeserializeAsync<Log>(fs);
            //    //Console.WriteLine($"Id: {restoredLog.Id}  Type: {restoredLog.Type} Path: {restoredLog.Path} Content: {restoredLog.Content}");
            //}

            string jsonString = File.ReadAllText(pathLog);
            return JsonSerializer.Deserialize<List<Log>>(jsonString);
        }

        public static string GetContentLog(Log source)
        {            
            return GetContentLogById(source.Id);
        }

        public static string GetContentLogById(Guid id)
        {
            string pathContent = $"LogContent\\{id}.json";

            return !File.Exists(pathContent) ? File.ReadAllText(pathContent) : null;
        }

        public static void SetListLog(List<Log> list)
        {
            string pathLog = "log.json";

            //if (!File.Exists(pathLog))
            //{
            //    File.Create(pathLog);
            //}

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            //Log logContent = new Log { lis}
            //List<Log> list1 = await GetListLog();

            //if (list1.SequenceEqual(list))
            //{
            //    Console.WriteLine("Файл не изменен");
            //    return;
            //}
            //using (FileStream fs = new FileStream(pathLog, FileMode.OpenOrCreate))
            ////using (FileStream fs = new FileStream("log.json", FileMode.Append))
            //{
            //    //var a = new List<Log>();
            //    //Log log = new Log() { Id = Guid.NewGuid(), Type = LogType.Create, Path = Environment.CurrentDirectory, Content = "Hello World!!!" };
            //    //Log log1 = new Log() { Id = Guid.NewGuid(), Type = LogType.Edit, Path = Environment.CurrentDirectory, Content = "Hello Human!!!" };
            //    //a.Add(log);
            //    //a.Add(log1);
            //    Task task = Task.Run(async ()=>  await JsonSerializer.SerializeAsync<List<Log>>(fs, list, options));
            //    //Log log1 = new Log() { Id = Guid.NewGuid(), Type = LogType.Create, Path = Environment.CurrentDirectory, Content = "Hello Human!!!" };
            //    //await JsonSerializer.SerializeAsync<Log>(fs, log1);
            //    Console.WriteLine("Data has been saved to file");
            //}

            //using (FileStream fs = new FileStream(pathLog, FileMode.OpenOrCreate))
            //{
            //    var byteStream = JsonSerializer.Serialize<List<Log>>(list, options);
            //    fs.Write(byteStream);
            //    Console.WriteLine("Data has been saved to file");
            //}

            string jsonString = JsonSerializer.Serialize(list, options);
            File.WriteAllText(pathLog, jsonString);
        }

        public static void AddLog(Log source)
        {
            //string pathLog = "log.json";

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            //Log logItem = new Log { Id = source.Id, Date = source.Date, Type = source.Type, Path = source.Path };

            //List<Log> list = GetListLog();
            //list.Add(logItem);
            ////if (list1.SequenceEqual(list))
            ////{
            ////    Console.WriteLine("Файл не изменен");
            ////    return;
            ////}
            //using (FileStream fs = new FileStream(pathLog, FileMode.OpenOrCreate))
            ////using (FileStream fs = new FileStream("log.json", FileMode.Append))
            //{
            //    //var a = new List<Log>();
            //    //Log log = new Log() { Id = Guid.NewGuid(), Type = LogType.Create, Path = Environment.CurrentDirectory, Content = "Hello World!!!" };
            //    //Log log1 = new Log() { Id = Guid.NewGuid(), Type = LogType.Edit, Path = Environment.CurrentDirectory, Content = "Hello Human!!!" };
            //    //a.Add(log);
            //    //a.Add(log1);
            //    Task task = Task.Run(async () => await JsonSerializer.SerializeAsync<List<Log>>(fs, list, options));
            //    //Log log1 = new Log() { Id = Guid.NewGuid(), Type = LogType.Create, Path = Environment.CurrentDirectory, Content = "Hello Human!!!" };
            //    //await JsonSerializer.SerializeAsync<Log>(fs, log1);

            //    if (!Directory.Exists("LogContent"))
            //    {
            //        Directory.CreateDirectory("LogContent");
            //    }

            //    //if (!string.IsNullOrWhiteSpace(source.Content))
            //    if(source.Type != LogType.Delete)
            //    {
            //        string pathLogContent = $"LogContent\\{source.Id}.json";
            //        //using (FileStream fsContent = new FileStream(pathLogContent, FileMode.OpenOrCreate))
            //        //{
            //        //    // преобразуем строку в байты
            //        //    byte[] array = Encoding.Default.GetBytes(source.Content);
            //        //    await fsContent.WriteAsync(array);
            //        //}
            //        File.WriteAllText(pathLogContent, source.Content);
            //    }


            //    //Console.WriteLine("Data has been saved to file");
            //}


            List<Log> list = GetListLog();
            list.Add(source);

            SetListLog(list);

            if (!Directory.Exists("LogContent"))
            {
                Directory.CreateDirectory("LogContent");
            }

            if (source.Type != LogType.Delete)
            {
                string pathLogContent = $"LogContent\\{source.Id}.json";

                File.WriteAllText(pathLogContent, source.Content);
            }
        }
    }
}
