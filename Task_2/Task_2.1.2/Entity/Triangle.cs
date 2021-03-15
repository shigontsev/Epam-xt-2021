using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Triangle:Axis
    {
        protected internal double A { get; set; }
        protected internal double B { get; set; }
        protected internal double C { get; set; }
        
        public Triangle(double a, double b, double c) : base()
        {
            if (!isTriangle(a, b, c) || isCorrect(a, b, c))
            {
                Console.WriteLine("Такую фигуру не создать");
                return;
            }
            A = a;
            B = b;
            C = c;
        }
        public Triangle(double a, double b, double c, double x, double y):base(x, y)
        {
            if (!isTriangle(a, b, c) || isCorrect(a, b, c))
            {
                Console.WriteLine("Такую фигуру не создать");
                return;
            }
            A = a;
            B = b;
            C = c;
            //if (!isTriangle)
            //    throw new Exception("Sides of triangle can` t be connect");
        }
        //public Triangle(Line a, Line b, Line c)
        //{
        //    isCorrect(a.Length, b.Length, c.Length);
        //    A = a.Length;
        //    B = b.Length;
        //    C = c.Length;
        //    if (!isTriangle)
        //        throw new Exception("Sides of triangle can` t be connect");

        //}
        private bool isCorrect(double a, double b, double c)
        {
            return (a < 0 || b < 0 || c < 0);
        }
        private bool isTriangle(double a, double b, double c)
        {
            return (a + b > c && a + c > b && b + c > a);
        }
        //static void isCorrectPoint(Line a, Line b, Line c)
        //{
        //    if (PointEquals(a.P1, b.P1))
        //    {

        //    }
        //}
        //static bool PointEquals(Point a, Point b)
        //=> a.X == b.X && a.Y == b.Y;
        public double Length
            => A + B + C;
        private double LengthHalf
            => Length / 2;
        //Формула Герона
        public double GetArea
            => Math.Sqrt(LengthHalf * (LengthHalf - A) * (LengthHalf - B) * (LengthHalf - C));
        public void Info()
        {
            Console.WriteLine("Фигура: Треугольник");
            Console.WriteLine($"Со сторонами A={A}; B={B}; C={C}");
            Console.WriteLine("Центр: " + base.ToString());
        }
    }
}
