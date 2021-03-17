using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.UI
{
    public static class Input
    {
        public static string Name()
        {
            Console.Write("ВВОД имя: ");
            return EnterString();
        }
        public static double X()
        {
            Console.Write("ВВОД координату X: ");
            return EnterDouble();
        }
        public static double Y()
        {
            Console.Write("ВВОД координату Y: ");
            return EnterDouble();
        }
        public static double InnerR()
        {
            double d = 0;
            do
            {
                Console.Write("ВВОД внутренний радиус: ");
                d = EnterDouble();
            } while (d<=0);
            return d;
        }
        public static double OuterR()
        {
            double d = 0;
            do
            {
                Console.Write("ВВОД внешний радиус: ");
                d = EnterDouble();
            } while (d <= 0);
            return d;
        }
        public static double R()
        {
            Console.Write("ВВОД радиус: ");
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
            Console.Write("ВВОД длину стороны A: ");
            return EnterDouble_Positive();
        }
        public static double B()
        {
            Console.Write("ВВОД длину стороны B: ");
            return EnterDouble_Positive();
        }
        public static double C()
        {
            Console.Write("ВВОД длину стороны C: ");
            return EnterDouble_Positive();
        }
        private static double EnterDouble_Positive()
        {
            double d = EnterDouble();
            while (d<=0)
            {
                Console.Write("Повторите ввод: ");
                d = EnterDouble();
            }
            return d;
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
        public static int EnterInt()
        {
            do
            {
                try
                {
                    return int.Parse(EnterString());
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
