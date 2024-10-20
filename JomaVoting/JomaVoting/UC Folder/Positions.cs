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
            LoadPositionData();
            AddStatusColumns();
        }


        private void LoadPositionData()
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
                        dataGridView1.DataSource = positionTable; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading position data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddPosition_Click(object sender, EventArgs e)
        {
            AddPosition addPosition = new AddPosition();
            addPosition.Show();
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

        private void DeletePosition(int rowIndex)
        {
            int positionID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["PositionID"].Value);

            DialogResult result = MessageBox.Show("Are you sure you want to delete this position?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM TBL_Position WHERE PositionID = @PositionID";

                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PositionID", positionID);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                LoadPositionData();
                                dataGridView1.Invalidate();
                                MessageBox.Show("Position deleted successfully.");

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting position: " + ex.Message);
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
                int positionID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["PositionID"].Value);

                AddPosition addPositionForm = new AddPosition(positionID);
                addPositionForm.ShowDialog(); 
                LoadPositionData(); 
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                DeletePosition(e.RowIndex);
            }
        }
    }
}
