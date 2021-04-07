using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_3._3._1
{
    public static class NumberArrayExtensions
    {
        #region Sbyte type
        public static sbyte Sum(this sbyte[] arr)
        {
            arr.HelperExeption();

            return (sbyte) arr.Sum(x => x);
        }

        public static sbyte Avg(this sbyte[] arr)
        {
            arr.HelperExeption();

            return (sbyte)arr.Average(x => x);
        }

        public static sbyte Franquency(this sbyte[] arr)
        {
            arr.HelperExeption();

            var a = arr.GroupBy(x => x).OrderByDescending(x => x.Count());
            return a.FirstOrDefault().Key;
        }
        #endregion Sbyte type

        #region short type
        public static short Sum(this short[] arr)
        {
            arr.HelperExeption();

            return (short)arr.Sum(x => x);
        }

        public static short Avg(this short[] arr)
        {
            arr.HelperExeption();

            return (short)arr.Average(x => x);
        }

        public static short Franquency(this short[] arr)
        {
            arr.HelperExeption();

            var a = arr.GroupBy(x => x).OrderByDescending(x => x.Count());
            return a.FirstOrDefault().Key;
        }
        #endregion short type

        #region Int type
        public static int Sum(this int[] arr)
        {
            //if (arr is null)
            //{
            //    throw new ArgumentNullException("array is null");
            //}
            //if (arr.Length == 0)
            //{
            //    throw new ArgumentException("array is empty");
            //}
            arr.HelperExeption();

            return arr.Sum(x => x);
        }

        public static int Avg(this int[] arr)
        {
            //if (arr is null)
            //{
            //    throw new ArgumentNullException("array is null");
            //}
            //if (arr.Length == 0)
            //{
            //    throw new ArgumentException("array is empty");
            //}
            arr.HelperExeption();

            return (int)arr.Average(x => x);
        }

        public static int Franquency(this int[] arr)
        {
            //if (arr is null)
            //{
            //    throw new ArgumentNullException("array is null");
            //}
            //if (arr.Length == 0)
            //{
            //    throw new ArgumentException("array is empty");
            //}
            arr.HelperExeption();

            var a = arr.GroupBy(x => x).OrderByDescending(x => x.Count());
            return a.FirstOrDefault().Key;
        }
        #endregion Int type

        #region long type
        public static long Sum(this long[] arr)
        {
            arr.HelperExeption();

            return (long)arr.Sum(x => x);
        }

        public static long Avg(this long[] arr)
        {
            arr.HelperExeption();

            return (long)arr.Average(x => x);
        }

        public static long Franquency(this long[] arr)
        {
            arr.HelperExeption();

            var a = arr.GroupBy(x => x).OrderByDescending(x => x.Count());
            return a.FirstOrDefault().Key;
        }
        #endregion long type

        #region Byte type
        public static byte Sum(this byte[] arr)
        {
            arr.HelperExeption();

            return (byte)arr.Sum(x => x);
        }

        public static byte Avg(this byte[] arr)
        {
            arr.HelperExeption();

            return (byte)arr.Average(x => x);
        }

        public static byte Franquency(this byte[] arr)
        {
            arr.HelperExeption();

            var a = arr.GroupBy(x => x).OrderByDescending(x => x.Count());
            return a.FirstOrDefault().Key;
        }
        #endregion Byte type

        #region ushort type
        public static ushort Sum(this ushort[] arr)
        {
            arr.HelperExeption();

            return (ushort)arr.Sum(x => x);
        }

        public static ushort Avg(this ushort[] arr)
        {
            arr.HelperExeption();

            return (ushort)arr.Average(x => x);
        }

        public static ushort Franquency(this ushort[] arr)
        {
            arr.HelperExeption();

            var a = arr.GroupBy(x => x).OrderByDescending(x => x.Count());
            return a.FirstOrDefault().Key;
        }
        #endregion ushort type

        #region uint type
        public static uint Sum(this uint[] arr)
        {
            arr.HelperExeption();

            return (uint)arr.Sum(x => x);
        }

        public static uint Avg(this uint[] arr)
        {
            arr.HelperExeption();

            return (uint)arr.Average(x => x);
        }

        public static uint Franquency(this uint[] arr)
        {
            arr.HelperExeption();

            var a = arr.GroupBy(x => x).OrderByDescending(x => x.Count());
            return a.FirstOrDefault().Key;
        }
        #endregion uint type

        #region ulong type
        public static ulong Sum(this ulong[] arr)
        {
            arr.HelperExeption();

            return (ulong)arr.Sum(x => (decimal) x);
        }

        public static ulong Avg(this ulong[] arr)
        {
            arr.HelperExeption();

            return (ulong)arr.Average(x => (decimal) x);
        }

        public static ulong Franquency(this ulong[] arr)
        {
            arr.HelperExeption();

            var a = arr.GroupBy(x => x).OrderByDescending(x => x.Count());
            return a.FirstOrDefault().Key;
        }
        #endregion ulong type

        #region float type
        public static float Sum(this float[] arr)
        {
            arr.HelperExeption();

            return (float)arr.Sum(x => x);
        }

        public static float Avg(this float[] arr)
        {
            arr.HelperExeption();

            return (float)arr.Average(x => x);
        }

        public static float Franquency(this float[] arr)
        {
            arr.HelperExeption();

            var a = arr.GroupBy(x => x).OrderByDescending(x => x.Count());
            return a.FirstOrDefault().Key;
        }
        #endregion float type

        #region double type
        public static double Sum(this double[] arr)
        {
            arr.HelperExeption();

            return (double)arr.Sum(x => x);
        }

        public static double Avg(this double[] arr)
        {
            arr.HelperExeption();

            return (double)arr.Average(x => x);
        }

        public static double Franquency(this double[] arr)
        {
            arr.HelperExeption();

            var a = arr.GroupBy(x => x).OrderByDescending(x => x.Count());
            return a.FirstOrDefault().Key;
        }
        #endregion double type

        #region decimal type
        public static decimal Sum(this decimal[] arr)
        {
            arr.HelperExeption();

            return (decimal)arr.Sum(x => x);
        }

        public static decimal Avg(this decimal[] arr)
        {
            arr.HelperExeption();

            return (decimal)arr.Average(x => x);
        }

        public static decimal Franquency(this decimal[] arr)
        {
            arr.HelperExeption();

            var a = arr.GroupBy(x => x).OrderByDescending(x => x.Count());
            return a.FirstOrDefault().Key;
        }
        #endregion decimal type

        #region EditArray numeric Type
        public static void EditArray(this sbyte[] arr, Func<sbyte, sbyte> func)
        {
            if (func is null)
            {
                return;
            }
            arr.HelperExeption();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = func.Invoke(arr[i]);
            }
        }

        public static void EditArray(this short[] arr, Func<short, short> func)
        {
            if (func is null)
            {
                return;
            }
            arr.HelperExeption();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = func.Invoke(arr[i]);
            }
        }

        public static void EditArray(this int[] arr, Func<int, int> func)
        {
            if (func is null)
            {
                return;
            }
            arr.HelperExeption();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = func.Invoke(arr[i]);
            }
        }

        public static void EditArray(this long[] arr, Func<long, long> func)
        {
            if (func is null)
            {
                return;
            }
            arr.HelperExeption();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = func.Invoke(arr[i]);
            }
        }

        public static void EditArray(this byte[] arr, Func<byte, byte> func)
        {
            if (func is null)
            {
                return;
            }
            arr.HelperExeption();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = func.Invoke(arr[i]);
            }
        }

        public static void EditArray(this ushort[] arr, Func<ushort, ushort> func)
        {
            if (func is null)
            {
                return;
            }
            arr.HelperExeption();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = func.Invoke(arr[i]);
            }
        }

        public static void EditArray(this uint[] arr, Func<uint, uint> func)
        {
            if (func is null)
            {
                return;
            }
            arr.HelperExeption();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = func.Invoke(arr[i]);
            }
        }

        public static void EditArray(this ulong[] arr, Func<ulong, ulong> func)
        {
            if (func is null)
            {
                return;
            }
            arr.HelperExeption();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = func.Invoke(arr[i]);
            }
        }

        public static void EditArray(this float[] arr, Func<float, float> func)
        {
            if (func is null)
            {
                return;
            }
            arr.HelperExeption();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = func.Invoke(arr[i]);
            }
        }

        public static void EditArray(this double[] arr, Func<double, double> func)
        {
            if (func is null)
            {
                return;
            }
            arr.HelperExeption();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = func.Invoke(arr[i]);
            }
        }

        public static void EditArray(this decimal[] arr, Func<decimal, decimal> func)
        {
            if (func is null)
            {
                return;
            }
            arr.HelperExeption();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = func.Invoke(arr[i]);
            }
        }
        #endregion EditArray numeric Type

        private static void HelperExeption<T>(this T[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException("array is null");
            }
            if (source.Length == 0)
            {
                throw new ArgumentException("array is empty");
            }
        }
    }
}
