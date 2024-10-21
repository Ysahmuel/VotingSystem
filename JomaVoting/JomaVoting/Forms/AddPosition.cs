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
    public partial class AddPosition : Form
    {
        private int PositionID = -1;
        public AddPosition()
        {
            InitializeComponent();
        }
        public AddPosition(int positionID)
        {
            InitializeComponent();
            PositionID = positionID;
            LoadPositionData(); 
        }

        private void LoadPositionData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    // SQL query to retrieve the PositionDescription and MaximumVote for a specific PositionID
                    string query = "SELECT PositionDescription, MaximumVote FROM TBL_Position WHERE PositionID = @PositionID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PositionID", PositionID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtPosition.Text = reader["PositionDescription"].ToString();
                           
                                int maxVote = Convert.ToInt32(reader["MaximumVote"]);

                                bool valueFound = false;

                                foreach (var item in cmbMaximumVote.Items)
                                {
                                    if (Convert.ToInt32(item) == maxVote)
                                    {
                                        cmbMaximumVote.SelectedItem = item;
                                        valueFound = true;
                                        break;
                                    }
                                }
                             }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the position data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string positionDescription = txtPosition.Text;
            string maximumVote = cmbMaximumVote.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString)) 
                {
                    connection.Open();
                    string query;

                    if (PositionID == -1)
                    {
                        // SQL query to insert a new position into the TBL_Position table
                        query = "INSERT INTO TBL_Position (PositionDescription, MaximumVote) " +
                                "VALUES (@PositionDescription, @MaximumVote)";
                    }
                    else
                    {
                        // SQL query to update an existing position's information
                        query = "UPDATE TBL_Position SET PositionDescription = @PositionDescription, MaximumVote = @MaximumVote WHERE PositionID = @PositionID";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PositionDescription", positionDescription);
                        cmd.Parameters.AddWithValue("@MaximumVote", maximumVote);

                        if (PositionID != -1)
                        {
                            cmd.Parameters.AddWithValue("@PositionID", PositionID);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Position data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPosition.Clear();
         
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
