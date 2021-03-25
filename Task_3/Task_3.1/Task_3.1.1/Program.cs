using System;

namespace Task_3._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("ВЫВОД: Введите N человек");
            Survivors survive = new Survivors(Input.InputIntValue());
            Console.WriteLine("ВЫВОД: Введите, какой по счету человек будет вычеркнут каждый раунд:");
            survive.Start(Input.InputIntValue());
            Console.ReadLine();
        }
    }
}
