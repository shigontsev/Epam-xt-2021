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

        private event Action<string> Notify;
        
        public List<Log> ListLog { get; private set; }

        public Dictionary<string, InfoState> ListFixation { get; private set; }

        private GIT _Logger;

        public FileResetter(GIT logger, Action<string> modeNotify)
        {
            _Logger = logger;

            if (!Directory.Exists(_Logger.CurrentPath))
            {
                throw new FileNotFoundException(nameof(_Logger.CurrentPath), "По данной директории папки не существует");
            }

            Notify = modeNotify;
        }

        /// <summary>
        /// Working by index Fixations
        /// </summary>
        public void Run_Fixation()
        {
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

        /// <summary>
        /// Working by select DateTime Fixations
        /// </summary>
        public void Run_SelectResetByDate()
        {
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

                //Notify?.Invoke("Введите дату и время в формате \"dd.MM.yyyy HH:mm:ss\" :");

                DateTime dateTime = Input.SetDateTime();

                FixationResetByDateTime(dateTime);
            }
            Notify?.Invoke("Выход из списка");
            ListFixation.Clear();

            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        #region By index Fixations

        /// <summary>
        /// Reset to fixation by selected index
        /// </summary>
        /// <param name="index">index Fixation</param>
        private void FixationResetByIndex(int index)
        {
            if (index > ListFixation.Count - 1 || index < 0)
            {
                Notify?.Invoke("Выбран не верный индекс");
                return;
            }

            var fixation = ListFixation.ElementAt(index);

            DeleteAllTxt();
            _Logger.CopyFiles(fixation.Value.Path, _Logger.CurrentPath);

            //Delete late fixations
            var eraseFixation = ListFixation.Skip(index + 1);
            foreach (var item in eraseFixation)
            {
                Directory.Delete(item.Value.Path, true);
                File.Delete($"{_Logger.FixationLogPathFolder}\\{item.Key}.json");
            }
        }

        /// <summary>
        /// Show list Fixation, and presenting command, for action by Index
        /// </summary>
        private void ShowFixationLog()
        {
            int i = 0;
            if (ListFixation.Count != 0)
            {
                foreach (var item in ListFixation)
                {
                    Notify?.Invoke($"{i} : Date = {item.Value.Date}; Key = {item.Key};");
                    i++;
                }
                Notify?.Invoke("Выберите индекс отката:");
                Notify?.Invoke("Или нажмите \'q\' для выхода.");
            }
            else
            {
                Notify?.Invoke("Список пуст, введите любую клавишу для выхода.");
            }
            Notify?.Invoke("ВВОД : ");
        }

        #endregion By index Fixations

        #region By dateTime Fixations

        /// <summary>
        /// Reset to fixation by selected dateTime
        /// </summary>
        /// <param name="dateTime">dateTime Fixation</param>
        private void FixationResetByDateTime(DateTime dateTime)
        {
            if (dateTime >= ListFixation.Last().Value.Date || dateTime < ListFixation.First().Value.Date)
            {
                Notify.Invoke("Выбрана не верная дата");
                return;
            }

            var currentFixation = ListFixation.First(x => x.Value.Date > dateTime);

            string pathCommitsOfFixation = Path.Combine(_Logger.FixationLogPathFolder, $"{currentFixation.Key}.json");

            var currenCommitsOfFixation = 
                JsonService.Deserialize(pathCommitsOfFixation)
                .Where(x=>x.Date<=dateTime).ToList();

            DeleteAllTxt();
            _Logger.CopyFiles(currentFixation.Value.Path, _Logger.CurrentPath);
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
                File.Delete(Path.Combine(_Logger.FixationLogPathFolder, $"{item.Key}.json"));
            }
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

        /// <summary>
        /// Show list Fixation, and presenting command, for action by DateTime
        /// </summary>
        private void ShowCommiteLogByDate()
        {
            int i = 0;
            if (ListFixation.Count != 0)
            {
                foreach (var item in ListFixation)
                {
                    Notify?.Invoke($"{i} : Date = {item.Value.Date}; Key = {item.Key};");
                    i++;
                }
                Notify?.Invoke("Введите любую клавишу для продолжения");
                Notify?.Invoke("Или нажмите \'q\' для выхода.");
            }
            else
            {
                Notify?.Invoke("Список пуст, введите любую клавишу для выхода.");
            }
            Notify?.Invoke("ВВОД : ");
        }

        #endregion By dateTime Fixations

        /// <summary>
        /// Clear current folder from *.txt files
        /// </summary>
        private void DeleteAllTxt()
        {
            if (Directory.Exists(_Logger.CurrentPath))
            {
                var files = Directory.GetFiles(_Logger.CurrentPath, "*.txt", SearchOption.AllDirectories)
                    .Where(f => !f.Contains(_Logger.LoggerPathFolder));
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }
        }
    }
}
