using System;
using System.Collections.Generic;
using System.Text;
using Task_2._2.Interfaces;

namespace Task_2._2.Entity
{
    public abstract class Person : IMovable
    {
        public Point Position { get; set; }

        public void Action()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
