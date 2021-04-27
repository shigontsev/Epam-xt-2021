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

            var menu = new MenuService(Environment.CurrentDirectory);

            menu.CallMenu();

            Console.ReadLine();
        }
    }

}
