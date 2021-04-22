using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4._1
{
    public class Message
    {
        public static void ShowLine(string text)
        {
            Console.WriteLine(text);
        }

        public static void Show(string text)
        {
            Console.Write(text);
        }

        public static void ShowLine(string text, params object[] args)
        {
            Console.WriteLine(text, args);
        }

        public static void Show(string text, params object[] args)
        {
            Console.Write(text, args);
        }
    }
}
