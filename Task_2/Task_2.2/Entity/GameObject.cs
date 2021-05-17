using Task_2._2.Interfaces;

namespace Task_2._2.Entity
{
    public abstract class GameObject: IPrintable
    {
        public Point Position { get; set; }

        public GameObject(Point point)
        {
            Position = point;
        }

        public abstract void Print();
    }
}
