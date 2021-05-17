using Task_2._2.Entity.Person;
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
}
