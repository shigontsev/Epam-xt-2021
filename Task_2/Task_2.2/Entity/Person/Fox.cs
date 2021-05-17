using System;

namespace Task_2._2.Entity.Person
{
    public class Fox : Enemy
    {
        public Fox(Point point) : base(point)
        {
        }

        public Fox(Point p, int life, int damage, int step) : base(p, life, damage, step)
        {
        }

        public override void GetInfo()
        {
            throw new NotImplementedException("Info Characters person");
        }

        public override void Print()
        {
            throw new NotImplementedException("Fox");
        }
    }
}
