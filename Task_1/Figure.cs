using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    public class Figure
    {
        /// <summary>
        /// 1.1.2. TRIANGLE
        /// </summary>
        static public void Triangle(int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// 1.1.3. ANOTHER TRIANGLE
        /// </summary>
        static public void Another_Triangle(int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int k = 0; k < N - i - 1; k++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j <= i * 2; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// 1.1.4. X-MAS TREE
        /// </summary>
        static public void X_Mas(int N)
        {
            for (int m = 1; m <= N; m++)
            {
                for (int i = 0; i < m; i++)
                {
                    for (int k = 0; k < N - i - 1; k++)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 0; j <= i * 2; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
