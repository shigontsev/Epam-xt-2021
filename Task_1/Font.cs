using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    public class Font
    {
        private string[] font = new string[] { "Bold", "Italic", "Underline" };

        private ArrayList bufferFont;
        public Font()
        {
            bufferFont = new ArrayList();
        }

        public void Action()
        {
            TurnInfo();
            Turn(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine();

        }

        public void Turn(string a)
        {
            switch (a)
            {
                case "1": Check(font[0]); break;
                case "2": Check(font[1]); break;
                case "3": Check(font[2]); break;
                default: Console.Write(" - Не верный ввод, повторите выбор"); break;
            }
        }

        private void TurnInfo()
        {
            Display();
            Console.WriteLine("Введите:");
            for (int i = 0; i < font.Length; i++)
            {
                Console.WriteLine($"\t{i + 1}: {font[i].ToLower()}");
            }
        }

        private void Check(string param)
        {
            if (bufferFont.Contains(param))
                bufferFont.Remove(param);
            else
                bufferFont.Add(param);
        }

        public void Display()
        {
            string info = "Параметры надписи:";
            if (bufferFont.Count > 0)
            {
                foreach (var item in bufferFont)
                {
                    info += " " + item;
                }
            }
            else
                info += " None";
            Console.WriteLine(info);
        }
    }
}
