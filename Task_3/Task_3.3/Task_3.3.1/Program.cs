using System;

namespace Task_3._3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var arr12 = new int[] { 1, 2, 3, 4, 5, 4 };
            var arr12 = new double[] { 1, 2, 3, 4, 5, 4 };
            Console.WriteLine(arr12.Sum());
            Console.WriteLine(arr12.Avg());
            Console.WriteLine(arr12.Franquency());
            arr12.EditArray(x => (double)(x * 3));
            arr12.ShowArray();
            //byte b1 = 255;
            //byte b2 = 5;
            //byte c = (byte)(b1 + b2);
            //Console.WriteLine(c);
            Console.WriteLine("--------------");
            var arr123 = new int[] { int.MaxValue, 1 };
            Console.WriteLine(arr123.Sum());
            Console.WriteLine(arr123.Avg());
            Console.WriteLine(arr123.Franquency());
            //arr123.EditArray(x => ((sbyte)x * 3));
            arr123.ShowArray();
            int aa = int.MinValue;
            Console.WriteLine(aa);
            Console.ReadLine();
        }

    }
}
