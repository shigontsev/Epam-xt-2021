using System;

namespace MyDLL
{
    public class ArraySymbol
    {
        private char[] arrChar;

        public int Length => arrChar.Length;

        public ArraySymbol() : this("")
        {
            
        }
        public ArraySymbol(string text)
        {
            arrChar = text.ToCharArray();
        }

        public char this[int index]
        {
            get
            {
                return arrChar[index];
            }
            set
            {
                arrChar[index] = value;
            }
        }

        public bool Equals(ArraySymbol arr)
        {
            if (arr.GetType() != this.GetType())
                return false;
            if (arr.Length != Length)
                return false;
            //for (int i = 0; i < Length; i++)
            //{
            //    if (arr[i] != this[i])
            //    {
            //        return false;
            //    }
            //}
            //return true;
            return this.CompareTo(arr) == 0 ? true : false;
        }        

        public int CompareTo(ArraySymbol c)
        {
            return this.ToString().CompareTo(c.ToString());
        }

        public char[] ToCharArray()
        {
            return arrChar;
        }

        public ArraySymbol FromCharArray(char[] arr)
        {
            arrChar = arr;
            return this;
        }
        public ArraySymbol FromString(string text)
        {
            arrChar = text.ToCharArray();
            return this;
        }
        public ArraySymbol Concat(char[] arr)
        {
            char[] arrNew = new char[Length + arr.Length];
            for (int i = 0; i < Length; i++)
            {
                arrNew[i] = arrChar[i];
            }
            for (int i = Length; i < arrNew.Length; i++)
            {
                arrNew[i] = arr[i - Length];
            }
            arrChar = arrNew;
            return this;
        }
        public ArraySymbol Concat(string text)
        {
            Concat(text.ToCharArray());
            return this;
        }
        public ArraySymbol Concat(params string[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Concat(text[i].ToCharArray());
            }
            return this;
        }
        public ArraySymbol Concat(ArraySymbol arr)
        {
            Concat(arr.ToCharArray());
            return this;
        }

        public ArraySymbol Concat(params ArraySymbol[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Concat(arr[i].ToCharArray());
            }
            return this;
        }

        public static ArraySymbol Concat(ArraySymbol c1, ArraySymbol c2)
        {
            return new ArraySymbol(c1.ToString()+c2.ToString());
        }

        public ArraySymbol Append(string text)
        {
            Concat(new ArraySymbol(text));
            return this;
        }

        public int IndexOf(char c)
        {
            for (int i = 0; i < Length; i++)
            {
                if (arrChar[i] == c)
                {
                    return i;
                }
            }
            return -1;
        }
        public int LastIndexOf(char c)
        {
            int index = -1;
            for (int i = 0; i < Length; i++)
            {
                if (arrChar[i] == c)
                {
                    index = i;
                }
            }
            return index;
        }
        public bool Contains(char c)
        {
            return IndexOf(c) != -1 ? true : false;
        }
        

        public ArraySymbol ToUpper()
        {
            for (int i = 0; i < Length; i++)
            {
                arrChar[i] = Char.ToUpper(arrChar[i]);
            }
            return this;
        }
        public ArraySymbol ToLower()
        {
            for (int i = 0; i < Length; i++)
            {
                arrChar[i] = Char.ToLower(arrChar[i]);
            }
            return this;
        }
        public ArraySymbol Insert(char c, int index)
        {
            char[] item = ToCharArray();
            arrChar = new char[Length + 1];
            for (int i = 0; i < Length; i++)
            {
                if (i < index)
                {
                    arrChar[i] = item[i];
                }
                else if (i == index)
                {
                    arrChar[i] = c;
                }
                else
                {
                    arrChar[i] = item[i - 1];
                }
            }
            return this;
        }
        public ArraySymbol Remove(int index)
        {
            char[] item = ToCharArray();
            arrChar = new char[Length - 1];
            for (int i = 0; i < Length; i++)
            {
                if (i < index)
                {
                    arrChar[i] = item[i];
                }
                else
                {
                    arrChar[i] = item[i + 1];
                }
            }
            return this;
        }

        public ArraySymbol Reverse()
        {
            //char[] item = this.ToCharArray();
            //for (int i = 0; i < item.Length; i++)
            //{
            //    arrChar[i] = item[item.Length - i - 1];
            //}
            for (int i = 0; i < this.Length / 2; i++)
            {
                char tmp = this[i];
                this[i] = this[this.Length - i - 1];
                this[this.Length - i - 1] = tmp;
            }
            return this;
        }

        public static ArraySymbol operator +(ArraySymbol c1, ArraySymbol c2)
        {
            return ArraySymbol.Concat(c1, c2);
        }
        public static ArraySymbol operator ++(ArraySymbol c1)
        {
            return c1.Concat(c1);
        }
        public static bool operator ==(ArraySymbol c1, ArraySymbol c2)
        {
            return c1.Equals(c2) ? true:false;
        }
        public static bool operator !=(ArraySymbol c1, ArraySymbol c2)
        {
            return c1.Equals(c2) ? false : true;
        }
        public override string ToString()
        {
            return new string(arrChar);
        }
    }
}
