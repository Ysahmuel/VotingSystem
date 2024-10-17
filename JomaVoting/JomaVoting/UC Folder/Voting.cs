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
        public Voting()
        {
            InitializeComponent();
            RetrieveAndDisplayCandidateData();
        }

        private void RetrieveAndDisplayCandidateData()
        {
            string query = "SELECT CandidateID, firstName, middleInitial, lastName FROM TBL_Candidate";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        candidateList.Clear();

                        while (reader.Read())
                        {
                            int candidateID = Convert.ToInt32(reader["CandidateID"]);
                            string firstName = reader["firstName"].ToString().Trim();
                            string middleInitial = reader["middleInitial"].ToString().Trim();
                            string lastName = reader["lastName"].ToString().Trim();

                            candidateList.Add(new Candidate
                            {
                                CandidateID = candidateID,
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

            foreach (var candidate in candidateList)
            {
                AddNewPanel(candidate.CandidateID, candidate.FirstName, candidate.MiddleInitial, candidate.LastName);
            }
        }
        private void AddNewPanel(int candidateID, string firstName, string middleInitial, string lastName)
        {
            CandidateProfile newProfile = new CandidateProfile();
            newProfile.candidateProfile(candidateID, firstName, middleInitial, lastName);
            newProfile.CheckBoxChanged += (sender, e) => OnCandidateCheckedChanged(candidateID, e); // Handle checkbox selection
            panelContainer.Controls.Add(newProfile);
        }

        private void OnCandidateCheckedChanged(int candidateID, bool isChecked)
        {
            if (isChecked)
            {
                selectedCandidateIDs.Add(candidateID);
            }
            else
            {
                selectedCandidateIDs.Remove(candidateID);
            }
        }

        private void SaveVotes(List<int> candidateIDs)
        {
            string insertQuery = "INSERT INTO TBL_Votes (Position, Candidate, Voter) VALUES (@Position, @Candidate, @Voter)";

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Assume we have the Voter's full name (this can be retrieved from the logged-in user)
                    string voterFullName = GetVoterFullName(); // Replace this with logic to get the voter's full name

                    foreach (int candidateID in candidateIDs)
                    {
                        // Get candidate details (name, position)
                        Candidate candidate = GetCandidateDetails(candidateID); // Retrieve candidate details

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Position", candidate.PositionDescription);  // Position is varchar
                            command.Parameters.AddWithValue("@Candidate", candidate.FullName);            // Candidate is varchar
                            command.Parameters.AddWithValue("@Voter", voterFullName);                     // Voter is varchar
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
            SaveVotes(selectedCandidateIDs); // Pass selected candidates to save
        }

        private string GetVoterFullName()
        {
            // Replace this with the actual logic to get the voter's full name (e.g., from logged-in user)
            return "John Joe Bingoball"; // Placeholder value
        }


        private Candidate GetCandidateDetails(int candidateID)
        {
            string query = "SELECT CONCAT(c.FirstName, ' ', c.MiddleInitial, ' ', c.LastName) AS FullName, p.PositionDescription " +
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
                                FullName = reader["FullName"].ToString(),
                                PositionDescription = reader["PositionDescription"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }
        public class Candidate
        {
            public int CandidateID { get; set; }
            public string FirstName { get; set; }
            public string MiddleInitial { get; set; }
            public string LastName { get; set; }
            public string FullName { get; set; }
            public string PositionDescription { get; set; }
        }

    }
    }


