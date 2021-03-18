using MyDLL;
using System;

namespace Task_2._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ArraySymbol A = new ArraySymbol("Hello");
            ArraySymbol B = new ArraySymbol(" World");
            ArraySymbol C = new ArraySymbol("Hello");
            //Console.WriteLine(A == C);
            //Console.WriteLine("Hello" == "Hello");
            Console.WriteLine(A.Equals(C));
            Console.WriteLine(A.Equals(B));
            //A.Concat(B);
            Console.WriteLine(A.Contains('u'));
            Console.WriteLine(A.Concat(new[] { ' ', 'H', 'u', 'm', 'a', 'n' }));
            Console.WriteLine(A.Concat(B));
            Console.WriteLine(A.Contains('u'));
            //Console.WriteLine(A.ToString());
            Console.WriteLine(A.ToLower());
            Console.WriteLine(A.ToUpper());
            Console.WriteLine(A);
            Console.WriteLine(A.Insert('d', 5));
            Console.WriteLine(A.Remove(5));
            Console.WriteLine(A.Remove(9));
            //Console.WriteLine(RuntimeHelpers.Equals(A, B));
            //Console.WriteLine(RuntimeHelpers.Equals(A, A));
            ArraySymbol all = new ArraySymbol();
            Console.WriteLine(all.Concat(A, B, C));
            Console.WriteLine(all);
            Console.WriteLine(all.IndexOf('l'));
            Console.WriteLine(all.LastIndexOf('l'));
            Console.WriteLine(all.Length);
            Console.WriteLine("--------------------");
            Console.WriteLine(ArraySymbol.Concat(C,B));
            Console.WriteLine(C);
            Console.WriteLine(C + B);
            Console.WriteLine(C);
            Console.WriteLine(C++);
            Console.WriteLine(C);
            Console.WriteLine(C == B);
            Console.WriteLine(C != B);
            Console.WriteLine(C == new ArraySymbol("Hello"));
            Console.WriteLine(C.Equals(new ArraySymbol("Hello")));
            Console.WriteLine(new ArraySymbol("Hello") == new ArraySymbol("Hello"));
            Console.WriteLine("--------------------");
            Console.WriteLine(C.Reverse());
            Console.WriteLine(C.Reverse());
            //int t = 0, t1 = 2;
            //Console.WriteLine(t + 2);
            //Console.WriteLine(t);
            char[] test = new char[] { 'h', 'e', 'l', 'l', 'o' };
            ArraySymbol testClass = new ArraySymbol(test);
            Console.WriteLine(String.Join("",test) + " " + testClass);
            //testClass[2] = 'd';
            Console.WriteLine(String.Join("", test) + " " + testClass);

            char[] test1 = testClass.ToCharArray();
            Console.WriteLine(String.Join("", test1) + " " + testClass);
            test1[2] = 'd';
            Console.WriteLine(String.Join("", test1) + " " + testClass);
            Console.WriteLine("-------------------------");
            ArraySymbol test2 = ArraySymbol.FromCharArray(test1);
            Console.WriteLine(String.Join("", test1) + " " + test2);
            test2[2] = 'F';
            Console.WriteLine(String.Join("", test1) + " " + test2);
            test1[4] = 'F';
            Console.WriteLine(String.Join("", test1) + " " + test2);
            var z = new char[test1.Length + test2.Length];
            test1.CopyTo(z, 0);
            test2.ToCharArray().CopyTo(z, test1.Length);
            Console.WriteLine(z);
            Console.ReadLine();
        }
    }
}
