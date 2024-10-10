using ScottPlot;
using ScottPlot.TickGenerators;
using SkiaSharp;
using System.Drawing;

namespace JomaVoting
{
    public partial class Form1 : Form

    {
        
        public Form1()
        {

            InitializeComponent();
        }

        private void LoadPage(UserControl page)
        {
            pnlMain.Controls.Clear(); // Clear the panel
            page.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(page);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadPage(new JomaVoting.Dashboard());
        }

        private void btnVotes_Click(object sender, EventArgs e)
        {
            LoadPage(new JomaVoting.Votes());
        }

        private void btnVoters_Click(object sender, EventArgs e)
        {
            LoadPage(new JomaVoting.Voters());
        }

        private void btnPositions_Click(object sender, EventArgs e)
        {
            LoadPage(new JomaVoting.Positions());
        }

        private void btnCandidates_Click(object sender, EventArgs e)
        {
            LoadPage(new JomaVoting.Candidates());
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }
        
    }
}
