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
    }
}
