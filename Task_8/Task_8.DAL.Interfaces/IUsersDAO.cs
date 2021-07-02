using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.Entities;

namespace Task_8.DAL.Interfaces
{
    public interface IUsersDAO
    {
        List<User> GetAllUsers();

        void AddUser(User user);

        void RemoveUser(Guid id);

        void Edit(Guid id, string newName, DateTime newDateOfBirth);

        void EditName(Guid id, string newName);

        void EditDateOfBirth(Guid id, DateTime newDateOfBirth);

        User GetUser(Guid id);

        User GetUser(string name);
    }
}
