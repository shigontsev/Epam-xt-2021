using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._2.Entity
{
    public class EmptySpace : GameObject
    {
        public EmptySpace(Point point) : base(point)
        {
        }

        public override void Print()
        {
            throw new NotImplementedException("Empty Space");
        }
    }
}
