using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Task_8.DAL.Interfaces;
using Task_8.Entities;

namespace Task_8.SqlDAL
{
    public class UsersDAO : IUsersDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public void AddUser(User user)
        {
            var users = GetAllUsers();

            var isContains = users.FirstOrDefault(u => u.Name == user.Name);
            if (isContains != null)
            {
                throw new ArgumentException(nameof(user.Name), $"User with name \'{user.Name}\' already exists");
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO [User](Id, Name, DateOfBirth) " +
                    "VALUES(@Id, @Name, @DateOfBirth)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                // DBNull.Value

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                throw new InvalidOperationException(
                    string.Format("Cannot add User"));
            }
        }

        public void Edit(Guid id, string newName, DateTime newDateOfBirth)
        {
            var users = GetAllUsers();
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user is null)
            {
                throw new ArgumentNullException(nameof(id), $"User at Id {id} doesn't exist");
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE [User] SET Name = @Name, DateOfBirth = @DateOfBirth " +
                    "WHERE Id = @Id";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", newName);
                command.Parameters.AddWithValue("@DateOfBirth", newDateOfBirth);
                
                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format("Cannot update User"));
            }
        }

        public void EditDateOfBirth(Guid id, DateTime newDateOfBirth)
        {
            var users = GetAllUsers();
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user is null)
            {
                throw new ArgumentNullException(nameof(id), $"User at Id {id} doesn't exist");
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE [User] SET DateOfBirth = @DateOfBirth " +
                    "WHERE Id = @Id";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@DateOfBirth", newDateOfBirth);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format("Cannot update User"));
            }
        }

        public void EditName(Guid id, string newName)
        {
            var users = GetAllUsers();
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user is null)
            {
                throw new ArgumentNullException(nameof(id), $"User at Id {id} doesn't exist");
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE [User] SET Name = @Name " +
                    "WHERE Id = @Id";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", newName);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format("Cannot update User"));
            }
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Name, DateOfBirth FROM [User]", _connection);
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

        public User GetUser(Guid id)
        {
            return GetAllUsers().FirstOrDefault(u => u.Id == id);
        }

        public User GetUser(string name)
        {
            return GetAllUsers().FirstOrDefault(u => u.Name == name);
        }

        public void RemoveUser(Guid id)
        {
            var users = GetAllUsers();
            var isContains = users.FirstOrDefault(u => u.Id == id);
            if (isContains == null)
            {
                throw new ArgumentNullException(nameof(id), $"User at Id {id} doesn't exist");
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM [User] " +
                    "WHERE Id = @id";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format("Cannot delete User"));
            }
        }
    }
}
