using ScottPlot;
using ScottPlot.TickGenerators;
using SkiaSharp;
using System.Drawing;

namespace JomaVoting
{
    public partial class VoterHomari : Form

    {

        public VoterHomari()
        {

            InitializeComponent();
        }

        private void LoadPage(UserControl page)
        {
            pnlMain.Controls.Clear(); // Clear the panel
            page.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(page);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadPage(new JomaVoting.Home());
        }

        private void btnPartyList_Click(object sender, EventArgs e)
        {
            LoadPage(new JomaVoting.Party());
        }

        private void btnVoting_Click(object sender, EventArgs e)
        {
            LoadPage(new JomaVoting.Voting());
        }
    }
}
