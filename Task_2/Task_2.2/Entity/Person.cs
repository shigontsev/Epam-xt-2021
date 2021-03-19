using System;
using System.Collections.Generic;
using System.Text;
using Task_2._2.Interfaces;

namespace Task_2._2.Entity
{
    public abstract class Person : GameObject, IMovable
    {
        public int Life { get; set; } = 4;

        public int Damage { get; set; } = 1;

        public int Step { get; set; } = 1;

        public Person(Point point):base(point)
        {

        }

        public Person(int life, int damage, int step, Point p) : base(p)
        {
            Life = life;
            Damage = damage;
            Step = step;
        }

        public abstract void Action();

        public virtual void MoveUp()
        {
            Position.Y += Step;
        }

        public virtual void MoveDown()
        {
            Position.Y -= Step;
        }

        public virtual void MoveLeft()
        {
            Position.X -= Step;
        }

        public virtual void MoveRight()
        {
            Position.X += Step;
        }
    }
}
