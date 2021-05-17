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

        public Square(double side, Point position) : base(side, side, position)
        {

        }

        public static Square CreateFigure(double side, Point position)
        {
            if (!isCorrect(side, side))
            {
                Console.WriteLine("Такую фигуру не создать");
                return null;
            }
            return new Square(side, position);
        }
        
        public override string ToString()
        {
            return string.Join(Environment.NewLine, "Фигура: Квадрат",
                "Центр = " + Position,
                $"Со стороной A={Width}",
                "Периметр = " + Length,
                "Площадь = " + Area);
        }
    }
}
