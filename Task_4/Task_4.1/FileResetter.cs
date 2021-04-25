using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Task_4._1
{
    public class FileResetter
    {
        public string PathCurrentFolder { get; private set; }

        public string PathLog => PathCurrentFolder + LogService._nameFileLog;

        public string PathFolderLogContent => PathCurrentFolder + LogService._nameFolderLogContent;

        public List<Log> ListLog { get; private set; }

        public FileResetter(string pathFolder)
        {
            if (!Directory.Exists(pathFolder))
            {
                throw new FileNotFoundException(nameof(pathFolder), "По данной директории папки не существует");
            }

            PathCurrentFolder = pathFolder;
        }

        public void Run()
        {
            ListLog = LogService.GetListLog(PathLog);

            ShowCommiteLog();

            if (ListLog.Count == 0)
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


        private void CommitResetByIndex(int index)
        {            
            if (index > ListLog.Count - 1 || index < 0)
            {
                Message.ShowLine("Выбран не верный индекс");
                return;
            }

            var listLogNew = ListLog.GetRange(0, index + 1).ToList();

            DeleteAllTxt();

            foreach (var item in listLogNew)
            {
                switch (item.Type)
                {
                    case LogType.Create:
                        CommitCreateOrEdit(item);
                        break;
                    case LogType.Edit:
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

            LogService.SetListLog(listLogNew, PathLog);
        }

        private void CommitCreateOrEdit(Log item)
        {
            File.WriteAllText(item.Path, LogService.GetContentLogById(item.Id, PathFolderLogContent));
        }

        private void CommitDelete(Log item)
        {
            File.Delete(item.Path);
        }

        private void CommitRename(Log item)
        {
            File.Move(item.OldPath, item.Path);
        }

        private void DeleteAllTxt()
        {
            if (Directory.Exists(PathCurrentFolder))
            {
                var files = Directory.GetFiles(PathCurrentFolder, "*.txt", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }
        }

        private void ShowCommiteLog()
        {
            int i = 0;
            if (ListLog.Count != 0)
            {
                foreach (var item in ListLog)
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
