using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyDLL
{
    public class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable, IEnumerable<T>
    {
        public CycledDynamicArray() : base()
        {
        }

        public CycledDynamicArray(IEnumerable<T> sourse) : base(sourse)
        {
        }

        public CycledDynamicArray(int capacity) : base(capacity)
        {
        }

        public override IEnumerator<T> GetEnumerator()
        {            
            while (true)
            {
                IEnumerator a = base.GetEnumerator();
                int i = 0;
                while (a.MoveNext() && i < Length)
                {
                    yield return (T)a.Current;
                    i++;
                }
            }
        }
    }
}
