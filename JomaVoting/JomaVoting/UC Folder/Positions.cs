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
    public partial class Positions : UserControl
    {
        public Positions()
        {
            InitializeComponent();
            LoadVotersData();
        }


        private void LoadVotersData()
        {
            string query = "SELECT PositionID, PositionDescription, MaximumVote FROM TBL_Position";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable positionTable = new DataTable();
                        adapter.Fill(positionTable);
                        dataGridView1.DataSource = positionTable; // Bind the DataGridView to the data
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading voter data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddPosition_Click(object sender, EventArgs e)
        {
            AddPosition addPosition = new AddPosition();
            addPosition.Show();
        }
    }
}
