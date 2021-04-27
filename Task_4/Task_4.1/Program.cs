using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4._1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //LogService.SaveState(Environment.CurrentDirectory);
            //Console.ReadLine();
            //string path = "D:\\ShigontsevY\\LearningKEK\\Учим\\Epam\\Epam-xt-2021\\Task_4\\Task_4.1\\bin\\Debug\\netcoreapp2.1\\LogContent\\0d5ffaa3-cbd2-497d-80ae-0e31e17ee99b.json";
            //Console.WriteLine("0d5ffaa3-cbd2-497d-80ae-0e31e17ee99b.json".Equals("0d5ffaa3-cbd2-497d-80ae-0e31e17ee99b.json"));
            //Console.WriteLine(File.Exists(path));
            //File.Delete(path);
            var menu = new MenuService(Environment.CurrentDirectory);

            menu.CallMenu();

            Console.ReadLine();
        }
    }

}
