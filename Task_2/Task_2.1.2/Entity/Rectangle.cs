using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Rectangle : Figure
    {
        public double Width { get; private set; }

        public double Height { get; private set; }

        public Rectangle(double width, double height) : this(width, height, new Point())
        {
            
        }

        public Rectangle(double width, double height, Point position) : base(position)
        {
            Width = width;
            Height = height;
        }

        public static Rectangle CreateFigure(double width, double height, Point position)
        {
            if (!isCorrect(width, height))
            {
                Console.WriteLine("Такую фигуру не создать");
                return null;
            }
            return new Rectangle(width, height, position);
        }

        public double Length => 2 * (Width + Height);

        public double Area => Width * Height;

        protected static bool isCorrect(double a, double b)
        {
            return !(a < 0 || b < 0);
        }
        
        public override string ToString()
        {
            return string.Join(Environment.NewLine, "Фигура: Прямоугольник",
                "Центр = ",
                $"Со сторонами A={Width}; B={Height}",
                "Периметр = " + Length,
                "Площадь = " + Area);
        }
    }
}
