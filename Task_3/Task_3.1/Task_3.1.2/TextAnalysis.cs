using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1._2
{
    public class TextAnalysis
    {
        private List<Frequency> distinctWords = new List<Frequency>();

        private List<string> allWords = new List<string>();

        public TextAnalysis(string text)
        {
            allWords.AddRange(ToSplitWords(text));
            DistinctWords();
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

        private void DistinctWords()
        {
            List<string> bufferDistWords = new List<string>();
            foreach (var item in allWords)
            {
                if (!bufferDistWords.Contains(item))
                {
                    bufferDistWords.Add(item);
                    int count = allWords.FindAll(x => x == item).Count;
                    distinctWords.Add(new Frequency(item, count));
                }
            }
        }

        public void GetInfo()
        {
            Console.WriteLine("List of frequency words:");
            foreach (var item in distinctWords)
            {
                //Console.WriteLine($"\"{item.Value}\" = {item.Count}");
                Console.WriteLine(item);
            }
        }

        public void SortByCount()
        {
            distinctWords.Sort();
        }

        public void SortByValue()
        {
            distinctWords.Sort(delegate (Frequency x, Frequency y)
            {
                if (x.Value == null && y.Value == null) return 0;
                else if (x.Value == null) return -1;
                else if (y.Value == null) return 1;
                else return x.Value.CompareTo(y.Value);
            });
        }

    }
}
