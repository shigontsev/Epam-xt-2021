using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Task_4._1
{
    public class ResetService
    {
        public static void Run()
        {
            var listLog = JsonService.GetListLog();

            ShowCommiteLog(listLog);

            if (listLog.Count == 0)
            {
                Console.ReadLine();
            }
            else
            {
                string input = Input.String();
                if (input == "q")
                {
                    Message.ShowLine("Выход из списка");
                    return;
                }
                if (!Input.TryInt(input, out int index))
                {
                    Message.ShowLine("Выход из списка");
                    return;
                }

                CommitResetByIndex(index);
            }
            Message.ShowLine("Выход из списка");
        }

        private static void DeleteAllTxt(string path)
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

        private static void CommitResetByIndex(int index)
        {
            var listLog = JsonService.GetListLog();
            if (index > listLog.Count - 1 || index < 0)
            {
                Message.ShowLine("Выбран не верный индекс");
                return;
            }

            var listLogNew = listLog.GetRange(0, index + 1).ToList();

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
                }
            }

            JsonService.SetListLog(listLogNew);
        }

        private static void CommitCreateOrEdit(Log item)
        {
            File.WriteAllText(item.Path, JsonService.GetContentLogById(item.Id));
        }

        private static void CommitDelete(Log item)
        {
            File.Delete(item.Path);
        }

        private static void CommitRename(Log item)
        {
            File.Move(item.OldPath, item.Path);
        }


        private static void ShowCommiteLog(List<Log> source)
        {
            int i = 0;
            if (source.Count != 0)
            {
                foreach (var item in source)
                {
                    Message.ShowLine($"{i} : Date = {item.Date}; Type = {item.Type}; Path = {item.Path}");
                    i++;
                }
                Message.ShowLine("Выберите индекс отката:");
                Message.ShowLine("Или нажмите \'q\' для выхода.");
            }
            else
            {
                Message.ShowLine("Список пуст, введите любую клавишу для выхода.");
            }
            Message.Show("ВВОД : ");
        }

    }
}
