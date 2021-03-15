using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Triangle
    {
        protected internal double A { get; set; }
        protected internal double B { get; set; }
        protected internal double C { get; set; }
        public bool isTriangle
        {
            get
            {
                if (A + B > C && A + C > B && B + C > A)
                {
                    return true;
                }
                return false;
            }
        }
        public Triangle(double a, double b, double c)
        {
            isCorrect(a, b, c);
            A = a;
            B = b;
            C = c;
            if (!isTriangle)
                throw new Exception("Sides of triangle can` t be connect");
            
        }
        public Triangle(Line a, Line b, Line c)
        {
            isCorrect(a.Length, b.Length, c.Length);
            A = a.Length;
            B = b.Length;
            C = c.Length;
            if (!isTriangle)
                throw new Exception("Sides of triangle can` t be connect");
            
        }
        static void isCorrect(double a, double b, double c)
        {
            if (a < 0 || b < 0 || c < 0)
                throw new Exception("Sides of triangle can` t be negative");
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
    }
}
