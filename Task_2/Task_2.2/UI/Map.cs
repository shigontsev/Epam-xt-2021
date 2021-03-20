using System;
using System.Collections.Generic;
using System.Text;
using Task_2._2.Entity;

namespace Task_2._2.UI
{
    public class Map
    {
        //Question: If i will be paint map in 2D,
        //Then I need the class and property Point? 
        public GameObject[,] mapObjects;
        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            mapObjects = new GameObject[Width, Height];
            for (int i = 0; i < mapObjects.GetLength(0); i++)
            {
                for (int j = 0; j < mapObjects.GetLength(1); j++)
                {
                    mapObjects[i, j].Position.X = i;
                    mapObjects[i, j].Position.Y = j;
                }
            }
        }

        public int Width { get; private set; }

        public int Height { get; private set; }
    }
}
