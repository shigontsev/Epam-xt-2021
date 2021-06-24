using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.Entities;

namespace Task_8.BLL.Interfaces
{
    public interface IUsersAndAwardsLogic
    {
        List<Award> GetAwardsByUser(Guid idUser);

        List<Award> GetAwardsByUser(User user);

        List<User> GetUsersByAward(Guid idAward);

        List<User> GetUsersByAward(Award award);
    }
}
