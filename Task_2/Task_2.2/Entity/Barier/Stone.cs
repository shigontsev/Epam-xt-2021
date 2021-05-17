using System;

namespace Task_2._2.Entity.Barrier
{
    public class Stone : Barrier
    {
        public Stone(Point point) : base(point)
        {
        }

        public override void Print()
        {
            throw new NotImplementedException("Stone");
        }
    }
}
