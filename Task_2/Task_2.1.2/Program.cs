﻿using System;
using Task_2._1._2.Entity;
using Task_2._1._2.UI;

namespace Task_2._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!"+Environment.NewLine);
            ////Ring ring = new Ring(5, 10, 2, 2);
            //Ring ring = new Ring(5, 10);
            //Round round = new Round(6, 1, 1);
            //Circle circle = new Circle(10, 0, -1);
            ////Console.WriteLine($"Расположен в координате ({ring.X};{ring.Y})");
            ////Console.WriteLine("Длина кольца = " + ring.Length);
            ////Console.WriteLine("Площадь кольца = " + ring.GetArea);
            ////Console.WriteLine("Длина круга внешнего = " + ring.outer.Length);
            ////Console.WriteLine("Площадь круга внешнего = " + ring.outer.GetArea);
            ////Console.WriteLine("Длина круга внутреннего = " + ring.inner.Length);
            ////Console.WriteLine("Площадь круга внутреннего = " + ring.inner.GetArea);
            ////Console.WriteLine();
            //Rectangle rct = new Rectangle(5,2, 3, 1);
            //Square sq = new Square(5);
            ////Console.WriteLine("Периметр квадрата = " + sq.Length);
            ////Console.WriteLine("Площадь квадрата = " + sq.GetArea);
            ////Console.WriteLine();
            //Triangle tr = new Triangle(3, 5, 7);
            ////Console.WriteLine("Периметр треугольника = " + tr.Length);
            ////Console.WriteLine("Площадь треугольника = " + tr.GetArea);
            ////Console.WriteLine();
            //Line line = new Line(0, 2, 5, 5);
            //rct.Info();
            //Console.WriteLine();
            //sq.Info();
            //Console.WriteLine();
            //tr.Info();
            //Console.WriteLine();
            //line.Info();
            //Console.WriteLine();
            //ring.Info();
            //Console.WriteLine();
            //round.Info();
            //Console.WriteLine();
            //circle.Info();

            //User user = new User("Yurii");
            //bool boolen = true;
            //while (boolen)
            //{
            //    //user.AddFigure();
            //    user.CommandBar(ref boolen);
            //}

            MultiUser multiUser = new MultiUser();
            bool boolen = true;
            while (boolen)
            {
                multiUser.CommandBar(ref boolen);
            }

            Console.ReadLine();
        }
    }
}
