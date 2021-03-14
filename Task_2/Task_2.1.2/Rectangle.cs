﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        //public Rectangle()
        //{

        //}
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public Rectangle(Line width, Line height)
        {
            Width = width.Length;
            Height = height.Length;
        }
        public double Length
            => 2 * (Width + Height);
        public double GetArea
            => Width * Height;
    }
}
