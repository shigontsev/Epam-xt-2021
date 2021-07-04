using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.BLL;
using Task_8.BLL.Interfaces;
using Task_8.DAL.Interfaces;
//using Task_8.JsonDAL;
using Task_8.SqlDAL;

namespace Task_8.Dependencies
{
    public class DependencyResolver
    {
        #region SINGLETONE

        private static DependencyResolver _instance;

        public static DependencyResolver Instance {
            get{
                if (_instance is null)
                {
                    _instance = new DependencyResolver();
                }
                return _instance;
            }
        }



        #endregion


        #region JsonBD
        //private IUsersDAO UsersDAO => new UsersDAO();

        //public IUsersLogic UsersLogic => new UsersLogic(UsersDAO);

        //private IAwardsDAO AwardsDAO => new AwardsDAO();

        //public IAwardsLogic AwardsLogic => new AwardsLogic(AwardsDAO);

        //private IUsersAndAwardsDAO UsersAndAwardsDAO => new UsersAndAwardsDAO();

        //public IUsersAndAwardsLogic UsersAndAwardsLogic => new UsersAndAwardsLogic(UsersAndAwardsDAO);

        //private IUserAndRoleDAO UserAndRoleDAO => new UserAndRoleDAO();

        //public IUserAndRoleLogic UserAndRoleLogic => new UserAndRoleLogic(UserAndRoleDAO);

        //private IAuthDAO AuthDAO => new AuthDAO();

        //public IAuthLogic AuthLogic => new AuthLogic(AuthDAO);

        #endregion JsonBD

        #region SqlBD
        private IUsersDAO UsersDAO => new UsersDAO();

        public IUsersLogic UsersLogic => new UsersLogic(UsersDAO);

        private IAwardsDAO AwardsDAO => new AwardsDAO();

        public IAwardsLogic AwardsLogic => new AwardsLogic(AwardsDAO);

        private IUsersAndAwardsDAO UsersAndAwardsDAO => new UsersAndAwardsDAO();

        public IUsersAndAwardsLogic UsersAndAwardsLogic => new UsersAndAwardsLogic(UsersAndAwardsDAO);

        private IUserAndRoleDAO UserAndRoleDAO => new UserAndRoleDAO();

        public IUserAndRoleLogic UserAndRoleLogic => new UserAndRoleLogic(UserAndRoleDAO);

        private IAuthDAO AuthDAO => new AuthDAO();

        public IAuthLogic AuthLogic => new AuthLogic(AuthDAO);
        #endregion SqlBD
    }
}
