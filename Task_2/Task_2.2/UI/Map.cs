using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._2.UI
{
    public class Map
    {
        public Map(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; private set; }

        public int Height { get; private set; }
    }
}
