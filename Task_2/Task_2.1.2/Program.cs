using System;
using System.Collections.Generic;
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
            bool exit = true;
            while (exit)
            {
                multiUser.CommandBar(ref exit);
            }
            Console.WriteLine("Конец программы");
            Console.ReadLine();
        }
    }
}
