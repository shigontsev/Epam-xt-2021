using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.Common.Helpers;
using Task_8.DAL.Interfaces;
using Task_8.Entities;

namespace Task_8.SqlDAL
{
    public class AuthDAO : IAuthDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public void CreatPassword(Guid idUser, string password)
        {
            string hashPass = Hasher.HashPassword(password);

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO User(IdUser, HashPass, DateOfBirth) " +
                    "VALUES(@IdUser, @HashPass, @DateOfBirth)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@IdUser", idUser);
                command.Parameters.AddWithValue("@HashPass", hashPass);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format("Cannot creat Password"));
            }
        }

        public bool IsAuthentication(string userName, string password)
        {
            User user = null;
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Name, DateOfBirth FROM User "
                    + "WHERE Name = @Name", _connection);
                command.Parameters.AddWithValue("@Name", userName);
                _connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user = new User(
                        id: (Guid)reader["Id"],
                        name: (string)reader["Name"],
                        dateOfBirth: (DateTime)reader["DateOfBirth"]
                        );
                    break;
                }
            }
            if (user is null)
            {
                return false;
            }

            AuthData passwordHash = null;
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT IdUser, HashPass FROM AuthData "
                    + "WHERE IdUser = @IdUser", _connection);
                command.Parameters.AddWithValue("@IdUser", user.Id);
                _connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    passwordHash = new AuthData(
                        idUser: (Guid)reader["IdUser"],
                        hashPass: (string)reader["HashPass"]
                        );
                    break;
                }
            }
            if (passwordHash is null)
            {
                return false;
            }

            return Hasher.VerifyHashedPassword(passwordHash.HashPass, password);
        }
    }
}
