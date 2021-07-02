using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8.Entities
{
    public class UserAndRoleNames
    {
        public string UserName { get; private set; }

        public string RoleName { get; private set; }

        public UserAndRoleNames(string userName, string roleName)
        {
            UserName = userName;
            RoleName = roleName;
        }
    }
}
