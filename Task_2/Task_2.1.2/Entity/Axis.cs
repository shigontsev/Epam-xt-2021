using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Axis
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Axis():this(0,0)
        {
            
        }
        public Axis(double x, double y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return new string($"({X};{Y})");
        }
    }
}
