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
            Console.Write("ВВОД внутренний радиус: ");
            double input = EnterDouble();
            return Math.Abs(input == 0 ? 1 : input);
        }

        public static double OuterR()
        {
            Console.Write("ВВОД внешний радиус: ");
            double input = EnterDouble();
            return Math.Abs(input == 0 ? 1 : input);
        }

        public static double R()
        {
            Console.Write("ВВОД радиус: ");
            double input = EnterDouble();
            return Math.Abs(input == 0?1: input);
        }

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

        public static string EnterString()
        {
            do
            {
                string enter = Console.ReadLine().Trim();
                if (enter != string.Empty)
                    return enter;
                Console.Write("Введено пустое значение, повторите:");
            } while (true);
        }

        private static double EnterDouble()
        {
            do
            {
                if (double.TryParse(EnterString(), out double result))
                    return result;
                Console.Write("Повторите ввод значения: ");
            } while (true);
        }

        public static int EnterInt()
        {
            do
            {
                if (int.TryParse(EnterString(), out int result))
                    return result;
                Console.Write("Повторите ввод значения: ");
            } while (true);
        }
    }
}
