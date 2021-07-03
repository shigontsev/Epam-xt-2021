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
    public class UsersAndAwardsDAO : IUsersAndAwardsDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        /// <summary>
        /// Присвоить награду пользователю
        /// </summary>
        /// <param name="idAward"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public bool AssignAwardToUser(Guid idAward, Guid idUser)
        {
            var isContains = GetAll().FirstOrDefault(x => (x.IdAward == idAward && x.IdUser == idUser));
            if (isContains != null)
            {
                return false;
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO UsersAndAwards(IdUser, IdAward) " +
                    "VALUES(@IdUser, @IdAward); SELECT CAST(scope_identity() AS INT) AS NewID";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@IdUser", idUser);
                command.Parameters.AddWithValue("@IdAward", idAward);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    return false;
            }
            return true;
        }

        public List<UsersAndAwards> GetAll()
        {
            var usersAndAwards = new List<UsersAndAwards>();
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Id, IdUser, IdAward FROM UsersAndAwards", _connection);
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    usersAndAwards.Add(new UsersAndAwards(
                        id: (int)reader["Id"],
                        idUser: (Guid)reader["IdUser"],
                        idAward: (Guid)reader["IdAward"]));
                }
            }

            return usersAndAwards;
        }

        /// <summary>
        /// Возвращает колекцию с полной строкой
        /// </summary>
        /// <returns></returns>
        public List<UsersAndAwardsFull> GetAllFull()
        {
            var usersAndAwardsFull = new List<UsersAndAwardsFull>();
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT UsersAndAwards.Id AS Id, User.Id AS IdUser, Award.Id AS IdAward, User.Name AS UserName, Award.Title AS TitleAward FROM User "
                    + "INNER JOIN UsersAndAwards ON User.Id = UsersAndAwards.IdUser "
                    + "INNER JOIN Award ON UsersAndAwards.IdAward = Award.Id", _connection);
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    usersAndAwardsFull.Add(new UsersAndAwardsFull(
                        id: (int)reader["Id"],
                        idUser: (Guid)reader["IdUser"],
                        idAward: (Guid)reader["IdAward"],
                        nameUser: (string)reader["NameUser"],
                        titleAward: (string)reader["TitleAward"]));
                }
            }

            return usersAndAwardsFull;
        }

        public List<Award> GetAwardsByUser(Guid idUser)
        {
            var awards = new List<Award>();
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Award.Id AS Id, Award.Title AS TitleAward FROM Award "
                    + "INNER JOIN UsersAndAwards ON Award.Id = UsersAndAwards.IdAward "
                    + "WHERE UsersAndAwards.IdUser = @IdUser", _connection);
                command.Parameters.AddWithValue("@IdUser", idUser);
                _connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    awards.Add(new Award(
                        id: (Guid)reader["Id"],
                        title: (string)reader["TitleAward"]));
                }
            }

            return awards;
        }

        public List<Award> GetAwardsNotAvailableByUser(Guid idUser)
        {
            var awards = new List<Award>();
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Award.Id AS Id, Award.Title AS TitleAward FROM Award "
                    + "INNER JOIN UsersAndAwards ON Award.Id = UsersAndAwards.IdAward "
                    + "WHERE UsersAndAwards.IdUser != @IdUser", _connection);
                command.Parameters.AddWithValue("@IdUser", idUser);
                _connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    awards.Add(new Award(
                        id: (Guid)reader["Id"],
                        title: (string)reader["TitleAward"]));
                }
            }

            return awards;
        }

        /// <summary>
        /// Возвращает полную строку
        /// </summary>
        /// <param name="idRow"></param>
        /// <returns></returns>
        public UsersAndAwardsFull GetRowFull(int idRow)
        {
            return GetAllFull().FirstOrDefault(r => r.Id == idRow);
        }

        public UsersAndAwardsFull GetRowFull(Guid idUser, Guid idAward)
        {
            return GetAllFull().FirstOrDefault(r => r.IdUser == idUser && r.IdAward == idAward);
        }

        public List<User> GetUsersByAward(Guid idAward)
        {
            var users = new List<User>();
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT User.Id AS Id, User.Name AS Name, User.DateOfBirth AS DateOfBirth FROM User "
                    + "INNER JOIN UsersAndAwards ON User.Id = UsersAndAwards.IdUser "
                    + "WHERE UsersAndAwards.IdAward = @IdAward", _connection);
                command.Parameters.AddWithValue("@IdAward", idAward);
                _connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User(
                        id: (Guid)reader["Id"],
                        name: (string)reader["Name"],
                        dateOfBirth: (DateTime)reader["DateOfBirth"]));
                }
            }

            return users;
        }

        public List<User> GetUsersNotAvailableByAward(Guid idAward)
        {
            var users = new List<User>();
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT User.Id AS Id, User.Name AS Name, User.DateOfBirth AS DateOfBirth FROM User "
                    + "INNER JOIN UsersAndAwards ON User.Id = UsersAndAwards.IdUser "
                    + "WHERE UsersAndAwards.IdAward != @IdAward", _connection);
                command.Parameters.AddWithValue("@IdAward", idAward);
                _connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User(
                        id: (Guid)reader["Id"],
                        name: (string)reader["Name"],
                        dateOfBirth: (DateTime)reader["DateOfBirth"]));
                }
            }

            return users;
        }

        /// <summary>
        /// Лишить пользователя награды
        /// </summary>
        /// <param name="idAward"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public bool UnAssignAwardToUser(Guid idAward, Guid idUser)
        {
            var isContains = GetAll().FirstOrDefault(x => (x.IdAward == idAward && x.IdUser == idUser));
            if (isContains == null)
            {
                return false;
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE INTO UsersAndAwards " +
                    "WHERE IdUser = @IdUser, IdAward = @IdAward";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@IdUser", idUser);
                command.Parameters.AddWithValue("@IdAward", idAward);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    return false;
            }
            return true;
        }
    }
}
