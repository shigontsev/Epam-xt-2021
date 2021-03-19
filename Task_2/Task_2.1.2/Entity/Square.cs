using System;
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

        public static Square CreateFigure(double side, double x, double y)
        {
            if (!isCorrect(side, side))
            {
                Console.WriteLine("Такую фигуру не создать");
                return null;
            }
            return new Square(side, x, y);
        }

        public override void PrintInfo()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return new string("Фигура: Квадрат" + Environment.NewLine +
                "Центр = " + Position + Environment.NewLine +
                $"Со стороной A={Width}" + Environment.NewLine +
                "Периметр = " + Length + Environment.NewLine +
                "Площадь = " + Area);
        }
    }
}
