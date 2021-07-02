using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Task_8.Dependencies;

namespace Task_8.PL.WebPages.Models
{
    public class CalculatorRoleProvider : RoleProvider
    {

        public override bool IsUserInRole(string username, string roleName)
        {
            var userAndRoleBll = DependencyResolver.Instance.UserAndRoleLogic;

            var userRoleName = userAndRoleBll.GetUserAndRoleNames()
                .FirstOrDefault(x => x.UserName == username && x.RoleName == roleName);

            return userRoleName !=null;
        }

        public override string[] GetRolesForUser(string username)
        {
            var user = DependencyResolver.Instance.UsersLogic.GetUser(username);
            var rolseUser = DependencyResolver.Instance.UserAndRoleLogic.GetRoleByUser(user);

            if (rolseUser != null)
            {
                var result = new string[rolseUser.Count];
                int index = 0;
                foreach (var item in rolseUser)
                {
                    result[index] = item.Name;
                    index++;
                }
                return result;
            }
            else
            {
                return new string[] { };
            }
        }

        #region Not implements
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion Not implements
    }
}