using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.DAL.Interfaces;
using Task_8.Entities;

namespace Task_8.JsonDAL
{
    public class UsersAndAwardsDAO : IUsersAndAwardsDAO
    {
        public List<UsersAndAwards> GetAll()
        {
            var list = JsonDAO<UsersAndAwards>.Deserialize(FilePath.JsonUsersAndAwardsPath);

            return list;
        }

        public List<Award> GetAwardsByUser(Guid idUser)
        {
            var idAwards = GetAll().FindAll(UaA => UaA.IdUser == idUser).Select(a=>a.IdAward).ToList();
            if(idAwards.Count == 0)
            {
                return new List<Award>();
            }
            var awards = JsonDAO<Award>.Deserialize(FilePath.JsonAwardsPath).FindAll(a=>idAwards.Contains(a.Id)).ToList();

            return awards;
        }

        public List<User> GetUsersByAward(Guid idAward)
        {
            var idUsers = GetAll().FindAll(UaA => UaA.IdAward == idAward).Select(a => a.IdUser).ToList();
            if(idUsers.Count == 0)
            {
                return new List<User>();
            }
            var users = JsonDAO<User>.Deserialize(FilePath.JsonUsersPath).FindAll(a => idUsers.Contains(a.Id)).ToList();

            return users;
        }
    }
}
