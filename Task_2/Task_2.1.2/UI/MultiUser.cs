using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task_2._1._2.UI
{
    public class MultiUser
    {
        private List<User> Users;
        public MultiUser()
        {
            Users = new List<User>();
        }
        public void CommandBar(ref bool boolen)
        {
            Console.WriteLine("ВЫВОД: Выберите действие");
            Console.WriteLine("1. Добавить пользователя");
            Console.WriteLine("2. Выбрать пользователя");
            Console.WriteLine("3. Очистить список пользователей");
            Console.WriteLine("4. Выход");
            Console.Write("ВВОД: ");
            switch (Input.EnterString())
            {
                case "1":
                    Add(); break;
                case "2":
                    SelectUser(); break;
                case "3":
                    Clear(); break;
                case "4":
                    boolen = false;
                    break;
                default:
                    break;
            }
            Console.WriteLine();
        }
        public void Add()
        {
            Users.Add(new User(Input.Name()));
            Console.WriteLine($"ВЫВОД: Добавлен пользователь \"{Users.Last().Name}\"");
        }
        public void SelectUser()
        {
            ShowListUsers();
            //bool boolen = true;
            User user = null;
            Console.Write("ВВОД: ");
            try
            {
                user = SelectByIndex(Input.EnterInt());
                Console.WriteLine("ВЫВОД: Пользователь " + user.ToString());
                bool boolen = true;
                while (boolen)
                {
                    user.CommandBar(ref boolen);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Не верно указан индекс. Повторите!");
            }
            //while (boolen)
            //{
            //    Console.Write("ВВОД: ");
            //    try
            //    {
            //        user = SelectByIndex(Input.EnterInt());
            //        boolen = false;
            //    }
            //    catch (Exception)
            //    {
            //        Console.WriteLine("Не верно указан индекс. Повторите!");
            //    }
            //}
            //Console.WriteLine("ВЫВОД: Пользователь " + user.ToString());
            //boolen = true;
            //while (boolen)
            //{
            //    user.CommandBar(ref boolen);
            //}
        }
        
        public void Clear()
        {
            Users.Clear();
        }
        private User SelectByIndex(int index)
        {
            return Users.ElementAt(index);
        }
        //private User SelectByName(string name)
        //{
        //    return Users.FirstOrDefault(x => x.Name == name);
        //}
        private void ShowListUsers()
        {
            Console.WriteLine("ВЫВОД: Список пользователей");
            foreach (var item in Users)
            {
                Console.WriteLine(String.Format("{0}: {1}",
                    Users.FindIndex(x=>x.Name==item.Name),item.ToString()));
            }
        }
    }
}
