using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Task_4._1
{
    public class ResetService
    {
        public static void DeleteAllTxt(string path)
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

        public static void CommiteList(Action<List<Log>> action)
        {
            var listLog = JsonService.GetListLog();

            action?.Invoke(listLog);

            if (listLog.Count == 0)
            {
                Console.ReadLine();
            }
            else
            {
                //try
                //{
                var a = int.TryParse(Console.ReadLine(), out int input);
                //string input = Console.ReadLine();
                //var a = input.All(x => char.IsDigit(x));
                if (a)
                {
                    var item = listLog.ElementAt(input);
                    Console.WriteLine($" : Date = {item.Date}; Type = {item.Type}; Path = {item.Path}");
                }
                else
                {
                    Console.WriteLine("Введен не числовое значение");
                }
                //Console.WriteLine("Введен не числовое значение");
                //}
                //catch (Exception)
                //{
                //    Console.WriteLine("Введен не числовое значение");
                //}

            }

            //if (Console.Read() != 'q')
            //{

            //}
        }

        public void CommitResetByIndex(int index)
        {
            var listLogNew = JsonService.GetListLog().GetRange(0, index + 1).ToList();

            DeleteAllTxt(Environment.CurrentDirectory);

            foreach (var item in listLogNew)
            {
                switch (item.Type)
                {
                    case LogType.Create | LogType.Edit:
                        CommitCreateOrEdit(item);
                        break;
                    case LogType.Delete:
                        CommitDelete(item);
                        break;
                    case LogType.Rename:
                        CommitRename(item);
                        break;
                    default:
                        break;
                }
            }
        }

        private void CommitCreateOrEdit(Log item)
        {
            File.WriteAllText(item.Path, JsonService.GetContentLogById(item.Id));
        }

        private void CommitDelete(Log item)
        {
            File.Delete(item.Path);
        }

        //private void CommitEdit(Log item)
        //{
        //    File.WriteAllText(item.Path, JsonService.GetContentLogById(item.Id));
        //}

        private void CommitRename(Log item)
        {
            File.Move(item.OldPath, item.Path);
        }

    }
}
