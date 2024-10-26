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
using JomaVoting.Repositories;

namespace JomaVoting
{
    public partial class AddPosition : Form
    {
        public delegate void PositionAddedEventHandler();
        public event PositionAddedEventHandler PositionAdded;

        private int PositionID = -1;
        private PositionRepository _positionRepository;

        public AddPosition()
        {
            InitializeComponent();
            _positionRepository = new PositionRepository(DatabaseConfig.ConnectionString);
        }

        public AddPosition(int positionID) : this()
        {
            PositionID = positionID;
            LoadPositionDataAsync();
        }

        private async void LoadPositionDataAsync()
        {
            try
            {
                var positionData = await _positionRepository.GetPositionsAsync();
                var positionRow = positionData.Select($"PositionID = {PositionID}");

                if (positionRow.Length > 0)
                {
                    txtPosition.Text = positionRow[0]["PositionDescription"].ToString();
                    int maxVote = Convert.ToInt32(positionRow[0]["MaximumVote"]);

                    foreach (var item in cmbMaximumVote.Items)
                    {
                        if (Convert.ToInt32(item) == maxVote)
                        {
                            cmbMaximumVote.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the position data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            string positionDescription = txtPosition.Text.Trim();
            string maximumVote = cmbMaximumVote.Text;

            if (string.IsNullOrWhiteSpace(positionDescription))
            {
                MessageBox.Show("Position description cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await _positionRepository.SavePositionAsync(positionDescription, maximumVote, PositionID);
                MessageBox.Show("Position data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Raise the PositionAdded event after successful save
                PositionAdded?.Invoke();

                txtPosition.Clear();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
