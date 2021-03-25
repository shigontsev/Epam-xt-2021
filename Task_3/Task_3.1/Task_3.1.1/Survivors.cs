using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1._1
{
    public class Survivors
    {
        private Queue<string> listHuman;

        public int Length => listHuman.Count;

        public Survivors(int n)
        {
            CreatListHuman(n);
        }

        private void CreatListHuman(int n)
        {
            listHuman = new Queue<string>();
            for (int i = 1; i <= n; i++)
            {
                listHuman.Enqueue($"{i}");
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
                    Console.WriteLine(this.ToString());
                    OutOfListByMod(N, ref schet);
                    round++;
                    Console.WriteLine($"Раунд {round}. Вычеркнут человек. Людей осталось: {Length}");
                }
            }
            catch (EndGameException)
            {
                Console.WriteLine("ВЫВОД: Игра окончена. Невозможно вычеркнуть больше людей.");
            }
        }

        private void OutOfListByMod(int N, ref int schet)
        {
            while (true)
            {
                schet++;
                if (Length < N)
                {
                    throw new EndGameException();
                }
                else if (schet % N == 0)
                {
                    listHuman.Dequeue();
                    break;
                }
                else
                {
                    listHuman.Enqueue(listHuman.Dequeue());
                }
            }
        }
        public override string ToString()
        {
            return string.Join(' ', listHuman.ToArray());
        }
    }

    public class EndGameException : ArgumentOutOfRangeException
    {
        public EndGameException() : base() { }
    }

    public class NegativeException : ArgumentOutOfRangeException
    {
        public NegativeException() : base() { }
    }

    public class ArgumentZeroException : ArgumentOutOfRangeException
    {
        public ArgumentZeroException() : base() { }
    }
}
