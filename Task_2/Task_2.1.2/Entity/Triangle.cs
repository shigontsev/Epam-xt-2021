using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Triangle : Figure
    {
        public double A { get; set; }

        public double B { get; set; }

        public double C { get; set; }
        
        public Triangle(double a, double b, double c) : this(a, b, c, new Point())
        {
           
        }
        public Triangle(double a, double b, double c, Point position) : base(position)
        {            
            A = a;
            B = b;
            C = c;            
        }
        public static Triangle CreateFigure(double a, double b, double c, Point position)
        {
            if(!isTriangle(a, b, c) || !isCorrect(a, b, c))
            {
                Console.WriteLine("Такую фигуру не создать");
                return null;
            }
            return new Triangle(a, b, c, position);
        }

        private static bool isCorrect(double a, double b, double c)
        {
            return !(a < 0 || b < 0 || c < 0);
        }

        private static bool isTriangle(double a, double b, double c)
        {
            return (a + b > c && a + c > b && b + c > a);
        }
        
        public double Length => A + B + C;

        private double LengthHalf => Length / 2;

        //Формула Герона
        public double Area => 
            Math.Sqrt(LengthHalf * (LengthHalf - A) * (LengthHalf - B) * (LengthHalf - C));
        
        public override string ToString()
        {
            return string.Join(Environment.NewLine, "Фигура: Треугольник",
                "Центр = " + Position,
                $"Со сторонами A={A}; B={B}; C={C}",
                "Периметр = " + Length,
                "Площадь = " + Area);
        }
    }
}
