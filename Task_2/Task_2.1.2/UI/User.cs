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

        public List<Figure> Figures { get; private set; }

        public User(string name)
        {
            Name = name;
            Figures = new List<Figure>();
        }
        
        public override string ToString()
        {
            return String.Format(Name);
        }
    }
}
