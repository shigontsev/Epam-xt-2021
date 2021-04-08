using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._3._3.Entity
{
    public class Pizza
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            private set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(Name) + " is null");
                }
                value = value.Trim();
                if (value == string.Empty)
                {
                    throw new ArgumentException(nameof(Name) + " is Empty");
                }

                _name = value; 
            }
        }

        private int _timeCook;

        public int TimeCook
        {
            get { return _timeCook; }
            private set 
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(TimeCook) + " < 1");
                }

                _timeCook = value; 
            }
        }


        public Pizza(string name, int timeCook)
        {
            Name = name;
            TimeCook = timeCook;
        }

        public override string ToString()
        {
            return string.Format($"{Name} :  time cooking {TimeCook} minutes");
        }
    }
}
