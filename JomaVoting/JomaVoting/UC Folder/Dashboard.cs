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
using JomaVoting.Repositories;

namespace JomaVoting
{
    public partial class Dashboard : UserControl
    {
        private DashboardRepository _dashboardRepository;

        public Dashboard()
        {
            InitializeComponent();
            _dashboardRepository = new DashboardRepository();
            InitializeDashboard();
        }

        private async void InitializeDashboard()
        {
            await LoadDashboardDataAsync();
        }

        private async Task LoadDashboardDataAsync()
        {
            await DisplayCurrentDateTimeAsync();
            await UpdateCandidateCountAsync();
            await UpdateVoterCountAsync();
            await DisplayLeadingCandidatesChartsAsync();
        }

        private async Task UpdateCandidateCountAsync()
        {
            try
            {
                int count = await _dashboardRepository.GetCandidateCountAsync();
                lblCandidateCount.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching candidate count: {ex.Message}");
            }
        }

        private async Task UpdateVoterCountAsync()
        {
            try
            {
                int count = await _dashboardRepository.GetVoterCountAsync();
                lblVoterCount.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching voter count: {ex.Message}");
            }
        }

        private async Task DisplayCurrentDateTimeAsync()
        {
            DateTime now = DateTime.Now;
            lblDate.Text = $"Date: {now:MMMM dd, yyyy}";
            lblTime.Text = $"Time: {now:hh:mm tt}";
            await Task.CompletedTask; 
        }

        private async Task DisplayLeadingCandidatesChartsAsync()
        {
            try
            {
                var positionData = await _dashboardRepository.GetLeadingCandidatesAsync();
                CreateCharts(positionData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching leading candidates: {ex.Message}");
            }
        }

        private void CreateCharts(Dictionary<string, List<(string Candidate, int VoteCount)>> positionData)
        {
            // Clear existing charts before creating new ones
            flowLayoutPanel1.Controls.Clear();

            foreach (var position in positionData.Keys)
            {
                Chart chart = CreateChartForPosition(position);
                HashSet<Color> usedColors = new HashSet<Color>();
                Random random = new Random();

                // Enable and configure the legend
                chart.Legends.Add("Legend1");
                chart.Legends["Legend1"].Docking = Docking.Left;
                chart.Legends["Legend1"].Title = "Candidates";

                // Populate the chart with candidates and their vote counts
                foreach (var (candidate, voteCount) in positionData[position])
                {
                    var series = chart.Series.Add(candidate);
                    series.ChartType = SeriesChartType.Column;
                    series.Points.AddXY(candidate, voteCount);

                    // Assign a unique color to each candidate
                    Color candidateColor;
                    do
                    {
                        candidateColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                    }
                    while (usedColors.Contains(candidateColor));

                    series.Color = candidateColor;
                    series.IsValueShownAsLabel = true;
                    series.Legend = "Legend1";
                }

                // Set chart properties
                chart.ChartAreas[0].AxisX.Title = "Leading Candidate";
                chart.ChartAreas[0].AxisY.Title = "Vote Count";
                chart.Titles.Add(position);
            }
        }

        private Chart CreateChartForPosition(string position)
        {
            Chart chart = new Chart
            {
                Dock = DockStyle.Top,
                Height = 400,
                Width = 800
            };
            chart.ChartAreas.Add(new ChartArea());
            flowLayoutPanel1.Controls.Add(chart);
            return chart;
        }
    }
}
