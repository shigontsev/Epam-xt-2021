using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1._2
{
#region Don't watch, for me. Task mad without Linq
    //public class Frequency : IEquatable<Frequency>, IComparable<Frequency>
#endregion Don't watch, for me. Task mad without Linq


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


        #region Don't watch, for me. Task mad without Linq
        //public override bool Equals(object obj) => this.Equals(obj as Frequency);

        //public int CompareTo(Frequency comparePart)
        //{
        //    if (comparePart == null)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        //return this.Count.CompareTo(comparePart.Count);        //Default comparer    
        //        switch (this.Count.CompareTo(comparePart.Count))        //Revers comparer
        //        {
        //            case 1: return -1;
        //            case -1: return 1;
        //            default: return 0;
        //        }
        //    }
        //}

        //public bool Equals(Frequency item)
        //{
        //    if (item == null)
        //        return false;
        //    if (Object.ReferenceEquals(this, item))
        //        return true;
        //    if (this.GetType() != item.GetType())
        //        return false;

        //    return (this.Value.Equals(item.Value));
        //}

        //public override int GetHashCode()
        //{
        //    return Value.GetHashCode();
        //}
        #endregion Don't watch, for me. Task mad without Linq
    }
}
