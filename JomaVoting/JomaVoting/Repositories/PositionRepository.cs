using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JomaVoting.Repositories
{
    internal class PositionRepository
    {

        private readonly string _connectionString;

        public PositionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<DataTable> GetPositionsAsync()
        {
            string query = "SELECT PositionID, PositionDescription, MaximumVote FROM TBL_Position";
            DataTable positionTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    await Task.Run(() => adapter.Fill(positionTable));
                }
            }
            return positionTable;
        }

        public async Task SavePositionAsync(string positionDescription, string maximumVote, int positionID = -1)
        {
            string query;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                if (positionID == -1)
                {
                    query = "INSERT INTO TBL_Position (PositionDescription, MaximumVote) VALUES (@PositionDescription, @MaximumVote)";
                }
                else
                {
                    query = "UPDATE TBL_Position SET PositionDescription = @PositionDescription, MaximumVote = @MaximumVote WHERE PositionID = @PositionID";
                }

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PositionDescription", positionDescription);
                    cmd.Parameters.AddWithValue("@MaximumVote", maximumVote);

                    if (positionID != -1)
                    {
                        cmd.Parameters.AddWithValue("@PositionID", positionID);
                    }

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeletePositionAsync(int positionID)
        {
            string query = "DELETE FROM TBL_Position WHERE PositionID = @PositionID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PositionID", positionID);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

