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
            Console.ReadLine();
        }
    }
}
