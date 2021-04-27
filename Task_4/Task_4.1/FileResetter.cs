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

        public Dictionary<string, InfoState> ListFixation { get; private set; }

        private LogService _Logger;

        public FileResetter(string pathFolder, LogService logger)
        {
            if (!Directory.Exists(pathFolder))
            {
                throw new FileNotFoundException(nameof(pathFolder), "По данной директории папки не существует");
            }

            PathCurrentFolder = pathFolder;

            _Logger = logger;
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

        public void RunFixation()
        {
            //ListLog = LogService.GetAllFixation(PathCurrentFolder + "\\FixationLog");

            ListFixation = _Logger.GetStates();


            ShowFixationLog();

            if (ListFixation.Count() == 0)
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

                FixationResetByIndex(index);
            }
            Message.ShowLine("Выход из списка");
        }

        private void FixationResetByIndex(int index)
        {
            if (index > ListFixation.Count - 1 || index < 0)
            {
                Message.ShowLine("Выбран не верный индекс");
                return;
            }

            var fixation = ListFixation.ElementAt(index);

            DeleteAllTxt();
            LogService.CopyFiles(fixation.Value.Path, PathCurrentFolder);

            var eraseFixation = ListFixation.Skip(index + 1);
            foreach (var item in eraseFixation)
            {
                Directory.Delete(item.Value.Path, true);
                File.Delete(PathCurrentFolder +
                    "\\FixationLog\\" + item.Key + ".json");
            }
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

            _Logger.SetListLog(listLogNew, PathLog);
        }

        private void CommitCreateOrEdit(Log item)
        {
            File.WriteAllText(item.Path, _Logger.GetContentLogById(item.Id, PathFolderLogContent));
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

        private void ShowFixationLog()
        {
            int i = 0;
            if (ListFixation.Count != 0)
            {
                foreach (var item in ListFixation)
                {
                    Message.ShowLine($"{i} : Date = {item.Value.Date}; Key = {item.Key};");
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
