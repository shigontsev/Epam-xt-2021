﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.Entities;

namespace Task_8.BLL.Interfaces
{
    public interface IUserAndRoleLogic
    {
        List<UserAndRole> GetUserAndRoles();

        List<Role> GetRoles();

        void CreateRole(string nameRole);

        void AssignRole(Guid idUser, int idRole);

        void AssignRole(UserAndRole userAndRole);

        List<Role> GetRoleByUser(Guid idUser);

        List<Role> GetRoleByUser(User User);

        List<UserAndRoleNames> GetUserAndRoleNames();
    }
}
