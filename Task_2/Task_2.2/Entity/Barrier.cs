using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._2.Entity
{
    public abstract class Barrier : GameObject
    {
        public Barrier(Point point) : base(point)
        {
        }
    }

    public class Tree : Barrier
    {
        public Tree(Point point) : base(point)
        {
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }
    }

    public class Stone : Barrier
    {
        public Stone(Point point) : base(point)
        {
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }
    }
}
