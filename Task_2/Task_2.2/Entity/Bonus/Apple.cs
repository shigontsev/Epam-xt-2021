using System;
using Task_2._2.Entity.Person;

namespace Task_2._2.Entity
{
    public class Apple : Bonus
    {
        public Apple(Point point) : base(point)
        {
        }

        public Apple(Point point, int countBonus) : base(point, countBonus)
        {
            
        }

        public override void GetInfo()
        {
            throw new NotImplementedException("Info Characters bonus");
        }

        public override void Print()
        {
            throw new NotImplementedException("Apple");
        }

        public override void TakeBonus(Player player)
        {
            player.Life+= CountBonus;
        }
    }
}
