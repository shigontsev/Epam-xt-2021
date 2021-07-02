using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.Common.Helpers;
using Task_8.DAL.Interfaces;
using Task_8.Entities;

namespace Task_8.JsonDAL
{
    public class AuthDAO : IAuthDAO
    {
        public bool IsAuthentication(string userName, string password)
        {
            var user = JsonDAO<User>.Deserialize(FilePath.JsonUsersPath).FirstOrDefault(u => u.Name == userName);
            if (user is null)
            {
                return false;
            }
            var passwordHash = JsonDAO<AuthData>.Deserialize(FilePath.JsonAuthDataPath).FirstOrDefault(p => p.IdUser == user.Id);
            if (passwordHash is null)
            {
                return false;
            }
            return Hasher.VerifyHashedPassword(passwordHash.HashPass, password);
        }

    }
}
