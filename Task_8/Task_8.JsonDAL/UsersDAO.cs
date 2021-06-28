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
        public List<User> GetAllUsers()
        {
            var users = JsonDAO<User>.Deserialize(FilePath.JsonUsersPath);

            return users ?? new List<User>();
        }

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

            //remove awards for current user in entities UsersAndAwards
            var UaA = JsonDAO<UsersAndAwards>.Deserialize(FilePath.JsonUsersAndAwardsPath).TakeWhile(x=>x.IdUser != id).ToList();
            JsonDAO<UsersAndAwards>.Serialize(FilePath.JsonUsersAndAwardsPath, UaA);
        }

        public void Edit(Guid id, string newName, DateTime newDateOfBirth)
        {
            var users = GetAllUsers();
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user is null)
            {
                throw new ArgumentNullException(nameof(id), $"User at Id {id} doesn't exist");
            }

            user.Edit(newName, newDateOfBirth);

            JsonDAO<User>.Serialize(FilePath.JsonUsersPath, users);
        }

        public void EditDateOfBirth(Guid id, DateTime newDateOfBirth)
        {
            var users = GetAllUsers();
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user is null)
            {
                throw new ArgumentNullException(nameof(id), $"User at Id {id} doesn't exist");
            }

            user.EditDateOfBirth(newDateOfBirth);

            JsonDAO<User>.Serialize(FilePath.JsonUsersPath, users);
        }

        public void EditName(Guid id, string newName)
        {
            var users = GetAllUsers();
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user is null)
            {
                throw new ArgumentNullException(nameof(id), $"User at Id {id} doesn't exist");
            }

            user.EditName(newName);

            JsonDAO<User>.Serialize(FilePath.JsonUsersPath, users);
        }

        public User GetUser(Guid id)
        {
            return GetAllUsers().FirstOrDefault(u => u.Id == id);
        }
    }
}
