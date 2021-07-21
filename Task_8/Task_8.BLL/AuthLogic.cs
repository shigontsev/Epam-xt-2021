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
    public class AuthLogic : IAuthLogic
    {
        private IAuthDAO _authDAO;

        public AuthLogic(IAuthDAO authDAO)
        {
            _authDAO = authDAO;
        }

        public void CreatPassword(Guid idUser, string password)
        {
            _authDAO.CreatPassword(idUser, password);
        }

        public bool IsAuthentication(string userName, string password)
        {
            return _authDAO.IsAuthentication(userName, password);
        }
    }
}
