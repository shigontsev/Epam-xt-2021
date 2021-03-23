using System;

namespace Task_3._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("ВЫВОД: Введите N");
            Survivors survive = new Survivors(InputIntValue());
            Console.WriteLine("ВЫВОД: Введите, какой по счету человек будет вычеркнут каждый раунд:");
            survive.Start(InputIntValue());
            Console.ReadLine();
        }
        static int InputIntValue()
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
