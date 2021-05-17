using System;
using Task_2._2.Entity.Person;

namespace Task_2._2.Entity
{
    public class Papper : Bonus
    {
        public Papper(Point point) : base(point)
        {

        }

        public override void GetInfo()
        {
            throw new NotImplementedException("Info Characters bonus");
        }

        public override void Print()
        {
            throw new NotImplementedException("Papper");
        }

        public override void TakeBonus(Player player)
        {
            player.Step+= CountBonus;
        }
    }
}
