using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task_4._1
{
    public class Menu
    {
        public string PathFolderWatching { get; private set; }
                
        public FileWatcher Watcher { get; private set; }

        public FileResetter Resetter { get; private set; }

        public GIT Logger { get; private set; }

        public Menu(string pathFolderWatching)
        {
            if (!Directory.Exists(pathFolderWatching))
            {
                throw new FileNotFoundException(nameof(pathFolderWatching), "По данному пути папки не существует");
            }

            PathFolderWatching = pathFolderWatching;

            Logger = new GIT(PathFolderWatching);

            Watcher = new FileWatcher(Logger, Console.WriteLine);
            Resetter = new FileResetter(Logger, Console.WriteLine);
        }

        public void CallMenu()
        {
            string[] contentMenu = {
                "Выберите следующее:",
                "1 : Наблюдение",
                "2 : Откат изменений",
                "Ввод \'q\' Выйти из приложения",
                "ENTER: "
            };

            string[] contentMenu_Resetter = {
                "Выбран откат изменений",
                "Выберите следующее:",
                "1 : Откат по индексу фиксации",
                "2 : Откат по выбранной дате и времени",
                "Ввод \'q\' Вернуться назад", "ENTER: "
            };
            
            //MenuAction
            DelegateMenu(contentMenu, 
                Watcher.Run, 
                () => DelegateMenu(contentMenu_Resetter, 
                        Resetter.Run_Fixation, 
                        Resetter.Run_SelectResetByDate));
        }
        
        private void DelegateMenu(string[] contentMenu, params Action[] action)
        {
            string commandButton = "";
            do
            {
                Console.Clear();
                Console.WriteLine(string.Join(Environment.NewLine, contentMenu));

                commandButton = Console.ReadLine();
                if (int.TryParse(commandButton, out int index) && (index > 0 && index <= action.Length))
                {
                    action[index - 1]?.Invoke();
                }

            } while (commandButton != "q");
        }
    }

}
