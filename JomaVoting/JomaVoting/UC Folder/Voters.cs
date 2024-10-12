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
        private object ex;

        public Voters()
        {
            InitializeComponent();
            LoadVotersData();
            AddStatusColumns();
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
        private void AddStatusColumns()
        {
            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(editColumn);

            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(deleteColumn);
        }

        private void DeleteVoter(int rowIndex)
        {
            int voterID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["VoterID"].Value);

            DialogResult result = MessageBox.Show("Are you sure you want to delete this voter?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM TBL_Voter WHERE VoterID = @VoterID";

                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VoterID", voterID);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                LoadVotersData();
                                dataGridView1.Invalidate();
                                MessageBox.Show("Voter deleted successfully.");
          
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting voter: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

             if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                DeleteVoter(e.RowIndex);
            }
        }
    }
}
