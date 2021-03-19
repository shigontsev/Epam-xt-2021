using System;
using System.Collections.Generic;
using System.Text;
using Task_2._2.Interfaces;

namespace Task_2._2.Entity
{
    public class Player : Person
    {
        public Player(Point point) : base(point)
        {
        }

        public Player(int life, int damage, int step, Point p) : base(life, damage, step, p)
        {
        }

        public override void Action()
        {
            throw new NotImplementedException();
        }
        
        public override void Print()
        {
            throw new NotImplementedException();
        }
    }
}
