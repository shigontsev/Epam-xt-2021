using System;

namespace MyDLL
{
    public class ArraySymbol
    {
        private char[] arrChar;

        public int Length => arrChar.Length;

        public ArraySymbol() : this(string.Empty)
        {

        }
        public ArraySymbol(string text)
        {
            arrChar = text.ToCharArray();
        }
        public ArraySymbol(char[] text)
        {
            arrChar = (char[]) text.Clone();
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

        public override bool Equals(object obj)
        {
            return this.arrChar.Equals(obj as ArraySymbol);
        }

        public bool Equals(ArraySymbol arr)
        {
            if (arr is null || arr.Length != Length)
                return false;
            return this.CompareTo(arr) == 0;
        }

        public int CompareTo(object obj)
        {
            return this.CompareTo(obj as ArraySymbol);
        }

        public int CompareTo(ArraySymbol c)
        {
            if (c is null || c.Length != Length)
                return 1;
            int result = 0;
            for (int i = 0; i < c.Length; i++)
            {
                result = this[i].CompareTo(c[i]);
                if (result!=0)
                {
                    return result;
                }
            }
            return result;
        }

        public char[] ToCharArray()
        {
            return (char[]) arrChar.Clone();
        }

        public static ArraySymbol FromCharArray(char[] arr)
        {
            return new ArraySymbol(arr);
        }

        public static ArraySymbol FromString(string text)
        {
            return new ArraySymbol(text);
        }

        public ArraySymbol Concat(char[] arr)
        {
            var arrNew = new char[Length + arr.Length];
            arrChar.CopyTo(arrNew, 0);
            arr.CopyTo(arrNew, Length);
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
            return (new ArraySymbol()).Concat(c1, c2);
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
            for (int i = Length - 1; i >= 0; i--)
            {
                if (arrChar[i] == c)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Contains(char c)
        {
            return IndexOf(c) != -1;
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
            char[] item = arrChar;
            arrChar = new char[Length + 1];
            Array.Copy(item, 0, arrChar, 0, index);
            arrChar[index] = c;
            Array.Copy(item, index, arrChar, index + 1, item.Length-index);
            return this;
        }

        public ArraySymbol Remove(int index)
        {
            char[] item = arrChar;
            arrChar = new char[Length - 1];
            Array.Copy(item, 0, arrChar, 0, index);
            Array.Copy(item, index + 1, arrChar, index, item.Length - index -1);
            return this;
        }

        public ArraySymbol Reverse()
        {
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
            return c1.Equals(c2);
        }

        public static bool operator !=(ArraySymbol c1, ArraySymbol c2)
        {
            return !c1.Equals(c2);
        }

        public override string ToString()
        {
            return new string(arrChar);
        }
    }
}
