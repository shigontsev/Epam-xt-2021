using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1._2
{
    public class Frequency: IEquatable<Frequency>, IComparable<Frequency>
    {
        public string Value { get; set; }

        public int Count { get; set; }

        public Frequency(string value, int count)
        {
            Value = value;
            Count = count;
        }

        public override string ToString()
        {
            return $"\"{Value}\" = {Count}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Frequency objAsPart = obj as Frequency;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public int CompareTo(Frequency comparePart)
        {
            if (comparePart == null)
            {
                return 1;
            }
            else
            {
                //return this.Count.CompareTo(comparePart.Count);        //Default comparer    
                switch (this.Count.CompareTo(comparePart.Count))        //Revers comparer
                {
                    case 1: return -1;
                    case -1: return 1;
                    default: return 0;
                }
            }
        }

        public bool Equals(Frequency other)
        {
            if (other == null)
                return false;
            return (this.Count.Equals(other.Count));
        }





        //public override int GetHashCode()
        //{
        //    return Count;
        //}
    }
}
