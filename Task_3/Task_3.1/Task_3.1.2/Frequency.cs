using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1._2
{
    public class Frequency
    {
        public string Value { get; private set; }

        public int Count { get; private set; }

        public Frequency(string value, int count)
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
