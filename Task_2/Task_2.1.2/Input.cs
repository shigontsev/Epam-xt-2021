using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public static class Input
    {
        public static string Name()
        {
            Console.Write("Ввести имя: ");
            return EnterString();
        }
        public static double X()
        {
            Console.Write("Ввести координату X: ");
            return EnterDouble();
        }
        public static double Y()
        {
            Console.Write("Ввести координату Y: ");
            return EnterDouble();
        }
        public static double InnerR()
        {
            Console.Write("Ввести внутренний радиус: ");
            return EnterDouble();
        }
        public static double OuterR()
        {
            Console.Write("Ввести внешний радиус: ");
            return EnterDouble();
        }
        public static double R()
        {
            Console.Write("Ввести радиус: ");
            return EnterDouble();
        }
        //public static double Height()
        //{
        //    Console.Write("Ввести длину стороны Height: ");
        //    return EnterDouble();
        //}
        //public static double Width()
        //{
        //    Console.Write("Ввести длину стороны Width: ");
        //    return EnterDouble();
        //}
        public static double A()
        {
            Console.Write("Ввести длину стороны A: ");
            return EnterDouble();
        }
        public static double B()
        {
            Console.Write("Ввести длину стороны B: ");
            return EnterDouble();
        }
        public static double C()
        {
            Console.Write("Ввести длину стороны C: ");
            return EnterDouble();
        }

        //public static string SecondName
        //{
        //    get { Console.Write("Ввести фамилию"); return Enter(); }
        //}
        public static string EnterString()
            => Console.ReadLine();
        private static double EnterDouble()
        {
            do
            {
                try
                {
                    return double.Parse(EnterString());
                }
                catch (Exception)
                {
                    Console.Write("Повторите ввод значения: ");
                }
            } while (true);
        }
        //private static double EnterDouble()
        //    => Double.Parse(EnterString());
    }
}
