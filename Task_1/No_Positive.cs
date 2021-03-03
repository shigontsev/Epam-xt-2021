using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    public class No_Positive
    {
        public static void ArrRandom(int[,,] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int k = 0; k < arr.GetLength(1); k++)
                {
                    for (int m = 0; m < arr.GetLength(2); m++)
                    {
                        arr[i, k, m] = rnd.Next(-100, 100);
                    }
                }
            }
        }
        public static void NoPositive(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int k = 0; k < arr.GetLength(1); k++)
                {
                    for (int m = 0; m < arr.GetLength(2); m++)
                    {
                        if (arr[i, k, m] > 0)
                            arr[i, k, m] = 0;
                    }
                }
            }
        }
        public static void Show(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int k = 0; k < arr.GetLength(1); k++)
                {
                    for (int m = 0; m < arr.GetLength(2); m++)
                    {
                        Console.Write(arr[i, k, m] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
