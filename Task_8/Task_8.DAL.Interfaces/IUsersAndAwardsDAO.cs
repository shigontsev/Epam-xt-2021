using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.Entities;

namespace Task_8.DAL.Interfaces
{
    public interface IUsersAndAwardsDAO
    {
        List<UsersAndAwards> GetAll();

        List<Award> GetAwardsByUser(Guid idUser);

        List<User> GetUsersByAward(Guid idAward);

        bool AssignAwardToUser(Guid idAward, Guid idUser);

        bool UnAssignAwardToUser(Guid idAward, Guid idUser);

        List<Award> GetAwardsNotAvailableByUser(Guid idUser);

        List<User> GetUsersNotAvailableByAward(Guid idAward);

        List<UsersAndAwardsFull> GetAllFull();

        UsersAndAwardsFull GetRowFull(int idRow);

        UsersAndAwardsFull GetRowFull(Guid idUser, Guid idAward);
    }
}
