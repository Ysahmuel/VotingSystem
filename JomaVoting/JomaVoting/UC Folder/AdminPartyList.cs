using JomaVoting.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JomaVoting
{
    public partial class AdminPartyList : UserControl
    {
        private PartyListRepository partylistRepository;

        public AdminPartyList()
        {
            InitializeComponent();
            partylistRepository = new PartyListRepository(DatabaseConfig.ConnectionString);
            LoadPartyListDataAsync();
            LoadPartyListAndCandidates();
        }

        private async void LoadPartyListDataAsync()
        {
            try
            {
                var candidateTable = await partylistRepository.GetPartyListAsync();
                dataGridView1.DataSource = candidateTable;
                AddStatusColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading party list data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddStatusColumns()
        {
            if (!dataGridView1.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    HeaderText = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(editColumn);
            }

            if (!dataGridView1.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(deleteColumn);
            }
        }

        private async void DeletePartyList(int rowIndex)
        {
            int partylistID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["PartyListID"].Value);

            DialogResult result = MessageBox.Show("Are you sure you want to delete this party list?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    await partylistRepository.DeletePartyListAsync(partylistID);
                    LoadPartyListDataAsync();
                    MessageBox.Show("Party list deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting party list: " + ex.Message);
                }
            }
        }



        private async void LoadPartyListAndCandidates()
        {
            try
            {
                List<PartyListRepository.PartyCandidate> partyCandidates = await partylistRepository.GetPartyCandidatesAsync();
                DisplayPartyCandidates(partyCandidates);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading party lists and candidates: " + ex.Message);
            }
        }

        private void DisplayPartyCandidates(List<PartyListRepository.PartyCandidate> partyCandidates)
        {
            flowLayoutPanel1.Controls.Clear(); // Clear existing controls

            // Group candidates by party list
            var groupedCandidates = partyCandidates
                .GroupBy(pc => pc.PartyListName)
                .ToDictionary(g => g.Key, g => g.ToList());

            if (groupedCandidates.Count == 0)
            {
                MessageBox.Show("No parties found to display.");
                return;
            }

            // Loop through each group of candidates
            foreach (var party in groupedCandidates)
            {
                // Create a panel for the party list
                Panel partyPanel = new Panel
                {
                    Size = new Size(300, 300),
                    Margin = new Padding(10, 5, 10, 5), // Adjust margin: top, right, bottom, left
                    BorderStyle = BorderStyle.FixedSingle,
                    AutoScroll = true
                };

                // Create labels for each candidate in the party list
                foreach (var candidate in party.Value)
                {
                    Label lblCandidate = new Label
                    {
                        Text = $"{candidate.Position}: {candidate.CandidateName}",
                        Font = new Font("Arial", 10),
                        Dock = DockStyle.Top,
                        AutoSize = true
                    };
                    partyPanel.Controls.Add(lblCandidate); // Add candidate labels below the party list label
                }

                // Create a label for the party list name (at the top of each panel)
                Label lblPartyList = new Label
                {
                    Text = $"{party.Key} Party List",
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                partyPanel.Controls.Add(lblPartyList); // Add the party list label first
                // Add the party panel to the main display panel
                flowLayoutPanel1.Controls.Add(partyPanel); // Ensure you're adding the party panel here
            }

            // Check if panels were added successfully
            if (flowLayoutPanel1.Controls.Count == 0)
            {
                MessageBox.Show("No panels were added to panelPartyList.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                int partylistID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["PartyListID"].Value);


                LoadPartyListDataAsync();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                DeletePartyList(e.RowIndex);
            }
        }
    }
}
