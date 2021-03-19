using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Circle:Figure
    {
        private double radius;

        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value == 1)
                    value = 1;
                //{ throw new ArgumentException(" Wrong! "); }
                radius = Math.Abs(value);
            }
        }

        public Circle():this(1)
        {
        }

        public Circle(double r):this(r, 0, 0)
        {

        }

        public Circle(double r, double x, double y):base(x, y)
        {
            Radius = r;
        }

        public static Circle CreateFigure(double r, double x, double y)
        {
            return new Circle(r, x, y);
        }

        public double Length => 2 * Math.PI * radius;

        public override void PrintInfo()
        {
            Console.WriteLine(this.ToString());
        }
        public override string ToString()
        {
            return new string("Фигура: Окружность"+Environment.NewLine+
                "Центр = " + Position + Environment.NewLine +
                "Радиус = " + Radius + Environment.NewLine +
                "Длина = " + Length);
        }
    }
}
