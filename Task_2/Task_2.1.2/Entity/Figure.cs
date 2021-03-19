using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public abstract class Figure:IFigure
    {
        public Point Position { get; set; }

        public Figure() : this(0, 0)
        {

        }

        public Figure(double x, double y)
        {
            //Position.X = x;
            //Position.Y = y;
            Position = new Point(x, y);
        }

        public abstract void PrintInfo();
    }
}
