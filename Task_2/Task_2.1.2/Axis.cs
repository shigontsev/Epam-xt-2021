using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public class Axis
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Axis():this(0,0)
        {
            
        }
        public Axis(double x, double y)
        {
            X = x;
            Y = y;
        }

    }
}
