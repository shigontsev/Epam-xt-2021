using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4._1
{
    public class Input
    {
        public static int Int()
        {
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException(nameof(result), "Введено не числовое значение");
            }
        }

        public static int Int(string input)
        {
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException(nameof(result), "Введено не числовое значение");
            }
        }

        public static bool TryInt(string input, out int result)
        {
            if (int.TryParse(input, out result))
            {
                return true;
            }
            else
            {
                Message.ShowLine("Введено не числовое значение");
                return false;
            }            
        }

        public static string String()
        {
            do
            {
                string result = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(result))
                {
                    Console.Write("Введено пустое значение, повторите попытку: ");
                }
                else
                {
                    return result;
                }
            } while (true);
        }

        public static DateTime SetDateTime()
        {
            do
            {
                try
                {
                    DateTime new_dateTime = new DateTime(
                        year: InputValueDateTime("Год"),
                        month: InputValueDateTime("Месяц"),
                        day: InputValueDateTime("День"),
                        hour: InputValueDateTime("Час"),
                        minute: InputValueDateTime("Минут"),
                        second: InputValueDateTime("Секунд")
                        );

                    return new_dateTime;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Не верно введена дата, {ex.Message} повторите попытку:");
                }
            } while (true);
        }

        private static int InputValueDateTime(string messeg)
        {            
            while (true)
            {
                try
                {
                    Console.Write($"Ввод {messeg} = ");
                    return Int();
                }
                catch (ArgumentException ex)
                {
                    Console.Write($"{ex.ParamName}, повторите попытку: ");
                }
            }
        }
    }
}
