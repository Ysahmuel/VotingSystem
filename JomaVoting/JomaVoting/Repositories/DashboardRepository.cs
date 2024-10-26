using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JomaVoting.Repositories
{
    public class DashboardRepository
    {
        private string _connectionString;

        public DashboardRepository()
        {
            _connectionString = DatabaseConfig.ConnectionString;
        }

        public async Task<int> GetCandidateCountAsync()
        {
            string query = "SELECT COUNT(*) FROM TBL_Candidate";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                await connection.OpenAsync();
                return (int)await command.ExecuteScalarAsync();
            }
        }

        public async Task<int> GetVoterCountAsync()
        {
            string query = "SELECT COUNT(*) FROM TBL_Voter";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                await connection.OpenAsync();
                return (int)await command.ExecuteScalarAsync();
            }
        }

        public async Task<Dictionary<string, List<(string Candidate, int VoteCount)>>>
            GetLeadingCandidatesAsync()
        {
            string query = @"
                SELECT Position, Candidate, COUNT(*) AS VoteCount
                FROM TBL_Votes
                GROUP BY Position, Candidate
                HAVING COUNT(*) > 0
                ORDER BY Position, VoteCount DESC";

            var positionData = new Dictionary<string, List<(string Candidate, int VoteCount)>>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    string position = reader["Position"].ToString();
                    string candidate = reader["Candidate"].ToString();
                    int voteCount = (int)reader["VoteCount"];

                    if (!positionData.ContainsKey(position))
                    {
                        positionData[position] = new List<(string Candidate, int VoteCount)>();
                    }
                    positionData[position].Add((candidate, voteCount));
                }
            }

            return positionData;
        }
    }
}
