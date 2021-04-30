using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1._2
{
    public class Word
    {
        public string Value { get;}

        public int Count { get;}

        public Word(string value, int count)
        {
            Value = value;
            Count = count;
        }

        public override string ToString()
        {
            return $"\"{Value}\" = {Count}";
        }


    }
}
