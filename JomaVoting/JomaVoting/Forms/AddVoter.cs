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
            string firstName = txtFirstName.Text;
            string middleInitial = txtMiddleInitial.Text;
            string lastName = txtLastName.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    string query;
                    string username = "";
                    string password = GeneratePassword(); // Generate a random password

                    if (VoterID == -1)
                    {
                        // Insert new voter and get VoterID for the new entry
                        query = "INSERT INTO TBL_Voter (FirstName, MiddleInitial, LastName, Username, Password) " +
                                "OUTPUT INSERTED.VoterID " + // Capture the inserted VoterID
                                "VALUES (@FirstName, @MiddleInitial, @LastName, @Username, @Password)";

                        // We need to generate the username now, but we don't know the VoterID yet
                        // So we use a temporary placeholder for the username and update it after getting the VoterID
                        username = $"{firstName}{lastName}TEMP";
                    }
                    else
                    {
                        // Update existing voter
                        query = "UPDATE TBL_Voter SET FirstName = @FirstName, MiddleInitial = @MiddleInitial, " +
                                "LastName = @LastName, Username = @Username, Password = @Password " +
                                "WHERE VoterID = @VoterID";

                        // Create the username using FirstName, LastName, and VoterID (since it exists)
                        username = $"{firstName}{lastName}{VoterID}";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@MiddleInitial", middleInitial);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Username", username);  // Add the username parameter
                        cmd.Parameters.AddWithValue("@Password", password);  // Add the password parameter

                        if (VoterID == -1)
                        {
                            // If inserting, execute and get the new VoterID
                            VoterID = (int)cmd.ExecuteScalar(); // Retrieve the inserted VoterID
                        }
                        else
                        {
                            // If updating, execute the command
                            cmd.Parameters.AddWithValue("@VoterID", VoterID);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // If inserting, update the Username with the new VoterID
                    if (VoterID != -1 && username.Contains("TEMP"))
                    {
                        username = $"{firstName}{lastName}{VoterID}";  // Generate the final username
                        query = "UPDATE TBL_Voter SET Username = @Username WHERE VoterID = @VoterID";
                        using (SqlCommand updateCmd = new SqlCommand(query, connection))
                        {
                            updateCmd.Parameters.AddWithValue("@Username", username);
                            updateCmd.Parameters.AddWithValue("@VoterID", VoterID);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Voter data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtFirstName.Clear();
                txtMiddleInitial.Clear();
                txtLastName.Clear();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GeneratePassword()
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder password = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++) // Generates a 10-character password
            {
                password.Append(valid[rnd.Next(valid.Length)]);
            }
            return password.ToString();
        }
    }
}
