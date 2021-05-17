using System;
using Task_2._2.Entity;

namespace Task_2._2.UI
{
    public class Map
    {
        //Question: If i will be paint map in 2D,
        //Then I need the class and property Point? 

        public int Width { get; private set; }

        public int Height { get; private set; }

        public GameObject[,] mapObjects { get; private set; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            mapObjects = new GameObject[Width, Height];
            //for (int i = 0; i < mapObjects.GetLength(0); i++)
            //{
            //    for (int j = 0; j < mapObjects.GetLength(1); j++)
            //    {
            //        mapObjects[i, j].Position.X = i;
            //        mapObjects[i, j].Position.Y = j;
            //    }
            //}
        }

        public void SetObject(GameObject gameObject)
        {
            if (gameObject.Position.X >= Width ||
                gameObject.Position.Y >= Height)
            {
                throw new ArgumentOutOfRangeException(nameof(gameObject.Position),
                    $"Selected {nameof(gameObject.Position)} outside the map area");
            }

            mapObjects[gameObject.Position.X, gameObject.Position.Y] = gameObject;
        }
    }
}
