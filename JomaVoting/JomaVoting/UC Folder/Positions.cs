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
    public partial class Positions : UserControl
    {
        private PositionRepository _positionRepository;

        public Positions()
        {
            InitializeComponent();
            _positionRepository = new PositionRepository(DatabaseConfig.ConnectionString);
            LoadPositionDataAsync();
        }

        private async void LoadPositionDataAsync()
        {
            try
            {
                var positionTable = await _positionRepository.GetPositionsAsync();
                dataGridView1.DataSource = positionTable;
                AddStatusColumns(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading position data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddPosition_Click(object sender, EventArgs e)
        {
            AddPosition addPosition = new AddPosition();
            addPosition.PositionAdded += AddPosition_PositionAdded; // Subscribe to the event
            addPosition.ShowDialog();
        }

        private void AddPosition_PositionAdded() // Event handler to refresh data
        {
            LoadPositionDataAsync();
        }

        private void AddStatusColumns()
        {
            // Check if the Edit column already exists
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

            // Check if the Delete column already exists
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

        private async void DeletePosition(int rowIndex)
        {
            int positionID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["PositionID"].Value);
            DialogResult result = MessageBox.Show("Are you sure you want to delete this position?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _positionRepository.DeletePositionAsync(positionID);
                    LoadPositionDataAsync();
                    MessageBox.Show("Position deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting position: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                int positionID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["PositionID"].Value);
                AddPosition addPositionForm = new AddPosition(positionID);
                addPositionForm.PositionAdded += AddPosition_PositionAdded; // Subscribe to refresh event
                addPositionForm.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                DeletePosition(e.RowIndex);
            }
        }
    }
}
