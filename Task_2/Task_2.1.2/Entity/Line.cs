using System;
using System.Collections.Generic;
using System.Text;
using Task_2._1._2.UI;

namespace Task_2._1._2.Entity
{
    public class Line : Figure
    {
        public Point SecondPosition { get; set; }
        
        public Line(Point p1, Point p2)
        {
            Position = p1;
            SecondPosition = p2;
        }

        public static Line CreateFigure(Point p1, Point p2)
        {
            return new Line(p1, p2);
        }

        public double Length => 
            Math.Sqrt(Math.Pow(Position.X - SecondPosition.X, 2)+ Math.Pow(Position.Y - SecondPosition.Y, 2));
        
        public override string ToString()
        {
            return string.Join(Environment.NewLine, "Фигура: Линия",
                $"В точках A={Position.ToString()}; B={SecondPosition.ToString()}",
                $"Длина = {Length}");
        }
    }
}
