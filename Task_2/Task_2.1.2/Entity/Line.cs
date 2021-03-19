using System;
using System.Collections.Generic;
using System.Text;
using Task_2._1._2.UI;

namespace Task_2._1._2.Entity
{
    public class Line: IFigure
    {
        public Point P1 { get; set; }

        public Point P2 { get; set; }

        //public Point P1;
        //public Point P2;

        public Line(double x1, double y1, double x2, double y2):this(new Point(x1,y1), new Point(x2, y2))
        {

        }

        public Line(Point p1, Point p2)
        {
            P1 = p1; P2 = p2;
        }

        public static Line CreateFigure(double x1, double y1, double x2, double y2)
        {
            return new Line(x1, y1, x2, y2);
        }

        public double Length => Math.Sqrt(Math.Pow(P1.X - P2.X, 2)+ Math.Pow(P1.Y - P2.Y, 2));

        public virtual void PrintInfo()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return new string("Фигура: Линия"+ Environment.NewLine+
                $"В точках A={P1.ToString()}; B={P2.ToString()}"+Environment.NewLine +
                $"Длина = {Length}");
        }
    }
}
