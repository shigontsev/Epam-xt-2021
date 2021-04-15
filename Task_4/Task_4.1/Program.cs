using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task_4._1
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //var prog = new Program();
            List<Log> list = await GetListLog();
            list.Add(new Log() { Id = Guid.NewGuid(), Type = LogType.Create, Path = Environment.CurrentDirectory, Content = "Hello Android!!!" });
            SetListLog(list);

            //TestJsonLog();


            Console.ReadLine();
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
                foreach (var item in restoredLog)
                {
                    Console.WriteLine($"Id: {item.Id}  Type: {item.Type} Path: {item.Path} Content: {item.Content}");
                }
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
    }

}
