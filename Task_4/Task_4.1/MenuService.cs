using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task_4._1
{
    public class MenuService
    {
        public string PathFolderWatching { get; private set; }
                
        public FileWatcher Watcher { get; private set; }

        public FileResetter Resetter { get; private set; }

        public LogService Logger { get; private set; }

        public MenuService(string pathFolderWatching)
        {
            if (!Directory.Exists(pathFolderWatching))
            {
                throw new FileNotFoundException(nameof(pathFolderWatching), "По данной директории папки не существует");
            }

            PathFolderWatching = pathFolderWatching;

            Logger = new LogService(PathFolderWatching);

            Watcher = new FileWatcher(PathFolderWatching, Logger);
            Resetter = new FileResetter(PathFolderWatching, Logger);
        }

        public void CallMenu()
        {
            string[] contentMenu = { "Выберите следующее:", "1 : Наблюдение", "2 : Откат изменений"
                    , "Ввод \'q\' Выйти из приложения", "ENTER: " };
            string[] contentMenu_Resetter = { "Выбран откат изменений","Выберите следующее:", "1 : Откат по индексу фиксации", "2 : Откат по выбранной дате и времени"
                    , "Ввод \'q\' Вернуться назад", "ENTER: " };
            
            //MenuAction
            DelegateMenu(contentMenu, 
                Watcher.Run, delegate {
                    DelegateMenu(contentMenu_Resetter, 
                        Resetter.Run_Fixation, Resetter.Run_SelectResetByDate);
                }
                );
        }
        
        private void DelegateMenu(string[] contentMenu, Action action1, Action action2)
        {
            string commandButton = "";
            do
            {
                Console.Clear();
                Console.WriteLine(string.Join(Environment.NewLine, contentMenu));

                commandButton = Console.ReadLine();
                switch (commandButton)
                {
                    case "1":
                        action1?.Invoke();
                        break;
                    case "2":
                        action2?.Invoke();
                        break;
                }

            } while (commandButton != "q");
        }
    }

}
