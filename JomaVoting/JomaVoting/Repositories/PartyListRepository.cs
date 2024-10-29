using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JomaVoting.VoterPartyList;

namespace JomaVoting.Repositories
{

    public class PartyListRepository
    {
        private readonly string _connectionString;

        public PartyListRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<DataTable> GetPartyListAsync()
        {
            string query = "SELECT PartyListID, PartyListName FROM TBL_PartyList";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable partylistTable = new DataTable();
                    await Task.Run(() => adapter.Fill(partylistTable));
                    return partylistTable;
                }
            }
        }
        public async Task DeletePartyListAsync(int partylistID)
        {
            string query = "DELETE FROM TBL_PartyList WHERE PartyListID = @PartyListID";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PartyListID", partylistID);
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }


        public async Task<List<PartyCandidate>> GetPartyCandidatesAsync()
        {
            List<PartyCandidate> partyCandidates = new List<PartyCandidate>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                SELECT 
                    P.PartyListName,
                    C.FirstName,
                    C.MiddleInitial,
                    C.LastName,
                    C.Position
                FROM 
                    TBL_PartyList P
                INNER JOIN 
                    TBL_Candidate C ON P.PartyListName = C.PartyList
                ORDER BY 
                    P.PartyListName, C.Position, C.LastName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            partyCandidates.Add(new PartyCandidate
                            {
                                PartyListName = reader["PartyListName"].ToString(),
                                CandidateName = $"{reader["FirstName"]} {reader["MiddleInitial"]}. {reader["LastName"]}",
                                Position = reader["Position"].ToString()
                            });
                        }
                    }
                }
            }

            return partyCandidates;
        }
        public class PartyCandidate
        {
            public string PartyListName { get; set; }
            public string CandidateName { get; set; }
            public string Position { get; set; }
        }
    }

}
