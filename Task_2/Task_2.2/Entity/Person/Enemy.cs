using System;

namespace Task_2._2.Entity.Person
{
    public abstract class Enemy : Person
    {
        public Enemy(Point point) : base(point)
        {
        }

        public Enemy(Point p, int life, int damage, int step) : base(p, life, damage, step)
        {
        }

        public override void Attack(Person person)
        {
            var player = person as Player;
            if(player != null)
            {
                player.Life -= Damage;
                throw new NotImplementedException("Attack");
            }
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
}
