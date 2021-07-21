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

        public List<User> GetAllUser()
        {
            return _usersDAO.GetAllUsers();
        }

        public void AddUser(User user)
        {
            _usersDAO.AddUser(user);
        }
        
        public void RemoveUser(Guid id)
        {
            _usersDAO.RemoveUser(id);
        }

        public void RemoveUser(User user) => RemoveUser(user.Id);

        public void Edit(Guid id, string newName, DateTime newDateOfBirth)
        {
            _usersDAO.Edit(id, newName, newDateOfBirth);
        }

        public void EditDateOfBirth(Guid id, DateTime newDateOfBirth)
        {
            _usersDAO.EditDateOfBirth(id, newDateOfBirth);
        }

        public void EditName(Guid id, string newName)
        {
            _usersDAO.EditName(id, newName);
        }

        public User GetUser(Guid id)
        {
            return _usersDAO.GetUser(id);
        }

        public User GetUser(User user)
            => GetUser(user.Id);

        public User GetUser(string name)
        {
            return _usersDAO.GetUser(name);
        }
    }
}
