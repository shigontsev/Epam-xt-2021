using System;
using System.Collections.Generic;
using System.Text;
using Task_2._2.Interfaces;

namespace Task_2._2.Entity
{
    public abstract class Enemy : Person
    {
        public Enemy(Point point) : base(point)
        {
        }

        public Enemy(int life, int damage, int step, Point p) : base(life, damage, step, p)
        {
        }

        public override void MoveDown()
        {
            base.MoveDown();
        }

        public override void MoveLeft()
        {
            base.MoveLeft();
        }

        public override void MoveRight()
        {
            base.MoveRight();
        }

        public override void MoveUp()
        {
            base.MoveUp();
        }
    }

    public class Bear : Enemy
    {
        public Bear(Point point) : base(point)
        {
        }

        public Bear(int life, int damage, int step, Point p) : base(life, damage, step, p)
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

    public class Fox : Enemy
    {
        public Fox(Point point) : base(point)
        {
        }

        public Fox(int life, int damage, int step, Point p) : base(life, damage, step, p)
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
