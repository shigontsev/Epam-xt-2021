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
    //public class Round : Axis
    //{
    //    private double radius;
    //    public double Radius
    //    {
    //        get
    //        {
    //            return radius;
    //        }
    //        set
    //        {
    //            if (value <= 0)
    //            { throw new ArgumentException(" Wrong! "); }
    //            radius = value;
    //        }
    //    }
    //    public Round(double r)
    //    {
    //        X = 0;
    //        Y = 0;
    //        Radius = r;
    //    }
    //    public Round(double x, double y, double r)
    //    {
    //        X = x;
    //        Y = y;
    //        Radius = r;
    //    }
    //    public double Length
    //        => 2 * Math.PI * radius;
    //    public double GetArea 
    //        => Math.PI * radius * radius;
    //}
}
