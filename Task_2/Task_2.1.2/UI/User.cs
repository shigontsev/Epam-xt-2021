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
                    Add(); break;
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
        private void Add()
        {
            Console.WriteLine("ВЫВОД: Выберите тип фигуры");
            InfoFigures();
            Console.Write("ВВОД: ");
            FigureType type = ReadType();
            switch (type)
            {
                case FigureType.Line:
                    Console.WriteLine("Выбрана фигура " + type);
                    AddFigure(Line.Enter(Input.X(), Input.Y(), Input.X(), Input.Y())); break;
                    //Figures.Add(Line.Enter(Input.X(), Input.Y(), Input.X(), Input.Y())); ShowLastFigure(); break;
                case FigureType.Circle:
                    Console.WriteLine("Выбрана фигура " + type);
                    AddFigure(Circle.Enter(Input.R(), Input.X(), Input.Y())); break;
                    //Figures.Add(Circle.Enter(Input.R(), Input.X(), Input.Y())); ShowLastFigure(); break;                    
                case FigureType.Round:
                    Console.WriteLine("Выбрана фигура " + type);
                    AddFigure(Round.Enter(Input.R(), Input.X(), Input.Y())); break;
                    //Figures.Add(Round.Enter(Input.R(), Input.X(), Input.Y())); ShowLastFigure(); break;
                case FigureType.Ring:
                    Console.WriteLine("Выбрана фигура " + type);
                    AddFigure(Ring.Enter(Input.InnerR(), Input.OuterR(), Input.X(), Input.Y())); break;
                    //Figures.Add(Ring.Enter(Input.InnerR(), Input.OuterR(), Input.X(), Input.Y())); ShowLastFigure(); break;
                case FigureType.Rectangle:
                    Console.WriteLine("Выбрана фигура " + type);
                    AddFigure(Rectangle.Enter(Input.A(), Input.B(), Input.X(), Input.Y())); break;
                //Figures.Add(Rectangle.Enter(Input.A(), Input.B(), Input.X(), Input.Y())); ShowLastFigure(); break;
                case FigureType.Square:
                    Console.WriteLine("Выбрана фигура " + type);
                    AddFigure(Square.Enter(Input.A(), Input.X(), Input.Y())); break;
                    //Figures.Add(Square.Enter(Input.A(), Input.X(), Input.Y())); ShowLastFigure(); break;
                case FigureType.Triangle:
                    Console.WriteLine("Выбрана фигура " + type);
                    AddFigure(Triangle.Enter(Input.A(), Input.B(), Input.C(), Input.X(), Input.Y())); break;
                    //Figures.Add(Triangle.Enter(Input.A(), Input.B(), Input.C(), Input.X(), Input.Y())); ShowLastFigure(); break;
                default: Console.WriteLine("Не выбрана"); break;
            }
            Console.WriteLine();
        }
        private void AddFigure(object figure)
        {
            var item = figure as IFigure;
            if (item == null)
            {
                Console.WriteLine("Фигура не создана");
                return;
            }
            Figures.Add(item); ShowLastFigure();
        }
        private void ShowAllFigure()
        {
            foreach (var item in Figures)
            {
                item.Info();
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        private void Clear()
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
            Console.WriteLine(Environment.NewLine + "Список фигур");
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
