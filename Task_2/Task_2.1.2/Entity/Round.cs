using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Round : Circle
    {
        public Round(double r):base(r)
        {

        }

        public Round(double r, double x, double y):base(r, x, y)
        {

        }

        public new static Round CreateFigure(double r, double x, double y)
        {
            return new Round(r, x, y);
        }

        public double Area => Math.PI * Math.Pow(Radius, 2);

        public override void PrintInfo()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return new string("Фигура: Круг" + Environment.NewLine+
                "Центр = " + Position +Environment.NewLine+
                "Радиус = " + Radius + Environment.NewLine +
                "Длина = " + Length + Environment.NewLine +
                "Площадь = " + Area);
        }
    }
}
