using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Round : Circle, IFigure
    {
        public Round(double r):base(r)
        {

        }
        public Round(double r, double x, double y):base(r, x, y)
        {

        }
        public new static Round Enter(double r, double x, double y)
        {
            return new Round(r, x, y);
        }
        public double GetArea
            => Math.PI * Radius * Radius;
        public override void Info()
        {
            Console.WriteLine("Фигура: Круг");
            Console.WriteLine("Центр = " + base.ToString());
            Console.WriteLine("Радиус = " + Radius);
            Console.WriteLine("Длина = " + Length);
            Console.WriteLine("Площадь = " + GetArea);
        }
    }
}
