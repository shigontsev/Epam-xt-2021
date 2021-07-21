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
    public class UserAndRoleLogic : IUserAndRoleLogic
    {
        private IUserAndRoleDAO _userAndRoleDAO;

        public UserAndRoleLogic(IUserAndRoleDAO userAndRoleDAO)
        {
            _userAndRoleDAO = userAndRoleDAO;
        }

        public void AssignRole(Guid idUser, int idRole)
        {
            _userAndRoleDAO.AssignRole(idUser, idRole);
        }

        public void AssignRole(UserAndRole userAndRole) 
            => AssignRole(userAndRole.IdUser, userAndRole.IdRole);

        public void CreateRole(string nameRole)
        {
            _userAndRoleDAO.CreateRole(nameRole);
        }

        public List<Role> GetRoleByUser(Guid idUser)
        {
            return _userAndRoleDAO.GetRoleByUser(idUser);
        }

        public List<Role> GetRoleByUser(User User)
            => GetRoleByUser(User.Id);

        public List<Role> GetRoles()
        {
            return _userAndRoleDAO.GetRoles();
        }

        public List<UserAndRoleNames> GetUserAndRoleNames()
        {
            return _userAndRoleDAO.GetUserAndRoleNames();
        }

        public List<UserAndRole> GetUserAndRoles()
        {
            return _userAndRoleDAO.GetUserAndRoles();
        }
    }
}
