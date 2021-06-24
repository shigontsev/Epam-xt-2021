using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.Entities;

namespace Task_8.BLL.Interfaces
{
    public interface IUsersLogic
    {
        void AddUser(User user);

        void RemoveUser(Guid id);

        void RemoveUser(User user);

        List<User> GetAllUsers();
    }
}
