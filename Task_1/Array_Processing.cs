using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    public class Array_Processing
    {
        int[] arr;
        public Array_Processing(int N)
        {
            arr = new int[N];
            GenRandArr();
        }
        public void NewArr()
        {
            GenRandArr();
        }
        private void GenRandArr()
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(100);
            }
        }
        public void ShowArr()
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public void ShowArrReverse()
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        public void Sort()
        {
            int temp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int k = 0; k < arr.Length - 1; k++)
                {
                    if (arr[k] > arr[k + 1])
                    {
                        temp = arr[k];
                        arr[k] = arr[k + 1];
                        arr[k + 1] = temp;
                    }
                }
            }
        }
        public void Max()
        {
            int max = arr[0];
            foreach (var item in arr)
            {
                if (max < item)
                    max = item;
            }
            Console.WriteLine($"Max = {max}");
        }
        public void Min()
        {
            int min = arr[0];
            foreach (var item in arr)
            {
                if (min > item)
                    min = item;
            }
            Console.WriteLine($"Min = {min}");
        }
    }
}
