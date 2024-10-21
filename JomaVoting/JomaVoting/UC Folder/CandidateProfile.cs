using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JomaVoting.UC_Folder
{
    public partial class CandidateProfile : UserControl
    {
        public int CandidateID { get; private set; }
        public string PositionID { get; private set; }
        public bool IsChecked => checkBox1.Checked;
        public event EventHandler CheckBoxChanged;

        public CandidateProfile()
        {
            InitializeComponent();
          
        }

        public void candidateProfile(int candidateID, string position, string firstName, string middleInitial, string lastName)
        {
            this.CandidateID = candidateID;
            this.PositionID = position;
            lblPosition.Text = "Position: " + position;
            lblCandidateName.Text = string.IsNullOrEmpty(middleInitial)
                ? $"{firstName} {lastName}"
                : $"{firstName} {middleInitial} {lastName}";
            pictureBox1.Image = GetImageFromDatabase(candidateID);
        }

        private Image GetImageFromDatabase(int candidateID)
        {
            // SQL query to retrieve the Picture column from TBL_Candidate for a specific candidateID
            string query = "SELECT Picture FROM [TBL_Candidate] WHERE candidateID = @candidateID";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@candidateID", candidateID);
                    try
                    {
                        connection.Open();
                        byte[] imageBytes = command.ExecuteScalar() as byte[];

                        if (imageBytes != null && imageBytes.Length > 0)
                        {
                            using (var ms = new MemoryStream(imageBytes))
                            {
                                return Image.FromStream(ms);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            return null;
        }

        public void EnableCheckbox()
        {
            checkBox1.CheckedChanged += CheckBoxChanged; 
            checkBox1.Enabled = true; 
        }

        public void DisableCheckbox()
        {
            checkBox1.CheckedChanged -= CheckBoxChanged; 
            checkBox1.Enabled = false; 
        }

        public void SetCheckBoxState(bool isChecked)
        {
            checkBox1.Checked = isChecked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}
