using JomaVoting.UC_Folder;
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
    public partial class Voting : UserControl
    {
        private List<Candidate> candidateList = new List<Candidate>();
        private List<int> selectedCandidateIDs = new List<int>();
        private Dictionary<string, int> positionSelectedCounts = new Dictionary<string, int>();
        private Dictionary<string, int> positionMaxVotes = new Dictionary<string, int>();
        private List<CandidateProfile> candidateProfiles = new List<CandidateProfile>();

        public Voting()
        {
            InitializeComponent();
            RetrieveAndDisplayCandidateData();
        }

        private void RetrieveAndDisplayCandidateData()
        {
            string query = "SELECT c.CandidateID, c.firstName, c.middleInitial, c.lastName, c.PositionID, p.MaximumVote " +
                           "FROM TBL_Candidate c " +
                           "JOIN TBL_Position p ON c.PositionID = p.PositionDescription";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        candidateList.Clear();
                        positionMaxVotes.Clear();

                        while (reader.Read())
                        {
                            int candidateID = Convert.ToInt32(reader["CandidateID"]);
                            string positionID = reader["PositionID"].ToString().Trim();
                            string firstName = reader["firstName"].ToString().Trim();
                            string middleInitial = reader["middleInitial"].ToString().Trim();
                            string lastName = reader["lastName"].ToString().Trim();
                            int maximumVote = Convert.ToInt32(reader["MaximumVote"]);

                            if (!positionMaxVotes.ContainsKey(positionID))
                            {
                                positionMaxVotes[positionID] = maximumVote;
                            }

                            candidateList.Add(new Candidate
                            {
                                CandidateID = candidateID,
                                PositionID = positionID,
                                FirstName = firstName,
                                MiddleInitial = middleInitial,
                                LastName = lastName
                            });
                        }

                        DisplayCandidate(candidateList);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }



        private void DisplayCandidate(List<Candidate> candidateList)
        {
            panelContainer.Controls.Clear();

            var groupedCandidates = candidateList.GroupBy(c => c.PositionID);

            foreach (var group in groupedCandidates)
            {
                // Retrieve the maximum vote for this position
                string positionID = group.Key;
                int maxVotes = positionMaxVotes[positionID]; // Get max votes from the dictionary

                // Create a position label with maximum vote information
                Label positionLabel = new Label();
                positionLabel.Text = $"{GetPositionDescription(positionID)} (Only {maxVotes} votes allowed)";
                positionLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                positionLabel.AutoSize = true;
                panelContainer.Controls.Add(positionLabel);

                foreach (var candidate in group)
                {
                    AddNewPanel(candidate.CandidateID, candidate.PositionID, candidate.FirstName, candidate.MiddleInitial, candidate.LastName);
                }
            }
        }


        private string GetPositionDescription(string positionID)
        {
            string positionDescription = string.Empty;

            string query = "SELECT PositionDescription FROM TBL_Position WHERE PositionDescription = @PositionDescription";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PositionDescription", positionID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            positionDescription = reader["PositionDescription"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No position found for PositionDescription: " + positionID);
                        }
                    }
                }
            }

            return string.IsNullOrEmpty(positionDescription) ? "Unknown Position" : positionDescription;
        }




        private void AddNewPanel(int candidateID, string position, string firstName, string middleInitial, string lastName)
        {
            CandidateProfile newProfile = new CandidateProfile();
            newProfile.candidateProfile(candidateID, position, firstName, middleInitial, lastName);
            newProfile.CheckBoxChanged += (sender, e) => OnCandidateCheckedChanged(candidateID, newProfile.IsChecked);
            panelContainer.Controls.Add(newProfile);
            candidateProfiles.Add(newProfile);

        }
        private void OnCandidateCheckedChanged(int candidateID, bool isChecked)
        {
            Candidate candidate = GetCandidateDetails(candidateID);

            if (candidate == null || string.IsNullOrEmpty(candidate.PositionID))
            {
                MessageBox.Show("Invalid candidate or position data.");
                return;
            }

            string positionID = candidate.PositionID;

            int currentSelected = positionSelectedCounts.ContainsKey(positionID) ? positionSelectedCounts[positionID] : 0;
            int maxAllowed = positionMaxVotes[positionID];

            if (isChecked)
            {
               


                positionSelectedCounts[positionID] = currentSelected + 1;
                selectedCandidateIDs.Add(candidateID);

                if (positionSelectedCounts[positionID] == maxAllowed)
                {
                    DisableAllOtherCheckboxesForPosition(positionID, candidateID); 
                }
            }
            else
            {
                positionSelectedCounts[positionID]--;
                selectedCandidateIDs.Remove(candidateID);

                if (positionSelectedCounts[positionID] <= 0)
                {
                    positionSelectedCounts[positionID] = 0; 
                    EnableAllCheckboxesForPosition(positionID); 
                }
                else
                {
                    if (positionSelectedCounts[positionID] < maxAllowed)
                    {
                        EnableAllCheckboxesForPosition(positionID); 
                    }
                }
            }
        }

        private void DisableAllOtherCheckboxesForPosition(string positionID, int selectedCandidateID)
        {
            foreach (var candidateProfile in candidateProfiles)
            {
                if (candidateProfile.CandidateID != selectedCandidateID && candidateProfile.PositionID == positionID)
                {
                    candidateProfile.DisableCheckbox(); 
                }
            }
        }

        private void EnableAllCheckboxesForPosition(string positionID)
        {
            foreach (var candidateProfile in candidateProfiles)
            {
                if (candidateProfile.PositionID == positionID)
                {
                    candidateProfile.EnableCheckbox(); 
                }
            }
        }












        private CandidateProfile GetCandidateProfileControl(int candidateID)
        {
            return candidateProfiles.FirstOrDefault(profile => profile.CandidateID == candidateID);
        }

        private Candidate GetCandidateDetails(int candidateID)
        {
            string query = "SELECT c.PositionID, CONCAT(c.FirstName, ' ', c.MiddleInitial, ' ', c.LastName) AS FullName, p.PositionDescription " +
                           "FROM TBL_Candidate c " +
                           "LEFT JOIN TBL_Position p ON c.PositionID = p.PositionDescription " + 
                           "WHERE c.CandidateID = @CandidateID";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CandidateID", candidateID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Candidate
                            {
                                CandidateID = candidateID,
                                FullName = reader["FullName"].ToString(),
                                PositionID = reader["PositionID"].ToString(),
                                PositionDescription = reader["PositionDescription"].ToString()
                            };
                        }
                    }
                }
            }
            return null; 
        }





        private void SaveVotes(List<int> candidateIDs)
        {
            string insertQuery = "INSERT INTO TBL_Votes (Position, Candidate, Voter) VALUES (@Position, @Candidate, @Voter)";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                try
                {
                    connection.Open();

                    string voterFullName = GetVoterFullName(); 

                    foreach (int candidateID in candidateIDs)
                    {
                        Candidate candidate = GetCandidateDetails(candidateID); 

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Position", candidate.PositionDescription);
                            command.Parameters.AddWithValue("@Candidate", candidate.FullName);      
                            command.Parameters.AddWithValue("@Voter", voterFullName);             
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Votes successfully saved!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving votes: " + ex.Message);
                }
            }
        }


        private void btnVote_Click(object sender, EventArgs e)
        {
            SaveVotes(selectedCandidateIDs); 
        }

        private string GetVoterFullName()
        {
            return "John Joe Bingoball"; 
        }

        public class Candidate
        {
            public int CandidateID { get; set; }
            public string PositionID { get; set; }
            public string FirstName { get; set; }
            public string MiddleInitial { get; set; }
            public string LastName { get; set; }
            public string FullName { get; set; }
            public string PositionDescription { get; set; }
            public int MaximumVote { get; set; }  
        }


    }
}


