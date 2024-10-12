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
        public AddCandidate(int candidateID)
        {
            InitializeComponent();
            CandidateID = candidateID;
            LoadPosition();
            LoadCandidateData(); 
        }

        private void LoadCandidateData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT c.FirstName, c.MiddleInitial, c.LastName, p.PositionDescription
                FROM TBL_Candidate c
                JOIN TBL_Position p ON c.PositionID = p.PositionDescription 
                WHERE c.CandidateID = @CandidateID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CandidateID", CandidateID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtFirstName.Text = reader["FirstName"].ToString();
                                txtMiddleInitial.Text = reader["MiddleInitial"].ToString();
                                txtLastName.Text = reader["LastName"].ToString();

                                string positionDescription = reader["PositionDescription"].ToString().Trim();

                                // Set the selected item in the ComboBox
                                if (cmbPositionsID.Items.Contains(positionDescription))
                                {
                                    cmbPositionsID.SelectedItem = positionDescription; 
                                }
                                else
                                {
                                    MessageBox.Show("Position description not found in the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Candidate not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading candidate data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string middleInitial = txtMiddleInitial.Text;
            string lastName = txtLastName.Text;
            string positionDescription = cmbPositionsID.SelectedItem?.ToString(); 

            // Save data to the database
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    string query;

                    if (CandidateID == -1)
                    {
                        // Insert new candidate
                        query = "INSERT INTO TBL_Candidate (FirstName, MiddleInitial, LastName, PositionID) VALUES (@FirstName, @MiddleInitial, @LastName, @PositionID)";
                    }
                    else
                    {
                        // Update existing candidate
                        query = "UPDATE TBL_Candidate SET FirstName = @FirstName, MiddleInitial = @MiddleInitial, LastName = @LastName, PositionID = @PositionID WHERE CandidateID = @CandidateID";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@MiddleInitial", middleInitial);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@PositionID", positionDescription);

                        if (CandidateID != -1)
                        {
                            cmd.Parameters.AddWithValue("@CandidateID", CandidateID);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Candidate data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            string positionDescription = reader["PositionDescription"].ToString().Trim();
                            cmbPositionsID.Items.Add(positionDescription); 
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading positions: " + ex.Message);
                    }
                }
            }
        }
     

        private void cmbPositionsID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
