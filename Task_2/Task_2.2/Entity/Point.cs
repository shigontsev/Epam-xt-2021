namespace Task_2._2.Entity
{
    public class Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return new string($"({X};{Y})");
        }
    }
}
