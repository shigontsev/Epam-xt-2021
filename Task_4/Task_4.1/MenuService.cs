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
                        ResetService.Run();
                        break;
                    default:
                        Message.ShowLine("Выбрана не верная функция.");
                        break;
                }

                Console.WriteLine("Ввод \'q\' Выйти из приложения");
            } while (Console.Read() != 'q');
        }        
    }
}
