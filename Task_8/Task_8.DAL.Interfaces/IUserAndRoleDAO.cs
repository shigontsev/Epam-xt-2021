using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.Entities;

namespace Task_8.DAL.Interfaces
{
    public interface IUserAndRoleDAO
    {
        List<UserAndRole> GetUserAndRoles();

        List<Role> GetRoles();

        void CreateRole(string nameRole);

        void AssignRole(Guid idUser, int idRole);

        Role GetRoleByUser(Guid idUser);
    }
}
