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
    public partial class Voters : UserControl
    {
        public Voters()
        {
            InitializeComponent();
            LoadVotersData();
        }

        private void btnAddVoter_Click(object sender, EventArgs e)
        {
            AddVoter addVoter = new AddVoter();
            addVoter.Show();
        }

        private void LoadVotersData()
        {
            string query = "SELECT VoterID, FirstName, MiddleInitial, LastName FROM TBL_Voter";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable voterTable = new DataTable();
                        adapter.Fill(voterTable);
                        dataGridView1.DataSource = voterTable; // Bind the DataGridView to the data
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading voter data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
