using System;
using Task_2._2.Entity.Person;

namespace Task_2._2.Entity
{
    public class Banana : Bonus
    {
        public Banana(Point point) : base(point)
        {
        }

        public Banana(Point point, int countBonus) : base(point, countBonus)
        {

        }

        public override void GetInfo()
        {
            throw new NotImplementedException("Info Characters bonus");
        }

        public override void Print()
        {
            throw new NotImplementedException("Banana");
        }

        public override void TakeBonus(Player player)
        {
            player.Damage+= CountBonus;
        }
    }
}
