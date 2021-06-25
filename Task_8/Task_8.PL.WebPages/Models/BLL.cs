using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_8.BLL.Interfaces;
using Task_8.Dependencies;

namespace Task_8.PL.WebPages.Models
{
    public static class BLL
    {
        public static IUsersLogic UsersBLL = DependencyResolver.Instance.UsersLogic;

        public static IAwardsLogic AwardsBLL = DependencyResolver.Instance.AwardsLogic;

        public static IUsersAndAwardsLogic UsersAndAwardsBLL = DependencyResolver.Instance.UsersAndAwardsLogic;
    }
}