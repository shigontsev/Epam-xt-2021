using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.DAL.Interfaces;
using Task_8.Entities;

namespace Task_8.JsonDAL
{
    public class UserAndRoleDAO : IUserAndRoleDAO
    {
        public List<UserAndRole> GetUserAndRoles()
        {
            var userAndRole = JsonDAO<UserAndRole>.Deserialize(FilePath.JsonUserAndRolePath);

            return userAndRole ?? new List<UserAndRole>();
        }

        public List<Role> GetRoles()
        {
            var roles = JsonDAO<Role>.Deserialize(FilePath.JsonRolesPath);

            return roles ?? new List<Role>();
        }

        public void AssignRole(Guid idUser, int idRole)
        {
            var userAndRole = JsonDAO<UserAndRole>.Deserialize(FilePath.JsonUserAndRolePath);

            userAndRole.Add(new UserAndRole(idUser, idRole));

            JsonDAO<UserAndRole>.Serialize(FilePath.JsonUserAndRolePath, userAndRole);
        }

        public void CreateRole(string nameRole)
        {
            var roles = GetRoles();
            if (roles.FirstOrDefault(r=>r.Name==nameRole) != null)
            {
                throw new ArgumentException(nameof(nameRole), $"Role with name \'{nameRole}\' already exists");
            }

            roles.Add(new Role(roles.Count == 0 ? 0 : roles.Last().Id + 1, nameRole));
            JsonDAO<Role>.Serialize(FilePath.JsonRolesPath, roles);
        }

        public List<Role> GetRoleByUser(Guid idUser)
        {
            var roles = GetRoles();
            var userRole = GetUserAndRoles().FindAll(r => r.IdUser == idUser);

            return roles.Where(r=>userRole.FirstOrDefault(x=>x.IdRole==r.Id)!=null).ToList();
        }

        public List<UserAndRoleNames> GetUserAndRoleNames()
        {
            var roles = GetRoles();
            var users = JsonDAO<User>.Deserialize(FilePath.JsonUsersPath);
            var userAndRole = GetUserAndRoles();

            var result = new List<UserAndRoleNames>();
            foreach (var row in userAndRole)
            {
                string userName = users.First(u => u.Id == row.IdUser).Name;
                string roleName = roles.First(r => r.Id == row.IdRole).Name;
                result.Add(new UserAndRoleNames(userName, roleName));
            }

            return result;
        }
    }
}
