using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    public class Task_1_2
    {
        public static double Averages(string text)
        {
            StringBuilder sb = new StringBuilder(text);
            for (int i = 0; i < sb.Length; i++)
            {
                if (Char.IsPunctuation(sb[i]))
                    sb[i] = ' ';
            }
            text = sb.ToString();
            //Console.WriteLine(text);
            string[] sub_text = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;
            for (int i = 0; i < sub_text.Length; i++)
            {
                sum += sub_text[i].Length;
            }
            //Console.WriteLine(sum + " " + sub_text.Length);
            //Получаем дробое значение
            return (double)sum / sub_text.Length;
        }

        public static string Doubler(string a, string b)
        {
            string new_text = "";
            foreach (char item in a)
            {
                if (b.Contains(item))
                {
                    new_text += string.Format($"{item}{item}");
                }
                else new_text += item;
            }
            return new_text;
        }

        public static int LowerCase(string text)
        {
            StringBuilder sb = new StringBuilder(text);
            for (int i = 0; i < sb.Length; i++)
            {
                if (Char.IsPunctuation(sb[i]))
                    sb[i] = ' ';
            }
            text = sb.ToString();
            //Console.WriteLine(text);
            string[] sub_text = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int count = 0;
            for (int i = 0; i < sub_text.Length; i++)
            {
                if (Char.IsLower(sub_text[i][0]))
                {
                    count++;
                }
            }
            return count;
        }

        public static string Validator(string text)
        {
            string punc_end = ".?!";
            StringBuilder sb = new StringBuilder(text);
            bool b = true;
            for (int i = 0; i < sb.Length; i++)
            {
                if (punc_end.Contains(sb[i]))
                {
                    b = true; continue;
                }
                if (b == true && Char.IsLetter(sb[i]))
                {
                    sb[i] = Char.ToUpper(sb[i]);
                    b = false;
                }
                else if (b == true && Char.IsDigit(sb[i]))
                {
                    b = false;
                }
            }
            text = sb.ToString();
            return text;
        }
    }
}
