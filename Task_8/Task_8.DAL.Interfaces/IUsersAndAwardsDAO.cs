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
        List<Award> GetAwardsByUser(Guid idUser);

        List<User> GetUsersByAward(Guid idAward);

        List<UsersAndAwards> GetAll();
    }
}
