using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task_2._1._2.UI
{
    public class MainMenu
    {
        private List<User> Users;

        public MainMenu()
        {
            Users = new List<User>();
        }

        public void CommandBar(ref bool exit)
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
                    exit = false;
                    break;
                default:
                    break;
            }
            Console.WriteLine();
        }

        private void Add()
        {
            Users.Add(new User(Input.Name()));
            Console.WriteLine($"ВЫВОД: Добавлен пользователь \"{Users.Last().Name}\"");
        }

        private void SelectUser()
        {
            ShowListUsers();
            User user = null;
            bool loginSuccesToUSer = true;
            Console.Write("ВВОД: ");
            try
            {
                user = SelectByIndex(Input.EnterInt());                
            }
            catch (Exception)
            {
                Console.WriteLine("Не верно указан индекс. Повторите!");
                loginSuccesToUSer = false;
            }
            if (loginSuccesToUSer)
            {
                Console.WriteLine("ВЫВОД: Пользователь " + user.ToString());
                bool exit = true;
                MenuFigures menuCurrentUser = new MenuFigures(user);
                while (exit)
                {
                    menuCurrentUser.CommandBar(ref exit);
                }
            }
        }
        
        private void Clear()
        {
            Users.Clear();
        }

        private User SelectByIndex(int index)
        {
            return Users.ElementAt(index);
        }

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
