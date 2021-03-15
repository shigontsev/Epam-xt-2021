using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Ring : Axis
    {
        public Round inner;
        public Round outer;
        public Ring(double inR, double outR): base()
        {
            inner = new Round(inR);
            outer = new Round(outR);
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
    }
}
