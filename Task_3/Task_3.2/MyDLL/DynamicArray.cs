using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyDLL
{
    public class DynamicArray<T>: IEnumerable<T>, IEnumerable, ICloneable
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

        public DynamicArray(IEnumerable<T> sourse) : this()
        {
            T[] tempArr = sourse.ToArray();
            //int tempSize = size;
            //while (tempSize < tempArr.Length)
            //{
            //    tempSize *= 2;
            //}
            //this.Length = tempArr.Length;
            //mainArray = new T[tempSize];
            ReSize(tempArr.Length);


            //for (int i = 0; i < tempArr.Length; i++)
            //{
            //    mainArray[i] = tempArr[i];
            //}

            //Array.Copy(tempArr, 0, mainArray, 0, tempArr.Length);
            Array.Copy(tempArr, mainArray, tempArr.Length);
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
                //for (int i = tempLength; i < this.Length; i++)
                //{
                //    mainArray[i] = tempArr[i - tempLength];
                //}
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

            //try
            //{
            ReSize(Length + 1);
            Array.Copy(mainArray, index, mainArray, index + 1, Length - index);
            mainArray[index] = item;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
            return true;
        }


        private void ReSize(int length)
        {
            if (Capacity < length)
            {
                int tempSize = size;
                while (tempSize < length)
                {
                    tempSize *= 2;
                }

                //which ToArray is better?
                var tempArr = mainArray.ToArray();
                //T[] tempArr = this.ToArray();

                this.Length = length;
                mainArray = new T[tempSize];
                //for (int i = 0; i < tempArr.Length; i++)
                //{
                //    mainArray[i] = tempArr[i];
                //}

                //Array.Copy(tempArr, 0, mainArray, 0, tempArr.Length);
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
                index = HelperOfIndex(index);
                return mainArray[index];
            }
            set
            {
                index = HelperOfIndex(index);
                mainArray[index] = value;
            }
        }

        private int HelperOfIndex(int index)
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
            //for (int i = 0; i < Length; i++)
            //{
            //    yield return mainArray[i];
            //}

            IEnumerator ie = mainArray.GetEnumerator();
            int i = 0;
            while (ie.MoveNext() && i < Length)
            {
                yield return (T)ie.Current;
                i++;
            }
            ie.Reset();
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

        public void EditCapacity(int capacity)
        {
            if (capacity == this.Capacity)
            {
                return;
            }
            else if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
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
