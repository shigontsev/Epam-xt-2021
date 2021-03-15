using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Round : Circle
    {
        public Round(double r):base(r)
        {

        }
        public Round(double r, double x, double y):base(r, x, y)
        {

        }
        public double GetArea
            => Math.PI * Radius * Radius;
    }
}
