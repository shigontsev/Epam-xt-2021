using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyDLL
{
    public class CycledDynamicArray<T> : DynamicArray<T>
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
            for (int i = 0; ; i++)
            {
                yield return this[i % Length];
            }
        }
    }
}
