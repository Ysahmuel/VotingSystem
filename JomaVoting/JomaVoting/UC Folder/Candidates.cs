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
            LoadCandidateData();
            AddStatusColumns();
        }

        private void btnAddCandidate_Click(object sender, EventArgs e)
        {
            AddCandidate addCandidate = new AddCandidate();
            addCandidate.Show();
        }

        private void LoadCandidateData()
        {
            // SQL query to select candidate data from the TBL_Candidate table
            string query = "SELECT CandidateID, FirstName, MiddleInitial, LastName, Picture, Section, Position FROM TBL_Candidate";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable candidateTable = new DataTable();
                        adapter.Fill(candidateTable);
                        dataGridView1.DataSource = candidateTable; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading candidate data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DeleteCandidate(int rowIndex)
        {
            int candidateID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["CandidateID"].Value);

            DialogResult result = MessageBox.Show("Are you sure you want to delete this candidate?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // SQL query to delete the candidate with the specified CandidateID from the TBL_Candidate table
                string query = "DELETE FROM TBL_Candidate WHERE CandidateID = @CandidateID";

                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CandidateID", candidateID);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                LoadCandidateData();
                                dataGridView1.Invalidate();
                                MessageBox.Show("Candidate deleted successfully.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting candidate: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                int candidateID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CandidateID"].Value);

                AddCandidate addCandidateForm = new AddCandidate(candidateID);
                addCandidateForm.ShowDialog(); 
                LoadCandidateData(); 
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                DeleteCandidate(e.RowIndex);
            }
        }
    }
}
