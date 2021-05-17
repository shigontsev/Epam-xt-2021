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

        public Ring(double inR, double outR): this(inR, outR, 0, 0)
        {
            
        }

        public Ring(double inR, double outR, double x, double y) : base(x, y)
        {            
            inner = new Round(inR, Position.X, Position.Y);
            outer = new Round(outR, Position.X, Position.Y);
        }

        public static Ring CreateFigure(double inR, double outR, double x, double y)
        {
            while (outR <= inR)
            {
                Console.WriteLine("Не верный внешний Радиус, Повторите Ввод:");
                outR = Input.OuterR();
            }
            return new Ring(inR, outR, x, y);
        }

        public double Area => outer.Area - inner.Area;

        public double Length => outer.Length + inner.Length;

        public override void PrintInfo()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return new string("Фигура: Кольцо" + Environment.NewLine +
                "Центр = " + Position + Environment.NewLine +
                "Внутренний радиус = " + inner.Radius + Environment.NewLine +
                "Внешний радиус = " + outer.Radius + Environment.NewLine +
                "Длина = " + Length + Environment.NewLine +
                "Площадь = " + Area);
        }
    }
}
