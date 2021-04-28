using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading;

namespace Task_4._1
{
    public class FileResetter
    {
        private delegate void EventHandler(string message);

        private event EventHandler Notify;


        public string PathCurrentFolder { get; private set; }

        public string PathLog => PathCurrentFolder + LogService._nameFileLog;

        //public string PathFolderLogContent => PathCurrentFolder + LogService._nameFolderLogContent;

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

            Notify += Message.ShowLine;
        }

        #region for commit
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

        public void Run_SelectResetByDate()
        {
            //ListLog = LogService.GetListLog(PathLog);
            ListFixation = _Logger.GetStates();

            ShowCommiteLogByDate();

            if (ListFixation.Count == 0)
            {
                Console.ReadLine();
            }
            else
            {
                string input = Input.String();
                if (input == "q")
                {
                    Notify?.Invoke("Выход из списка");
                    return;
                }

                Notify?.Invoke("Введите дату и время:");

                DateTime dateTime = Input.SetDateTime();

                FixationResetByDateTime(dateTime);

                //if (!Input.TryInt(input, out int index))
                //{
                //    Message.ShowLine("Выход из списка");
                //    return;
                //}

                //CommitResetByIndex(index);
            }
            Notify?.Invoke("Выход из списка");

            ListFixation.Clear();

            Thread.Sleep(TimeSpan.FromSeconds(3));
        }
        #endregion for commit


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
                    Notify?.Invoke("Выход из списка");
                    return;
                }
                if (!Input.TryInt(input, out int index))
                {
                    Notify?.Invoke("Выход из списка");
                    return;
                }

                FixationResetByIndex(index);
            }
            Notify?.Invoke("Выход из списка");
            ListFixation.Clear();

            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        //For fixation
        private void FixationResetByIndex(int index)
        {
            if (index > ListFixation.Count - 1 || index < 0)
            {
                Notify?.Invoke("Выбран не верный индекс");
                return;
            }

            var fixation = ListFixation.ElementAt(index);

            DeleteAllTxt();
            LogService.CopyFiles(fixation.Value.Path, PathCurrentFolder);

            //Delete late fixations
            var eraseFixation = ListFixation.Skip(index + 1);
            foreach (var item in eraseFixation)
            {
                Directory.Delete(item.Value.Path, true);
                File.Delete($"{_Logger.FixationLogPathFolder}\\{item.Key}.json");
            }
        }

        #region for commit
        //for commit
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

        private void FixationResetByDateTime(DateTime dateTime)
        {
            if (dateTime >= ListFixation.Last().Value.Date || dateTime < ListFixation.First().Value.Date)
            {
                Message.ShowLine("Выбрана не верная дата");
                return;
            }

            var currentFixation = ListFixation.First(x => x.Value.Date > dateTime);

            string pathCommitsOfFixation = $"{_Logger.FixationLogPathFolder}\\{currentFixation.Key}.json";

            var currenCommitsOfFixation = 
                LogService.Deserialize(pathCommitsOfFixation)
                .Where(x=>x.Date<=dateTime).ToList();

            DeleteAllTxt();
            LogService.CopyFiles(currentFixation.Value.Path, PathCurrentFolder);
            foreach (var item in currenCommitsOfFixation)
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

            //Delete late fixations
            var eraseFixation = ListFixation.Where(x=>x.Value.Date>dateTime);
            foreach (var item in eraseFixation)
            {
                Directory.Delete(item.Value.Path, true);
                File.Delete($"{_Logger.FixationLogPathFolder}\\{item.Key}.json");
            }
            

            ////Edit Commits current Of Fixation *.json
            //LogService.Serialize(currenCommitsOfFixation, pathCommitsOfFixation);
        }

        private void CommitCreateOrEdit(Log item)
        {
            File.WriteAllText(item.Path, _Logger.GetContentLogById(item.Id));
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

        private void ShowCommiteLogByDate()
        {
            int i = 0;
            if (ListFixation.Count != 0)
            {
                foreach (var item in ListFixation)
                {
                    Console.WriteLine($"{i} : Date = {item.Value.Date}; Key = {item.Key};");
                    i++;
                }
                Console.WriteLine("Введите любую клавишу для продолжения");
                Console.WriteLine("Или нажмите \'q\' для выхода.");
            }
            else
            {
                Notify?.Invoke("Список пуст, введите любую клавишу для выхода.");
            }
            Console.Write("ВВОД : ");
        }

        #endregion for commit

        /// <summary>
        /// Show list Fixation, and presenting command
        /// </summary>
        private void ShowFixationLog()
        {
            int i = 0;
            if (ListFixation.Count != 0)
            {
                foreach (var item in ListFixation)
                {
                    Console.WriteLine($"{i} : Date = {item.Value.Date}; Key = {item.Key};");
                    i++;
                }
                Console.WriteLine("Выберите индекс отката:");
                Console.WriteLine("Или нажмите \'q\' для выхода.");
            }
            else
            {
                Notify?.Invoke("Список пуст, введите любую клавишу для выхода.");
            }
            Console.Write("ВВОД : ");
        }

    }
}
