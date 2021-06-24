using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listA = new List<string>();
            listA.Add("a");
            listA.Add("b");
            listA.Add("b");

            List<string> listB = new List<string>();
            listB.Add("a");
            listB.Add("b");

            foreach (var item in listA.FindAll(x=>x=="c").ToList())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(listA.FindAll(x => x == "c").ToList().Count);

            Console.ReadLine();
        }
    }
}
