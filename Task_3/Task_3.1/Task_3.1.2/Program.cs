﻿using System;

namespace Task_3._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Введите текст: ");
            string text = "К вам пришёл редактор модного журнала. Ему очень нужна программа, которую он описал ниже. " +
                "Задан английский текст.Ваша задача понять, какие слова автор «любит» больше всего и " +
                "подловить его на однообразности речи. Или, наоборот, похвалить за разнообразие. " +
                "Для каждого слова в тексте указать, сколько раз оно встречается. " +
                "Подумайте, имеет ли значение регистр, какие разделители могут использоваться в тексте. " +
                "Попробуйте использовать свои наработки из Task 1.2. «String, not Sting». " +
                "Ввод и вывод также придумайте сами. В рамках консоли постарайтесь создать приятный и " +
                "понятный интерфейс – вашей программой будет пользоваться профессионал журналистики.";
            Console.WriteLine(text);
            //string text = Console.ReadLine();
            Console.WriteLine();
            TextAnalysis frq = new TextAnalysis(text);
            //frq.GetInfo();

            frq.SortByCount();
            //frq.SortByValue();
            frq.GetInfo();

            Console.ReadLine();
        }
    }
}
