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

        private void ReSize(int length)
        {
            int tempSize = size;
            while (tempSize < length)
            {
                tempSize *= 2;
            }

            //which ToArray is better?
            var tempArr = mainArray.ToArray();//Когда добвлю свой ToArray надо поменять
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
            DynamicArray<T> arrClone = new DynamicArray<T>(this);
            return arrClone;
        }

        public T[] ToArray()
        {
            T[] newArr = new T[Length];
            Array.Copy(mainArray, newArr, Length);
            return newArr;
        }


        /* Осталось
         6. Метод Remove, удаляющий из коллекции указанный элемент. Метод должен возвращать
            true, если удаление прошло успешно и false в противном случае. При удалении элементов
            реальная ёмкость массива не должна уменьшаться.

         7. Метод Insert, позволяющий добавить элемент в произвольную позицию массива (обратите
            внимание, может потребоваться расширить массив). Метод должен возвращать true, если
            добавление прошло успешно и false в противном случае. При выходе за границу массива
            должно генерироваться исключение ArgumentOutOfRangeException.
         2. Возможность ручного изменения значения Capacity с сохранением уцелевших данных
            (данные за пределами новой Capacity сохранять не нужно).
         */

    }
}
