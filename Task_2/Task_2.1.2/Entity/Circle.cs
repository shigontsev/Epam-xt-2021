using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Circle:Axis, IFigure
    {
        private double radius;
        protected internal double Radius
        {
            get
            {
                return radius;
            }
            set
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
        public double Length
            => 2 * Math.PI * radius;

        public virtual void Info()
        {
            Console.WriteLine("Фигура: Окружность");
            Console.WriteLine("Центр = " + base.ToString());
            Console.WriteLine("Длина = " + Length);
        }
    }
}
