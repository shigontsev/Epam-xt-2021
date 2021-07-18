using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_3._1._2
{
    public class TextAnalysis
    {        
        private string _text;

        public string Text
        {
            get { return _text; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(value) + " is Null or Empty");
                }

                _text = value; 
            }
        }


        private List<Word> distinctWords = new List<Word>();

        private List<string> allWords = new List<string>();

        public TextAnalysis(string text)
        {
            Text = text;
            allWords.AddRange(ToSplitWords(Text));

            GroupingWords();
        }

        private string[] ToSplitWords(string text)
        {
            StringBuilder sb = new StringBuilder(text.ToLower());
            for (int i = 0; i < sb.Length; i++)
            {
                if (Char.IsPunctuation(sb[i]))
                    sb[i] = ' ';
            }
            text = sb.ToString();

            string[] sub_text = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return sub_text;
        }

        private void GroupingWords()
        {
            distinctWords = allWords
                .GroupBy(x => x)
                .Select(x => new Word(value: x.Key, count: x.Count()))
                .ToList();
        }


        public void ShowStatisticsByCount()
        {
            GetInfo(distinctWords.OrderByDescending(x=>x.Count).ToList());
        }

        public void ShowStatisticsByValue()
        {
            GetInfo(distinctWords.OrderBy(x => x.Value).ToList());
        }

        private void GetInfo(List<Word> list)
        {
            Console.WriteLine("List of frequency words:");
            Console.WriteLine(string.Join(Environment.NewLine, list));
        }

    }
}
