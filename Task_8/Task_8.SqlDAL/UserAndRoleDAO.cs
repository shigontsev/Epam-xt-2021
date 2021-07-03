using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.DAL.Interfaces;
using Task_8.Entities;

namespace Task_8.SqlDAL
{
    public class UserAndRoleDAO : IUserAndRoleDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public void AssignRole(Guid idUser, int idRole)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO UsersAndRoles(IdUser, IdRole) " +
                    "VALUES(@IdUser, @IdRole)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@IdUser", idUser);
                command.Parameters.AddWithValue("@IdRole", idRole);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format("Cannot assign Role to User"));
            }
        }

        public void CreateRole(string nameRole)
        {
            var roles = GetRoles();
            if (roles.FirstOrDefault(r => r.Name == nameRole) != null)
            {
                throw new ArgumentException(nameof(nameRole), $"Role with name \'{nameRole}\' already exists");
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Role(Name) " +
                    "VALUES(@Name); SELECT CAST(scope_identity() AS INT) AS NewID";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Name", nameRole);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format("Cannot create new Role"));
            }
        }

        public List<Role> GetRoleByUser(Guid idUser)
        {
            var roles = GetRoles();
            var userRole = GetUserAndRoles().FindAll(r => r.IdUser == idUser);

            return roles.Where(r => userRole.FirstOrDefault(x => x.IdRole == r.Id) != null).ToList();
        }

        public List<Role> GetRoles()
        {
            var roles = new List<Role>();
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Name FROM Role", _connection);
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    roles.Add(new Role(
                        id: (int)reader["Id"],
                        name: (string)reader["Name"]));
                }
            }

            return roles;
        }

        public List<UserAndRoleNames> GetUserAndRoleNames()
        {
            var userAndRoleNames = new List<UserAndRoleNames>();

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT User.Name AS UserName, Role.Name AS RoleName FROM User "
                    + "INNER JOIN UsersAndRoles ON User.Id = UsersAndRoles.IdUser "
                    + "INNER JOIN Role ON UsersAndRoles.IdRole = Role.Id", _connection);
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userAndRoleNames.Add(new UserAndRoleNames(
                        userName: (string)reader["UserName"],
                        roleName: (string)reader["RoleName"]));
                }
            }

            return userAndRoleNames;
        }

        public List<UserAndRole> GetUserAndRoles()
        {
            var userAndRoles = new List<UserAndRole>();
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT IdUser, IdRole FROM UsersAndRoles", _connection);
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userAndRoles.Add(new UserAndRole(
                        idUser: (Guid)reader["IdUser"],
                        idRole: (int)reader["IdRole"]));
                }
            }

            return userAndRoles;
        }
    }
}
