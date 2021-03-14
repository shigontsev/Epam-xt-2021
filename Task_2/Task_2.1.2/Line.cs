﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public class Line
    {
        public Point P1;
        public Point P2;
        public Line(double x1, double y1, double x2, double y2):this(new Point(x1,y1), new Point(x2, y2))
        {

        }
        public Line(Point p1, Point p2)
        {
            P1 = p1; P2 = p2;
        }
        public double Length
            => Math.Sqrt(Sqr(P1.X-P2.X)+Sqr(P1.Y-P2.Y));
        private double Sqr(double a)
            => a * a;
    }
}
