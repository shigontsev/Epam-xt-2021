using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Rectangle:Axis
    {
        protected internal double Width { get; set; }
        protected internal double Height { get; set; }

        public Rectangle(double width, double height):base()
        {
            Width = width;
            Height = height;
        }
        public Rectangle(double width, double height, double x, double y) : base(x, y)
        {
            Width = width;
            Height = height;
        }
        public double Length
            => 2 * (Width + Height);
        public double GetArea
            => Width * Height;

        protected internal Point[] Points
        {
            get
            {
                Point[] points = new Point[4];
                points[0] = new Point(X - Width / 2, Y - Height / 2);
                points[1] = new Point(X - Width / 2, Y + Height / 2);
                points[2] = new Point(X + Width / 2, Y + Height / 2);
                points[3] = new Point(X + Width / 2, Y - Height / 2);
                return points;
            }
        }
        private string[] PointsString()
        {
            string[] temp = new string[Points.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = Points[i].ToString();
            }
            return temp;
        }
        public string ShowPoints
            => String.Format("{0}", String.Join(", ", PointsString()));

        public void Info()
        {
            Console.WriteLine("Фигура: Прямоугольник");
            Console.WriteLine($"Со сторонами A={Width}; B={Height}");
            Console.WriteLine("Центр: " + base.ToString());
            Console.WriteLine("Расположение точек: " + ShowPoints);
        }
    }
}
