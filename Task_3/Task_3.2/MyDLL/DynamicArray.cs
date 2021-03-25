using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyDLL
{
    public class DynamicArray<T>: IEnumerable<T>, IEnumerable
    {
        private const int size = 8;

        private T[] mainArray;

        public int Capacity => mainArray.Length;

        public int Length { get; private set; } = 0;

        public DynamicArray()
        {
            mainArray = new T[size];
        }

        public DynamicArray(int capacity)
        {
            mainArray = new T[capacity];
            //mainArray = arr.
        }

        //public DynamicArray(T arr)
        //{
        //    //mainArray = arr.
        //}

        public DynamicArray(IEnumerable<T> sourse)
        {
            T[] tempArr = sourse.ToArray();
            int tempSize = size;
            while (tempSize < tempArr.Length)
            {
                tempSize *= 2;
            }
            this.Length = tempArr.Length;
            mainArray = new T[tempSize];
            //ReSize(tempArr.Length);
            for (int i = 0; i < tempArr.Length; i++)
            {
                mainArray[i] = tempArr[i];
            }
        }

        public void Add(T item)
        {
            if (Length+1 >= Capacity)
            {
                ReSize(Length + 1);
                mainArray[Length - 1] = item;
            }
            else
            {
                Length++;
                mainArray[Length - 1] = item;
            }
        }

        private void ReSize(int length)
        {
            int tempSize = size;
            while (tempSize < length)
            {
                tempSize *= 2;
            }
            var tempArr = mainArray.ToArray();//Когда добвлю свой ToArray надо поменять
            this.Length = length;
            mainArray = new T[tempSize];
            for (int i = 0; i < tempArr.Length; i++)
            {
                mainArray[i] = tempArr[i];
            }
        }

        public void AddRange(IEnumerable<T> sourse)
        {
            T[] tempArr = sourse.ToArray();
            if (tempArr.Length > 0)
            {
                int tempLength = this.Length;
                if (Length + tempArr.Length >= Capacity)
                {
                    ReSize(Length + tempArr.Length);
                }
                else
                {
                    Length += tempArr.Length;
                }
                for (int i = tempLength; i < this.Length; i++)
                {
                    mainArray[i] = tempArr[i - tempLength];
                }
            }            
        }

        public T this[int index]
        {
            get { return mainArray[index]; }
            set { mainArray[index] = value; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            //return ((IEnumerable<T>)mainArray).GetEnumerator();
            return ((IEnumerable<T>)mainArray.Take(Length)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //return((IEnumerable<T>)mainArray).GetEnumerator();
            return ((IEnumerable<T>)mainArray.Take(Length)).GetEnumerator();
        }
    }
}
