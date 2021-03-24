using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1._1
{
    public static class Input
    {
        public static int InputIntValue()
        {
            do
            {
                Console.Write("ВВОД: ");
                try
                {
                    int result = int.Parse(Console.ReadLine());
                    if (result < 0)
                    {
                        throw new ArgumentNegativeException();
                    }
                    if (result == 0)
                    {
                        throw new ArgumentZeroException();
                    }
                    return result;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Не верный формат ввода, повторите попытку.");
                }
                catch (ArgumentZeroException)
                {
                    Console.WriteLine("Нулевое значение ввода, повторите попытку.");
                }
                catch (ArgumentNegativeException)
                {
                    Console.WriteLine("Отрицательное значение, повторите попытку.");
                }
            } while (true);
        }
    }
}
