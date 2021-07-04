using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8.Entities
{
    public class UsersAndAwards
    {
        public int Id { get; private set; }

        public Guid IdUser { get; private set; }

        public Guid IdAward { get; private set; }

        public UsersAndAwards(int id, Guid idUser, Guid idAward)
        {
            Id = id;
            IdUser = idUser;
            IdAward = idAward;
        }
    }
}
