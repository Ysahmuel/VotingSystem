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
using JomaVoting.Repositories;

namespace JomaVoting
{
    public partial class AddCandidate : Form
    {

        public delegate void CandidateAddedEventHandler();
        public event CandidateAddedEventHandler CandidateAdded;

        private int CandidateID = -1;
        private CandidateRepository candidateRepository;

        public AddCandidate()
        {
            InitializeComponent();
            candidateRepository = new CandidateRepository(DatabaseConfig.ConnectionString);
            LoadPositionAsync();
        }

        public AddCandidate(int candidateID) : this()
        {
            CandidateID = candidateID;
            LoadCandidateDataAsync();
        }

        private async void LoadCandidateDataAsync()
        {
            try
            {
                // Load candidate data using candidateRepository
                DataTable candidateData = await candidateRepository.GetCandidatesAsync();
                foreach (DataRow row in candidateData.Rows)
                {
                    if ((int)row["CandidateID"] == CandidateID)
                    {
                        txtFirstName.Text = row["FirstName"].ToString();
                        txtMiddleInitial.Text = row["MiddleInitial"].ToString();
                        txtLastName.Text = row["LastName"].ToString();
                        if (row["Picture"] != DBNull.Value)
                        {
                            byte[] pictureData = (byte[])row["Picture"];
                            using (MemoryStream ms = new MemoryStream(pictureData))
                            {
                                pictureBox1.Image = Image.FromStream(ms);
                            }
                        }
                        cmbPositionsID.SelectedItem = row["Position"].ToString();
                        break;
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

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string middleInitial = txtMiddleInitial.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string positionDescription = cmbPositionsID.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(positionDescription))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] pictureData = GetPictureData();

            try
            {
                await candidateRepository.SaveCandidateAsync(CandidateID, firstName, middleInitial, lastName, pictureData, positionDescription);
                MessageBox.Show("Candidate data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CandidateAdded?.Invoke();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadPositionAsync()
        {
            try
            {

                var positions = await candidateRepository.GetPositionsAsync();
                cmbPositionsID.DataSource = positions;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading positions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] GetPictureData()
        {
            if (pictureBox1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            return null; 
        }

        private void btnInsertImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }
    }
}
