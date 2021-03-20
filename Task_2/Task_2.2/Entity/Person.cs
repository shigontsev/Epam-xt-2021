using System;
using System.Collections.Generic;
using System.Text;
using Task_2._2.Interfaces;

namespace Task_2._2.Entity
{
    public abstract class Person : GameObject, IMovable, IDamageable, IInfo
    {
        private int life = 4;

        public int Life
        {
            get { return life; }
            set { life = value < 0? 0: value; }
        }

        private int damage = 1;

        public int Damage
        {
            get { return damage; }
            set { damage = value < 0 ? 0 : value; }
        }

        private int step = 1;

        public int Step
        {
            get { return step; }
            set { step = value < 0 ? 0 : value; }
        }

        //public int Life { get; set; } = 4;

        //public int Damage { get; set; } = 1;

        //public int Step { get; set; } = 1;

        public Person(Point point):base(point)
        {

        }

        public Person(Point p, int life, int damage, int step) : base(p)
        {
            Life = life;
            Damage = damage;
            Step = step;
        }

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

        public abstract void Attack(Person person);
        public abstract void GetInfo();
    }
}
