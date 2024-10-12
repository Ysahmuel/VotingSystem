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
    public partial class AddCandidate : Form
    {
        private int CandidateID = -1;
        private List<string> allPosition = new List<string>();
        public AddCandidate()
        {
            InitializeComponent();
            LoadPosition();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Simulate saving data
            string firstName = txtFirstName.Text;
            string middleInitial = txtMiddleInitial.Text;
            string lastName = txtLastName.Text;
            string positionID = cmbPositionsID.Text;

            // Save data to the database
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString)) // Ensure DatabaseConfig.ConnectionString is defined properly
                {
                    connection.Open();
                    string query;

                    if (CandidateID == -1)
                    {
                        // Insert new voter
                        query = "INSERT INTO TBL_Candidate (FirstName, MiddleInitial, LastName, PositionID) " +
                                "VALUES (@FirstName, @MiddleInitial, @LastName, @PositionID)";
                    }
                    else
                    {
                        // Update existing voter
                        query = "UPDATE TBL_Candidate SET FirstName = @FirstName, MiddleInitial = @MiddleInitial, LastName = @LastName, PositionID = PostionID WHERE CandidateID = @CandidateID";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@MiddleInitial", middleInitial);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@PositionID", positionID);

                        // If updating, pass the VoterID as a parameter
                        if (CandidateID != -1)
                        {
                            cmd.Parameters.AddWithValue("@CandidateID", CandidateID);
                        }

                        // Execute the query (insert or update)
                        cmd.ExecuteNonQuery();
                    }
                }

                // Notify the user of success
                MessageBox.Show("Candidate data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields after saving
                txtFirstName.Clear();
                txtMiddleInitial.Clear();
                txtLastName.Clear();
                cmbPositionsID.Text = " ";

                // Close the form
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPosition()
        {
            string query = "SELECT PositionDescription FROM TBL_Position";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            string PositionDescription = reader["PositionDescription"].ToString().Trim();

                            cmbPositionsID.Items.Add(PositionDescription);
                            allPosition.Add(PositionDescription);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        private void cmbPositionsID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
