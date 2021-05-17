using System;

namespace Task_2._2.Entity.Barrier
{
    public class Tree : Barrier
    {
        public Tree(Point point) : base(point)
        {
        }

        public override void Print()
        {
            throw new NotImplementedException("Tree");
        }
    }
}
