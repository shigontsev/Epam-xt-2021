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

            JsonDAO<UserAndRole>.Serialize(FilePath.JsonUsersAndAwardsPath, userAndRole);
        }

        public void CreateRole(string nameRole)
        {
            var roles = GetRoles();
            if (roles.FirstOrDefault(r=>r.Name==nameRole) != null)
            {
                throw new ArgumentException(nameof(nameRole), $"Role with name \'{nameRole}\' already exists");
            }

            roles.Add(new Role(roles.Count == 0 ? 0 : roles.Last().Id + 1, nameRole));
        }

        public Role GetRoleByUser(Guid idUser)
        {
            var roles = GetRoles();
            var idRole = GetUserAndRoles().First(r => r.IdUser == idUser).IdRole;
            return GetRoles().First(r=>r.Id == idRole);
        }
    }
}
