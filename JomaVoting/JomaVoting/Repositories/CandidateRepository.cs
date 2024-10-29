using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JomaVoting.Voting;

namespace JomaVoting.Repositories
{
    public class CandidateRepository
    {
        private readonly string _connectionString;

        public CandidateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<DataTable> GetCandidatesAsync()
        {
            string query = "SELECT CandidateID, FirstName, MiddleInitial, LastName, Picture, Position, PartyList FROM TBL_Candidate";
            using (SqlConnection connection = new SqlConnection(_connectionString))
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

            using (SqlConnection connection = new SqlConnection(_connectionString))
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

        public async Task<List<string>> GetPartyListAsync()
        {
            List<string> partylist = new List<string>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT PartyListName FROM TBL_PartyList";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        partylist.Add(reader["PartyListName"].ToString());
                    }
                }
            }

            return partylist;
        }


        public async Task DeleteCandidateAsync(int candidateID)
        {
            string query = "DELETE FROM TBL_Candidate WHERE CandidateID = @CandidateID";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CandidateID", candidateID);
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task SaveCandidateAsync(string firstName, string middleInitial, string lastName, byte[] picture, string position, string partyList, string section = null, int candidateID = -1)
        {
            string query;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                if (candidateID == -1)
                {
                    query = "INSERT INTO TBL_Candidate (FirstName, MiddleInitial, LastName, Picture, Position, Section, PartyList) VALUES (@FirstName, @MiddleInitial, @LastName, @Picture, @Position, @Section, @PartyList)";
                }
                else
                {
                    query = "UPDATE TBL_Candidate SET FirstName = @FirstName, MiddleInitial = @MiddleInitial, LastName = @LastName, Picture = @Picture, Position = @Position, Section = @Section, PartyList = @PartyList WHERE CandidateID = @CandidateID";
                }
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@MiddleInitial", middleInitial);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Position", position);
                    cmd.Parameters.AddWithValue("@PartyList", partyList);
                    cmd.Parameters.AddWithValue("@Picture", picture ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Section", section ?? (object)DBNull.Value);
                    

                    if (candidateID != -1)
                    {
                        cmd.Parameters.AddWithValue("@CandidateID", candidateID);
                    }

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
