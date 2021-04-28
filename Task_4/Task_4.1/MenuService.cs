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

        public FileResetter LogFixation { get; private set; }

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
            LogFixation = new FileResetter(PathFolderWatching, Logger);
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
                        //Select by index
                        LogFixation.Run_Fixation();
                        ////Select by dateTime
                        //LogFixation.Run_SelectResetByDate();
                        break;
                }

            } while (commandButton != "q");
        }        
    }
}
