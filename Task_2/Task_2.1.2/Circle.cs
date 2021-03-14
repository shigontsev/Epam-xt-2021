using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public class Circle:Axis
    {
        private double radius;
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value < 1)
                    value = 1;
                //{ throw new ArgumentException(" Wrong! "); }
                radius = value;
            }
        }
        //public Circle()
        //{
        //    X = 0;
        //    Y = 0;
        //    //Radius = 0;
        //}
        public Circle():this(1)
        {
        }
        public Circle(double r):base()
        {
            Radius = r;
        }
        public Circle(double r, double x, double y):base(x, y)
        {
            Radius = r;
        }
        public double Length
            => 2 * Math.PI * radius;
    }
}
