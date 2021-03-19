using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._2.Entity
{
    public abstract class GameObject
    {
        public Point Position { get; set; }

        public GameObject(Point point)
        {
            Position = point;
        }

        public abstract void Print();
    }
}
