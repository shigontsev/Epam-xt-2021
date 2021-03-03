using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            while (true)
            {
                Console.WriteLine("Выбрать из предложенных:");
                Console.WriteLine("1: RECTANGLE\n" +
                    "2: TRIANGLE\n" +
                    "3: ANOTHER_TRIANGLE\n" +
                    "4: X-MAS_TREE\n" +
                    "5: SUM_OF_NUMBERS\n" +
                    "6: FONT_ADJUSTMENT\n" +
                    "7: ARRAY_PROCESSING\n" +
                    "8: NO_POSITIVE\n" +
                    "9: NON-NEGATIVE_SUM\n" +
                    "10: 2D_ARRAY\n" +
                    "21: AVERAGES\n" +
                    "22: DOUBLER\n" +
                    "23: LOWERCASE\n" +
                    "24: VALIDATOR\n");
                string a = Console.ReadLine();
                switch (a)
                {
                    case "1": Rectangle(); break;
                    case "2": Triangle(); break;
                    case "3": Another_Triangle(); break;
                    case "4": X_Mas(); break;
                    case "5": SumOfNumbers(); break;
                    case "6": FontAdjustment(); break;
                    case "7": ArrayProcessing(); break;
                    case "8": NoPositive(); break;
                    case "9": SumPositive(); break;
                    case "10": Arr2D(); break;
                    case "21": Averages(); break;
                    case "22": Doubler(); break;
                    case "23": LowerCase(); break;
                    case "24": Validator(); break;
                    default: Console.WriteLine("Повторите свой выбор"); break;
                }
                Console.ReadLine();
            }
        }
        /// <summary>
        /// 1.1.1 RECTANGLE
        /// </summary>
        public static void Rectangle()
        {
            try
            {
                Console.Write("Ввод A = ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Ввод B = ");
                int b = int.Parse(Console.ReadLine());

                if (a <= 0 || b <= 0)
                {
                    Console.WriteLine("Введены некоректные параметры");
                }
                else
                {
                    int square = a * b;
                    Console.WriteLine("Площадь = " + square);
                }
                //Console.ReadLine();
            }
            catch (Exception)
            {
                //Console.WriteLine("Выбранн не верный тип ввода значений");
            }
        }
        /// <summary>
        /// 1.1.2. TRIANGLE
        /// </summary>
        static public void Triangle()
        {
            Console.Write("Ввод N = ");
            int N = int.Parse(Console.ReadLine());
            Figure.Triangle(N);
        }
        /// <summary>
        /// 1.1.3. ANOTHER TRIANGLE
        /// </summary>
        static public void Another_Triangle()
        {
            Console.Write("Ввод N = ");
            int N = int.Parse(Console.ReadLine());
            Figure.Another_Triangle(N);
        }
        /// <summary>
        /// 1.1.4. X-MAS TREE
        /// </summary>
        static public void X_Mas()
        {
            Console.Write("Ввод N = ");
            int N = int.Parse(Console.ReadLine());
            Figure.X_Mas(N);
        }
        /// <summary>
        /// 1.1.5. SUM OF NUMBERS
        /// </summary>
        static void SumOfNumbers()
        {
            Console.Write("Ввод N = ");
            int N = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i < N; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine($"Сумма чисел кратные 3 и 5:\nSum = {sum}");
        }
        /// <summary>
        /// 1.1.6. FONT ADJUSTMENT
        /// </summary>
        static void FontAdjustment()
        {
            Font fa = new Font();
            while (true)
            {
                fa.Action();
            }
        }
        /// <summary>
        /// 1.1.7. ARRAY PROCESSING
        /// </summary>
        static void ArrayProcessing()
        {
            Array_Processing arrR = new Array_Processing(15);
            Console.WriteLine("Сгенерирован массив:");
            arrR.ShowArr();
            Console.WriteLine("Отсортирован массив:");
            arrR.Sort();
            arrR.ShowArr();
            arrR.Max();
            arrR.Min();
        }
        /// <summary>
        /// 1.1.8. NO POSITIVE
        /// </summary>
        static void NoPositive()
        {
            int[,,] arr3D = new int[4, 4, 4];
            Console.WriteLine("Сгенерирован 3D массив");
            No_Positive.ArrRandom(arr3D);
            No_Positive.Show(arr3D);
            Console.WriteLine("Приунывший 3D массив");
            No_Positive.NoPositive(arr3D);
            No_Positive.Show(arr3D);
        }
        /// <summary>
        /// 1.1.9. NON-NEGATIVE SUM
        /// </summary>
        static void SumPositive()
        {
            int[] arr = new int[10];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-10, 10);
            }
            Console.WriteLine("Массив:");
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.Write("\nСумма положительных значений = ");
            int sum = 0;
            foreach (var item in arr)
            {
                if (item > 0)
                    sum += item;
            }Console.WriteLine(sum);
        }
        /// <summary>
        /// 1.1.10. NON-NEGATIVE SUM
        /// </summary>
        static void Arr2D()
        {
            int[,] arr = new int[5,4];
            Arr_2D.ArrGen(arr);
            Console.WriteLine("Массив: ");
            Arr_2D.ArrShow(arr);
            Console.Write("Сумма элементво в четной позиции = "+Arr_2D.Sum_Chet(arr));
        }
        /// <summary>
        /// 1.2.1. AVERAGES
        /// </summary>
        static void Averages()
        {
            Console.Write("ВВОД: ");
            string text = "";
            //Ручной ввод? Да|Нет
            if (false)
            {
                text = Console.ReadLine();
            }
            else
            {
                text = "Викентий хорошо отметил день рождения: покушал пиццу, посмотрел кино, пообщался со студентами в чате";
                Console.WriteLine(text);
            }
            //Получаем дробое значение
            Console.WriteLine("ВЫВОД: " + Task_1_2.Averages(text));
        }
        /// <summary>
        /// 1.2.2. DOUBLER
        /// </summary>
        static void Doubler()
        {
            string text = "";
            string text2 = "";
            //Ручной ввод? Да|Нет
            if (false)
            {
                Console.Write("ВВОД 1: ");
                text = Console.ReadLine();
                Console.Write("ВВОД 2: ");
                text2 = Console.ReadLine();
            }
            else
            {
                Console.Write("ВВОД 1: ");
                text = "написать программу, которая";
                Console.WriteLine(text);
                Console.Write("ВВОД 2: ");
                text2 = "описание";
                Console.WriteLine(text2);
            }
            Console.WriteLine("ВЫВОД: " + Task_1_2.Doubler(text, text2));
        }
        /// <summary>
        /// 1.2.3. LOWERCASE
        /// </summary>
        static void LowerCase()
        {
            Console.Write("ВВОД: ");
            string text = "";
            //Ручной ввод? Да|Нет
            if (false)
            {
                text = Console.ReadLine();
            }
            else
            {
                text = "Антон хорошо начал утро: послушал Стинга, выпил кофе и посмотрел Звёздные Войны";
                Console.WriteLine(text);
            }
            Console.WriteLine("ВЫВОД: " + Task_1_2.LowerCase(text));
        }
        /// <summary>
        /// 1.2.4. VALIDATOR
        /// </summary>
        static void Validator()
        {
            Console.Write("ВВОД: ");
            string text = "";
            //Ручной ввод? Да|Нет
            if (false)
            {
                text = Console.ReadLine();
            }
            else
            {
                text = "я плохо учил русский язык. забываю начинать предложения с заглавной. хорошо, что можно написать программу!";
                Console.WriteLine(text);
            }
            Console.WriteLine("ВЫВОД: " + Task_1_2.Validator(text));
        }

    }
}
