using System;
using Task_2._1._2.Entity;
using Task_2._1._2.UI;

namespace Task_2._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!"+Environment.NewLine);

            MainMenu multiUser = new MainMenu();
            bool boolen = true;
            while (boolen)
            {
                multiUser.CommandBar(ref boolen);
            }
            Console.WriteLine("Конец программы");
            Console.ReadLine();
        }
    }
}
