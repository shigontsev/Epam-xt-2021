using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Rectangle:Figure
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public Rectangle(double width, double height):this(width, height, 0, 0)
        {
            
        }

        public Rectangle(double width, double height, double x, double y) : base(x, y)
        {
            Width = width;
            Height = height;
        }

        public static Rectangle CreateFigure(double width, double height, double x, double y)
        {
            if (!isCorrect(width, height))
            {
                Console.WriteLine("Такую фигуру не создать");
                return null;
            }
            return new Rectangle(width, height, x, y);
        }

        public double Length => 2 * (Width + Height);

        public double Area => Width * Height;

        protected static bool isCorrect(double a, double b)
        {
            return !(a < 0 || b < 0);
        }

        public override void PrintInfo()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return new string("Фигура: Прямоугольник" + Environment.NewLine +
                "Центр = " + Position + Environment.NewLine +
                $"Со сторонами A={Width}; B={Height}" + Environment.NewLine +
                "Периметр = " + Length + Environment.NewLine +
                "Площадь = " + Area);
        }
    }
}
