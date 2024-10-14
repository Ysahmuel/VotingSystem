using ScottPlot.TickGenerators;
using ScottPlot;
using SkiaSharp;
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

namespace JomaVoting
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
            DisplayCurrentDateTime();  // Add date and time display logic
            CreateAndDisplayPlot();    // Existing plot logic
            UpdateCandidateCount();     // Add candidate count display logic
        }

        private void UpdateCandidateCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM TBL_Candidate"; // Query to count candidates

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open(); // Open the connection
                    count = (int)command.ExecuteScalar(); // Execute the query
                }
                lblCandidateCount.Text = count.ToString(); // Update the label
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching candidate count: {ex.Message}"); // Handle exceptions
            }
        }

        private void DisplayCurrentDateTime()
        {
            DateTime now = DateTime.Now;
            // Set the current date in lblDate
            string currentDate = now.ToString("MMMM dd, yyyy");
            lblDate.Text = $"Date: {currentDate}";

            // Set the current time in lblTime
            string currentTime = now.ToString("hh:mm tt");
            lblTime.Text = $"Time: {currentTime}";
        }

        private void CreateAndDisplayPlot()
        {
            // Create a new ScottPlot.Plot
            var myPlot = new ScottPlot.Plot();

            // Create a bar plot with specified values
            double[] values = { 5, 10, 7, 13, 25, 60 };
            string[] barLabels = { "pasas", "panda", "macgaylor", "diddy", "bingoball", "fucku" }; // Define labels for each bar
            myPlot.Add.Bars(values);

            // Loop through each bar to add labels
            for (int i = 0; i < values.Length; i++)
            {
                // Place labels at the center of each bar
                myPlot.Add.Text(barLabels[i], i, values[i] + 1); // Position slightly above the bar
            }

            myPlot.Axes.Margins(bottom: 0); // Set margins

            // Create a tick for each bar with long titles
            Tick[] ticks =
            {
                new Tick(0, "First Long Title"),
                new Tick(1, "Second Long Title"),
                new Tick(2, "Third Long Title"),
                new Tick(3, "Fourth Long Title"),
                new Tick(4, "Fifth Long Title"),
                new Tick(5, "Sixth Long Title")
            };

            // Assign custom tick labels to the bottom axis
            myPlot.Axes.Bottom.TickGenerator = new NumericManual(ticks);
            myPlot.Axes.Bottom.TickLabelStyle.Rotation = 45; // Rotate labels for better visibility
            myPlot.Axes.Bottom.TickLabelStyle.Alignment = ScottPlot.Alignment.MiddleLeft; // Align labels

            // Determine the width of the largest tick label
            float largestLabelWidth = 0;
            using (SKPaint paint = new SKPaint())
            {
                foreach (Tick tick in ticks)
                {
                    PixelSize size = myPlot.Axes.Bottom.TickLabelStyle.Measure(tick.Label, paint).Size;
                    largestLabelWidth = Math.Max(largestLabelWidth, size.Width);
                }
            }

            // Ensure axis panels do not get smaller than the largest label
            myPlot.Axes.Bottom.MinimumSize = largestLabelWidth;

            // Instead of assigning, update the existing plot
            formsPlot1.Plot.Clear(); // Clear existing plots if needed
            formsPlot1.Plot.Add.Bars(values); // Add bars to the FormsPlot control

            // Adding text labels directly to the formsPlot1 instance
            for (int i = 0; i < values.Length; i++)
            {
                formsPlot1.Plot.Add.Text(barLabels[i], i, values[i] + 1); // Add text to the formsPlot
            }
            formsPlot1.Refresh(); // Refresh to show the updated plot

            // Optionally save the plot as an image
            myPlot.SavePng("demo.png", 400, 300); // Save the plot image
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}
