using System;
using MyDLL;
namespace Task_3._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            DynamicArray<int> arr = new DynamicArray<int>(new int[]{ 1,2,3});
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
