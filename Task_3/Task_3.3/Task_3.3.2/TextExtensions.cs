using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_3._3._2
{
    public static class TextExtensions
    {
        public static TypeText GetTypeText(this string text)
        {
            if (text is null)
            {
                throw new ArgumentNullException("text is null");
            }
            if (text == string.Empty)
            {
                throw new ArgumentException("text is empty");
            }

            if (text.All(x => char.IsDigit(x)))
            {
                return TypeText.Digital;
            }
            else if (text.All(x => IsLetterRussian(x)))
            {
                return TypeText.Russian;
            }
            else if (text.All(x => IsLetterEnglish(x)))
            {
                return TypeText.English;
            }

            return TypeText.Mixed;
        }

        private static bool IsLetterRussian(char symbol)
        {
            char item = char.ToLower(symbol);

            return (item >= 'а' && item <= 'я' || item == 'ё');
        }

        private static bool IsLetterEnglish(char symbol)
        {
            char item = char.ToLower(symbol);

            return (item >= 'a' && item <= 'z');
        }
    }

    public enum TypeText
    {
        Digital,
        Russian,
        English,
        Mixed
    }
}
