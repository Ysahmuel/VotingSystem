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
using JomaVoting.Repositories;



namespace JomaVoting
{
    public partial class AddVoter : Form
    {
        public delegate void VoterAddedEventHandler();
        public event VoterAddedEventHandler VoterAdded;

        private int VoterID = -1;
        private readonly VoterRepository _voterRepository;

        public AddVoter()
        {
            InitializeComponent();
            _voterRepository = new VoterRepository(DatabaseConfig.ConnectionString);
        }

        public AddVoter(int voterID) : this()
        {
            VoterID = voterID;
            LoadVoterDataAsync();
        }

        private async void LoadVoterDataAsync()
        {
            try
            {
                var voter = await _voterRepository.GetVoterAsync(VoterID);
                if (voter != null)
                {
                    txtFirstName.Text = voter.FirstName;
                    txtMiddleInitial.Text = voter.MiddleInitial;
                    txtLastName.Text = voter.LastName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the voter data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string middleInitial = txtMiddleInitial.Text;
            string lastName = txtLastName.Text;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("First Name and Last Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var voter = new Voter
            {
                VoterID = VoterID,
                FirstName = firstName,
                MiddleInitial = middleInitial,
                LastName = lastName
            };

            try
            {
                VoterID = await _voterRepository.SaveVoterAsync(voter);
                MessageBox.Show("Voter data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                VoterAdded?.Invoke();
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
            for (int i = 0; i < 10; i++) 
            {
                password.Append(valid[rnd.Next(valid.Length)]);
            }
            return password.ToString();
        }
    }
}
