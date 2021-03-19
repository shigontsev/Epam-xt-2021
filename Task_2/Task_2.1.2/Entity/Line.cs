using System;
using System.Collections.Generic;
using System.Text;
using Task_2._1._2.UI;

namespace Task_2._1._2.Entity
{
    public class Line: Figure
    {
        public Point SecondPosition { get; set; }

        public Line(double x1, double y1, double x2, double y2):this(new Point(x1,y1), new Point(x2, y2))
        {

        }

        public Line(Point p1, Point p2)
        {
            Position = p1; SecondPosition = p2;
        }

        public static Line CreateFigure(double x1, double y1, double x2, double y2)
        {
            return new Line(x1, y1, x2, y2);
        }

        public double Length => Math.Sqrt(Math.Pow(Position.X - SecondPosition.X, 2)+ Math.Pow(Position.Y - SecondPosition.Y, 2));

        public override void PrintInfo()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return new string("Фигура: Линия"+ Environment.NewLine+
                $"В точках A={Position.ToString()}; B={SecondPosition.ToString()}"+Environment.NewLine +
                $"Длина = {Length}");
        }
    }
}
