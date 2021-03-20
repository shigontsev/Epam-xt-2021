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

        public Player(Point p, int life, int damage, int step) : base(p, life, damage, step)
        {
        }

        public override void Attack(Person person)
        {
            var enemy = person as Enemy;
            if (enemy != null)
            {
                enemy.Life -= Damage;
                throw new NotImplementedException("Attack");
            }
        }

        public override void GetInfo()
        {
            throw new NotImplementedException("Info Characters person");
        }

        public override void Print()
        {
            throw new NotImplementedException("Player");
        }
    }
}
