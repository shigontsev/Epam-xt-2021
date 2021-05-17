using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public abstract class Figure : IFigure, IShowable 
    {
        public Point Position { get; set; }

        public Figure() : this(new Point())
        {

        }

        public Figure(Point position)
        {
            //Position.X = x;
            //Position.Y = y;
            Position = position;
        }

        public void ShowInfo()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
