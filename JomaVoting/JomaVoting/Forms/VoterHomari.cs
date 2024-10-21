using ScottPlot;
using ScottPlot.TickGenerators;
using SkiaSharp;
using System.Drawing;

namespace JomaVoting
{
    public partial class VoterHomari : Form

    {
        private string loggedInUsername;
      
        public VoterHomari(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            lblUsername.Text = "Logged in as: " + loggedInUsername;

        }
        private void LoadPage(UserControl page)
        {
            pnlMain.Controls.Clear(); 
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
