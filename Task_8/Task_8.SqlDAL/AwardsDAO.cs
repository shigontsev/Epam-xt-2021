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
    public class AwardsDAO : IAwardsDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public void AddAward(Award award)
        {
            var awards = GetAllAwards();

            var isContains = awards.FirstOrDefault(a => a.Title == award.Title);
            if (isContains != null)
            {
                throw new ArgumentException(nameof(award.Title), $"Award with Title \'{award.Title}\' already exists");
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Award(Id, Title) " +
                    "VALUES(@Id, @Title)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id", award.Id);
                command.Parameters.AddWithValue("@Title", award.Title);
                // DBNull.Value

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format("Cannot add Award"));
            }
        }

        public void EditTitel(Guid id, string newTitle)
        {
            var awards = GetAllAwards();
            var award = awards.FirstOrDefault(u => u.Id == id);
            if (award is null)
            {
                throw new ArgumentNullException(nameof(id), $"Award at Id {id} doesn't exist");
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Award SET Title = @Title " +
                    "WHERE Id = @Id";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Title", newTitle);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format("Cannot update Award"));
            }
        }

        public List<Award> GetAllAwards()
        {
            var awards = new List<Award>();
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Title FROM Award", _connection);
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    awards.Add(new Award(
                        id: (Guid)reader["Id"],
                        title: (string)reader["Title"]
                        ));
                }
            }

            return awards;
        }

        public Award GetAward(Guid id)
        {
            return GetAllAwards().FirstOrDefault(a => a.Id == id);
        }

        public void RemoveAward(Guid id)
        {
            var awards = GetAllAwards();
            var isContains = awards.FirstOrDefault(a => a.Id == id);
            if (isContains == null)
            {
                throw new ArgumentNullException(nameof(id), $"Award at Id {id} doesn't exist");
            }

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE INTO Award " +
                    "WHERE Id = @id";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                if (result == 0)
                    throw new InvalidOperationException(
                        string.Format("Cannot delete Award"));
            }
        }
    }
}
