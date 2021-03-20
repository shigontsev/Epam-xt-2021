using System;
using System.Collections.Generic;
using System.Text;
using Task_2._2.Interfaces;

namespace Task_2._2.Entity
{
    public abstract class Bonus : GameObject, IInfo
    {
        public int CountBonus { get; set; } = 1;

        public Bonus(Point point) : this(point, 1)
        {
        }

        public Bonus(Point point, int countBonus) : base(point)
        {
            CountBonus = countBonus;
        }

        public abstract void GetInfo();
        public abstract void TakeBonus(Player player);
    }

    public class Apple : Bonus
    {
        public Apple(Point point) : base(point)
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

    public class Banana : Bonus
    {
        public Banana(Point point) : base(point)
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

    enum TypeBonus
    {
        Apple,
        Banana,
        Papper
    }
}
