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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Simulate saving data
            string positionDescription = txtPosition.Text;
            string maximumVote = cmbMaximumVote.Text;

            // Save data to the database
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString)) // Ensure DatabaseConfig.ConnectionString is defined properly
                {
                    connection.Open();
                    string query;

                    if (PositionID == -1)
                    {
                        // Insert new voter
                        query = "INSERT INTO TBL_Position (PositionDescription, MaximumVote) " +
                                "VALUES (@PositionDescription, @MaximumVote)";
                    }
                    else
                    {
                        // Update existing voter
                        query = "UPDATE TBL_Position SET PositionDescription = @PositionDescription, MaximumVote = @MaximumVote WHERE PositionID = @PositionID";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@PositionDescription", positionDescription);
                        cmd.Parameters.AddWithValue("@MaximumVote", maximumVote);

                        // If updating, pass the VoterID as a parameter
                        if (PositionID != -1)
                        {
                            cmd.Parameters.AddWithValue("@PositionID", PositionID);
                        }

                        // Execute the query (insert or update)
                        cmd.ExecuteNonQuery();
                    }
                }

                // Notify the user of success
                MessageBox.Show("Position data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields after saving
                txtPosition.Clear();    
                cmbMaximumVote.Text = " ";

                // Close the form
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
