using System;
using System.Collections.Generic;
using System.Text;
using Task_2._1._2.UI;

namespace Task_2._1._2.Entity
{
    public class Ring : Axis, IFigure
    {
        public Round inner;
        public Round outer;
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
        public static Ring Enter(double inR, double outR, double x, double y)
        {
            while (outR <= inR)
            {
                Console.WriteLine("Не верный внешний Радиус, Повторите Ввод:");
                outR = Input.OuterR();
            }
            return new Ring(inR, outR, x, y);
        }
        public double GetArea
            => outer.GetArea - inner.GetArea;
        public double Length
            => outer.Length + inner.Length;

        public virtual void Info()
        {
            Console.WriteLine("Фигура: Кольцо");
            Console.WriteLine("Центр = " + base.ToString());
            Console.WriteLine("Внутренний радиус = " + inner.Radius);
            Console.WriteLine("Внешний радиус = " + outer.Radius);
            Console.WriteLine("Длина = " + Length);
            Console.WriteLine("Площадь = " + GetArea);
        }
    }
}
