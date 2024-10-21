using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JomaVoting
{
    public partial class Votes : UserControl
    {
        public Votes()
        {
            InitializeComponent();
            LoadVotesData();
        }

        private void LoadVotesData()
        {
            // SQL query to retrieve position, candidate, and voter information from TBL_Votes
            string query = @"SELECT Position, Candidate, Voter FROM TBL_Votes;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable votesTable = new DataTable();
                        adapter.Fill(votesTable);
                        dataGridView1.DataSource = votesTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading votes data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
