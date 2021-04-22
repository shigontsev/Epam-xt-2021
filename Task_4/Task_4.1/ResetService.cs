using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Task_4._1
{
    public class ResetService
    {
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
                try
                {
                    string input = Input.String();
                    if (input == "q")
                    {
                        Message.ShowLine("Выход из списка");
                        return;
                    }
                    int index = Input.Int(input);

                    CommitResetByIndex(index);
                }
                catch (ArgumentException ex)
                {
                    Message.ShowLine(ex.ParamName);
                    Message.ShowLine("Выход из списка");
                }
            }
        }

        private static void CommitResetByIndex(int index)
        {
            var listLog = JsonService.GetListLog();
            if (index > listLog.Count - 1 || index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Выбран не верный индекс");
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

    }
}
