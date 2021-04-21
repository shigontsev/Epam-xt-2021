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
            Console.WriteLine(string.Join(Environment.NewLine, contentMenu));
            int.TryParse(Console.ReadLine(), out int resulte);
            switch (resulte)
            {
                case 1:
                    LogService.Run();
                    break;
                case 2:
                    ResetService.CommiteList(ShowCommiteList);
                    break;
                default:
                    break;
            }

            Console.WriteLine("Press \'q\' Выйти из меню");
            while (Console.Read() != 'q') ;
        }

        public static void ShowCommiteList(List<Log> source)
        {
            int i = 0;
            if (source.Count != 0)
            {
                foreach (var item in source)
                {
                    Console.WriteLine($"{i} : Date = {item.Date}; Type = {item.Type}; Path = {item.Path}");
                    i++;
                }
                Console.WriteLine("Выберите индекс отката:");
                Console.WriteLine("Или Press \'q\' to quit the sample.");
            }
            else
            {
                Console.WriteLine("Список пуст, введите любую клавишу для выхода.");
                //Console.WriteLine("Press Any Button to quit the sample.");
            }
            Console.Write("ВВОД : ");

        }
    }
}
