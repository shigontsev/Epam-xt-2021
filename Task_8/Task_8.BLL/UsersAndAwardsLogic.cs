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
    public class UsersAndAwardsLogic : IUsersAndAwardsLogic
    {
        private IUsersAndAwardsDAO _usersAndAwardsDAO;

        public UsersAndAwardsLogic(IUsersAndAwardsDAO usersAndAwardsDAO)
        {
            _usersAndAwardsDAO = usersAndAwardsDAO;
        }

        public List<Award> GetAwardsByUser(Guid idUser)
        {
            return _usersAndAwardsDAO.GetAwardsByUser(idUser);
        }

        public List<Award> GetAwardsByUser(User user) => GetAwardsByUser(user.Id);

        public List<User> GetUsersByAward(Guid idAward)
        {
            return _usersAndAwardsDAO.GetUsersByAward(idAward);
        }

        public List<User> GetUsersByAward(Award award) => GetUsersByAward(award.Id);
    }
}
