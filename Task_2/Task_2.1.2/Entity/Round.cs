using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Round : Circle
    {
        public Round(double r) : base(r)
        {

        }

        public Round(double r, Point position) : base(r, position)
        {

        }

        public new static Round CreateFigure(double r, Point position)
        {
            return new Round(r, position);
        }

        public double Area => Math.PI * Math.Pow(Radius, 2);
        
        public override string ToString()
        {
            return string.Join(Environment.NewLine, "Фигура: Круг",
                "Центр = ",
                "Радиус = ",
                "Длина = " + Length,
                "Площадь = " + Area);
        }
    }
}
