using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2.Entity
{
    public class Square : Rectangle, IFigure
    {
        public Square(double side):base(side, side)
        {

        }
        public Square(double side, double x, double y) : base(side, side, x, y)
        {

        }
        public static Square Enter(double side, double x, double y)
        {
            return new Square(side, x, y);
        }
        //public Square(Line side):base(side,side)
        //{

        //}
        public override void Info()
        {
            Console.WriteLine("Фигура: Квадрат");
            Console.WriteLine($"Со стороной A={Width}");
            Console.WriteLine("Центр: " + base.ToString());
            Console.WriteLine("Периметр = " + Length);
            Console.WriteLine("Площадь = " + GetArea);
        }
    }
}
