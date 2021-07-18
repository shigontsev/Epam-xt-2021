using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point() : this(0,0)
        {

        }
        public Point(double x, double y)
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
