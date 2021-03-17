using System;
using System.Collections.Generic;
using System.Text;
using Task_2._1._2.UI;

namespace Task_2._1._2.Entity
{
    public class Line: IFigure
    {
        private Point P1;
        private Point P2;
        public Line(double x1, double y1, double x2, double y2):this(new Point(x1,y1), new Point(x2, y2))
        {

        }
        public Line(Point p1, Point p2)
        {
            P1 = p1; P2 = p2;
        }
        public static Line Enter(double x1, double y1, double x2, double y2)
        {
            //if (x1==x2 && y1==y2)
            //{
            //    Console.WriteLine("Координаты в одной точке, повторите ввод:");
            //    return Line.Enter(Input.X(), Input.Y(), Input.X(), Input.Y());
            //}
            return new Line(x1, y1, x2, y2);
        }
        public double Length
            => Math.Sqrt(Sqr(P1.X-P2.X)+Sqr(P1.Y-P2.Y));
        private double Sqr(double a)
            => a * a;
        public virtual void Info()
        {
            Console.WriteLine("Фигура: Линия");
            Console.WriteLine($"В точках A={P1.ToString()}; B={P2.ToString()}");
            Console.WriteLine("Длина = " + Length);
        }
    }
}
