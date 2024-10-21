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

using System.Windows.Forms.DataVisualization.Charting;

namespace JomaVoting
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
            DisplayCurrentDateTime();
            UpdateCandidateCount();
            UpdateVoterCount();
            DisplayLeadingCandidatesCharts();
        }

        private void UpdateCandidateCount()
        {
            int count = 0;
            // SQL query to count the total number of candidates in the TBL_Candidate table
            string query = "SELECT COUNT(*) FROM TBL_Candidate";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    count = (int)command.ExecuteScalar();
                }
                lblCandidateCount.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching candidate count: {ex.Message}");
            }
        }

        private void UpdateVoterCount()
        {
            int count = 0;
            // SQL query to count the total number of voters in the TBL_Voter table
            string query = "SELECT COUNT(*) FROM TBL_Voter";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    count = (int)command.ExecuteScalar();
                }
                lblVoterCount.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching voter count: {ex.Message}");
            }
        }

        private void DisplayCurrentDateTime()
        {
            DateTime now = DateTime.Now;
            string currentDate = now.ToString("MMMM dd, yyyy");
            lblDate.Text = $"Date: {currentDate}";

            string currentTime = now.ToString("hh:mm tt");
            lblTime.Text = $"Time: {currentTime}";
        }
        private void DisplayLeadingCandidatesCharts()
        {
            // SQL query to count votes for each candidate by position
            string query = @"
    SELECT Position, Candidate, COUNT(*) AS VoteCount
    FROM TBL_Votes
    GROUP BY Position, Candidate
    HAVING COUNT(*) > 0
    ORDER BY Position, VoteCount DESC";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    var positionData = new Dictionary<string, List<(string Candidate, int VoteCount)>>();

                    // Read the data into a dictionary
                    while (reader.Read())
                    {
                        string position = reader["Position"].ToString();
                        string candidate = reader["Candidate"].ToString();
                        int voteCount = (int)reader["VoteCount"];

                        if (!positionData.ContainsKey(position))
                        {
                            positionData[position] = new List<(string Candidate, int VoteCount)>();
                        }
                        positionData[position].Add((candidate, voteCount));
                    }

                    // Check if position data is populated
                    if (positionData.Count == 0)
                    {
                        MessageBox.Show("No data available for leading candidates.");
                        return; // Exit if no data
                    }

                    // Create a chart for each position
                    foreach (var position in positionData.Keys)
                    {
                        Chart chart = CreateChartForPosition(position);

                        // Track used colors to ensure uniqueness
                        HashSet<Color> usedColors = new HashSet<Color>();
                        Random random = new Random();

                        // Enable and configure the legend
                        chart.Legends.Add("Legend1");
                        chart.Legends["Legend1"].Docking = Docking.Left; // Place the legend on the left side
                        chart.Legends["Legend1"].Title = "Candidates";   // Optional: Title for the legend

                        // Populate the chart with candidates and their vote counts
                        foreach (var (candidate, voteCount) in positionData[position])
                        {
                            var series = chart.Series.Add(candidate);
                            series.ChartType = SeriesChartType.Column; // Keep vertical bars
                            series.Points.AddXY(candidate, voteCount);

                            // Assign a unique color to each candidate
                            Color candidateColor;
                            do
                            {
                                // Generate a random color
                                candidateColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                            }
                            while (usedColors.Contains(candidateColor)); // Ensure the color isn't already used

                            series.Color = candidateColor; // Assign the color
                            series.IsValueShownAsLabel = true; // Show value labels on bars

                            // Add legend item for the candidate
                            series.Legend = "Legend1"; // Link the series to the legend
                        }

                        // Set chart properties
                        chart.ChartAreas[0].AxisX.Title = "Leading Candidate"; // X-axis is candidates
                        chart.ChartAreas[0].AxisY.Title = "Vote Count";  // Y-axis is vote count
                        chart.Titles.Add($"{position}");       // Set title for the chart
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching leading candidates: {ex.Message}");
            }
        }


        private Chart CreateChartForPosition(string position)
        {
            Chart chart = new Chart();
            chart.Dock = DockStyle.Top; // Dock the chart to fill horizontally if needed
            chart.Height = 400; // Set height as needed
            chart.Width = 800;  // Increase the width for a wider chart

            // Add a ChartArea
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            // Add the chart to the FlowLayoutPanel
            flowLayoutPanel1.Controls.Add(chart); // Ensure flowLayoutPanel1 is defined in your form

            return chart;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
