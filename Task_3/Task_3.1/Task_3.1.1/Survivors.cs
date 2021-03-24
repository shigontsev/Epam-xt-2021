using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1._1
{
    public class Survivors
    {
        private ArrayList listHuman;

        public int Length => listHuman.Count;

        public Survivors(int n)
        {
            CreatListHuman(n);
        }

        private void CreatListHuman(int n)
        {
            listHuman = new ArrayList();
            for (int i = 1; i <= n; i++)
            {
                listHuman.Add($"{i}");
            }
            Console.WriteLine($"ВЫВОД: Сгенерирован круг людей из {Length} человек");
        }

        public void Start(int N)
        {
            try
            {
                int round = 0;
                int schet = 0;
                while (true)
                {
                    Console.WriteLine(string.Join(' ', listHuman.ToArray()));
                    OutOfListByMod(N, ref schet);
                    round++;
                    Console.WriteLine($"Раунд {round}. Вычеркнут человек. Людей осталось: {Length}");
                }
            }
            catch (ArgumentNegativeException)
            {
                Console.WriteLine("ВЫВОД: Игра окончена. Невозможно вычеркнуть больше людей.");
            }
        }

        public void OutOfListByMod(int N, ref int schet)
        {
            if (Length < N)
            {
                throw new ArgumentNegativeException();
            }
            for (int i = 0; i < listHuman.Count; i++)
            {
                schet++;
                if (schet % 2 == 0)
                {
                    listHuman.RemoveAt(i);
                    i--;
                }
            }
        }
    }
    public class ArgumentNegativeException : ArgumentOutOfRangeException
    {
        public ArgumentNegativeException() : base() { }

        //public ArgumentNegativeException(string paramName) : base(paramName) { }

        //public ArgumentNegativeException(string paramName, string message) : base(paramName, message) { }
    }
    public class ArgumentZeroException : ArgumentOutOfRangeException
    {
        public ArgumentZeroException() : base() { }

        //public ArgumentNegativeException(string paramName) : base(paramName) { }

        //public ArgumentNegativeException(string paramName, string message) : base(paramName, message) { }
    }
}
