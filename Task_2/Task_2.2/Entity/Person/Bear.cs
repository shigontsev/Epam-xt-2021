using System;

namespace Task_2._2.Entity.Person
{
    public class Bear : Enemy
    {
        public Bear(Point point) : base(point)
        {
        }

        public Bear(Point p, int life, int damage, int step) : base(p, life, damage, step)
        {
        }

        public override void GetInfo()
        {
            throw new NotImplementedException("Info Characters person");
        }

        public override void Print()
        {
            throw new NotImplementedException("Bear");
        }
    }
}
