using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.DAL.Interfaces;
using Task_8.Entities;

namespace Task_8.JsonDAL
{
    public class UsersDAO : IUsersDAO
    {
        public void AddUser(User user)
        {
            var users = GetAllUsers();

            var isContains = users.FirstOrDefault(u => u.Name == user.Name);
            if (isContains != null)
            {
                throw new ArgumentException(nameof(user.Name), $"User with name \'{user.Name}\' already exists");
            }

            users.Add(user);
            JsonDAO<User>.Serialize(FilePath.JsonUsersPath, users);
        }

        public List<User> GetAllUsers()
        {
            var users = JsonDAO<User>.Deserialize(FilePath.JsonUsersPath);

            return users;
        }

        public void RemoveUser(Guid id)
        {
            var users = GetAllUsers();

            var isContains = users.FirstOrDefault(u => u.Id == id);
            if (isContains == null)
            {
                throw new ArgumentNullException(nameof(id), $"User at Id {id} doesn't exist");
            }

            users.Remove(isContains);
            JsonDAO<User>.Serialize(FilePath.JsonUsersPath, users);
        }
    }
}
