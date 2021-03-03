using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    public class Arr_2D
    {
        //int[,] arr;
        public static void ArrGen(int[,]arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int k = 0; k < arr.GetLength(1); k++)
                {
                    arr[i, k] = rnd.Next(20);
                }
            }
        }
        public static void ArrShow(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int k = 0; k < arr.GetLength(1); k++)
                {
                    Console.Write(arr[i, k] + " ");
                }
                Console.WriteLine();
            }
        }
        public static int Sum_Chet(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int k = 0; k < arr.GetLength(1); k++)
                {
                    if ((i + k) % 2 == 0)
                    {
                        sum += arr[i, k];
                    }
                }
            }
            return sum;
        }
    }
}
