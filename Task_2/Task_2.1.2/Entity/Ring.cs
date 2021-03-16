using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Ring : Axis, IFigure
    {
        protected internal Round inner;
        protected internal Round outer;
        public Ring(double inR, double outR): this(inR, outR, 0, 0)
        {
            //inner = new Round(inR);
            //outer = new Round(outR);
        }
        public Ring(double inR, double outR, double x, double y) : base(x, y)
        {
            inner = new Round(inR, X, Y);
            outer = new Round(outR, X, Y);
        }
        public double GetArea
            => outer.GetArea - inner.GetArea;
        public double Length
            => outer.Length + inner.Length;

        public virtual void Info()
        {
            Console.WriteLine("Фигура: Кольцо");
            Console.WriteLine("Центр = " + base.ToString());
            Console.WriteLine("Внутренний радиус = " + inner.Length);
            Console.WriteLine("Внешний радиус = " + outer.Length);
            Console.WriteLine("Длина = " + Length);
            Console.WriteLine("Площадь = " + GetArea);
        }
    }
}
