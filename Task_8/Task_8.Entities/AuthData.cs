using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8.Entities
{
    public class AuthData
    {      
        public Guid IdUser { get; private set; }

        public string HashPass { get; private set; }

        public AuthData(Guid idUser, string hashPass)
        {
            IdUser = idUser;
            HashPass = hashPass ?? throw new ArgumentNullException(nameof(hashPass));
        }
    }
}
