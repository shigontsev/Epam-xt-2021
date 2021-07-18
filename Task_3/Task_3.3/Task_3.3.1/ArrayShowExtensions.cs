using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._3._1
{
    public static class ArrayShowExtensions
    {
        public static void ShowArray<T>(this T[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException("array is null");
            }
            //var array = source.GetEnumerator();
            Console.WriteLine(string.Join(" ", source));
        }
    }
}
