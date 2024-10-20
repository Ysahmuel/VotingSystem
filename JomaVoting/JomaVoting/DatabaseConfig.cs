using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JomaVoting
{
    public static class DatabaseConfig
    {
        private static readonly string connectionString = "Data Source =(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ROSA\\OneDrive\\Documents\\GitHub\\VotingSystem\\JomaVoting\\JomaVoting\\JomaVoteDB.mdf;Integrated Security=True";

        public static string ConnectionString
        {
            get { return connectionString; }
        }
    }
}
