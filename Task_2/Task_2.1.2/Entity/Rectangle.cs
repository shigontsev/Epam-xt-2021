using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Rectangle:Axis, IFigure
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Rectangle(double width, double height):this(width, height, 0, 0)
        {
            //Width = width;
            //Height = height;
        }
        public Rectangle(double width, double height, double x, double y) : base(x, y)
        {
            //if (isCorrect(width, height))
            //{
            //    Console.WriteLine("Такую фигуру не создать");
            //    return;
            //}
            Width = width;
            Height = height;
        }
        public static Rectangle Enter(double width, double height, double x, double y)
        {
            //while (outR <= inR)
            //{
            //    Console.WriteLine("Не верный внешний Радиус, Повторите Ввод:");
            //    outR = Input.OuterR();
            //}
            if (isCorrect(width, height))
            {
                Console.WriteLine("Такую фигуру не создать");
                return null;
            }
            return new Rectangle(width, height, x, y);
        }
        public double Length
            => 2 * (Width + Height);
        public double GetArea
            => Width * Height;

        private static bool isCorrect(double a, double b)
        {
            return (a < 0 || b < 0);
        }

        public virtual void Info()
        {
            Console.WriteLine("Фигура: Прямоугольник");
            Console.WriteLine($"Со сторонами A={Width}; B={Height}");
            Console.WriteLine("Центр: " + base.ToString());
            Console.WriteLine("Периметр = " + Length);
            Console.WriteLine("Площадь = " + GetArea);
        }

        //protected internal Point[] Points
        //{
        //    get
        //    {
        //        Point[] points = new Point[4];
        //        points[0] = new Point(X - Width / 2, Y - Height / 2);
        //        points[1] = new Point(X - Width / 2, Y + Height / 2);
        //        points[2] = new Point(X + Width / 2, Y + Height / 2);
        //        points[3] = new Point(X + Width / 2, Y - Height / 2);
        //        return points;
        //    }
        //}
        //private string[] PointsString()
        //{
        //    string[] temp = new string[Points.Length];
        //    for (int i = 0; i < temp.Length; i++)
        //    {
        //        temp[i] = Points[i].ToString();
        //    }
        //    return temp;
        //}
        //public string ShowPoints
        //    => String.Format("{0}", String.Join(", ", PointsString()));
        //public void Info()
        //{
        //    Console.WriteLine("Фигура: Прямоугольник");
        //    Console.WriteLine($"Со сторонами A={Width}; B={Height}");
        //    Console.WriteLine("Центр: " + base.ToString());
        //    Console.WriteLine("Расположение точек: " + ShowPoints);
        //}
    }
}
