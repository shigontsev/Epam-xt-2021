using System;

namespace Task_3._3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var text = new {
                digital = "2388378289",
                rus = "ЕхалоуХьюман",
                eng = "HelloHuman",
                mixed = "Hello android №085"
            };

            Console.WriteLine(text.digital.GetTypeText());

            Console.WriteLine(text.rus.GetTypeText());

            Console.WriteLine(text.eng.GetTypeText());

            Console.WriteLine(text.mixed.GetTypeText());

            Console.ReadLine();
        }
    }
}
