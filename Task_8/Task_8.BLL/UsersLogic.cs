using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.BLL.Interfaces;
using Task_8.DAL.Interfaces;
using Task_8.Entities;

namespace Task_8.BLL
{
    public class UsersLogic : IUsersLogic
    {
        private IUsersDAO _usersDAO;

        public UsersLogic(IUsersDAO usersDAO)
        {
            _usersDAO = usersDAO;
        }

        public void AddUser(User user)
        {
            _usersDAO.AddUser(user);
        }

        public List<User> GetAllUsers()
        {
            return _usersDAO.GetAllUsers();
        }

        public void RemoveUser(Guid id)
        {
            _usersDAO.RemoveUser(id);
        }

        public void RemoveUser(User user) => RemoveUser(user.Id);
    }
}
