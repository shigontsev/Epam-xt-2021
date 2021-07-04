using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8.Entities
{
    public class UsersAndAwardsFull
    {
        public int Id { get; private set; }

        public Guid IdUser { get; private set; }

        public string NameUser { get; private set; }

        public Guid IdAward { get; private set; }

        public string TitleAward { get; private set; }


        public UsersAndAwardsFull(int id, Guid idUser, Guid idAward, string nameUser, string titleAward)
        {
            Id = id;
            IdUser = idUser;
            IdAward = idAward;
            NameUser = nameUser;
            TitleAward = titleAward;
        }
    }
}
