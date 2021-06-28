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

        public List<UsersAndAwards> GetAll()
        {
            return _usersAndAwardsDAO.GetAll();
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
        
        public bool AssignAwardToUser(Guid idAward, Guid idUser)
        {
            return _usersAndAwardsDAO.AssignAwardToUser(idAward, idUser);
        }

        public bool AssignAwardToUser(UsersAndAwards usersAndAwards)
            => _usersAndAwardsDAO.AssignAwardToUser(usersAndAwards.IdAward, usersAndAwards.IdUser);

        public bool UnAssignAwardToUser(Guid idAward, Guid idUser)
        {
            return _usersAndAwardsDAO.UnAssignAwardToUser(idAward, idUser);
        }

        public bool UnAssignAwardToUser(UsersAndAwards usersAndAwards)
            => _usersAndAwardsDAO.UnAssignAwardToUser(usersAndAwards.IdAward, usersAndAwards.IdUser);

        public List<Award> GetAwardsNotAvailableByUser(Guid idUser)
        {
            return _usersAndAwardsDAO.GetAwardsNotAvailableByUser(idUser);
        }

        public List<Award> GetAwardsNotAvailableByUser(User user)
            => GetAwardsNotAvailableByUser(user.Id);

        public List<User> GetUsersNotAvailableByAward(Guid idAward)
        {
            return _usersAndAwardsDAO.GetUsersNotAvailableByAward(idAward);
        }

        public List<User> GetUsersNotAvailableByAward(Award award)
            => GetUsersNotAvailableByAward(award.Id);
    }
}
