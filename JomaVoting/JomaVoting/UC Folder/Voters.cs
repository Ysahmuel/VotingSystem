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
    public partial class Voters : UserControl
    {
        private readonly VoterRepository _voterRepository;

        public Voters()
        {
            InitializeComponent();
            _voterRepository = new VoterRepository(DatabaseConfig.ConnectionString);
            LoadVotersDataAsync();
        }

        private void btnAddVoter_Click(object sender, EventArgs e)
        {
            AddVoter addVoter = new AddVoter();
            addVoter.VoterAdded += AddVoter_VoterAdded;
            addVoter.Show();
        }
        private void AddVoter_VoterAdded() // Event handler to refresh data
        {
            LoadVotersDataAsync();
        }

        private async void LoadVotersDataAsync()
        {
            try
            {
                var voters = await _voterRepository.GetAllVotersAsync();
                dataGridView1.DataSource = voters;
                AddStatusColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading voter data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private async void DeleteVoter(int rowIndex)
    {
        int voterID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["VoterID"].Value);

        DialogResult result = MessageBox.Show("Are you sure you want to delete this voter?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            try
            {
                await _voterRepository.DeleteVoterAsync(voterID);
                LoadVotersDataAsync(); 
                MessageBox.Show("Voter deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting voter: " + ex.Message);
            }
        }
    }

    private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

        if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
        {
                int voterID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["VoterID"].Value);
                var addVoterForm = new AddVoter(voterID);
                addVoterForm.VoterAdded += AddVoter_VoterAdded;
                addVoterForm.ShowDialog(); 
        }
        else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
        {
            DeleteVoter(e.RowIndex);
        }
    }
    }
}
