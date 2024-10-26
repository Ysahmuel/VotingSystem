using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JomaVoting.Repositories
{
    public class CandidateRepository
    {
        private string connectionString;

        public CandidateRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<DataTable> GetCandidatesAsync()
        {
            string query = "SELECT CandidateID, FirstName, MiddleInitial, LastName, Picture, Position FROM TBL_Candidate";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable candidateTable = new DataTable();
                    await Task.Run(() => adapter.Fill(candidateTable));
                    return candidateTable;
                }
            }
        }
        public async Task<List<string>> GetPositionsAsync()
        {
            List<string> positions = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT PositionDescription FROM TBL_Position";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        positions.Add(reader["PositionDescription"].ToString());
                    }
                }
            }

            return positions;
        }


        public async Task DeleteCandidateAsync(int candidateID)
        {
            string query = "DELETE FROM TBL_Candidate WHERE CandidateID = @CandidateID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CandidateID", candidateID);
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task SaveCandidateAsync(int? candidateID, string firstName, string middleInitial, string lastName, byte[] picture, string position)
        {
            string query = candidateID.HasValue
                ? "UPDATE TBL_Candidate SET FirstName = @FirstName, MiddleInitial = @MiddleInitial, LastName = @LastName, Picture = @Picture, Position = @Position WHERE CandidateID = @CandidateID"
                : "INSERT INTO TBL_Candidate (FirstName, MiddleInitial, LastName, Picture, Position) VALUES (@FirstName, @MiddleInitial, @LastName, @Picture, @Position)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@MiddleInitial", middleInitial);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Position", position);
                    command.Parameters.AddWithValue("@Picture", picture ?? (object)DBNull.Value);

                    if (candidateID.HasValue)
                    {
                        command.Parameters.AddWithValue("@CandidateID", candidateID.Value);
                    }

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
