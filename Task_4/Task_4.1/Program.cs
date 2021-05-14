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
            var menu = new Menu(Environment.CurrentDirectory);

            var listPathFiles = Directory.GetFiles(Environment.CurrentDirectory, "*.txt", SearchOption.AllDirectories);
            var listPathFolders = Directory.GetDirectories(Environment.CurrentDirectory, "", SearchOption.AllDirectories);
            Console.WriteLine(0x80070020 & 0x0000FFFF);
            menu.CallMenu();
        }
    }

}
