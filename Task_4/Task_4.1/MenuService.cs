using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4._1
{
    public class MenuService
    {
        public static void CallMenu()
        {
            string[] contentMenu = { "Выберите следующее:", "1 : Наблюдение", "2 : Откат изменений", "ENTER: " };

            do
            {
                Console.Clear();
                Message.ShowLine(string.Join(Environment.NewLine, contentMenu));
                int.TryParse(Console.ReadLine(), out int resulte);
                switch (resulte)
                {
                    case 1:
                        Message.ShowLine("Началось наблюдение...");
                        LogService.Run();
                        break;
                    case 2:
                        ResetService.CommiteList(ShowCommiteList);
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Press \'q\' Выйти из приложения");
            } while (Console.Read() != 'q');
        }

        public static void ShowCommiteList(List<Log> source)
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
