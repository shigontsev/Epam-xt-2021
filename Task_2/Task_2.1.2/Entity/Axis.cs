using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Axis
    {
        protected internal double X { get; set; }
        protected internal double Y { get; set; }
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
