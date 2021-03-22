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
                listHuman.Add($"Human {i}");
            }
            Console.WriteLine($"ВЫВОД: Сгенерирован круг людей из {Length} человек");
        }

        public void Start(int N)
        {
            try
            {
                int round = 0;
                while (true)
                {
                    OutOfListByMod(N);
                    round++;
                    Console.WriteLine($"Раунд {round}. Вычеркнут человек. Людей осталось: {Length}");
                }
            }
            catch (ArgumentNegativeException)
            {
                Console.WriteLine("ВЫВОД: Игра окончена. Невозможно вычеркнуть больше людей.");
            }
        }

        public void OutOfListByMod(int N)
        {
            if (Length < N)
            {
                throw new ArgumentNegativeException(nameof(Length));
            }
                
            for (int i = 0; i < Length; i++)
            {
                if ((i + 1) % N == 0)
                {
                    listHuman[i] = null;
                }
            }
            listHuman.Remove(null);
        }
    }
    public class ArgumentNegativeException : ArgumentOutOfRangeException
    {
        public ArgumentNegativeException() : base() { }
        public ArgumentNegativeException(string paramName) : base(paramName) { }
        public ArgumentNegativeException(string paramName, string message) : base(paramName, message) { }
    }
}
