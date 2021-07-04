using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8.Entities
{
    public class UserAndRole
    {
        public Guid IdUser { get; private set; }

        public int IdRole { get; private set; }

        public UserAndRole(Guid idUser, int idRole)
        {
            IdUser = idUser;
            IdRole = idRole;
        }
    }
}
