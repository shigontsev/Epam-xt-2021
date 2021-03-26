using System;
using System.Collections;
using MyDLL;
namespace Task_3._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            DynamicArray<int> arr = new DynamicArray<int>(new int[]{ 1, 2, 3, 4});
            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine(string.Join("-", arr) +$"; {nameof(arr.Length)} = {arr.Length}; {nameof(arr.Capacity)} = {arr.Capacity}");

            arr.Add(5);
            Console.WriteLine(string.Join("-", arr) + $"; {nameof(arr.Length)} = {arr.Length}; {nameof(arr.Capacity)} = {arr.Capacity}");

            arr.AddRange(new[] { 6, 7, 8, 9, 10 });
            Console.WriteLine(string.Join("-", arr) + $"; {nameof(arr.Length)} = {arr.Length}; {nameof(arr.Capacity)} = {arr.Capacity}");

            DynamicArray<int> arr1 = (DynamicArray<int>)arr.Clone();
            Console.WriteLine(string.Join("-", arr1) + $"; {nameof(arr1.Length)} = {arr1.Length}; {nameof(arr1.Capacity)} = {arr1.Capacity}");

            int[] arr2 = arr1.ToArray();
            Console.WriteLine(string.Join("-", arr2) + $"; {nameof(arr2.Length)} = {arr2.Length}");

            #region CycledDynamicArray test
            //CycledDynamicArray<int> cycle = new CycledDynamicArray<int>(arr2);
            //foreach (var item in cycle)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion CycledDynamicArray test


            Console.WriteLine(arr1.Remove(10));
            Console.WriteLine(string.Join("-", arr1) + $"; {nameof(arr1.Length)} = {arr1.Length}; {nameof(arr1.Capacity)} = {arr1.Capacity}");



            //ArrayList array = new ArrayList() { 1, 2, 3, 3, 4, 5 };
            //array.Remove(3);
            //Console.WriteLine(string.Join("-", array.ToArray()));

            Console.ReadLine();
        }
    }
}
