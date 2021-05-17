using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Circle : Figure
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
                if (value == 0)
                    value = 1;
                radius = Math.Abs(value);
            }
        }

        public Circle() : this(1)
        {
        }

        public Circle(double r) : this(r, new Point())
        {

        }

        public Circle(double r, Point position) : base(position)
        {
            Radius = r;
        }

        public static Circle CreateFigure(double r, Point position)
        {
            return new Circle(r, position);
        }

        public double Length => 2 * Math.PI * radius;

        public override string ToString()
        {
            return string.Join(Environment.NewLine, "Фигура: Окружность",
                "Центр = " + Position,
                "Радиус = " + Radius,
                "Длина = " + Length);
        }
    }
}
