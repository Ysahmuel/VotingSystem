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
            LoadPartyListAsync();
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
                        cmbPartyListName.SelectedItem = row["PartyList"].ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading candidate data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string middleInitial = txtMiddleInitial.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string positionDescription = cmbPositionsID.SelectedItem?.ToString();
            string partylist = cmbPartyListName.SelectedItem?.ToString();
            byte[] pictureData = null;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(positionDescription) || string.IsNullOrWhiteSpace(partylist))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                // Pass the CandidateID when saving
                await candidateRepository.SaveCandidateAsync(firstName, middleInitial, lastName, pictureData, positionDescription, partylist, candidateID: CandidateID);
                MessageBox.Show("Candidate data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CandidateAdded?.Invoke();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadPartyListAsync()
        {
            try
            {
                var partylist = await candidateRepository.GetPartyListAsync();
                cmbPartyListName.DataSource = partylist;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading party list names: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
