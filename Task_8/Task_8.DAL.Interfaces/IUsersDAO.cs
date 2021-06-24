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
        void AddUser(User user);

        void RemoveUser(Guid id);

        List<User> GetAllUsers();
    }
}
