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
using System.Drawing.Imaging;

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

                    // SQL query to retrieve candidate's first name, middle initial, last name, and position description by CandidateID
                    string query = @"SELECT c.FirstName, c.MiddleInitial, c.LastName, p.PositionDescription
                                    FROM TBL_Candidate c
                                    JOIN TBL_Position p ON c.Position = p.PositionDescription 
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

        private Image ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string middleInitial = txtMiddleInitial.Text;
            string lastName = txtLastName.Text;
            string positionDescription = cmbPositionsID.SelectedItem?.ToString();
            byte[] pictureData = null;

            if (pictureBox1.Image != null)
            {
                Image resizedImage = ResizeImage(pictureBox1.Image, 50, 50);

                using (MemoryStream ms = new MemoryStream())
                {
                    resizedImage.Save(ms, ImageFormat.Png); 
                    pictureData = ms.ToArray();
                }
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    string query;

                    if (CandidateID == -1)
                    {
                        // SQL query to insert a new candidate into the TBL_Candidate table
                        query = "INSERT INTO TBL_Candidate (FirstName, MiddleInitial, LastName, Picture, Position) VALUES (@FirstName, @MiddleInitial, @LastName, @Picture, @Position)";
                    }
                    else
                    {
                        // SQL query to update an existing candidate's information
                        query = "UPDATE TBL_Candidate SET FirstName = @FirstName, MiddleInitial = @MiddleInitial, LastName = @LastName, Picture = @Picture, Position = @Position WHERE CandidateID = @CandidateID";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@MiddleInitial", middleInitial);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Position", positionDescription);

                        if (pictureData != null)
                        {
                            cmd.Parameters.AddWithValue("@Picture", pictureData);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Picture", DBNull.Value); 
                        }

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
            // SQL query to retrieve all position descriptions from the TBL_Position table
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

        private void btnInsertImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png) | *.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
            }
        }
    }
}
