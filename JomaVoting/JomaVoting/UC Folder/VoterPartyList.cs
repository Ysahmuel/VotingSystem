using JomaVoting.Repositories;
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
using static JomaVoting.Voting;

namespace JomaVoting
{
    public partial class VoterPartyList : UserControl
    {
        private PartyListRepository partylistRepository;

        public VoterPartyList()
        {
            InitializeComponent();
            partylistRepository = new PartyListRepository(DatabaseConfig.ConnectionString);
            LoadPartyListAndCandidates();
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
    }
}
 
