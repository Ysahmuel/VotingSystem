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
using JomaVoting.Repositories;

namespace JomaVoting
{
    public partial class Candidates : UserControl
    {
        private CandidateRepository candidateRepository;

        public Candidates()
        {
            InitializeComponent();
            candidateRepository = new CandidateRepository(DatabaseConfig.ConnectionString);
            LoadCandidateDataAsync();
           
        }

        private void btnAddCandidate_Click(object sender, EventArgs e)
        {
            AddCandidate addCandidate = new AddCandidate();
            addCandidate.CandidateAdded += AddCandidate_CandidateAdded;
            addCandidate.Show();
        }
        private void AddCandidate_CandidateAdded() 
        {
            LoadCandidateDataAsync();
        }

        private async void LoadCandidateDataAsync()
        {
            try
            {
                var candidateTable = await candidateRepository.GetCandidatesAsync();
                dataGridView1.DataSource = candidateTable;
                AddStatusColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading candidate data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddStatusColumns()
        {
            if (!dataGridView1.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    HeaderText = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(editColumn);
            }

            if (!dataGridView1.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(deleteColumn);
            }
        }

        private async void DeleteCandidate(int rowIndex)
        {
            int candidateID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["CandidateID"].Value);

            DialogResult result = MessageBox.Show("Are you sure you want to delete this candidate?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    await candidateRepository.DeleteCandidateAsync(candidateID);
                    LoadCandidateDataAsync();
                    MessageBox.Show("Candidate deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting candidate: " + ex.Message);
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
                LoadCandidateDataAsync();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                DeleteCandidate(e.RowIndex);
            }
        }

    }
}
