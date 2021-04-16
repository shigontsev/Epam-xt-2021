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
        public static async Task<List<Log>> GetListLog()
        {
            // чтение данных
            using (FileStream fs = new FileStream("log.json", FileMode.OpenOrCreate))
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

        public static async Task SetListLog(List<Log> list)
        {
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

        public static async Task AddLog(Log source)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            Log logItem = new Log { Id = source.Id, Date = source.Date, Type = source.Type, Path = source.Path };

            List<Log> list = await GetListLog();
            list.Add(logItem);
            //if (list1.SequenceEqual(list))
            //{
            //    Console.WriteLine("Файл не изменен");
            //    return;
            //}
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

                string pathLogContent = $"\\LogContent\\{source.Id}.json";
                using (FileStream fsContent = new FileStream(pathLogContent, FileMode.OpenOrCreate))
                {
                    // преобразуем строку в байты
                    byte[] array = Encoding.Default.GetBytes(source.Content);
                    await fsContent.WriteAsync(array);
                }

                //Console.WriteLine("Data has been saved to file");
            }
            
        }
    }
}
