﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Square : Rectangle
    {
        public Square(double side):base(side, side)
        {

        }
        public Square(double side, double x, double y) : base(side, side, x, y)
        {

        }
        //public Square(Line side):base(side,side)
        //{
            
        //}
    }
}
