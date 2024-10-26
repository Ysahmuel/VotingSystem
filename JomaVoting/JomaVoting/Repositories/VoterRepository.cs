using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JomaVoting.Repositories
{

    public class VoterRepository
    {
        private readonly string _connectionString;

        public VoterRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Voter> GetVoterAsync(int voterID)
        {
            Voter voter = null;
            string query = "SELECT FirstName, MiddleInitial, LastName FROM TBL_Voter WHERE VoterID = @VoterID";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VoterID", voterID);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            voter = new Voter
                            {
                                VoterID = voterID,
                                FirstName = reader.GetString(0),
                                MiddleInitial = reader.IsDBNull(1) ? null : reader.GetString(1),
                                LastName = reader.GetString(2)
                            };
                        }
                    }
                }
            }
            return voter;
        }
        public async Task<List<Voter>> GetAllVotersAsync()
        {
            var voters = new List<Voter>();
            string query = "SELECT VoterID, FirstName, MiddleInitial, LastName FROM TBL_Voter";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var voter = new Voter
                            {
                                VoterID = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                MiddleInitial = reader.IsDBNull(2) ? null : reader.GetString(2),
                                LastName = reader.GetString(3)
                            };
                            voters.Add(voter);
                        }
                    }
                }
            }
            return voters;
        }

        public async Task<int> SaveVoterAsync(Voter voter)
        {
            string query;
            if (voter.VoterID == -1)
            {
                query = "INSERT INTO TBL_Voter (FirstName, MiddleInitial, LastName) OUTPUT INSERTED.VoterID VALUES (@FirstName, @MiddleInitial, @LastName)";
            }
            else
            {
                query = "UPDATE TBL_Voter SET FirstName = @FirstName, MiddleInitial = @MiddleInitial, LastName = @LastName WHERE VoterID = @VoterID";
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", voter.FirstName);
                    command.Parameters.AddWithValue("@MiddleInitial", (object)voter.MiddleInitial ?? DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", voter.LastName);

                    if (voter.VoterID != -1)
                    {
                        command.Parameters.AddWithValue("@VoterID", voter.VoterID);
                        await command.ExecuteNonQueryAsync();
                        return voter.VoterID;
                    }
                    else
                    {
                        return (int)await command.ExecuteScalarAsync();
                    }
                }
            }
        }

        public async Task DeleteVoterAsync(int voterID)
        {
            string query = "DELETE FROM TBL_Voter WHERE VoterID = @VoterID";
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VoterID", voterID);
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

    public class Voter
    {
        public int VoterID { get; set; } = -1;
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
    }
}


