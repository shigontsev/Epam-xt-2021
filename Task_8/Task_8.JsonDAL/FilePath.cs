using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8.JsonDAL
{
    internal static class FilePath
    {
        private static string JsonFilesPath = AppDomain.CurrentDomain.BaseDirectory + @"\App_Data\";

        public static string JsonUsersPath = JsonFilesPath + "Users.json";

        public static string JsonAwardsPath = JsonFilesPath + "Awards.json";

        public static string JsonUsersAndAwardsPath = JsonFilesPath + "UsersAndAwards.json";

        public static string JsonRolesPath = JsonFilesPath + "Roles.json";

        public static string JsonAuthDataPath = JsonFilesPath + "AuthData.json";

        public static string JsonUserAndRolePath = JsonFilesPath + "UserAndRole.json";
    }
}
