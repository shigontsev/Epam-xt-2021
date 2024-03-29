﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyDLL
{
    public class DynamicArray<T>: IEnumerable<T>, IEnumerable, ICloneable
    {
        private const int DefaultCapacity = 8;

        private T[] mainArray;

        public int Capacity => mainArray.Length;

        public int Length { get; private set; } = 0;

        public DynamicArray()
        {
            mainArray = new T[DefaultCapacity];
        }

        public DynamicArray(int capacity)
        {
            mainArray = new T[capacity];
        }

        public DynamicArray(IEnumerable<T> sourse)
        {
            Length = sourse.Count();

            mainArray = Length <= DefaultCapacity ?
                new T[DefaultCapacity] :
                (Length % DefaultCapacity == 0 ?
                new T[Length] :
                new T[Length / DefaultCapacity * DefaultCapacity * 2]);

            Array.Copy(sourse.ToArray(), mainArray, Length);
        }

        public void Add(T item)
        {
            if (Length == Capacity)
            {
                ReCapacity(Length + 1);
            }
            else
            {
                Length++;
            }
            mainArray[Length - 1] = item;
        }

        public void AddRange(IEnumerable<T> sourse)
        {
            T[] tempArr = sourse.ToArray();
            if (tempArr.Length > 0)
            {
                int tempLength = this.Length;
                if (Length + tempArr.Length >= Capacity)
                {
                    ReCapacity(Length + tempArr.Length);
                }
                else
                {
                    Length += tempArr.Length;
                }
                
                Array.Copy(tempArr, 0, mainArray, tempLength, tempArr.Length);
            }
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Length; i++)
            {
                if (mainArray[i].Equals(item))
                {
                    if (i + 1 < Length)
                    {
                        Array.Copy(mainArray, i + 1, mainArray, i, mainArray.Length - i - 1);
                    }
                    this.Length--;
                    mainArray[this.Length] = default(T);
                    return true;
                }
            }
            return false;
        }

        public bool Insert(int index, T item)
        {
            if (index < 0)
            {
                index += Length;
            }
            if (index > Length || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            ReCapacity(Length + 1);

            Array.Copy(mainArray, index, mainArray, index + 1, Length - index);
            mainArray[index] = item;
            return true;
        }


        private void ReCapacity(int length)
        {
            if (Capacity < length)
            {
                int tempCapacity = DefaultCapacity;
                while (tempCapacity < length)
                {
                    tempCapacity *= 2;
                }

                var tempArr = mainArray.ToArray();

                this.Length = length;
                mainArray = new T[tempCapacity];
                
                Array.Copy(tempArr, mainArray, tempArr.Length);
            }
            else
            {
                this.Length = length;
            }
        }

        public T this[int index]
        {
            get
            {
                index = ResolveIndex(index);
                return mainArray[index];
            }
            set
            {
                index = ResolveIndex(index);
                mainArray[index] = value;
            }
        }

        private int ResolveIndex(int index)
        {
            if (index >= Length || index < 0 - Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if(index >= 0)
            {
                return index;
            }
            else
            {
                return index + Length;
            }
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return mainArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public object Clone()
        {
            return new DynamicArray<T>(this);
        }

        public T[] ToArray()
        {
            T[] newArr = new T[Length];
            Array.Copy(mainArray, newArr, Length);
            return newArr;
        }

        public void SetCapacity(int capacity)
        {
            if (capacity == this.Capacity)
            {
                return;
            }
            else if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), $"{nameof(capacity)} < 0");
            }
            else
            {
                if (capacity < this.Length)
                {
                    Length = capacity;
                }
                T[] tempArr = new T[Length];
                Array.Copy(mainArray, tempArr, Length);
                mainArray = new T[capacity];
                Array.Copy(tempArr, mainArray, tempArr.Length);
            }
        }

        public override string ToString()
        {
            return new string(string.Join('-', this) + $"; {nameof(Length)} = {Length}; {nameof(Capacity)} = {Capacity}");
        }
    }
}
