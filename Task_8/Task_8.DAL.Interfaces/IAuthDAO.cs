using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.Entities;

namespace Task_8.DAL.Interfaces
{
    public interface IAuthDAO
    {
        bool IsAuthentication(string userName, string password);

        void CreatPassword(Guid idUser, string password);
    }
}
