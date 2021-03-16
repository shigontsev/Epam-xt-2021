using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_2._1._2.Entity;

namespace Task_2._1._2.UI
{
    public class User
    {
        public string Name { get; private set; }
        private List<IFigure> Figures;
        public User(string name)
        {
            Name = name;
            Figures = new List<IFigure>();
        }
        public void CommandBar(ref bool boolen)
        {
            Console.WriteLine("ВЫВОД: Выберите действие");
            Console.WriteLine("1. Добавить фигуру");
            Console.WriteLine("2. Вывести фигуры");
            Console.WriteLine("3. Очистить холст");
            Console.WriteLine("4. Выход");
            Console.Write("ВВОД: ");
            switch (Input.EnterString())
            {
                case "1":
                    AddFigure(); break;
                case "2":
                    ShowAllFigure(); break;
                case "3":
                    Clear(); break;
                case "4":
                    boolen = false;
                    break;
                default:
                    break;
            }
            Console.WriteLine();
        }
        public void AddFigure()
        {
            Console.WriteLine("ВЫВОД: Выберите тип фигуры");
            InfoFigures();
            Console.Write("ВВОД: ");
            FigureType type = ReadType();
            switch (type)
            {
                //case FigureType.Line: Figures.Add(new Line(0, 2, 5, 5)); ShowLastFigure(); break;
                //case FigureType.Circle: Figures.Add(new Circle(10, 0, -1)); ShowLastFigure(); break;
                //case FigureType.Round: Figures.Add(new Round(6, 1, 1)); ShowLastFigure(); break;
                //case FigureType.Ring: Figures.Add(new Ring(5, 10, 0, 0)); ShowLastFigure(); break;
                //case FigureType.Rectangle: Figures.Add(new Rectangle(5, 2, 3, 1)); ShowLastFigure(); break;
                //case FigureType.Square: Figures.Add(new Square(5, 0, 0)); ShowLastFigure(); break;
                //case FigureType.Triangle: Figures.Add(new Triangle(3, 5, 7, 0, 0)); ShowLastFigure(); break;
                case FigureType.Line:
                    Console.WriteLine("Выбрана фигура " + type);
                    Figures.Add(new Line(Input.X(), Input.Y(), Input.X(), Input.Y())); ShowLastFigure(); break;
                case FigureType.Circle:
                    Console.WriteLine("Выбрана фигура " + type);
                    Figures.Add(new Circle(Input.R(), Input.X(), Input.Y())); ShowLastFigure(); break;
                case FigureType.Round:
                    Console.WriteLine("Выбрана фигура " + type);
                    Figures.Add(new Round(Input.R(), Input.X(), Input.Y())); ShowLastFigure(); break;
                case FigureType.Ring:
                    Console.WriteLine("Выбрана фигура " + type);
                    Figures.Add(new Ring(Input.InnerR(), Input.OuterR(), Input.X(), Input.Y())); ShowLastFigure(); break;
                case FigureType.Rectangle:
                    Console.WriteLine("Выбрана фигура " + type);
                    Figures.Add(new Rectangle(Input.A(), Input.B(), Input.X(), Input.Y())); ShowLastFigure(); break;
                case FigureType.Square:
                    Console.WriteLine("Выбрана фигура " + type);
                    Figures.Add(new Square(Input.A(), Input.X(), Input.Y())); ShowLastFigure(); break;
                case FigureType.Triangle:
                    Console.WriteLine("Выбрана фигура " + type);
                    Figures.Add(new Triangle(Input.A(), Input.B(), Input.C(), Input.X(), Input.Y())); ShowLastFigure(); break;
                default: Console.WriteLine("Не выбрана"); break;
            }
            Console.WriteLine();
        }
        public void ShowAllFigure()
        {
            foreach (var item in Figures)
            {
                item.Info();
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void Clear()
        {
            Figures.Clear();
            Console.WriteLine();
        }
        //public void ToChooseFigure()
        //{
        //    while (true)
        //    {
        //        AddFigure();
        //    }
        //}
        private void InfoFigures()
        {
            var valuesAsArray = Enum.GetValues(typeof(FigureType));
            foreach (var item in valuesAsArray)
            {
                Console.WriteLine($"{(int)item}: {item}");
            }
            Console.WriteLine();
        }
        private static FigureType ReadType()
        {
            do
            {
                string value = Console.ReadLine();
                if (Enum.TryParse(value, out FigureType result))
                    return result;

            } while (true);
        }

        
        private void ShowLastFigure()
        {
            Figures.Last().Info();
        }

        
        public override string ToString()
        {
            return String.Format(Name);
            //return String.Format("Пользователь: " + Name);
        }
    }
    enum FigureType
    {
        //None,
        Line = 1,
        Circle,
        Round,
        Ring,
        Rectangle,
        Square,
        Triangle
    }
}
