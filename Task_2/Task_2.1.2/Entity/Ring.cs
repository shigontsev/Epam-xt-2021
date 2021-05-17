using System;
using System.Collections.Generic;
using System.Text;
using Task_2._1._2.UI;

namespace Task_2._1._2.Entity
{
    public class Ring : Figure
    {
        public Round inner { get; set; }

        public Round outer { get; set; }

        public Ring(double inR, double outR): this(inR, outR, new Point())
        {
            
        }

        public Ring(double inR, double outR, Point position) : base(position)
        {            
            inner = new Round(inR, Position);
            outer = new Round(outR, Position);
        }

        public static Ring CreateFigure(double inR, double outR, Point position)
        {
            while (outR <= inR)
            {
                Console.WriteLine("Не верный внешний Радиус, Повторите Ввод:");
                outR = Input.OuterR();
            }
            return new Ring(inR, outR, position);
        }

        public double Area => outer.Area - inner.Area;

        public double Length => outer.Length + inner.Length;

        public override string ToString()
        {
            return string.Join(Environment.NewLine, "Фигура: Кольцо",
                "Центр = " + Position,
                "Внутренний радиус = " + inner.Radius,
                "Внешний радиус = " + outer.Radius,
                "Длина = " + Length,
                "Площадь = " + Area);
        }
    }
}
