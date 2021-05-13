using System;
using System.Collections;
using MyDLL;
namespace Task_3._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> arr = new DynamicArray<int>(new int[]{ 1, 2, 3, 4,5,6,7,8,9,10});
            Console.WriteLine(arr);

            arr.Add(5);
            Console.WriteLine(arr);

            arr.AddRange(new[] { 6, 7, 8, 9, 10 });
            Console.WriteLine(arr);

            DynamicArray<int> arr1 = (DynamicArray<int>)arr.Clone();
            Console.WriteLine(arr1);

            int[] arr2 = arr1.ToArray();
            Console.WriteLine(arr2);

            #region CycledDynamicArray test
            CycledDynamicArray<int> cycle = new CycledDynamicArray<int>(arr2);
            foreach (var item in cycle)
            {
                Console.WriteLine(item);
            }
            #endregion CycledDynamicArray test


            Console.WriteLine(arr1.Remove(10));
            Console.WriteLine(arr1);

            Console.WriteLine(arr1.Remove(9));
            Console.WriteLine(arr1);

            Console.WriteLine(arr1.Remove(8));
            Console.WriteLine(arr1);

            //Console.WriteLine(arr1.Insert(4, 10));
            //arr1.Add(5);
            arr1.AddRange(new[] { 6, 7, 8, 9, 10 });
            Console.WriteLine(arr1);

            arr1.AddRange(new[] { 6, 7, 8, 9, 10 });
            Console.WriteLine(arr1);

            arr1.SetCapacity(19);
            Console.WriteLine(arr1);

            arr1.SetCapacity(13);
            Console.WriteLine(arr1);

            arr1.SetCapacity(20);
            Console.WriteLine(arr1);

            //Console.WriteLine(arr1);

            //ArrayList array = new ArrayList() { 1, 2, 3, 3, 4, 5 };
            //array.Remove(3);
            //Console.WriteLine(string.Join("-", array.ToArray()));

            Console.ReadLine();
        }
    }
}
