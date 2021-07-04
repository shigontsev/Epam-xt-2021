using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.Dependencies;
using Task_8.Entities;

namespace Task_8.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> listA = new List<string>();
            //listA.Add("a");
            //listA.Add("b");
            //listA.Add("b");

            //List<string> listB = new List<string>();
            //listB.Add("a");
            //listB.Add("b");

            //foreach (var item in listA.FindAll(x=>x=="c").ToList())
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine(listA.FindAll(x => x == "c").ToList().Count);

            var bllUsers = DependencyResolver.Instance.UsersLogic;

            ShowUsers(bllUsers.GetAllUser());
            //bllUsers.AddUser(new User("Bob", new DateTime(year: 1990, month: 6, day: 11)));
            bllUsers.Edit(Guid.Parse("622562c0-51d9-4336-bb77-b838e23a5317"),
                "Fedr", new DateTime(year: 1985, month: 1, day: 1));

            ShowUsers(bllUsers.GetAllUser());

            Console.ReadLine();
        }


        static void ShowUsers(List<User> users)
        {
            if (users.Count == 0)
            {
                Console.WriteLine("List users is empty"+Environment.NewLine);
                return;
            }

            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}; Name: {user.Name}; Age: {user.Age}");
            }
            Console.WriteLine();
        }
    }
}
