using System;

namespace Task_2._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Ring ring = new Ring(5, 10, 2, 2);
            Ring ring = new Ring(5, 10);
            Console.WriteLine($"Расположен в координате ({ring.X};{ring.Y})");
            Console.WriteLine("Длина кольца = " + ring.Length);
            Console.WriteLine("Площадь кольца = " + ring.GetArea);
            Console.WriteLine("Длина круга внешнего = " + ring.outer.Length);
            Console.WriteLine("Площадь круга внешнего = " + ring.outer.GetArea);
            Console.WriteLine("Длина круга внутреннего = " + ring.inner.Length);
            Console.WriteLine("Площадь круга внутреннего = " + ring.inner.GetArea);
            Console.WriteLine();
            Square sq = new Square(5);
            Console.WriteLine("Периметр квадрата = " + sq.Length);
            Console.WriteLine("Площадь квадрата = " + sq.GetArea);
            Console.WriteLine();
            Triangle tr = new Triangle(3, 5, 7);
            Console.WriteLine("Периметр треугольника = " + tr.Length);
            Console.WriteLine("Площадь треугольника = " + tr.GetArea);
            Console.ReadLine();
        }
    }
}
