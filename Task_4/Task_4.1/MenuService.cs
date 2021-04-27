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

        public FileResetter LogCommits { get; private set; }

        public MenuService(string pathFolderWatching)
        {
            if (!Directory.Exists(pathFolderWatching))
            {
                throw new FileNotFoundException(nameof(pathFolderWatching), "По данной директории папки не существует");
            }

            PathFolderWatching = pathFolderWatching;

            Watcher = new FileWatcher(PathFolderWatching);
            LogCommits = new FileResetter(PathFolderWatching);
        }

        public void CallMenu()
        {
            string[] contentMenu = { "Выберите следующее:", "1 : Наблюдение", "2 : Откат изменений"
                    , "Ввод \'q\' Выйти из приложения", "ENTER: " };

            string commandButton = "";
            do
            {
                Console.Clear();
                Console.WriteLine(string.Join(Environment.NewLine, contentMenu));

                commandButton = Console.ReadLine();
                switch (commandButton)
                {
                    case "1":
                        Watcher.Run();
                        break;
                    case "2":
                        LogCommits.RunFixation();
                        break;
                }

            } while (commandButton != "q");
        }        
    }
}
