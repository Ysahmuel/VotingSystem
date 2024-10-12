using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace JomaVoting
{
    public partial class AddVoter : Form
    {
        private int VoterID = -1;

        public AddVoter()
        {
            InitializeComponent();
        }

        public AddVoter(int voterID)
        {
            InitializeComponent();
            VoterID = voterID;
            LoadVoterData(); // Load voter data for editing
        }
        private void LoadVoterData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT FirstName, MiddleInitial, LastName FROM TBL_Voter WHERE VoterID = @VoterID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@VoterID", VoterID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtFirstName.Text = reader["FirstName"].ToString();
                                txtMiddleInitial.Text = reader["MiddleInitial"].ToString();
                                txtLastName.Text = reader["LastName"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the voter data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Simulate saving data
            string firstName = txtFirstName.Text;
            string middleInitial = txtMiddleInitial.Text;
            string lastName = txtLastName.Text;

            // Save data to the database
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString)) // Ensure DatabaseConfig.ConnectionString is defined properly
                {
                    connection.Open();
                    string query;

                    if (VoterID == -1)
                    {
                        // Insert new voter
                        query = "INSERT INTO TBL_Voter (FirstName, MiddleInitial, LastName) " +
                                "VALUES (@FirstName, @MiddleInitial, @LastName)";
                    }
                    else
                    {
                        // Update existing voter
                        query = "UPDATE TBL_Voter SET FirstName = @FirstName, MiddleInitial = @MiddleInitial, LastName = @LastName WHERE VoterID = @VoterID";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@MiddleInitial", middleInitial);
                        cmd.Parameters.AddWithValue("@LastName", lastName);

                        // If updating, pass the VoterID as a parameter
                        if (VoterID != -1)
                        {
                            cmd.Parameters.AddWithValue("@VoterID", VoterID);
                        }

                        // Execute the query (insert or update)
                        cmd.ExecuteNonQuery();
                    }
                }

                // Notify the user of success
                MessageBox.Show("Voter data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields after saving
                txtFirstName.Clear();
                txtMiddleInitial.Clear();
                txtLastName.Clear();

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
