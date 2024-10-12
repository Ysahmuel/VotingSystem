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
    public partial class Candidates : UserControl
    {
        public Candidates()
        {
            InitializeComponent();
            LoadVotersData();
        }

        private void btnAddCandidate_Click(object sender, EventArgs e)
        {
            AddCandidate addCandidate = new AddCandidate();
            addCandidate.Show();
        }

        private void LoadVotersData()
        {
            string query = "SELECT FirstName, MiddleInitial, LastName, PositionID FROM TBL_Candidate";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable candidateTable = new DataTable();
                        adapter.Fill(candidateTable);
                        dataGridView1.DataSource = candidateTable; // Bind the DataGridView to the data
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading voter data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
