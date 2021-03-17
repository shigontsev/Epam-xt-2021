using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Circle:Axis, IFigure
    {
        private double radius;
        public double Radius
        {
            get
            {
                return radius;
            }
            private set
            {
                if (value < 1)
                    value = 1;
                //{ throw new ArgumentException(" Wrong! "); }
                radius = value;
            }
        }
        public Circle():this(1)
        {
        }
        public Circle(double r):base()
        {
            Radius = r;
        }
        public Circle(double r, double x, double y):base(x, y)
        {
            Radius = r;
        }
        public static Circle Enter(double r, double x, double y)
        {
            return new Circle(r, x, y);
        }
        public double Length
            => 2 * Math.PI * radius;

        public virtual void Info()
        {
            Console.WriteLine("Фигура: Окружность");
            Console.WriteLine("Центр = " + base.ToString());
            Console.WriteLine("Радиус = " + Radius);
            Console.WriteLine("Длина = " + Length);
        }
    }
}
