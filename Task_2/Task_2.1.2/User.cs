using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_2._1._2.Entity;

namespace Task_2._1._2
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

        public void AddFigure()
        {
            FigureType type = ReadType();
            switch (type)
            {
                case FigureType.Line: Figures.Add(new Line(0, 2, 5, 5)); ShowLastFigure(); break;
                case FigureType.Circle: Figures.Add(new Circle(10, 0, -1)); ShowLastFigure(); break;
                case FigureType.Round: Figures.Add(new Round(6, 1, 1)); ShowLastFigure(); break;
                case FigureType.Ring: Figures.Add(new Ring(5, 10, 0, 0)); ShowLastFigure(); break;
                case FigureType.Rectangle: Figures.Add(new Rectangle(5, 2, 3, 1)); ShowLastFigure(); break;
                case FigureType.Square: Figures.Add(new Square(5, 0, 0)); ShowLastFigure(); break;
                case FigureType.Triangle: Figures.Add(new Triangle(3, 5, 7, 0, 0)); ShowLastFigure(); break;
                default:Console.WriteLine("Не выбран"); break;
        }
    }
        public static FigureType ReadType()
        {
            do
            {
                string value = Console.ReadLine();
                if (Enum.TryParse<FigureType>(value, out FigureType result))
                    return result;

            } while (true);
        }

        public void ShowAllFigure()
        {
            foreach (var item in Figures)
            {
                item.Info();
            }
        }
        public void ShowLastFigure()
        {
            Figures.Last().Info();
        }

        public void Clear()
        {
            Figures.Clear();
        }        
    }
    public enum FigureType
    {
        None,
        Line,
        Circle,
        Round,
        Ring,
        Rectangle,
        Square,
        Triangle
    }
}
