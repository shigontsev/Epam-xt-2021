using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._2.Entity
{
    public abstract class Bonus : GameObject
    {
        public Bonus(Point point) : base(point)
        {
        }
    }

    public class Apple : Bonus
    {
        public Apple(Point point) : base(point)
        {
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }
    }

    public class Banana : Bonus
    {
        public Banana(Point point) : base(point)
        {
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }
    }


}
