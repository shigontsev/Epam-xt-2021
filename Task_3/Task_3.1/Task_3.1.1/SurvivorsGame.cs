using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1._1
{
    public class SurvivorsGame
    {
        private Queue<int> listHuman;

        public int Length => listHuman.Count;

        public SurvivorsGame(int n)
        {
            CreatListHuman(n);
        }

        private void CreatListHuman(int n)
        {
            listHuman = new Queue<int>();
            for (int i = 1; i <= n; i++)
            {
                listHuman.Enqueue(i);
            }
            Console.WriteLine($"ВЫВОД: Сгенерирован круг людей из {Length} человек");
        }

        public void Start(int N)
        {
            int round = 0;
            int counter = 0;
            bool dropout = true;

            do
            {
                Console.WriteLine(this.ToString());
                dropout = OutOfListByMod(N, ref counter);
                round++;
                Console.WriteLine($"Раунд {round}. Вычеркнут человек. Людей осталось: {Length}");
            } while (dropout);

            Console.WriteLine("ВЫВОД: Игра окончена. Невозможно вычеркнуть больше людей.");
        }

        private bool OutOfListByMod(int N, ref int counter)
        {
            while (true)
            {
                counter++;
                if (Length < N)
                {
                    return false;
                }
                else if (counter % N == 0)
                {
                    listHuman.Dequeue();
                    return true;
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
